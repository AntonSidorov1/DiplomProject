
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{

    /// <summary>
    /// Роли пользователя в системе
    /// </summary>
    public class UserRolesController
    {
        public bool IsGoest(Session session) => UserIsGoest(session);
        /// <summary>
        /// Получить контроллер
        /// </summary>
        /// <returns></returns>
        public static UserRolesController GetController() => new UserRolesController();

        /// <summary>
        /// Получить список ролей у пользователя с заданной сессией
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public RolesList GetRoles(Session session)
        {
            if(!SessionsController.GetController().CheckActive(session))
            {
                throw new ArgumentException("Сессия не активна или несуществует");
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
                throw e;
            }

            return roles;
        }


        /// <summary>
        /// Пользователь - Гость
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public static bool UserIsGoest(Session session)
        {
            if (!SessionsController.GetController().CheckActive(session))
                return false;
            RolesList roles = UserRolesController.GetController().GetRoles(session);
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
