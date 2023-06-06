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
    /// Контроллер окружения
    /// </summary>
    [AppRoute("[controller]")]
    [ApiController]
    public class EnvirontmentController : ControllerBase
    {

        /// <summary>
        /// Получить параметры окружения по ключу сессии
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        [HttpPut("Get-By-User")]
        public ActionResult<Environtment> GetByUser(Session session)
        {
            string token = EnvirontmentTokenController.GetEnvirontmantByToken(session.Token);
            return EnvirontmentTokenController.GetController().Get(new EnvirontmentSession(token));
        }


        /// <summary>
        /// Получить параметры окружения по ключу сессии
        /// </summary>
        /// <returns></returns>
        [HttpGet("By-User")]
        [Authorize]
        public ActionResult<Environtment> GetByUser()
        {
            return GetByUser(new Session(User.Identity.Name ?? ""));
        }


        [NonAction]
        public static EnvirontmentController GetController() => new EnvirontmentController();
    }
}
