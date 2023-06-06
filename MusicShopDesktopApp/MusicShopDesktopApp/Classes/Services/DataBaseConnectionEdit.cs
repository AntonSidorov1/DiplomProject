using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Строка подключения к базе данных
    /// </summary>
    public class DataBaseConnectionEdit
    {
        /// <summary>
        /// Получить строку подключения к базе данных
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public string Get(Session token)
        {
            if(!Contains(token))
            {
                throw new ArgumentNullException();
            }
            return GetConnectionString();
        }

        public bool AllowEdit(Session token) => GetLogin().CheckAllowEditConnection(token);

        public bool Contains(Session token) => GetLogin().CheckWorking(token);

        public static string GetConnectionString() => DataBaseConfiguration.ConnectionString;

        public LoginForEditConnection GetLogin() => new LoginForEditConnection();


        /// <summary>
        /// Получить отдельные параметры из строки подключения к базе данных
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public ConnectionStringDataBase GetParts(Session token)
        {

            if (!Contains(token))
            {
                throw new ArgumentNullException();
            }
            return ConnectionDataBase.GetConnection(Get(token)).Copy();
        }

        /// <summary>
        /// Изменить строку подключения к базе данных
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Change(ConnectionStringDataBase value, Session token)
        {
            if (!AllowEdit(token))
                return false;
            DataBaseConfiguration.ConnectionString = value.CopyWithFull().ConnectionString;
            return true;
        }

        /// <summary>
        /// Установить строку подключения к базе данных По-умолчанию
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public ConnectionStringDataBase Default(Session token)
        {
            if (!AllowEdit(token))
            {
                throw new ArgumentNullException();
            }
            DataBaseConfiguration.Clear();
            return DataBaseConfiguration.GetConnection();
        }

        /// <summary>
        /// Рабочая ли строка подключения к базе данных
        /// </summary>
        /// <returns></returns>
        public bool Check()
        {
            return DataBaseConfiguration.Check();
        }
    }
}
