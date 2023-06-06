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
    /// Контроллер для работы с аккаунтами
    /// </summary>
    [AppRoute("[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        /// <summary>
        /// Получить данные аккаунта по токену сессии
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        [HttpPut("Get-Data")]
        public ActionResult<AccountWithRoles> GetAccount([FromBody] Session session)
        {
            if (!SessionsController.GetController().CheckActive(session))
            {
                return Unauthorized("Null");
            }
            if (UserRolesController.UserIsGoest(session))
            {
                AccountWithRoles account = new AccountWithRoles { Login = "Гость" };
                account.Roles.Add(new Role { RoleEng = "Goest", RoleRus = "Гость", ID = 0 });
                return account;
            }
            session = SessionsController.GetSessions().Get(session.Token);

            SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"Select [UserID] From [UserSignIn] where [LoginToken]='{session.Token}'";
                int user = Convert.ToInt32(command.ExecuteScalar());
                AccountWithID account = AccountsList.GetDatasListFromDB().GetByID(user);

                SessionsController.GetAndUpdateEnvirontmentSession((session as SessionEdit).Session, connection);
                connection.Close();
                return account.GetUserWithRoles();
            }
            catch (Exception e)
            {
                connection.Close();
                return StatusCode(500, "Null");
            }
        }

        /// <summary>
        /// Зарегистрироваться (Добавить клиента), используя Jwt-токен сессии гостя
        /// </summary>
        /// <returns></returns>
        [HttpGet("Data")]
        [Authorize]
        public ActionResult<AccountWithRoles> GetAccount()
        {
            return GetAccount(new Session(User.Identity.Name));
        }

        /// <summary>
        /// Зарегистрироваться (Добавить клиента), используя Jwt-токен сессии гостя
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        [HttpPost("Registrate")]
        [Authorize(Roles = "Goest")]
        public ActionResult<RegistrateSession> Registrate(Account account)
        {
            AccountWithGoestToken accountGoest = account.CopyWithGosetToken(User.Identity.Name);
            return AddClient(accountGoest);
        }

        /// <summary>
        /// Зарегистрироваться (Добавить клиента), используя токен сессии гостя
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        [HttpPost("Add-Client")]
        public ActionResult<RegistrateSession> AddClient([FromBody] AccountWithGoestToken account)
        {
            string goest = account.GoestToken;
            Session session = new Session(goest);
            if (!SessionsController.GetController().CheckActive(session))
            {
                return Unauthorized("Null");
            }
            if(!UserRolesController.UserIsGoest(session))
            {
                return StatusCode(403, "Null");
            }

            string environtment = SessionsController.GetAndUpdateEnvirontmentSession(goest).Token;

            environtment = SessionsController.GetEnvirontmentSessions().Find(s => s.Token == environtment).Session;

            string token = SessionsController
                .AddSessionToHistory(
                account.CopyWithEnvirontment(environtment));



            if(!AccountsList.GetDatasListFromDB(false).AddClientToDB(account))
            {
                SessionsController.UpdateTokenNoSuccessfully(token);
                return Conflict("Null");
            }

            SessionEdit sessionEdit = SessionsController.GetSessions().Find(s => s.Token == token);

            return sessionEdit.Copy().CopyRegistrate();
        }

        /// <summary>
        /// Поменять пароль
        /// </summary>
        /// <param name="secret"></param>
        /// <returns></returns>
        [HttpPatch("Change-Password")]
        public ActionResult<bool> ChangePassword(SecretSession secret)
        {
            if (!SessionsController.GetController().CheckActive(secret.GetSession()))
                return Unauthorized("Null");
            string login = GetAccount(new Session(secret.Token)).Value.Login;
            return AccountsList.GetDatasListFromDB().ChangePassword(login, secret.Password);
        }


        /// <summary>
        /// Поменять пароль
        /// </summary>
        /// <param name="secret"></param>
        /// <returns></returns>
        [HttpPatch("Change-Password/By-JWT")]
        [Authorize]
        public ActionResult<bool> ChangePassword(Secret secret)
        {
            SecretSession secretSession = new SecretSession();
            secretSession.Password = secret.Password;
            secretSession.Token = User.Identity.Name;
            return ChangePassword(secretSession);
        }

        /// <summary>
        /// Изменить ФИО у пользователя
        /// </summary>
        /// <param name="initials"></param>
        /// <returns></returns>
        [HttpPatch("Change-FIO")]
        public ActionResult<bool> SetFIO(InitialsSession initials)
        {
            Session session = initials.GetSession();
            if(!SessionsController.GetController().CheckActive(session))
            {
                return Unauthorized(false);
            }
            if(UserRolesController.UserIsGoest(session))
            {
                return Unauthorized(false);
            }
            int id = AccountsController.GetController().GetAccount(session).Value.ID;

            try
            {
                SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
                connection.Open();
                try
                {
                    SqlCommand command;
                    try
                    {
                        command = new SqlCommand();
                        command.Connection = connection;
                        command.CommandText = $"Delete From [UserInitials] where [UserID]={id}";
                        command.ExecuteNonQuery();
                    }
                    catch
                    {

                    }

                    if (initials.FamilyName != "" && initials.FirstName != "")
                    {
                        command = new SqlCommand();
                        command.Connection = connection;
                        command.CommandText = "Insert Into [UserInitials] ([UserID], [UserFamily], [UserName], [UserSurName]) " +
                            $"Values ({id}, @family, @name, @sur)";
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@family", initials.FamilyName);
                        command.Parameters.AddWithValue("@name", initials.FirstName);
                        command.Parameters.AddWithValue("@sur", initials.SurName);
                        command.ExecuteNonQuery();
                    }

                    connection.Close();
                    return true;
                }
                catch(Exception e)
                {
                    connection.Close();
                    throw new Exception(e.Message, e);
                }
            }
            catch
            {
                return BadRequest(false);
            }
            
        }

        /// <summary>
        /// Изменить ФИО у пользователя
        /// </summary>
        /// <param name="initials"></param>
        /// <returns></returns>
        [HttpPatch("Change-FIO/By-JWT")]
        [Authorize]
        public ActionResult<bool> SetFIO(Initials initials)
        {
            return SetFIO(initials.GetInitialsSession(User.Identity.Name));
        }

        /// <summary>
        /// Создать контроллер
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public static AccountsController GetController() => new AccountsController();


        /// <summary>
        /// Удалить номер телефона
        /// </summary>
        /// <returns></returns>
        [HttpDelete("Delete-Account")]
        [Authorize]
        public ActionResult<bool> DeleteUser()
        {
            return DeleteUser(new Session(User.Identity.Name));
        }

        /// <summary>
        /// Удалить номер телефона
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        [HttpPut("Delete-Account")]
        public ActionResult<bool> DeleteUser(Session session)
        {
            if (!SessionsController.GetController().CheckActive(session))
                return Unauthorized(false);
            if (UserRolesController.GetController().IsGoest(session).Value)
                return Unauthorized(false);
            int user = AccountsController.GetController().GetAccount(session).Value.ID;
            return AccountsList.GetDatasList().DeleteFromDB(user) ? Ok(true) : NotFound(false);
        }

    }
}
