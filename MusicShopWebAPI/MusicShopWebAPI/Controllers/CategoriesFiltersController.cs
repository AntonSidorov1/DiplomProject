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
    /// Контроллер категорий
    /// </summary>
    [AppRoute("[controller]")]
    [ApiController]
    public class CategoriesFiltersController : ControllerBase
    {

        /// <summary>
        /// Получить список фильтров категорий
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        [HttpPut("Get")]
        public ActionResult<CategoriesFiltersList> GetCategoriesFilters([FromBody] Session session)
        {
            if (!SessionsController.GetController().CheckActive(session))
                return Unauthorized("Null");
            return GetCategoriesFilters();
        }

        /// <summary>
        /// Получить список фильтров категорий
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public ActionResult<CategoriesFiltersList> GetCategoriesByJwt() => GetCategoriesFilters(new Session(User.Identity.Name));

        /// <summary>
        /// Получить список фильтров категорий
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public CategoriesFiltersList GetCategoriesFilters() => CategoriesFiltersList.GetListFromDB();

        /// <summary>
        /// Получить фильтр категории по его ID
        /// </summary>
        /// <param name="session"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}/Get")]
        public ActionResult<CategoryFilter> GetCategoryFilter([FromBody] Session session, int id)
        {
            if (!SessionsController.GetController().CheckActive(session))
                return Unauthorized("Null");
            return GetCategoriesFilters().GetByID(id);
        }

        /// <summary>
        /// Получить фильтр категории по его названию
        /// </summary>
        /// <param name="session"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPut("By-Name/{name}")]
        public ActionResult<CategoryFilter> GetCategoryFilter([FromBody] Session session, string name)
        {
            if (!SessionsController.GetController().CheckActive(session))
                return Unauthorized("Null");
            return GetCategoriesFilters().GetByName(name);
        }

        /// <summary>
        /// Получить фильтр категории по его названию
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("By-Name/{name}")]
        public ActionResult<CategoryFilter> GetCategoryFilter(string name)
             => GetCategoryFilter(new Session(User.Identity.Name), name);

        /// <summary>
        /// Получить фильтр категорий по его ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<CategoryFilter> GetCategoryFilter(int id)
            => GetCategoryFilter(new Session(User.Identity.Name), id);
    }
}
