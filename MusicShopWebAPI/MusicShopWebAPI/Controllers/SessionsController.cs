using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;
using System.Threading;

namespace MusicShopWebAPI
{
    /// <summary>
    /// Управление сессиями
    /// </summary>
    [AppRoute("[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        [NonAction]
        public static SessionEditList GetEnvirontmentSessions() => EnvirontmentTokenController.GetSessions();

        /// <summary>
        /// Получить список сессий
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public static SessionEditList GetSessions(bool checkActive=false, int count = 20)
        {
            try
            {
                EnvirontmentTokenController.UpdateSessions();
            }
            catch
            {

            }
            SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
            connection.Open();
            SessionEditList sessions = new SessionEditList()
            {
                RemovingOld = false
            };
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Select [LoginToken], [DateOpen] From [LoginHistoryView] ";
                command.Parameters.Clear();
                if(checkActive)
                {
                    command.CommandText += " where LoginActive = @active";
                    command.Parameters.AddWithValue("@active", true);
                }
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        SessionEdit session = new SessionEdit();
                        session.Token = reader.GetString(0);
                        session.Date = reader.GetDateTime(1);
                        sessions.Add(session);
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    reader.Close();
                    throw e;
                }

                connection.Close();
            }
            catch (Exception e)
            {
                try
                {
                    connection.Close();
                }
                catch
                {

                }
                if(count > 20)
                {
                    Thread.Sleep(AddressesList.GetRandomMilliSeconds());
                    return GetSessions(checkActive, count - 1);
                }
                throw e;
            }
            return sessions;
        }

        [NonAction]
        public static SessionEdit GetSession() => GetSessions().Add();

        [NonAction]
        public static void UpdateTokenNoSuccessfully(string token, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Update [LoginHistory] " +
                "Set [LoginSuccessfully] = @active, [LoginActive]=@active " +
                $"where [LoginToken]='{token}'";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@active", false);

            command.ExecuteNonQuery();
        }

        [NonAction]
        public static void UpdateTokenNoSuccessfully(string token)
        {
            SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
            connection.Open();

            try
            {
                UpdateTokenNoSuccessfully(token, connection);

                connection.Close();
            }
            catch(Exception e)
            {
                connection.Close();
                throw new Exception(e.Message, e);
            }
        }

        [NonAction]
        public static string AddSessionToHistory(AccountEnvirontment environtmentSession, SqlConnection connection)
        {
            SessionEditList sessions = GetEnvirontmentSessions();
            SessionEdit session = sessions.Get(environtmentSession.EnvirontmentToken);
            SessionEdit token = GetSession();
            SqlCommand command = new SqlCommand();

            command.Connection = connection;
            command.CommandText = "Insert Into [LoginHistory] " +
                "([LoginToken], [EnvirontmentToken], [UserLogin], [UserPassword], [LoginSuccessfully], [LoginActive]) " +
                $"Values ('{token.Token}', '{session.Token}', @login, @password, @active, @active)";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@active", true);
            command.Parameters.AddWithValue("@login", environtmentSession.Login);
            command.Parameters.AddWithValue("@password", environtmentSession.Password);

            command.ExecuteNonQuery();
            return token.Token;
        }

        [NonAction]
        public static string AddSessionToHistory(AccountEnvirontment environtmentSession)
        {
            SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
            connection.Open();
            string token = "";
            try
            {
                token = AddSessionToHistory(environtmentSession, connection);
                connection.Close();
            }
            catch(Exception e)
            {
                connection.Close();
                throw new Exception(e.Message, e);
            }
            return token;
        }


