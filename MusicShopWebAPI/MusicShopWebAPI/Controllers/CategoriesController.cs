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
    public class CategoriesController : ControllerBase
    {

        /// <summary>
        /// Получить список категорий
        /// </summary>
        /// <param name="session"></param>
        /// <param name="filterID"></param>
        /// <returns></returns>
        [HttpPut("Get")]
        public ActionResult<CategoriesList> GetCategories([FromBody] Session session, int filterID = 0)
        {
            if (!SessionsController.GetController().CheckActive(session))
                return Unauthorized("Null");
            return GetCategories(filterID);
        }

        /// <summary>
        /// Получить список категорий
        /// </summary>
        /// <param name="filterID"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public ActionResult<CategoriesList> GetCategoriesByJwt(int filterID = 0) => GetCategories(new Session(User.Identity.Name), filterID);

        /// <summary>
        /// Получить список категорий
        /// </summary>
        /// <param name="filterID"></param>
        /// <returns></returns>
        [NonAction]
        public CategoriesList GetCategories(int filterID = 0) => CategoriesList.GetListFromDB(filterID);

        /// <summary>
        /// Получить категорию по её ID
        /// </summary>
        /// <param name="session"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}/Get")]
        public ActionResult<Category> GetCategory([FromBody] Session session, int id)
        {
            if (!SessionsController.GetController().CheckActive(session))
                return Unauthorized("Null");
            return GetCategories().GetByID(id);
        }

        /// <summary>
        /// Получить подкатегории в категории по её ID
        /// </summary>
        /// <param name="session"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}/Sub-Categories/Get")]
        public ActionResult<CategoriesList> GetSubCategories([FromBody] Session session, int id = 0, int filterID = 0)
        {
            if (!SessionsController.GetController().CheckActive(session))
                return Unauthorized("Null");
            return GetCategories().GetSubCategories(id, filterID);
        }

        /// <summary>
        /// Получить надкатегорию для категории по её ID
        /// </summary>
        /// <param name="session"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}/Root-Categories/Get")]
        public ActionResult<Category> GetRootCategory([FromBody] Session session, int id = 0)
        {
            if (!SessionsController.GetController().CheckActive(session))
                return Unauthorized("Null");
            return GetCategories().GetRootCategory(id);
        }

        /// <summary>
        /// Получить категорию по её названию
        /// </summary>
        /// <param name="session"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPut("By-Name/{name}")]
        public ActionResult<Category> GetCategory([FromBody] Session session, string name)
        {
            if (!SessionsController.GetController().CheckActive(session))
                return Unauthorized("Null");
            return GetCategories().GetByName(name);
        }

        /// <summary>
        /// Получить категорию по её названию
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("By-Name/{name}")]
        public ActionResult<Category> GetCategory(string name)
             => GetCategory(new Session(User.Identity.Name), name);

        /// <summary>
        /// Получить категорию по её ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<Category> GetCategory(int id)
            => GetCategory(new Session(User.Identity.Name), id);


        /// <summary>
        /// Получить подкатегории в категории по её ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("{id}/Sub-Categories")]
        public ActionResult<CategoriesList> GetSubCategories(int id = 0, int filterID = 0)
            => GetSubCategories(new Session(User.Identity.Name), id, filterID);

        /// <summary>
        /// Получить надкатегорию для категории по её ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("{id}/Root-Categories")]
        public ActionResult<Category> GetRootCategory(int id = 0)
            => GetRootCategory(new Session(User.Identity.Name), id);
    }
}
