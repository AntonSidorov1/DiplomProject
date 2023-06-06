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
    /// Контроллер для работы с товарами
    /// </summary>
    [AppRoute("[controller]")]
    [ApiController]
    public class ProductsInStocksController : ControllerBase
    {
        /// <summary>
        /// Создать контроллер
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public static ProductsInStocksController GetController() => new ProductsInStocksController();

        [NonAction]
        public bool Contains(int id) => StocksController.GetController().GetStocks().ContainsByID(id);

        [NonAction]
        public static PounktType GetPounktType() => PounktType.Stock;

        /// <summary>
        /// Получить список товаров на складе с введённым id
        /// </summary>
        /// <param name="sortByName"></param>
        /// <param name="sortByPrice"></param>
        /// <returns></returns>
        [HttpGet("By-Stock-ID/{id}")]
        [Authorize]
        public ActionResult<ProductsInPounktList> GetProducts(string sortByName = "None", string sortByPrice = "None", int category = 0, string nameFilter = "", int id = 0
            , int minDiscount = 0, int maxDiscount = 100,
            bool listFull = false)
            => GetProducts(new Session(User.Identity.Name), sortByName, sortByPrice, category, nameFilter, id, minDiscount, maxDiscount, listFull);

        /// <summary>
        /// Получить список товаров на складе с введённым id
        /// </summary>
        /// <param name="session"></param>
        /// <param name="sortByName"></param>
        /// <param name="sortByPrice"></param>
        /// <returns></returns>
        [HttpPut("Get-By-Stock-ID/{id}")]
        public ActionResult<ProductsInPounktList> GetProducts([FromBody] Session session, string sortByName = "None", string sortByPrice = "None", int category = 0, string nameFilter="", int id = 0
            , int minDiscount = 0, int maxDiscount = 100,
            bool listFull = false)
        {
            if (!SessionsController.GetController().CheckActive(session))
                return Unauthorized("Null");
            if (id > 0)
            {
                if (!StocksController.GetController().GetStocks(session).Value.ContainsByID(id))
                {
                    return NotFound("Null");
                }
            }

            Order byPrice, byName;
            if (StringNormalize.Normalize(sortByName) == StringNormalize.Normalize("Asc"))
            {
                byName = Order.Asc;
            }
            else if (StringNormalize.Normalize(sortByName) == StringNormalize.Normalize("Desc"))
            {
                byName = Order.Desc;
            }
            else
            {
                byName = Order.None;
            }

            if (StringNormalize.Normalize(sortByPrice) == StringNormalize.Normalize("Asc"))
            {
                byPrice = Order.Asc;
            }
            else if (StringNormalize.Normalize(sortByPrice) == StringNormalize.Normalize("Desc"))
            {
                byPrice = Order.Desc;
            }
            else
            {
                byPrice = Order.None;
            }

            return ProductsInPounktList.GetListFromDB(byName, byPrice, category, nameFilter, GetPounktType(), id, listFull)
                .GetListByDiscount(minDiscount, maxDiscount);
        }


        /// <summary>
        /// Список товаров с количеством
        /// </summary>
        /// <param name="session"></param>
        /// <param name="sortByName"></param>
        /// <param name="sortByPrice"></param>
        /// <param name="category"></param>
        /// <param name="nameFilter"></param>
        /// <returns></returns>
        [HttpPut("Get-By-Stock-ID/{id}/With-Count/Get")]
        public ActionResult<ListProductsWithInfo<ProductInPounkt>> GetProductsWithInfo
            ([FromBody] Session session, string sortByName = "None", string sortByPrice = "None", int category = 0, string nameFilter = "",
            int id = 0
            , int minDiscount = 0, int maxDiscount = 100,
            bool listFull = false)
        {
            if (!SessionsController.GetController().CheckActive(session))
                return Unauthorized("Null");
            ActionResult<ProductsInPounktList> result = 
                GetProducts(session, sortByName, sortByPrice, category, nameFilter, id, minDiscount, maxDiscount, listFull);
            try
            {
                return new ListProductsWithInfo<ProductInPounkt>(
                    result.Value);
            }
            catch
            {
                return NoContent();
            }
        }

        /// <summary>
        /// Список товаров с количеством
        /// </summary>
        /// <param name="sortByName"></param>
        /// <param name="sortByPrice"></param>
        /// <param name="category"></param>
        /// <param name="nameFilter"></param>
        /// <returns></returns>
        [HttpGet("By-Stock-ID/{id}/With-Count")]
        [Authorize]
        public ActionResult<ListProductsWithInfo<ProductInPounkt>> GetProductsWithInfo
            (string sortByName = "None", string sortByPrice = "None", int category = 0, string nameFilter = "",
            int id = 0, int minDiscount = 0, int maxDiscount = 100,
            bool listFull = false)
        {
            return GetProductsWithInfo(new Session(User.Identity.Name), sortByName, sortByPrice, category, nameFilter,
                id, minDiscount, maxDiscount, listFull);
        }

        [NonAction]
        public ProductsInPounktList GetProducts(int pounktID = 0) => ProductsInPounktList.GetListFromDB(pounktID: pounktID, pounktType: GetPounktType());

        /// <summary>
        /// Получить товар по его ID на складе с введённым pounktID
        /// </summary>
        /// <param name="session"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("By-Stock-ID/{pounktID}/Products/{id}/Get")]
        public ActionResult<ProductInPounkt> GetProduct(Session session, int id, int pounktID = 0)
        {
            if (!SessionsController.GetController().CheckActive(session))
                return Unauthorized("Null");
            if (!Contains(pounktID))
                return NoContent();
            ProductsInPounktList products = GetProducts(pounktID);
            if (!products.ContainsByID(id))
            {
                ProductsList products1 = ProductsController.GetController().GetProducts();
                if (!products1.ContainsByID(id))
                    return NoContent();
                return products1.GetByID(id).CopyProductInPounkt(GetPounktType());
            }
            return products.GetByID(id);
        }

        /// <summary>
        /// Получить товар по его Артиклю на складе с введённым pounktID
        /// </summary>
        /// <param name="session"></param>
        /// <param name="articul"></param>
        /// <returns></returns>
        [HttpPut("By-Stock-ID/{pounktID}/By-Articul/{articul}")]
        public ActionResult<Product> GetProduct(Session session, string articul, int pounktID = 0)
        {
            if (!SessionsController.GetController().CheckActive(session))
                return Unauthorized("Null");
            if (!Contains(pounktID))
                return NoContent();
            ProductsInPounktList products = GetProducts(pounktID);
            if (!products.ContainsByArticul(articul))
            {
                ProductsList products1 = ProductsController.GetController().GetProducts();
                if (!products1.ContainsByArticul(articul))
                    return NoContent();
                return products1.GetByArticul(articul).CopyProductInPounkt(GetPounktType());
            }
            return products.GetByArticul(articul);
        }

        /// <summary>
        /// Получить товар по его Артиклю на складе с введённым pounktID
        /// </summary>
        /// <param name="articul"></param>
        /// <returns></returns>
        [HttpGet("By-Stock-ID/{pounktID}/By-Articul/{articul}")]
        public ActionResult<Product> GetProduct(string articul, int pounktID = 0)
        {
            return GetProduct(new Session(User.Identity.Name), articul, pounktID);
        }

        /// <summary>
        /// Получить товар по его ID на складе с введённым pounktID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("By-Stock-ID/{pounktID}/Products/{id}")]
        [Authorize]
        public ActionResult<ProductInPounkt> GetProduct(int id, int pounktID = 0)
        {
            return GetProduct(new Session(User.Identity.Name), id, pounktID);
        }

    }
}
