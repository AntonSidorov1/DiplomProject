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
    /// Города
    /// </summary>
    [AppRoute("[controller]")]
    [ApiController]
    public class SitiesController : ControllerBase
    {
        /// <summary>
        /// Создать контроллер
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public static SitiesController GetController() => new SitiesController();


        /// <summary>
        /// Получить список городов
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        [HttpPut("Get")]
        public ActionResult<SitiesList> GetSities([FromBody] Session session)
        {
            if (!SessionsController.GetController().CheckActive(session))
                return Unauthorized("Null");
            return GetSities();
        }

        /// <summary>
        /// Получить список городов
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public ActionResult<SitiesList> GetSitiesByJwt() => GetSities(new Session(User.Identity.Name));

        /// <summary>
        /// Получить список организаций
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public SitiesList GetSities() => SitiesList.GetListFromDB();

        /// <summary>
        /// Получить город по его ID
        /// </summary>
        /// <param name="session"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}/Get")]
        public ActionResult<Sity> GetSity([FromBody] Session session, int id)
        {
            if (!SessionsController.GetController().CheckActive(session))
                return Unauthorized("Null");
            return GetSities().GetByID(id);
        }

        /// <summary>
        /// Получить город по его ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<Sity> GetSity(int id)
            => GetSity(new Session(User.Identity.Name), id);
    }
}
