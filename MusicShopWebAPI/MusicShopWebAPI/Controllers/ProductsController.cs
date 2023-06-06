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
    public class ProductsController : ControllerBase
    {
        [NonAction]
        public static ProductsController GetController() => new ProductsController();

        /// <summary>
        /// Получить список товаров
        /// </summary>
        /// <param name="sortByName"></param>
        /// <param name="sortByPrice"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult<ProductsList> GetProducts(string sortByName = "None", string sortByPrice = "None", int category = 0, string nameFilter = ""
            , int minDiscount = 0, int maxDiscount = 100)
            => GetProducts(new Session(User.Identity.Name), sortByName, sortByPrice, category, nameFilter
                , minDiscount, maxDiscount);

        /// <summary>
        /// Список товаров с количеством
        /// </summary>
        /// <param name="session"></param>
        /// <param name="sortByName"></param>
        /// <param name="sortByPrice"></param>
        /// <param name="category"></param>
        /// <param name="nameFilter"></param>
        /// <returns></returns>
        [HttpPut("With-Count/Get")]
        public ActionResult<ListProductsWithInfo<Product>> GetProductsWithInfo
            ([FromBody] Session session, string sortByName = "None", string sortByPrice = "None", int category = 0, string nameFilter = ""
            , int minDiscount = 0, int maxDiscount = 100)
        {
            if (!SessionsController.GetController().CheckActive(session))
                return Unauthorized("Null");
            
            ListProductsWithInfo<Product> products = new ListProductsWithInfo<Product>(
                GetProducts(session, sortByName, sortByPrice, category, nameFilter, minDiscount, maxDiscount).Value);
            return products;
        }


        /// <summary>
        /// Список товаров с количеством
        /// </summary>
        /// <param name="sortByName"></param>
        /// <param name="sortByPrice"></param>
        /// <param name="category"></param>
        /// <param name="nameFilter"></param>
        /// <returns></returns>
        [HttpGet("With-Count")]
        [Authorize]
        public ActionResult<ListProductsWithInfo<Product>> GetProductsWithInfo
            (string sortByName = "None", string sortByPrice = "None", int category = 0, string nameFilter = ""
            , int minDiscount = 0, int maxDiscount = 100)
        {
            return GetProductsWithInfo(new Session(User.Identity.Name), sortByName, sortByPrice, category, nameFilter, minDiscount, maxDiscount);
        }

        /// <summary>
        /// Получить список товаров
        /// </summary>
        /// <param name="session"></param>
        /// <param name="sortByName"></param>
        /// <param name="sortByPrice"></param>
        /// <returns></returns>
        [HttpPut("Get")]
        public ActionResult<ProductsList> GetProducts
            ([FromBody] Session session, string sortByName = "None", string sortByPrice = "None", int category = 0, string nameFilter=""
            , int minDiscount = 0, int maxDiscount = 100)
        {
            if (!SessionsController.GetController().CheckActive(session))
                return Unauthorized("Null");

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

            return ProductsList.GetListFromDB(byName, byPrice, category, nameFilter).GetListByDiscount(minDiscount, maxDiscount);
        }

        [NonAction]
        public ProductsList GetProducts() => ProductsList.GetListFromDB();

        /// <summary>
        /// Получить товар по его ID
        /// </summary>
        /// <param name="session"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}/Get")]
        public ActionResult<Product> GetProduct(Session session, int id)
        {
            if (!SessionsController.GetController().CheckActive(session))
                return Unauthorized("Null");
            return GetProducts().FirstOrDefault(p => p.ID == id);
        }

        /// <summary>
        /// Получить товар по его Артиклю
        /// </summary>
        /// <param name="session"></param>
        /// <param name="articul"></param>
        /// <returns></returns>
        [HttpPut("By-Articul/{articul}")]
        public ActionResult<Product> GetProduct(Session session, string articul)
        {
            if (!SessionsController.GetController().CheckActive(session))
                return Unauthorized("Null");
            return GetProducts().FirstOrDefault(p => p.Articul.Trim() == articul.Trim());
        }

        /// <summary>
        /// Получить товар по его Артиклю
        /// </summary>
        /// <param name="articul"></param>
        /// <returns></returns>
        [HttpGet("By-Articul/{articul}")]
        public ActionResult<Product> GetProduct(string articul)
        {
            return GetProduct(new Session(User.Identity.Name), articul);
        }

        /// <summary>
        /// Получить товар по его ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<Product> GetProduct(int id)
        {
            return GetProduct(new Session(User.Identity.Name), id);
        }

    }
}
