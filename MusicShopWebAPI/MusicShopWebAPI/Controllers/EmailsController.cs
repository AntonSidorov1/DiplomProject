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
    public class EmailsController : ControllerBase
    {
        /// <summary>
        /// Создать контроллер
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public static EmailsController GetController() => new EmailsController();

        /// <summary>
        /// Получить список электронных почт
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        [HttpPut("Get")]
        public ActionResult<EmailsList> Get(Session session)
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
            return EmailsList.GetListFromDB(id);
        }

        /// <summary>
        /// Получить список электронных почт
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public ActionResult<EmailsList> Get() => Get(new Session(User.Identity.Name));

        /// <summary>
        /// Получить электронную почту по её ID
        /// </summary>
        /// <param name="session"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}/Get")]
        public ActionResult<Email> Get(Session session, int id) => Get(session).Value.GetByID(id);

        /// <summary>
        /// Получить электронную почту по её ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<Email> Get(int id) => Get(new Session(User.Identity.Name), id);

        /// <summary>
        /// Добавить Email-адрес
        /// </summary>
        /// <param name="telefon"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        public ActionResult<bool> AddEmail(EmailSession telefon)
        {
            if (!SessionsController.GetController().CheckActive(telefon))
                return Unauthorized(false);
            if (UserRolesController.GetController().IsGoest(telefon).Value)
                return Unauthorized(false);
            int user = AccountsController.GetController().GetAccount(telefon).Value.ID;
            return EmailsList.GetList().AddToDB(user, telefon.CopyEmail()) ? Ok(true) : Conflict(false);
        }

        /// <summary>
        /// Добавить Email-адрес
        /// </summary>
        /// <param name="telefon"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult<bool> AddEmail(EmailValue telefon)
        {
            return AddEmail(telefon.CopySession(User.Identity.Name));
        }

        /// <summary>
        /// Удалить Email-адрес
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult<bool> DeleteEmail(int id)
        {
            return DeleteEmail(new Session(User.Identity.Name), id);
        }

        /// <summary>
        /// Удалить Email-адрес
        /// </summary>
        /// <param name="id"></param>
        /// <param name="telefon"></param>
        /// <returns></returns>
        [HttpPut("{id}/Delete")]
        public ActionResult<bool> DeleteEmail(Session telefon, int id)
        {
            if (!SessionsController.GetController().CheckActive(telefon))
                return Unauthorized(false);
            if (UserRolesController.GetController().IsGoest(telefon).Value)
                return Unauthorized(false);
            int user = AccountsController.GetController().GetAccount(telefon).Value.ID;
            return EmailsList.GetList().DeleteFromDB(user, id) ? Ok(true) : NotFound(false);
        }

    }
}
