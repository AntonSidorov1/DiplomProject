using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Инициалы пользователя с его токеном
    /// </summary>
    public class InitialsSession : Initials
    {
        string token = "";

        /// <summary>
        /// Токен
        /// </summary>
        public string Token
        {
            get => token;
            set => token = value;
        }

        public Session GetSession() => new Session(Token);
    }
}