        /// <summary>
        /// Войти в систему (авторизироваться)
        /// </summary>
        [HttpPost("Sign-In")]
        public ActionResult<JwtSession> SignIn(AccountEnvirontment environtmentSession)
        {
            SessionEditList sessions = GetEnvirontmentSessions();

            if (!sessions.Contains(environtmentSession.EnvirontmentToken, false))
                return Unauthorized("Null");

            JwtSession jwtSession = new JwtSession();
            SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
            connection.Open();
            try
            {
                SessionEdit session = sessions.Get(environtmentSession.EnvirontmentToken);
                SessionEdit token = GetSession();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Insert Into [LoginHistory] " +
                    "([LoginToken], [EnvirontmentToken], [UserLogin], [UserPassword], [LoginSuccessfully], [LoginActive]) " +
                    $"Values ('{token.Token}', '{session.Token}', @login, @password, @active, @active)";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@active", true);
                command.Parameters.AddWithValue("@login", environtmentSession.Login);
                command.Parameters.AddWithValue("@password", environtmentSession.Password);

                command.ExecuteNonQuery();

                AccountsList accounts = AccountsList.GetDatasListFromDB(false);
                if (!accounts.ContainsAccount(environtmentSession))
                {
                    UpdateTokenNoSuccessfully(token.Token, connection);

                    connection.Close();
                    throw new UserException("Неверный логин или пароль") { Code = 400 };
                }

                accounts = AccountsList.GetDatasListFromDB();
                if (!accounts.ContainsAccount(environtmentSession))
                {
                    UpdateTokenNoSuccessfully(token.Token, connection);

                    connection.Close();
                    throw new UserException("Пользователь с данным логином заблокирован") { Code = 423 };
                }
                string roles = "";
                AccountWithID account = new AccountWithID();
                try
                {
                    account = accounts.GetByLogin(environtmentSession.Login);
                    roles = account.GetUserWithRoles().Roles.GetRolesName();
                }
                catch(UserException e)
                {
                    try
                    {
                        UpdateTokenNoSuccessfully(token.Token, connection);
                        connection.Close();
                    }
                    catch
                    {

                    }
                    throw e;
                }
                catch (Exception e)
                {
                    UpdateTokenNoSuccessfully(token.Token, connection);
                    connection.Close();
                    return BadRequest(e.Message);
                }

                ActionResult<JwtSession> actionJwtSession = GetSession(account, token, environtmentSession.GetEnvirontment(), connection);
                connection.Close();
                return actionJwtSession;
            }
            catch(UserException e)
            {
                return StatusCode(e.Code, e.Message);
            }
            catch (Exception e)
            {
                connection.Close();
                return StatusCode(500, "null");
            }
            

            return jwtSession;
        }

        [NonAction]
        public ActionResult<JwtSession> GetSession(AccountWithID account, SessionEdit token, EnvirontmentSession environtmentSession)
        {
            SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
            connection.Open();

            try
            {
                ActionResult<JwtSession> jwtSession = GetSession(account, token, environtmentSession, connection);
                connection.Close();
                return jwtSession;
            }
            catch(Exception e)
            {
                connection.Close();
                return StatusCode(500, "null");
            }
        }

