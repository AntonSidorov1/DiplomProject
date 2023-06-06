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
    /// Корзина
    /// </summary>
    [AppRoute("[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        public static ShoppingCartsList carts = new ShoppingCartsList();

        /// <summary>
        /// Создать контроллер
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public static ShoppingCartController GetController()
            => new ShoppingCartController();

        /// <summary>
        /// Открыть сессию для формирования корзины
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        [HttpPut("Open")]
        public ActionResult<ShoppingCartSession> GetOrderSession(Session session)
        {
            if (!SessionsController.GetController().CheckActive(session))
                return Unauthorized("Null");
            return carts.Add(session);
        }

        /// <summary>
        /// Открыть сессию для формирования корзины
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        [HttpPost("Open")]
        [Authorize]
        public ActionResult<ShoppingCartSession> GetOrderSession()
            => GetOrderSession(new Session(User.Identity.Name));

        /// <summary>
        /// Получить содержимое корзины
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        [HttpPut("Get")]
        public ActionResult<List<ProductInShoppingCart>> GetOrder(ShoppingCartSession session)
        {
            if (!carts.ContainsOrderToken(session.OrderToken))
                return Unauthorized("Null");
            ProductsInShoppingCartList products = carts.Get(session);
            products.SetChange();
            
            return products.AbstractList();
        }

        /// <summary>
        /// Задать список товаров в заказе
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        [HttpPost("Set")]
        public ActionResult<bool> SetOrder(ProductsQuantitiesSession session)
        {
            if (!carts.ContainsOrderToken(session.OrderToken))
                return Unauthorized("Null");
            ProductsInShoppingCartList products = carts.Get(session.CopySession());
            return products.SetProductsWithCountRange(session.Products);
        }

        /// <summary>
        /// Задать список товаров в заказе
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        [HttpPost("Set/With-Traiding-Point-ID")]
        public ActionResult<bool> SetOrderWithTraidingPoint(SessionWithTraidingPoint session)
        {
            if (!carts.ContainsOrderToken(session.OrderToken))
                return Unauthorized("Null");
            ProductsInShoppingCartList products = carts.Get(session.CopySession());
            return products.SetProductsWithCountRange(session);
        }

        /// <summary>
        /// Получить содержимое корзины
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        [HttpPut("Get/Full-Info")]
        public ActionResult<OrderShoppingCart> GetOrderFullInfo(ShoppingCartSession session)
        {
            if (!carts.ContainsOrderToken(session.OrderToken))
                return Unauthorized("Null");
            ProductsInShoppingCartList products = carts.Get(session);
            products.SetChange();
            return new OrderShoppingCart(products);
        }

        /// <summary>
        /// Проверка возможности формирования корзины с заданным токеном
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        [HttpPut("Get/Check")]
        public bool Check(ShoppingCartSession session)
        {
            return carts.ContainsOrderToken(session);
        }


        /// <summary>
        /// Добавить товар в корзину по его ID
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        [HttpPut("Add/{id}")]
        public ActionResult<bool> AddProductToOrder(ShoppingCartSession session, int id)
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
        [HttpPut("Add/By-Articul/{articul}")]
        public ActionResult<bool> AddProductToOrder(ShoppingCartSession session, string articul)
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
        [NonAction]
        public ActionResult<bool> AddProductToOrder(ShoppingCartSession session, Product product)
        {
            if(!carts.ContainsOrderToken(session))
                return Unauthorized("Null");
            ProductsInShoppingCartList cart = carts.Get(session);
            cart.SetChange();
            return cart.AddProduct(product);
        }

        /// <summary>
        /// Удалить товар из корзины
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        [HttpPut("Delete/By-Index/{index}")]
        public ActionResult<bool> DeleteProductFromOrder(ShoppingCartSession session, int index)
        {
            try
            {
                if (!carts.ContainsOrderToken(session))
                    return Unauthorized("Null");
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
        [HttpPut("Get/{index}")]
        public ActionResult<ProductInShoppingCart> GetProductFromOrder(ShoppingCartSession session, int index)
        {
            if (!carts.ContainsOrderToken(session))
                return Unauthorized("Null");
            ProductsInShoppingCartList products = carts.Get(session);
            products.SetChange();
            return products.GetByIndex(index);

        }

        /// <summary>
        /// Получить информацию о заказе
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        [HttpPut("Get-Info")]
        public ActionResult<OrderCart> GetProductFromOrder(ShoppingCartSession session)
        {
            if (!carts.ContainsOrderToken(session))
                return Unauthorized("Null");
            ProductsInShoppingCartList products = carts.Get(session);
            products.SetChange();
            return products.GetOrderData();

        }

        /// <summary>
        /// Добавить товар в корзину по его индексу
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        [HttpPut("Add/By-Index/{index}")]
        public ActionResult<bool> AddProductToOrderByIndex(ShoppingCartSession session, int index)
        {
            if (!carts.ContainsOrderToken(session))
                return Unauthorized("Null");
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
        [HttpPut("Sub/{index}")]
        public ActionResult<bool> SubProductFromOrder(ShoppingCartSession session, int index)
        {
            if (!carts.ContainsOrderToken(session))
                return Unauthorized("Null");
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
        [HttpPut("Change-Count/{index}")]
        public ActionResult<bool> ChangeProductAtOrder(ShoppingCartSession session, int index, int quantity = 0)
        {
            if (!carts.ContainsOrderToken(session))
                return Unauthorized("Null");
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
        [HttpPut("Clear")]
        public ActionResult<bool> ClearOrder(ShoppingCartSession session)
        {
            try
            {
                if (!carts.ContainsOrderToken(session))
                    return Unauthorized("Null");
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
        [HttpPut("Set/By-ID/{id}/With-Count/{quantity}")]
        public ActionResult<bool> SetProductToOrder(ShoppingCartSession session, int id, int quantity = 1)
        {
            try
            {
                if (!carts.ContainsOrderToken(session))
                    return Unauthorized("Null");
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
        [NonAction]
        public ActionResult<bool> SetProductToOrder(ShoppingCartSession session, Product product, int quantity = 1)
        {
            if (!carts.ContainsOrderToken(session))
                return Unauthorized("Null");
            ProductsInShoppingCartList cart = carts.Get(session);
            cart.SetChange();
            return cart.AddProductWithCount(product, quantity);
        }

        /// <summary>
        /// Добавить товар по артиклю в корзину с определённым количеством
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        [HttpPut("Set/By-Articul/{articul}/With-Count/{quantity}")]
        public ActionResult<bool> SetProductToOrder(ShoppingCartSession session, string articul, int quantity = 1)
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
        [HttpPut("Set-Shop/{shopID}")]
        public ActionResult<bool> SetShop(ShoppingCartSession session, int shopID)
        {
            try
            {
                if (!carts.ContainsOrderToken(session))
                    return Unauthorized("Null");
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
        [HttpPut("Set-Pount-Of-Issue/{pountOfIssueID}")]
        public ActionResult<bool> SetPountOfIssue(ShoppingCartSession session, int pountOfIssueID)
        {
            try
            {
                if (!carts.ContainsOrderToken(session))
                    return Unauthorized("Null");
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
        [HttpPut("Delete-Pickup-Point")]
        public ActionResult<bool> DeletePountOfIssue(ShoppingCartSession session)
        {
            try
            {
                if (!carts.ContainsOrderToken(session))
                    return Unauthorized("Null");
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
