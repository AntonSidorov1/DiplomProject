using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    /// <summary>
    /// Сессия для входа в зарегистрированный аккаунт
    /// </summary>
    public class RegistrateEnvirontmentSession : RegistrateSession
    {
        public RegistrateEnvirontmentSession()
        {
        }

        public RegistrateEnvirontmentSession(string tokenRegistrate) : base(tokenRegistrate)
        {
        }

        string environtmentToken = "";

        /// <summary>
        /// Токен окружения
        /// </summary>
        public string EnvirontmentToken
        {
            get => environtmentToken;
            set => environtmentToken = value;
        }


    }
}
