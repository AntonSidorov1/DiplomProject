using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Корзина
    /// </summary>
    public class ShoppingCartController 
    {
        public static ShoppingCartsList carts = new ShoppingCartsList();

        /// <summary>
        /// Создать контроллер
        /// </summary>
        /// <returns></returns>
        public static ShoppingCartController GetController()
            => new ShoppingCartController();

        /// <summary>
        /// Открыть сессию для формирования корзины
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public ShoppingCartSession GetOrderSession(Session session)
        {
            if (!SessionsController.GetController().CheckActive(session))
                throw new Exception("Вы больше не авторизированы");
            return carts.Add(session);
        }

        /// <summary>
        /// Получить содержимое корзины
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public List<ProductInShoppingCart> GetOrder(ShoppingCartSession session)
        {
            if (!carts.ContainsOrderToken(session.OrderToken))
                throw new Exception("Вы больше не авторизированы");
            ProductsInShoppingCartList products = carts.Get(session);
            products.SetChange();
            
            return products.AbstractList();
        }

        /// <summary>
        /// Задать список товаров в заказе
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public bool SetOrder(ProductsQuantitiesSession session)
        {
            if (!carts.ContainsOrderToken(session.OrderToken))
                throw new Exception("Вы больше не авторизированы");
            ProductsInShoppingCartList products = carts.Get(session.CopySession());
            return products.SetProductsWithCountRange(session.Products);
        }

        /// <summary>
        /// Задать список товаров в заказе
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public bool SetOrderWithTraidingPoint(SessionWithTraidingPoint session)
        {
            if (!carts.ContainsOrderToken(session.OrderToken))
                throw new Exception("Вы больше не авторизированы");
            ProductsInShoppingCartList products = carts.Get(session.CopySession());
            return products.SetProductsWithCountRange(session);
        }

        /// <summary>
        /// Получить содержимое корзины
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public OrderShoppingCart GetOrderFullInfo(ShoppingCartSession session)
        {
            if (!carts.ContainsOrderToken(session.OrderToken))
                throw new Exception("Вы больше не авторизированы");
            ProductsInShoppingCartList products = carts.Get(session);
            products.SetChange();
            return new OrderShoppingCart(products);
        }

        /// <summary>
        /// Проверка возможности формирования корзины с заданным токеном
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public bool Check(ShoppingCartSession session)
        {
            return carts.ContainsOrderToken(session);
        }


        /// <summary>
        /// Добавить товар в корзину по его ID
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public bool AddProductToOrder(ShoppingCartSession session, int id)
        {
            ProductsList products = ProductsList.GetListFromDB();
            if (!products.ContainsByID(id))
                return false;
            return AddProductToOrder(session, products.GetByID(id));

        }

        /// <summary>
        /// Добавить товар в корзину по его артиклю
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public bool AddProductToOrder(ShoppingCartSession session, string articul)
        {
            ProductsList products = ProductsList.GetListFromDB();
            if (!products.ContainsByArticul(articul))
                return false;
            return AddProductToOrder(session, products.GetByArticul(articul));
        }

        /// <summary>
        /// Добавить товар в корзину
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public bool AddProductToOrder(ShoppingCartSession session, Product product)
        {
            if(!carts.ContainsOrderToken(session))
                throw new Exception("Вы больше не авторизированы");
            ProductsInShoppingCartList cart = carts.Get(session);
            cart.SetChange();
            return cart.AddProduct(product);
        }

        /// <summary>
        /// Удалить товар из корзины
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public bool DeleteProductFromOrder(ShoppingCartSession session, int index)
        {
            try
            {
                if (!carts.ContainsOrderToken(session))
                    throw new Exception("Вы больше не авторизированы");
                ProductsInShoppingCartList cart = carts.Get(session);
                cart.SetChange();
                cart.RemoveAt(index);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// получить информацию о товаре в корзине по его индексу
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public ProductInShoppingCart GetProductFromOrder(ShoppingCartSession session, int index)
        {
            if (!carts.ContainsOrderToken(session))
                throw new Exception("Вы больше не авторизированы");
            ProductsInShoppingCartList products = carts.Get(session);
            products.SetChange();
            return products.GetByIndex(index);

        }

        /// <summary>
        /// Получить информацию о заказе
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public OrderCart GetProductFromOrder(ShoppingCartSession session)
        {
            if (!carts.ContainsOrderToken(session))
                throw new Exception("Вы больше не авторизированы");
            ProductsInShoppingCartList products = carts.Get(session);
            products.SetChange();
            return products.GetOrderData();

        }

        /// <summary>
        /// Добавить товар в корзину по его индексу
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public bool AddProductToOrderByIndex(ShoppingCartSession session, int index)
        {
            if (!carts.ContainsOrderToken(session))
                throw new Exception("Вы больше не авторизированы");
            ProductsInShoppingCartList products = carts.Get(session);

            products.SetChange();
            if (!products.ContainsByIndex(index))
            {
                return false;
            }
            return AddProductToOrder(session, products.GetByIndex(index));
        }



        /// <summary>
        /// уменьшить количество товара в корзине по его индексу
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public bool SubProductFromOrder(ShoppingCartSession session, int index)
        {
            if (!carts.ContainsOrderToken(session))
                throw new Exception("Вы больше не авторизированы");
            ProductsInShoppingCartList products = carts.Get(session);
            products.SetChange();
            if (!products.ContainsByIndex(index))
            {
                return false;
            }
            return products.SubstractProduct(index);

        }

        /// <summary>
        /// Поменять количество товара в корзине по его индексу
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public bool ChangeProductAtOrder(ShoppingCartSession session, int index, int quantity = 0)
        {
            if (!carts.ContainsOrderToken(session))
                throw new Exception("Вы больше не авторизированы");
            ProductsInShoppingCartList products = carts.Get(session);
            products.SetChange();
            if (!products.ContainsByIndex(index))
            {
                return false;
            }
            return products.SetProductCount(index, quantity);

        }

        /// <summary>
        /// Очистить корзину
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public bool ClearOrder(ShoppingCartSession session)
        {
            try
            {
                if (!carts.ContainsOrderToken(session))
                    throw new Exception("Вы больше не авторизированы");
                ProductsInShoppingCartList products = carts.Get(session);
                products.Clear();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Добавить товар по id в корзину с определённым количеством
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public bool SetProductToOrder(ShoppingCartSession session, int id, int quantity = 1)
        {
            try
            {
                if (!carts.ContainsOrderToken(session))
                    throw new Exception("Вы больше не авторизированы");
                ProductsList products = ProductsList.GetListFromDB();
                if (!products.ContainsByID(id))
                    return false;

                return SetProductToOrder(session, products.GetByID(id), quantity); 
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Добавить товар в корзину с определённым количеством
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public bool SetProductToOrder(ShoppingCartSession session, Product product, int quantity = 1)
        {
            if (!carts.ContainsOrderToken(session))
                throw new Exception("Вы больше не авторизированы");
            ProductsInShoppingCartList cart = carts.Get(session);
            cart.SetChange();
            return cart.AddProductWithCount(product, quantity);
        }

        /// <summary>
        /// Добавить товар по артиклю в корзину с определённым количеством
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public bool SetProductToOrder(ShoppingCartSession session, string articul, int quantity = 1)
        {
            ProductsList products = ProductsList.GetListFromDB();
            if (!products.ContainsByArticul(articul))
                return false;
            return SetProductToOrder(session, products.GetByArticul(articul), quantity);
        }

        /// <summary>
        /// Установить магазин для получения заказа
        /// </summary>
        /// <param name="session"></param>
        /// <param name="shopID"></param>
        /// <returns></returns>
        public bool SetShop(ShoppingCartSession session, int shopID)
        {
            try
            {
                if (!carts.ContainsOrderToken(session))
                    throw new Exception("Вы больше не авторизированы");
                ProductsInShoppingCartList cart = carts.Get(session);
                cart.SetChange();
                cart.SetListChange(shopID, PounktType.Shop);
                cart.SetChange();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Установить магазин для получения заказа
        /// </summary>
        /// <param name="session"></param>
        /// <param name="pountOfIssueID"></param>
        /// <returns></returns>
        public bool SetPountOfIssue(ShoppingCartSession session, int pountOfIssueID)
        {
            try
            {
                if (!carts.ContainsOrderToken(session))
                    throw new Exception("Вы больше не авторизированы");
                ProductsInShoppingCartList cart = carts.Get(session);
                cart.SetChange();
                cart.SetListChange(pountOfIssueID, PounktType.Stock);
                cart.SetChange();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Удалить пункт получения
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public bool DeletePountOfIssue(ShoppingCartSession session)
        {
            try
            {
                if (!carts.ContainsOrderToken(session))
                    throw new Exception("Вы больше не авторизированы");
                ProductsInShoppingCartList cart = carts.Get(session);
                cart.SetChange();
                cart.SetListChange(0);
                cart.SetChange();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
