using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Аутотификация для редактирования строки подключения к базе данных
    /// </summary>
    public class LoginForEditConnection
    {
        /// <summary>
        /// Получить пароль, по токену для редактирования строки подключения к базе данных
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Secret GetPassword( Session token)
        {
            if (CheckWorking(token))
                return DataBaseConfiguration.Password;
            throw new ArgumentNullException();
        }

        /// <summary>
        /// Закрыть сессию для редактирования строки подключения к базе данных
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool Close( Session token)
        {
            if(!CheckWorking(token))
            {
                return false;
            }
            DataBaseConfiguration.SessionsList.Remove(token.Token);
            return true;
        }

        /// <summary>
        /// Проверить можно ли с данным токеном редактировать строку подключения к базе данных (AllowEditConnection) и менять пароль для этого (working)
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public CheckToken Check(Session token)
        {
            CheckToken check = new CheckToken();
            check.Working = DataBaseConfiguration.SessionsList.Contains(token.Token, false);
            if(check.Working)
            {
                check.AllowEditConnection = DataBaseConfiguration.SessionsList.Get(token.Token).AllowEditConnection;
            }
            
            return check;
        }

        public bool CheckWorking(Session token) => Check(token).Working;

        public bool CheckAllowEditConnection(Session token) => CheckWorking(token) && Check(token).AllowEditConnection;

        /// <summary>
        /// Авторизироваться для редактирования строки подключения к базе данных
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Session Open(Secret value)
        {
            if(value.Password == DataBaseConfiguration.Password.Password)
            {
                string token = DataBaseConfiguration.SessionsList.Add(true).Session;
                return new Session(token);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Авторизироваться, используя токен администратора для работы с паролем для редактирования строки подключения
        /// </summary>
        /// <param name="session">Токен сессии</param>
        /// <returns></returns>
        public Session OpenByAdmin(Session session)
        {
            if(!SessionsController.GetController().CheckActive(session))
            {
                throw new ArgumentNullException();
            }
            try
            {
                if (UserRolesController.UserIsGoest(session))
                {
                    throw new ArgumentNullException();
                }

                UserRolesController userRoles = UserRolesController.GetController();
                RolesList roles = userRoles.GetRoles(session);
                if (!roles.Contains("admin"))
                {
                    throw new ArgumentNullException("Пользователь не админ");
                }

                string token = DataBaseConfiguration.SessionsList.Add(false).Session;
                return new Session(token);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Сменить пароль для редактирования строки подключения к базе данных
        /// </summary>
        /// <param name="secret"></param>
        /// <returns></returns>
        public bool ChangePassword(string token, Secret password)
        {
            if (!CheckWorking(new Session(token)))
                return false;
            DataBaseConfiguration.Password = password;
            return true;
        }

    }
}
