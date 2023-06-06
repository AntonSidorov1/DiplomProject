using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Токен окружения
    /// </summary>
    public class EnvirontmentSession : AbstracSignInSession
    {
        string environtmentToken = "";

        public EnvirontmentSession()
        {
        }

        public EnvirontmentSession(string token) : base(token)
        {
        }

        /// <summary>
        /// Токен окружения
        /// </summary>
        public string EnvirontmentToken
        {
            get => environtmentToken;
            set => environtmentToken = value;
        }

        /// <summary>
        /// Токен сессии
        /// </summary>
        protected override string Token { get => EnvirontmentToken; set => EnvirontmentToken = value; }

    }
}