        [NonAction]
        public ActionResult<JwtSession> GetSession(AccountWithID account, SessionEdit token, EnvirontmentSession environtmentSession, SqlConnection connection)
        {
            JwtSession jwtSession = new JwtSession();
            string roles = account.GetUserWithRoles().Roles.GetRolesName();
            SessionEditList sessions = GetEnvirontmentSessions();
            SessionEdit session = sessions.Get(environtmentSession.EnvirontmentToken);

            AddSignIn(token, account, connection);
            UpdateEnvirontmentToken(session.Token, connection);

            jwtSession = GetSessions().Find(s => s.Token == token.Token).CopyJWT();
            AppAuthService _appAuthService = new AppAuthService();
            try
            {
                jwtSession.JwtToken = _appAuthService.Authenticate(jwtSession.Token, roles).AuthToken;

            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
            return jwtSession;
        }

        [NonAction]
        public static void AddSignIn(SessionEdit token, AccountWithID account, SqlConnection connection)
        {

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Insert Into [UserSignIn] " +
                "([LoginToken], [UserID]) " +
                $"Values ('{token.Token}', {account.ID})";
            command.ExecuteNonQuery();

        }

        [NonAction]
        public static void AddSignIn(SessionEdit token, AccountWithID account)
        {
            SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
            connection.Open();
            try
            {
                AddSignIn(token, account, connection);
                connection.Close();
            }
            catch(Exception e)
            {
                connection.Close();
                throw new Exception(e.Message, e);
            }
        }

        [NonAction]
        public static void AddSignIn(SessionEdit token, SqlConnection connection)
        {

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Insert Into [UserSignIn] " +
                "([LoginToken]) " +
                $"Values ('{token.Token}')";
            command.ExecuteNonQuery();

        }

        /// <summary>
        /// Войти с токеном регистрации
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        [HttpPost("Sign-In/By-Registrate-Token")]
        public ActionResult<JwtSession> SignInByRegistrateToken(RegistrateEnvirontmentSession session)
        {
            if(!CheckActive(session.Copy()))
            {
                return Unauthorized("Null");
            }

            if(!GetEnvirontmentSessions().ContainsTokenAutotification(session.EnvirontmentToken))
            {
                return Unauthorized("Null");
            }

            try
            {
                EnvirontmentSession environtmentSession = GetEnvirontmentSession(session.Copy()).Value;
                if (environtmentSession.EnvirontmentToken != session.EnvirontmentToken)
                    throw new ArgumentNullException("Неверный токен регистрации или окружения");

                SessionEdit sessionEdit = GetSessions().Get(session.RegistrateToken);
                SessionEdit environtmentEdit = GetEnvirontmentSessions().Get(session.EnvirontmentToken);

                string login = "";
                SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
                connection.Open();
               
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = $"Select [UserLogin] From [LoginHistory] where [LoginToken]='{sessionEdit.Token}'";
                    login = Convert.ToString(command.ExecuteScalar());

                    connection.Close();
                }
                catch (Exception e)
                {
                    connection.Close();
                    throw e;
                }

                AccountWithID account = AccountsList.GetDatasListFromDB().GetByLogin(login);

                return GetSession(account, sessionEdit, environtmentSession);


            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Войти госем
        /// </summary>
        [HttpPost("Goest")]
        public ActionResult<JwtSession> LoginGoest(EnvirontmentSession environtmentSession)
        {
            SessionEditList sessions = GetEnvirontmentSessions();

            if (!sessions.Contains(environtmentSession.EnvirontmentToken, false))
                return Unauthorized("Null");

            JwtSession jwtSession = new JwtSession();
            SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
            connection.Open();
            try
            {
                SessionEdit session = sessions.Get(environtmentSession.EnvirontmentToken);
                SessionEdit token = GetSession();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Insert Into [LoginHistory] " +
                    "([LoginToken], [EnvirontmentToken], [UserLogin], [LoginSuccessfully], [LoginActive]) " +
                    $"Values ('{token.Token}', '{session.Token}', 'Goest', @active, @active)";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@active", true);
                command.ExecuteNonQuery();


                AddSignIn(token, connection);

                UpdateEnvirontmentToken(session.Token, connection);
                connection.Close();

                jwtSession = GetSessions().Find(s => s.Token == token.Token).CopyJWT();
                AppAuthService _appAuthService = new AppAuthService();
                try
                {
                    jwtSession.JwtToken = _appAuthService.Authenticate(jwtSession.Token, "Goest").AuthToken;

                }
                catch (Exception ex)
                {
                    return Unauthorized(ex.Message);
                }
            }
            catch(Exception e)
            {
                connection.Close();
                return StatusCode(500, "null");
            }

            return jwtSession;
        }

        [NonAction]
        public static void UpdateEnvirontmentToken(string token, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = $"Update [Environtment] Set [DateOpen]=GetDate(), [DateLastActive]=GetDate() where [EnvirontmentToken]='{token}'";
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Изменяет время последней активности токена окружения
        /// </summary>
        /// <param name="token"></param>
        /// <param name="connection"></param>
        [NonAction]
        public static void UpdateActiveToken(string token, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = $"Update [Environtment] Set [DateLastActive]=GetDate() where [EnvirontmentToken]='{token}'";
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Получить токен окружения по заданному ключу сессии
        /// </summary>
        /// <param name="token"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        [NonAction]
        public static Session GetEnvirontment(string token, SqlConnection connection)
        {
            Session session = new Session();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = $"Select [EnvirontmentToken] From [LoginHistory] where LoginToken='{token}'";
            session.Token = Convert.ToString(command.ExecuteScalar());
            return session;
        }

        /// <summary>
        /// Получить токен окружения по заданному ключу сессии
        /// </summary>
        /// <param name="token"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        [NonAction]
        public static Session GetAndUpdateEnvirontment(string token, SqlConnection connection)
        {
            Session session = GetEnvirontment(token, connection);
            UpdateActiveToken(session.Token, connection);
            return session;
        }

        /// <summary>
        /// Получить токен окружения по заданному ключу сессии
        /// </summary>
        /// <param name="token"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        [NonAction]
        public static Session GetAndUpdateEnvirontmentSession(string token, SqlConnection connection)
        {
            SessionEdit session = GetSessions(true).Get(token);

            return GetAndUpdateEnvirontment(session.Token, connection);
        }
        /// <summary>
        /// Получить токен окружения по заданному ключу сессии
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [NonAction]
        public static Session GetAndUpdateEnvirontmentSession(string token)
        {
            Session session = new Session();
            SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
            connection.Open();
            try
            {
                session = GetAndUpdateEnvirontmentSession(token, connection);
                connection.Close();
            }
            catch
            {
                connection.Close();
            }
            return session;
        }

        [NonAction]
        public ActionResult<EnvirontmentSession> GetEnvirontmentSession(string token)
        {
            if(!GetSessions(true).ContainsTokenAutotification(token))
            {
                return Unauthorized("Null");
            }
            Session session = GetAndUpdateEnvirontmentSession(token);
            return GetEnvirontmentSessions().Find(s => s.Token == session.Token).Copy();
        }

        [NonAction]
        public ActionResult<EnvirontmentSession> GetEnvirontmentSession(Session token)
        {
            return GetEnvirontmentSession(token.Token);
        }

        /// <summary>
        /// Закрытие сессии (выход из системы)
        /// </summary>
        /// <returns></returns>
        [HttpDelete("Sign-Out")]
        [Authorize]
        public ActionResult<EnvirontmentSession> LogOut()
        {
            return SignOut(new Session(User.Identity.Name));
        }


        /// <summary>
        /// Закрытие сессии (выход из системы)
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        [HttpPut("Sign-Out")]
        public ActionResult<EnvirontmentSession> SignOut([FromBody] Session session)
        {
            EnvirontmentSession environtment = new EnvirontmentSession();

            SessionEditList sessions = GetSessions(true);
            if (!sessions.Contains(session.Token, false))
            {
                return Unauthorized("Null");
            }
            SessionEdit token = sessions.Get(session.Token);

            SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
            connection.Open();

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"Select [EnvirontmentToken] From [LoginHistory] where LoginToken='{token.Token}'";
                environtment.EnvirontmentToken = Convert.ToString(command.ExecuteScalar());

                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"Update [LoginHistory] set [LoginActive]=@active where LoginToken='{token.Token}'";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@active", false);
                command.ExecuteNonQuery();

                connection.Close();
            }
            catch(Exception e)
            {
                connection.Close();
                return StatusCode(500, "Null");
            }


            return GetEnvirontmentSessions().Find(s => s.Token == environtment.EnvirontmentToken).Copy();
        }

        /// <summary>
        /// Можно ли пользоваться данным токеном сессии
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        [HttpPut("Is-Active")]
        public bool CheckActive([FromBody] Session session)
        {
            try
            {
                GetAndUpdateEnvirontmentSession(session.Token);
            }
            catch
            {

            }
            bool check = GetSessions(true).ContainsTokenAutotification(session.Token);
            return check;
        }

        /// <summary>
        /// Можно ли пользоваться данным токеном сессии
        /// </summary>
        /// <returns></returns>
        [HttpGet("Is-Active")]
        [Authorize]
        public bool CheckActive()
        {
            return CheckActive(new Session(User.Identity.Name ?? ""));
        }

        /// <summary>
        /// Получить контроллер
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public static SessionsController GetController() => new SessionsController();

        /// <summary>
        /// Получить токен сессии по JWT-токену
        /// </summary>
        /// <returns></returns>
        [HttpGet("By-JWT")]
        [Authorize]
        public ActionResult<Session> GetByJWT()
        {
            string token = User.Identity.Name ?? "";
            Session session = new Session(token);
            if (!CheckActive(session))
            {
                return Unauthorized("Null");
            }
            return session;
        }

        /// <summary>
        /// Пользователь активен и не гость
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        [HttpPut("Is-Active-And-No-Goest")]
        public ActionResult<bool> CheckActiveAndNoGoest(Session session)
        {
            if (!CheckActive(session))
                return false;
            if (UserRolesController.GetController().IsGoest(session).Value)
                return false;
            return true;
        }

        /// <summary>
        /// Пользователь активен и не гость
        /// </summary>
        /// <returns></returns>
        [HttpGet("Is-Active-And-No-Goest")]
        [Authorize]
        public ActionResult<bool> CheckActiveAndNoGoest() => CheckActiveAndNoGoest(new Session(User.Identity.Name));

        /// <summary>
        /// Получить историю входов пользователя с заданной сессией
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        [HttpPut("Get-Sessions")]
        public ActionResult<SessionsWithEnvirontmentList> Get(Session session)
        {
            if (!CheckActive(session))
            {
                return Unauthorized("Null");
            }
            if (UserRolesController.GetController().IsGoest(session).Value)
            {
                return Unauthorized("Null");
            }
            try
            {
                Account account = AccountsController.GetController().GetAccount(session).Value;
                return SessionsWithEnvirontmentList.GetListFromDB(account, session);
            }
            catch
            {
                return NotFound("Null");
            }
        }

        /// <summary>
        /// Получить историю входов пользователя с заданной сессией
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get-Sessions")]
        [Authorize]
        public ActionResult<SessionsWithEnvirontmentList> Get()
        {
            return Get(new Session(User.Identity.Name));
        }

        /// <summary>
        /// Закрытие сессии (выход из системы)
        /// </summary>
        /// <returns></returns>
        [HttpGet("Close")]
        [Authorize]
        public ActionResult<bool> CloseSession()
        {
            return CloseSession(new Session(User.Identity.Name));
        }


        /// <summary>
        /// Закрытие сессии (выход из системы)
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        [HttpPut("Close")]
        public ActionResult<bool> CloseSession(Session session)
        {
            

            try
            {
                SessionEditList sessions = GetSessions(true);
                if (!sessions.Contains(session.Token, false))
                {
                    return StatusCode(StatusCodes.Status400BadRequest, false);
                }
                return SessionClose(session)? true: StatusCode(StatusCodes.Status400BadRequest, false); ;
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, false);
            }
        }

        /// <summary>
        /// Закрытие сессии (выход из системы)
        /// </summary>
        /// <param name="session"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [NonAction]
        public bool SessionClose(Session session, int count = 20)
        {

            try
            {
                SessionEditList sessions = GetSessions(false);
                if (!sessions.Contains(session.Token, false))
                {
                    return false;
                }

                SessionEdit token = sessions.Get(session.Token);

                SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
                connection.Open();

                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = $"Update [LoginHistory] set [LoginActive]=@active where LoginToken='{token.Token}'";
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@active", false);
                    int rows = command.ExecuteNonQuery();
                    if (rows < 1)
                    {
                        return false;
                    }

                    connection.Close();
                }
                catch (Exception e)
                {
                    try
                    {
                        connection.Close();
                    }
                    catch
                    {

                    }
                    if (count > 0)
                    {
                        Thread.Sleep(AddressesList.GetRandomMilliSeconds());
                        return SessionClose(session, count - 1);

                    }
                    return false;
                }
            }
            catch
            {
                return false;
            }

            return true;
        }


        /// <summary>
        /// Закрыть все сессии, кроме текущей
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        [HttpPut("Close-All")]
        public ActionResult<bool> CloseAllSessions(Session session)
        {
            try
            {
                List<SessionWithEnvirontment> sessions = Get(session).Value;
                sessions = sessions.FindAll(s => s.Token != session.Token);
                foreach (Session seans in sessions)
                {
                    try
                    {
                        SessionClose(seans);
                    }
                    catch
                    {

                    }
                }
                return true;
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, false);
            }
        }

        /// <summary>
        /// Закрыть все сессии, кроме текущей
        /// </summary>
        /// <returns></returns>
        [HttpDelete("Close-All")]
        [Authorize]
        public ActionResult<bool> CloseAllSessions()
        {
            return CloseAllSessions(new Session(User.Identity.Name));
        }

    }
}
