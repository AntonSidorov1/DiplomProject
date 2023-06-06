using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicShopWebAPI
{
    /// <summary>
    /// Токен окружения для последующей авторизации
    /// </summary>
    [AppRoute("[controller]")]
    [ApiController]
    public class EnvirontmentTokenController : ControllerBase
    {
        /// <summary>
        /// Получить список сессий
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public static SessionEditList GetSessions()
        {
            try
            {
                UpdateSessions();
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
                command.CommandText = "Select [EnvirontmentToken], [DateOpen] From [Environtment]";
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while(reader.Read())
                    {
                        SessionEdit session = new SessionEdit();
                        session.Token = reader.GetString(0);
                        session.Date = reader.GetDateTime(1);
                        sessions.Add(session);
                    }
                    reader.Close();
                }
                catch(Exception e)
                {
                    reader.Close();
                    throw e;
                }

                connection.Close();
            }
            catch(Exception e)
            {
                connection.Close();
                throw e;
            }
            return sessions;
        }


        /// <summary>
        /// Получить токен окружения для последующей авторизации
        /// </summary>
        /// <returns></returns>
        [HttpPost("Open")]
        public ActionResult<EnvirontmentSession> Get([FromBody] Environtment environment)
        {
            SessionEdit session = GetSessions().Add();
            
            try
            {
                UpdateSessions();
            }
            catch
            {

            }

            SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Insert Into [Environtment] " +
                    "([EnvirontmentToken], [OperationSystem], [DeviceName], [ProgramName], [ProgramVersion], [BrowserUse])" +
                    $" Values ('{session.Token}', @system, @device, @program, @programVersion, @browser)";
                SqlParameterCollection parameters = command.Parameters;
                parameters.Clear();
                parameters.AddWithValue("@system", environment.Device.OperationSystem);
                parameters.AddWithValue("@device", environment.Device.Name);
                parameters.AddWithValue("@program", environment.Application.Name);
                parameters.AddWithValue("@programVersion", environment.Application.Version);
                parameters.AddWithValue("@browser", environment.Browser.Use);

                command.ExecuteNonQuery();

                if(environment.Browser.Use)
                {
                    command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "Update [Environtment] " +
                        "Set [BrowserName]=@browser, [BrowserVersion]=@browserVersion" +
                        $" where [EnvirontmentToken]='{session.Token}'";
                    parameters = command.Parameters;
                    parameters.Clear();
                    parameters.AddWithValue("@browserVersion", environment.Browser.Version);
                    parameters.AddWithValue("@browser", environment.Browser.Name);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                return StatusCode(500);
            }

            session = GetSessions().Find(s => s.Token == session.Token);

            return session.GetSession().Copy();
        }

        [NonAction]
        public static void UpdateSessions()
        {
            SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Update [Environtment] Set [DateOpen] = [DateOpen]";
                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                throw new Exception(e.Message, e);
            }
        }

        /// <summary>
        /// Получить параметры окружения по его токену
        /// </summary>
        /// <param name="session1"></param>
        /// <returns></returns>
        [HttpPut("Get-Parameters")]
        public ActionResult<Environtment> Get([FromBody] EnvirontmentSession session1)
        {
            return Get(session1, 20);
        }

        /// <summary>
        /// Получить параметры окружения по его токену
        /// </summary>
        /// <param name="session1"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [NonAction]
        public ActionResult<Environtment> Get(EnvirontmentSession session1, int count)
        {
            Session session = session1.Copy();
            SessionEditList sessions = GetSessions();
            SessionEdit sessionEdit = new SessionEdit();
            if (!sessions.Contains(session.Token, false))
            {
                return Unauthorized("null");
            }
            else
            {
                sessionEdit = sessions.Get(session.Token);
            }

            Environtment environtment = new Environtment();

            SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
            connection.Open();

            try
            {
                SqlCommand command = new SqlCommand { Connection = connection };
                command.CommandText = $"Select * From [Environtment] where [EnvirontmentToken]='{sessionEdit.Token}'";
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    reader.Read();

                    environtment.Application.Name = reader.GetString(reader.GetOrdinal("ProgramName"));
                    environtment.Application.Version = reader.GetString(reader.GetOrdinal("ProgramVersion"));

                    environtment.Device.Name = reader.GetString(reader.GetOrdinal("DeviceName"));
                    environtment.Device.OperationSystem = reader.GetString(reader.GetOrdinal("OperationSystem"));

                    environtment.Browser.Use = reader.GetBoolean(reader.GetOrdinal("BrowserUse"));
                    if(environtment.Browser.Use)
                    {
                        environtment.Browser.Name = reader.GetString(reader.GetOrdinal("BrowserName"));
                        environtment.Browser.Version = reader.GetString(reader.GetOrdinal("BrowserVersion"));
                    }

                    reader.Close();
                }
                catch(Exception e)
                {
                    reader.Close();
                    throw new Exception(e.Message, e);
                }

                connection.Close();
            }
            catch
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
                    return Get(session1, count - 1);
                }
                return StatusCode(500);
            }

            return environtment;
        }

        /// <summary>
        /// Закрыть токен окружения (Делает невозможным авторизироваться)
        /// </summary>
        /// <param name="session1"></param>
        [HttpPut("Close")]
        public ActionResult<bool> Close([FromBody] EnvirontmentSession session1)
        {
            Session session = session1.Copy();
            SessionEditList sessions = GetSessions();
            SessionEdit sessionEdit = new SessionEdit();
            if (!sessions.Contains(session.Token, false))
            {
                return Unauthorized(false);
            }
            else
            {
                sessionEdit = sessions.Get(session.Token);
            }

            SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
            connection.Open();

            try
            {
                SqlCommand command = new SqlCommand { Connection = connection };
                command.CommandText = $"Delete From [Environtment] where [EnvirontmentToken] ='{sessionEdit.Token}'";
                command.ExecuteNonQuery();

                connection.Close();
            }
            catch
            {
                connection.Close();
                return StatusCode(500, false);
            }
            return true;
        }

        /// <summary>
        /// Получить токен окружения по токену гостя, для возможности авторизации с логином и паролем
        /// </summary>
        [HttpPut("By-Goest")]
        public ActionResult<EnvirontmentSession> Get(Session session)
        {
            if (!SessionsController.GetController().CheckActive(session))
                return Unauthorized("Null");
            
            if(!UserRolesController.UserIsGoest(session))
            {
                return BadRequest("Null");
            }
            return SessionsController.GetController().GetEnvirontmentSession(session);
        }

        [NonAction]
        public static string GetEnvirontmantByToken(string session, bool checkActive = true)
        {
            try
            {
                SessionsController.GetAndUpdateEnvirontmentSession(session);
            }
            catch
            {

            }

            EnvirontmentSession environtment = new EnvirontmentSession();

            SessionEditList sessions = SessionsController.GetSessions(checkActive);

            SessionEdit token = sessions.Get(session);

            SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
            connection.Open();

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"Select [EnvirontmentToken] From [LoginHistory] where LoginToken='{token.Token}'";
                environtment.EnvirontmentToken = Convert.ToString(command.ExecuteScalar());

                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                throw new Exception(e.Message, e);
            }


            return SessionsController.GetEnvirontmentSessions().Find(s => s.Token == environtment.EnvirontmentToken).Copy().EnvirontmentToken;

        }

        /// <summary>
        /// Получить токен окружения по JWT-токену гостя, для возможности авторизации с логином и паролем
        /// </summary>
        [HttpGet("By-Goest")]
        [Authorize(Roles ="Goest")]
        public ActionResult<EnvirontmentSession> Get()
        {
            return Get(new Session(User.Identity.Name));
        }

        [NonAction]
        public static EnvirontmentTokenController GetController() => new EnvirontmentTokenController();
    }
}
