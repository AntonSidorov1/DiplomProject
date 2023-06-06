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
    /// Телефоны
    /// </summary>
    [AppRoute("[controller]")]
    [ApiController]
    public class TelefonsController : ControllerBase
    {
        /// <summary>
        /// Создать контроллер
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public static TelefonsController GetController() => new TelefonsController();

        /// <summary>
        /// Получить список телефонов
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        [HttpPut("Get")]
        public ActionResult<TelefonsList> Get(Session session)
        {
            SessionsController controller = SessionsController.GetController();
            if(!controller.CheckActive(session))
            {
                return Unauthorized("Null");
            }
            if(UserRolesController.GetController().IsGoest(session).Value)
            {
                return Unauthorized("Null");
            }
            int id = AccountsController.GetController().GetAccount(session).Value.ID;
            return TelefonsList.GetListFromDB(id);
        }

        /// <summary>
        /// Получить список телефонов
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public ActionResult<TelefonsList> Get() => Get(new Session(User.Identity.Name));

        /// <summary>
        /// Получить телефон по его ID
        /// </summary>
        /// <param name="session"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}/Get")]
        public ActionResult<Telefon> Get(Session session, int id) => Get(session).Value.GetByID(id);

        /// <summary>
        /// Получить телефон по его ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<Telefon> Get(int id) => Get(new Session(User.Identity.Name), id);

        /// <summary>
        /// Добавить номер телефона
        /// </summary>
        /// <param name="telefon"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        public ActionResult<bool> AddTelefon(TelefonSession telefon)
        {
            if (!SessionsController.GetController().CheckActive(telefon))
                return Unauthorized(false);
            if (UserRolesController.GetController().IsGoest(telefon).Value)
                return Unauthorized(false);
            int user = AccountsController.GetController().GetAccount(telefon).Value.ID;
            return TelefonsList.GetList().AddToDB(user, telefon.CopyTelefon()) ? Ok(true) : Conflict(false);
        }

        /// <summary>
        /// Добавить номер телефона
        /// </summary>
        /// <param name="telefon"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult<bool> AddTelefon(TelefonValue telefon)
        {
            return AddTelefon(telefon.CopySession(User.Identity.Name));
        }

        /// <summary>
        /// Удалить номер телефона
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult<bool> DeleteTelefon(int id)
        {
            return DeleteTelefon(new Session(User.Identity.Name), id);
        }

        /// <summary>
        /// Удалить номер телефона
        /// </summary>
        /// <param name="id"></param>
        /// <param name="telefon"></param>
        /// <returns></returns>
        [HttpPut("{id}/Delete")]
        public ActionResult<bool> DeleteTelefon(Session telefon, int id)
        {
            if (!SessionsController.GetController().CheckActive(telefon))
                return Unauthorized(false);
            if (UserRolesController.GetController().IsGoest(telefon).Value)
                return Unauthorized(false);
            int user = AccountsController.GetController().GetAccount(telefon).Value.ID;
            return TelefonsList.GetList().DeleteFromDB(user, id) ? Ok(true) : NotFound(false);
        }


    }
}
