using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Контроллер заказов
    /// </summary>
    public class OrdersController
    {

        /// <summary>
        /// Создать контроллер
        /// </summary>
        /// <returns></returns>
        public static OrdersController GetController()
            => new OrdersController();

        /// <summary>
        /// Корзины пользователей
        /// </summary>
        public static ShoppingCartsList ShoppingCarts => ShoppingCartController.carts;

        /// <summary>
        /// Оформить заказ
        /// </summary>
        /// <param name="orderSession"></param>
        /// <returns></returns>
        public OrderValue SetOrder(OrderSession orderSession)
        {
            Session session = orderSession.CopySession();
            if (!SessionsController.GetController().CheckActive(session))
                throw new Exception("Вы больше не авторизированы");
            if (!ShoppingCarts.ContainsOrderToken(orderSession))
                throw new Exception("Невозможно сделать заказ");
            ProductsInShoppingCartList products = ShoppingCarts.Get(orderSession);
            products.SetChange();
            if (!products.Mayby)
            {
                throw new Exception("Невозможно сделать заказ");
            }
            try
            {
                AccountWithRoles account = AccountsController.GetController().GetAccount(session);
                if (account.IsGoest())
                {
                    throw new Exception("Вы больше не авторизированы");
                }
                if (!account.IsClient())
                {
                    throw new Exception("Вы больше не являетесь клиентом");
                }

                OrderValue order = new OrderValue();
                try
                {
                    order.SetOrder(OrdersList.AddToDB(products.GetOrder()));
                    if (!OrdersList.AddClientDB(account.ID, order.ID))
                        throw new Exception();
                    if (!OrdersList.AddProductsToOrderInDB(products, order.ID))
                        throw new Exception();

                    if (products.PounktType == PounktType.Shop)
                    {
                        if (!OrdersList.AddInShopInDB(products.PounktID, order.ID))
                        {
                            throw new Exception();
                        }
                        try
                        {
                            OrdersList.ChangeProductsCountInShop(products.PounktID, products);
                        }
                        catch
                        {

                        }
                    }
                    else if (products.PounktType == PounktType.Stock)
                    {
                        if (!OrdersList.AddInPounktOfIssueInDB(products.PounktID, order.ID))
                        {
                            throw new Exception();
                        }
                        try
                        {
                            OrdersList.ChangeProductsCountInStock(products.TradingPoint.StockID, products);
                        }
                        catch
                        {

                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                    products.Clear();
                }
                catch
                {
                    OrdersList.DeleteFromDB(order.ID);
                    throw new Exception("Невозможно сделать заказ");
                }

                return order;
            }
            catch
            {
                throw new Exception("Невозможно сделать заказ");
            }
        }

        /// <summary>
        /// Получить историю заказов
        /// </summary>
        /// <param name="session"></param>
        /// <param name="numberFilter"></param>
        /// <returns></returns>
        public OrdersWithStatusesList Get(Session session, string numberFilter = "")
        {
            if (!SessionsController.GetController().CheckActive(session))
                throw new Exception("Вы больше не авторизированы");
            if (UserRolesController.GetController().IsGoest(session))
                throw new Exception("Вы больше не авторизированы");
            AccountWithRoles account = AccountsController.GetController().GetAccount(session);
            int clientID = 0;
            if (!account.IsClient())
            {
                if (!account.IsShowOrdersUser())
                    throw new Exception("Вы не являетесь " +
                        "ни клиентом," +
                        "ни продавцом," +
                        "ни менеджером по заказу" +
                        "ни директором," +
                        "ни администратором");
            }
            else if(Helper.SetClient)
            {
                clientID = account.ID;
            }
            return Get(clientID, numberFilter);
        }

        public static OrdersWithStatusesList Get(int clientID, string numberFilter)
        {
            return OrdersWithStatusesList.GetListFromDB(numberFilter, clientID);
        }

        /// <summary>
        /// Получить заказ по его ID
        /// </summary>
        /// <param name="session"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public OrderWithStatus Get(Session session, int id)
        {
            if (!SessionsController.GetController().CheckActive(session))
                throw new Exception("Вы больше не авторизированы");
            if (UserRolesController.GetController().IsGoest(session))
                throw new Exception("Вы больше не авторизированы");
            AccountWithRoles account = AccountsController.GetController().GetAccount(session);
            int clientID = 0;
            if (!account.IsClient())
            {
                if (!account.IsShowOrdersUser())
                    throw new Exception("Вы не являетесь " +
                        "ни клиентом," +
                        "ни продавцом," +
                        "ни менеджером по заказу" +
                        "ни директором," +
                        "ни администратором");
            }
            else if (Helper.SetClient)
            {
                clientID = account.ID;
            }
            return Get(clientID, "").GetByID(id);
        }

        /// <summary>
        /// Получить заказ по его номеру
        /// </summary>
        /// <param name="session"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public OrderWithStatus GetOrder(Session session, string number)
        {
            if (!SessionsController.GetController().CheckActive(session))
                throw new Exception("Вы больше не авторизированы");
            if (UserRolesController.GetController().IsGoest(session))
                throw new Exception("Вы больше не авторизированы");
            AccountWithRoles account = AccountsController.GetController().GetAccount(session);
            int clientID = 0;
            if (!account.IsClient())
            {
                if (!account.IsShowOrdersUser())
                    throw new Exception("Вы не являетесь " +
                        "ни клиентом," +
                        "ни продавцом," +
                        "ни менеджером по заказу" +
                        "ни директором," +
                        "ни администратором");
            }
            else if (Helper.SetClient)
            {
                clientID = account.ID;
            }
            return Get(clientID, "").GetByNumber(number);
        }


        public ProductsInOrderList GetProductsByOrder(int id) => ProductsInOrderList.GetListFromDB(id);

        /// <summary>
        /// Получить заказ по его ID
        /// </summary>
        /// <param name="session"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public OrderFullInfo GetProducts(Session session, int id)
        {
            if (!SessionsController.GetController().CheckActive(session))
                throw new Exception("Вы больше не авторизированы");
            if (UserRolesController.GetController().IsGoest(session))
                throw new Exception("Вы больше не авторизированы");
            AccountWithRoles account = AccountsController.GetController().GetAccount(session);
            int clientID = 0;
            if (!account.IsClient())
            {
                if (!account.IsShowOrdersUser())
                    throw new Exception("Вы не являетесь " +
                        "ни клиентом," +
                        "ни продавцом," +
                        "ни менеджером по заказу" +
                        "ни директором," +
                        "ни администратором");
            }
            else if (Helper.SetClient)
            {
                clientID = account.ID;
            }
            OrdersWithStatusesList orders = Get(clientID, "");
            if (!orders.ContainsByID(id))
                throw new Exception("Данного заказа не существует");

            return new OrderFullInfo(orders.GetByID(id));
        }


        /// <summary>
        /// Получить заказ по его номеру
        /// </summary>
        /// <param name="session"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public OrderFullInfo GetProducts(Session session, string number)
        {
            if (!SessionsController.GetController().CheckActive(session))
                throw new Exception("Вы больше не авторизированы");
            if (UserRolesController.GetController().IsGoest(session))
                throw new Exception("Вы больше не авторизированы");
            AccountWithRoles account = AccountsController.GetController().GetAccount(session);
            int clientID = 0;
            if (!account.IsClient())
            {
                if (!account.IsShowOrdersUser())
                    throw new Exception("Вы не являетесь " +
                        "ни клиентом," +
                        "ни продавцом," +
                        "ни менеджером по заказу" +
                        "ни директором," +
                        "ни администратором");
            }
            else if (Helper.SetClient)
            {
                clientID = account.ID;
            }
            OrdersWithStatusesList orders = Get(clientID, "");
            if (!orders.ContainsByNumber(number))
                throw new Exception("Данного заказа не существует");
            OrderWithStatus order = orders.GetByNumber(number);
            return GetProducts(session, order.ID);
        }


        /// <summary>
        /// Повторить заказ по его ID
        /// </summary>
        /// <param name="session"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public ShoppingCartSession Reapeart(Session session, int id)
        {
            if (!SessionsController.GetController().CheckActive(session))
                throw new Exception("Вы больше не авторизированы");
            if (UserRolesController.GetController().IsGoest(session))
                throw new Exception("Вы больше не авторизированы");
            AccountWithRoles account = AccountsController.GetController().GetAccount(session);
            if (!account.IsClient())
            {
                throw new Exception("Вы больше не являетесь клиентом");
            }
            int clientID = account.ID;
            if (!Get(clientID, "").ContainsByID(id))
                throw new Exception("Данного заказа не существует");

            ShoppingCartSession cartSession = ShoppingCarts.Add(session);
            ProductsInShoppingCartList cart = ShoppingCarts.Get(cartSession);
            cart.SetProductsWithCountRange(GetProductsByOrder(id).GetProductQuantities());
            return cartSession;
        }

        /// <summary>
        /// Повторить заказ по его номеру
        /// </summary>
        /// <param name="session"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public ShoppingCartSession Reapeart(Session session, string number)
        {
            if (!SessionsController.GetController().CheckActive(session))
                throw new Exception("Вы больше не авторизированы");
            if (UserRolesController.GetController().IsGoest(session))
                throw new Exception("Вы больше не авторизированы");
            AccountWithRoles account = AccountsController.GetController().GetAccount(session);
            if (!account.IsClient())
            {
                throw new Exception("Вы больше не являетесь клиентом");
            }
            int clientID = account.ID;
            OrdersWithStatusesList orders = Get(clientID, "");
            if (!orders.ContainsByNumber(number))
                throw new Exception("Данного заказа не существует");
            OrderWithStatus order = orders.GetByNumber(number);

            ShoppingCartSession cartSession = ShoppingCarts.Add(session);
            ProductsInShoppingCartList cart = ShoppingCarts.Get(cartSession);
            cart.SetProductsWithCountRange(GetProductsByOrder(order.ID).GetProductQuantities());
            return cartSession;
        }

    }
}
