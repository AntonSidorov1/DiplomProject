using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicShopWebAPI
{
    /// <summary>
    /// Аутотификация для редактирования строки подключения к базе данных
    /// </summary>
    [AppRoute("[controller]")]
    [ApiController]
    public class LoginForEditConnectionParametersController : ControllerBase
    {
        /// <summary>
        /// Получить пароль, по токену для редактирования строки подключения к базе данных
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPut("Get-Password")]
        public ActionResult<Secret> Get([FromBody] Session token)
        {
            return CheckWorking(token) ? Ok(DataBaseConfiguration.Password) : Unauthorized("Null");
        }

        /// <summary>
        /// Закрыть сессию для редактирования строки подключения к базе данных
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPut("Sign-Out")]
        public ActionResult<bool> Delete([FromBody] Session token)
        {
            if(!CheckWorking(token))
            {
                return Unauthorized(false);
            }
            DataBaseConfiguration.SessionsList.Remove(token.Token);
            return Ok(true);
        }

        /// <summary>
        /// Проверить можно ли с данным токеном редактировать строку подключения к базе данных (AllowEditConnection) и менять пароль для этого (working)
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPut("Check")]
        public CheckToken Check([FromBody] Session token)
        {
            CheckToken check = new CheckToken();
            check.Working = DataBaseConfiguration.SessionsList.Contains(token.Token, false);
            if(check.Working)
            {
                check.AllowEditConnection = DataBaseConfiguration.SessionsList.Get(token.Token).AllowEditConnection;
            }
            
            return check;
        }

        [NonAction]
        public bool CheckWorking(Session token) => Check(token).Working;

        [NonAction]
        public bool CheckAllowEditConnection(Session token) => CheckWorking(token) && Check(token).AllowEditConnection;

        /// <summary>
        /// Авторизироваться для редактирования строки подключения к базе данных
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost("Sign-In")]
        public ActionResult<Session> Post([FromBody] Secret value)
        {
            if(value.Password == DataBaseConfiguration.Password.Password)
            {
                string token = DataBaseConfiguration.SessionsList.Add(true).Session;
                return Ok(new Session(token));
            }
            else
            {
                return StatusCode(404, "Null");
            }
        }

        /// <summary>
        /// Авторизироваться, используя токен администратора для работы с паролем для редактирования строки подключения
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("By-Admin")]
        public ActionResult<Session> GetByAdmin()
        {
            return PostByAdmin(new Session(User.Identity.Name));
        }

        /// <summary>
        /// Авторизироваться, используя токен администратора для работы с паролем для редактирования строки подключения
        /// </summary>
        /// <param name="session">Токен сессии</param>
        /// <returns></returns>
        [HttpPost("By-Admin")]
        public ActionResult<Session> PostByAdmin([FromBody] Session session)
        {
            if(!SessionsController.GetController().CheckActive(session))
            {
                return Unauthorized("Null");
            }
            try
            {
                if (UserRolesController.UserIsGoest(session))
                {
                    throw new ArgumentNullException();
                }

                UserRolesController userRoles = UserRolesController.GetController();
                RolesList roles = userRoles.GetRoles(session).Value;
                if (!roles.Contains("admin"))
                {
                    throw new ArgumentNullException();
                }

                string token = DataBaseConfiguration.SessionsList.Add(false).Session;
                return Ok(new Session(token));
            }
            catch (Exception e)
            {
                return StatusCode(403, "Null");
            }
        }

        /// <summary>
        /// Сменить пароль для редактирования строки подключения к базе данных
        /// </summary>
        /// <param name="secret"></param>
        /// <returns></returns>
        [HttpPatch("Change-Password")]
        public ActionResult<bool> Put([FromBody] SecretSession secret)
        {
            if (!CheckWorking(new Session(secret.Token)))
                return Unauthorized(false);
            DataBaseConfiguration.Password = secret.Copy();
            return Ok(true);
        }

    }
}
