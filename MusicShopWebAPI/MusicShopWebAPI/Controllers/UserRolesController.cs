using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{

    /// <summary>
    /// Роли пользователя в системе
    /// </summary>
    [AppRoute("[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        /// <summary>
        /// Получить контроллер
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public static UserRolesController GetController() => new UserRolesController();

        /// <summary>
        /// Получить список ролей у пользователя с заданной сессией
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult<RolesList> GetRolesByJWT()
        {
            return GetRoles(new Session(User.Identity.Name));
        }

        /// <summary>
        /// Получить список ролей у пользователя с заданной сессией
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        [HttpPut("Get-Roles")]
        public ActionResult<RolesList> GetRoles([FromBody]Session session)
        {
            if(!SessionsController.GetController().CheckActive(session))
            {
                return Unauthorized("Null");
            }
            session = SessionsController.GetSessions(true).Get(session.Token);

            RolesList roles = RolesController.GetRoles();
            SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"Select [UserID] From [UserSignIn] where [LoginToken]='{session.Token}'";
                try
                {
                    int user = Convert.ToInt32(command.ExecuteScalar());
                    if(user==0)
                    {
                        throw new Exception();
                    }
                    roles = AccountsList.GetDatasListFromDB(false).GetByID(user).GetUserWithRoles().Roles;
                }
                catch (Exception e)
                {
                    roles = roles.Get(role => role.ID == 0);
                }

                SessionsController.GetAndUpdateEnvirontmentSession((session as SessionEdit).Session, connection);
                connection.Close();
            }
            catch(Exception e)
            {
                connection.Close();
                return StatusCode(500, "Null");
            }

            return roles;
        }

        /// <summary>
        /// Пользователь - гость
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        [HttpPut("Is-Goest")]
        public ActionResult<bool> IsGoest(Session session) => UserIsGoest(session);

        /// <summary>
        /// Пользователь - гость
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("Is-Goest")]
        public ActionResult<bool> IsGoest() => IsGoest(new Session(User.Identity.Name));


        /// <summary>
        /// Пользователь - Гость
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        [NonAction]
        public static bool UserIsGoest(Session session)
        {
            if (!SessionsController.GetController().CheckActive(session))
                return false;
            RolesList roles = UserRolesController.GetController().GetRoles(session).Value;
            if (roles.Count != 1)
            {
                return false;
            }
            if (roles[0].ID != 0)
            {
                return false;
            }
            return true;
        }

    }
}
