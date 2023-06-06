
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Threading;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Управление сессиями
    /// </summary>
    public class SessionsController
    {
        
        public static SessionEditList GetEnvirontmentSessions() => EnvirontmentTokenController.GetSessions();


        /// <summary>
        /// Получить список сессий
        /// </summary>
        /// <returns></returns>
        public static SessionEditList GetSessions(bool checkActive = false, int count = 20)
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
                if (checkActive)
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
                if (count > 20)
                {
                    Thread.Sleep(AddressesList.GetRandomMilliSeconds());
                    return GetSessions(checkActive, count - 1);
                }
                throw e;
            }
            return sessions;
        }

        public static SessionEdit GetSession() => GetSessions().Add();

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
        public Session SignIn(EnvirontmentSession session, Account account) => SignIn(account.CopyWithEnvirontment(session.EnvirontmentToken));

        /// <summary>
        /// Войти в систему (авторизироваться)
        /// </summary>
        public Session SignIn(AccountEnvirontment environtmentSession)
        {
            SessionEditList sessions = GetEnvirontmentSessions();

            if (!sessions.Contains(environtmentSession.EnvirontmentToken, false))
                throw new ArgumentException("Сессия не активна или несуществует");

            Session jwtSession = new Session();
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
                catch (Exception e)
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

                Session actionJwtSession = GetSession(account, token, environtmentSession.GetEnvirontment(), connection);
                connection.Close();
                return actionJwtSession;
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
                throw e;
            }

            return jwtSession;
        }

        public Session GetSession(AccountWithID account, SessionEdit token, EnvirontmentSession environtmentSession)
        {
            SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
            connection.Open();

            try
            {
                Session jwtSession = GetSession(account, token, environtmentSession, connection); 
                connection.Close();
                return jwtSession;
            }
            catch(Exception e)
            {
                connection.Close();
                throw new Exception(e.Message, e);
            }
        }

        public Session GetSession(AccountWithID account, SessionEdit token, EnvirontmentSession environtmentSession, SqlConnection connection)
        {
            Session jwtSession = new Session();
            string roles = account.GetUserWithRoles().Roles.GetRolesName();
            SessionEditList sessions = GetEnvirontmentSessions();
            SessionEdit session = sessions.Get(environtmentSession.EnvirontmentToken);

            AddSignIn(token, account, connection);
            UpdateEnvirontmentToken(session.Token, connection);

            jwtSession = GetSessions().Find(s => s.Token == token.Token).GetSession(); ;
            
            return jwtSession;
        }

        public static void AddSignIn(SessionEdit token, AccountWithID account, SqlConnection connection)
        {

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Insert Into [UserSignIn] " +
                "([LoginToken], [UserID]) " +
                $"Values ('{token.Token}', {account.ID})";
            command.ExecuteNonQuery();

        }

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
        public Session SignInByRegistrateToken(RegistrateEnvirontmentSession session)
        {
            if(!CheckActive(session.Copy()))
            {
                throw new ArgumentException("Сессия не активна или несуществует");
            }

            if(!GetEnvirontmentSessions().ContainsTokenAutotification(session.EnvirontmentToken))
            {
                throw new ArgumentException("Сессия не активна или несуществует");
            }

            try
            {
                EnvirontmentSession environtmentSession = GetEnvirontmentSession(session.Copy());
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

                throw e;
            }
        }

        /// <summary>
        /// Войти госем
        /// </summary>
        public Session LoginGoest(EnvirontmentSession environtmentSession)
        {
            SessionEditList sessions = GetEnvirontmentSessions();

            if (!sessions.Contains(environtmentSession.EnvirontmentToken, false))
                throw new ArgumentException("Сессия не активна или несуществует");

            Session jwtSession = new Session();
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

                jwtSession = GetSessions().Find(s => s.Token == token.Token).GetSession();
                
            }
            catch(Exception e)
            {
                connection.Close();
                throw e;
            }

            return jwtSession;
        }

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

        public EnvirontmentSession GetEnvirontmentSession(string token)
        {
            if(!GetSessions(true).ContainsTokenAutotification(token))
            {
                throw new ArgumentException("Сессия не активна или несуществует");
            }
            Session session = GetAndUpdateEnvirontmentSession(token);
            return GetEnvirontmentSessions().Find(s => s.Token == session.Token).Copy();
        }

        public EnvirontmentSession GetEnvirontmentSession(Session token)
        {
            return GetEnvirontmentSession(token.Token);
        }


        /// <summary>
        /// Закрытие сессии (выход из системы)
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public EnvirontmentSession SignOut(Session session)
        {
            EnvirontmentSession environtment = new EnvirontmentSession();

            SessionEditList sessions = GetSessions(true);
            if (!sessions.Contains(session.Token, false))
            {
                throw new ArgumentException("Сессия не активна или несуществует");
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
                throw e;
            }


            return GetEnvirontmentSessions().Find(s => s.Token == environtment.EnvirontmentToken).Copy();
        }

        /// <summary>
        /// Закрытие сессии (выход из системы)
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public bool CloseSession(Session session)
        {
            try
            {
                SessionEditList sessions = GetSessions(true);
                if (!sessions.Contains(session.Token, false))
                {
                    return false;
                }
                return SessionClose(session);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Можно ли пользоваться данным токеном сессии
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public bool CheckActive(Session session)
        {
            bool check = GetSessions(true).ContainsTokenAutotification(session.Token);
            return check;
        }

        /// <summary>
        /// Получить контроллер
        /// </summary>
        /// <returns></returns>
        public static SessionsController GetController() => new SessionsController();

        /// <summary>
        /// Пользователь активен и не гость
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public bool CheckActiveAndNoGoest(Session session)
        {
            if (!CheckActive(session))
                return false;
            if (UserRolesController.GetController().IsGoest(session))
                return false;
            return true;
        }

        /// <summary>
        /// Получить историю входов пользователя с заданной сессией
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public SessionsWithEnvirontmentList Get(Session session)
        {
            if (!CheckActive(session))
            {
                throw new UserException("Вы больше не авторизированы в системе", 401);
            }
            if (UserRolesController.GetController().IsGoest(session))
            {
                throw new UserException("Вы больше не авторизированы в системе", 401);
            }
            try
            {
                Account account = AccountsController.GetController().GetAccount(session);
                return SessionsWithEnvirontmentList.GetListFromDB(account, session);
            }
            catch
            {
                throw new UserException("Вы больше не авторизированы в системе", 404);
            }
        }


        /// <summary>
        /// Закрытие сессии (выход из системы)
        /// </summary>
        /// <param name="session"></param>
        /// <param name="count"></param>
        /// <returns></returns>
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
        public bool CloseAllSessions(Session session)
        {
            try
            {
                List<SessionWithEnvirontment> sessions = Get(session);
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
                return false;
            }
        }

    }
}
