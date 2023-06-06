using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    /// <summary>
    /// Контроллер заказов
    /// </summary>
    [AppRoute("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        /// <summary>
        /// Создать контроллер
        /// </summary>
        /// <returns></returns>
        [NonAction]
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
        [HttpPut("Set-Order")]
        public ActionResult<OrderValue> SetOrder(OrderSession orderSession)
        {
            Session session = orderSession.CopySession();
            if (!SessionsController.GetController().CheckActive(session))
                return Unauthorized("Null");
            if (!ShoppingCarts.ContainsOrderToken(orderSession))
                return BadRequest("Null");
            ProductsInShoppingCartList products = ShoppingCarts.Get(orderSession);
            products.SetChange();
            if (!products.Mayby)
            {
                return BadRequest("Null");
            }
            try
            {
                AccountWithRoles account = AccountsController.GetController().GetAccount(session).Value;
                if (account.IsGoest())
                {
                    return Unauthorized("Null");
                }
                if (!account.IsClient())
                {
                    return StatusCode(StatusCodes.Status403Forbidden);
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
                    return BadRequest("Null");
                }

                return order;
            }
            catch
            {
                return BadRequest("Null");
            }
        }

        /// <summary>
        /// Оформить заказ
        /// </summary>
        /// <param name="orderSession"></param>
        /// <returns></returns>
        [HttpPost("Set-Order")]
        [Authorize]
        public ActionResult<OrderValue> SetOrder(ShoppingCartSession orderSession)
        {
            return SetOrder(orderSession.CopyOrderSession(User.Identity.Name));
        }

        /// <summary>
        /// Получить историю заказов
        /// </summary>
        /// <param name="session"></param>
        /// <param name="numberFilter"></param>
        /// <returns></returns>
        [HttpPut("Get")]
        public ActionResult<OrdersWithStatusesList> Get(Session session, string numberFilter = "")
        {
            if (!SessionsController.GetController().CheckActive(session))
                return Unauthorized("Null");
            if (UserRolesController.GetController().IsGoest(session).Value)
                return Unauthorized("Null");
            AccountWithRoles account = AccountsController.GetController().GetAccount(session).Value;
            if(!account.IsClient())
            {
                return StatusCode(StatusCodes.Status403Forbidden, "Null");
            }
            int clientID = account.ID;
            return Get(clientID, numberFilter);
        }

        [NonAction]
        public static OrdersWithStatusesList Get(int clientID, string numberFilter)
        {
            return OrdersWithStatusesList.GetListFromDB(numberFilter, clientID);
        }

        /// <summary>
        /// Получить историю заказов
        /// </summary>
        /// <param name="numberFilter"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public ActionResult<OrdersWithStatusesList> Get(string numberFilter = "")
        {
            return Get(new Session(User.Identity.Name), numberFilter);
        }

        /// <summary>
        /// Получить заказ по его ID
        /// </summary>
        /// <param name="session"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}/Get")]
        public ActionResult<OrderWithStatus> Get(Session session, int id)
        {
            if (!SessionsController.GetController().CheckActive(session))
                return Unauthorized("Null");
            if (UserRolesController.GetController().IsGoest(session).Value)
                return Unauthorized("Null");
            AccountWithRoles account = AccountsController.GetController().GetAccount(session).Value;
            if (!account.IsClient())
            {
                return StatusCode(StatusCodes.Status403Forbidden, "Null");
            }
            int clientID = account.ID;
            return Get(clientID, "").GetByID(id);
        }


        /// <summary>
        /// Получить заказ по его ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<OrderWithStatus> Get(int id)
        {
            return Get(new Session(User.Identity.Name), id);
        }


        /// <summary>
        /// Получить заказ по его номеру
        /// </summary>
        /// <param name="session"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        [HttpPut("By-Number/{number}/Get")]
        public ActionResult<OrderWithStatus> GetOrder(Session session, string number)
        {
            if (!SessionsController.GetController().CheckActive(session))
                return Unauthorized("Null");
            if (UserRolesController.GetController().IsGoest(session).Value)
                return Unauthorized("Null");
            AccountWithRoles account = AccountsController.GetController().GetAccount(session).Value;
            if (!account.IsClient())
            {
                return StatusCode(StatusCodes.Status403Forbidden, "Null");
            }
            int clientID = account.ID;
            return Get(clientID, "").GetByNumber(number);
        }


        /// <summary>
        /// Получить заказ по его номеру
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        [HttpGet("By-Number/{number}")]
        [Authorize]
        public ActionResult<OrderWithStatus> GetOrder(string number)
        {
            return GetOrder(new Session(User.Identity.Name), number);
        }

        [NonAction]
        public ProductsInOrderList GetProductsByOrder(int id) => ProductsInOrderList.GetListFromDB(id);

        /// <summary>
        /// Получить заказ по его ID, включая список товаров в нём
        /// </summary>
        /// <param name="session"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}/Full-Info/Get")]
        public ActionResult<OrderFullInfo> GetProducts(Session session, int id)
        {
            if (!SessionsController.GetController().CheckActive(session))
                return Unauthorized("Null");
            if (UserRolesController.GetController().IsGoest(session).Value)
                return Unauthorized("Null");
            AccountWithRoles account = AccountsController.GetController().GetAccount(session).Value;
            if (!account.IsClient())
            {
                return StatusCode(StatusCodes.Status403Forbidden, "Null");
            }
            int clientID = account.ID;
            OrdersWithStatusesList orders = Get(clientID, "");
            if (!orders.ContainsByID(id))
                return NoContent();

            return new OrderFullInfo(orders.GetByID(id));
        }


        /// <summary>
        /// Получить заказ по его ID, включая список товаров в нём
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/Full-Info")]
        [Authorize]
        public ActionResult<OrderFullInfo> GetProducts(int id)
        {
            return GetProducts(new Session(User.Identity.Name), id);
        }

        /// <summary>
        /// Получить заказ по его номеру, включая список товаров в нём
        /// </summary>
        /// <param name="session"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        [HttpPut("By-Number/{number}/Full-Info/Get")]
        public ActionResult<OrderFullInfo> GetProducts(Session session, string number)
        {
            if (!SessionsController.GetController().CheckActive(session))
                return Unauthorized("Null");
            if (UserRolesController.GetController().IsGoest(session).Value)
                return Unauthorized("Null");
            AccountWithRoles account = AccountsController.GetController().GetAccount(session).Value;
            if (!account.IsClient())
            {
                return StatusCode(StatusCodes.Status403Forbidden, "Null");
            }
            int clientID = account.ID;
            OrdersWithStatusesList orders = Get(clientID, "");
            if (!orders.ContainsByNumber(number))
                return NoContent();
            OrderWithStatus order = orders.GetByNumber(number);
            return GetProducts(session, order.ID);
        }


        /// <summary>
        /// Получить заказ по его номеру
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        [HttpGet("By-Number/{number}/Full-Info")]
        [Authorize]
        public ActionResult<OrderFullInfo> GetProducts(string number)
        {
            return GetProducts(new Session(User.Identity.Name), number);
        }

        /// <summary>
        /// Повторить заказ по его ID
        /// </summary>
        /// <param name="session"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}/Repeart/Get")]
        public ActionResult<ShoppingCartSession> Reapeart(Session session, int id)
        {
            if (!SessionsController.GetController().CheckActive(session))
                return Unauthorized("Null");
            if (UserRolesController.GetController().IsGoest(session).Value)
                return Unauthorized("Null");
            AccountWithRoles account = AccountsController.GetController().GetAccount(session).Value;
            if (!account.IsClient())
            {
                return StatusCode(StatusCodes.Status403Forbidden, "Null");
            }
            int clientID = account.ID;
            if (!Get(clientID, "").ContainsByID(id))
                return NoContent();

            ShoppingCartSession cartSession = ShoppingCarts.Add(session);
            ProductsInShoppingCartList cart = ShoppingCarts.Get(cartSession);
            cart.SetProductsWithCountRange(GetProductsByOrder(id).GetProductQuantities());
            return cartSession;
        }


        /// <summary>
        /// Повторить заказ по его ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/Repeart")]
        [Authorize]
        public ActionResult<ShoppingCartSession> Reapeart(int id)
        {
            return Reapeart(new Session(User.Identity.Name), id);
        }

        /// <summary>
        /// Повторить заказ по его номеру
        /// </summary>
        /// <param name="session"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        [HttpPut("By-Number/{number}/Repeart/Get")]
        public ActionResult<ShoppingCartSession> Reapeart(Session session, string number)
        {
            if (!SessionsController.GetController().CheckActive(session))
                return Unauthorized("Null");
            if (UserRolesController.GetController().IsGoest(session).Value)
                return Unauthorized("Null");
            AccountWithRoles account = AccountsController.GetController().GetAccount(session).Value;
            if (!account.IsClient())
            {
                return StatusCode(StatusCodes.Status403Forbidden, "Null");
            }
            int clientID = account.ID;
            OrdersWithStatusesList orders = Get(clientID, "");
            if (!orders.ContainsByNumber(number))
                return NoContent();
            OrderWithStatus order = orders.GetByNumber(number);

            ShoppingCartSession cartSession = ShoppingCarts.Add(session);
            ProductsInShoppingCartList cart = ShoppingCarts.Get(cartSession);
            cart.SetProductsWithCountRange(GetProductsByOrder(order.ID).GetProductQuantities());
            return cartSession;
        }


        /// <summary>
        /// Повторить заказ по его номеру
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        [HttpGet("By-Number/{number}/Repeart")]
        [Authorize]
        public ActionResult<ShoppingCartSession> Reapeart(string number)
        {
            return Reapeart(new Session(User.Identity.Name), number);
        }

        /// <summary>
        /// Отменить заказ по его ID
        /// </summary>
        /// <param name="session"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}/Cancel")]
        public ActionResult<bool> Cancel(Session session, int id)
        {
            if (!SessionsController.GetController().CheckActive(session))
                return Unauthorized("Null");
            if (UserRolesController.GetController().IsGoest(session).Value)
                return Unauthorized("Null");
            AccountWithRoles account = AccountsController.GetController().GetAccount(session).Value;
            if (!account.IsClient())
            {
                return StatusCode(StatusCodes.Status403Forbidden, "Null");
            }
            int clientID = account.ID;
            if (!Get(clientID, "").ContainsByID(id))
                return NoContent();

            return OrdersList.CancelOrder(id);
        }

        /// <summary>
        /// Отменить заказ по его ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}/Cancel")]
        [Authorize]
        public ActionResult<bool> Cancel(int id)
        {
            return Cancel(new Session(User.Identity.Name), id);
        }

        /// <summary>
        /// Отменить заказ по его номеру
        /// </summary>
        /// <param name="session"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        [HttpPut("By-Number/{number}/Cancel")]
        public ActionResult<bool> Cancel(Session session, string number)
        {
            if (!SessionsController.GetController().CheckActive(session))
                return Unauthorized("Null");
            if (UserRolesController.GetController().IsGoest(session).Value)
                return Unauthorized("Null");
            AccountWithRoles account = AccountsController.GetController().GetAccount(session).Value;
            if (!account.IsClient())
            {
                return StatusCode(StatusCodes.Status403Forbidden, "Null");
            }
            int clientID = account.ID;
            OrdersWithStatusesList orders = Get(clientID, "");
            if (!orders.ContainsByNumber(number))
                return NoContent();
            OrderWithStatus order = orders.GetByNumber(number);

            return OrdersList.CancelOrder(number);
        }

        /// <summary>
        /// Отменить заказ по его номеру
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        [HttpDelete("By-Number/{number}/Cancel")]
        [Authorize]
        public ActionResult<bool> Cancel(string number)
        {
            return Cancel(new Session(User.Identity.Name), number);
        }


    }
}
