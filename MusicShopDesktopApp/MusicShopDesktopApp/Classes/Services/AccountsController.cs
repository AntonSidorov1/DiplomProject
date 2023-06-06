
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Контроллер для работы с аккаунтами
    /// </summary>
    
    public class AccountsController 
    {
        /// <summary>
        /// Получить данные аккаунта по токену сессии
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public AccountWithRoles GetAccount(Session session)
        {
            if (!SessionsController.GetController().CheckActive(session))
            {
                throw new ArgumentNullException("Сессия не активна или не существует");
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
                throw new Exception(e.Message, e);
            }
        }

        /// <summary>
        /// Зарегистрироваться (Добавить клиента), используя токен сессии гостя
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public RegistrateSession Registrate(Account account, Session goest)
        {
            Session session = new Session(goest.Token);
            if (!SessionsController.GetController().CheckActive(session))
            {
                throw new ArgumentNullException("Сессия не активна или не существует");
            }
            if(!UserRolesController.UserIsGoest(session))
            {
                throw new ArgumentNullException("Пользователь должен быть гостем");
            }

            string environtment = SessionsController.GetAndUpdateEnvirontmentSession(goest.Token).Token;

            environtment = SessionsController.GetEnvirontmentSessions().Find(s => s.Token == environtment).Session;

            string token = SessionsController
                .AddSessionToHistory(
                account.CopyWithEnvirontment(environtment));



            if(!AccountsList.GetDatasListFromDB(false).AddClientToDB(account))
            {
                SessionsController.UpdateTokenNoSuccessfully(token);
                throw new ArgumentException("Невозможно добавить пользователя");
            }

            SessionEdit sessionEdit = SessionsController.GetSessions().Find(s => s.Token == token);

            return sessionEdit.Copy().CopyRegistrate();
        }


        /// <summary>
        /// Поменять пароль
        /// </summary>
        /// <param name="secret"></param>
        /// <returns></returns>
        public bool ChangePassword(SecretSession secret)
        {
            if (!SessionsController.GetController().CheckActive(secret.GetSession()))
                return false;
            string login = GetAccount(new Session(secret.Token)).Login;
            return AccountsList.GetDatasListFromDB().ChangePassword(login, secret.Password);
        }

        /// <summary>
        /// Создать контроллер
        /// </summary>
        /// <returns></returns>
        public static AccountsController GetController() => new AccountsController();

        /// <summary>
        /// Изменить ФИО у пользователя
        /// </summary>
        /// <param name="initials"></param>
        /// <returns></returns>
        public bool SetFIO(InitialsSession initials)
        {
            Session session = initials.GetSession();
            if (!SessionsController.GetController().CheckActive(session))
            {
                return false;
            }
            try
            {
                if (UserRolesController.UserIsGoest(session))
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            int id = AccountsController.GetController().GetAccount(session).ID;

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
                catch (Exception e)
                {
                    connection.Close();
                    throw new Exception(e.Message, e);
                }
            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        /// Удалить номер телефона
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public bool DeleteUser(Session session)
        {
            if (!SessionsController.GetController().CheckActive(session))
                return false;
            if (UserRolesController.GetController().IsGoest(session))
                return false;
            try
            {
                int user = AccountsController.GetController().GetAccount(session).ID;
                return AccountsList.GetDatasList().DeleteFromDB(user);
            }
            catch
            {
                return false;
            }
        }

    }
}
