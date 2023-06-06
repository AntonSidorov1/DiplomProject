using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Сессия регистрации пользователя
    /// </summary>
    public class RegistrateSession : AbstracSignInSession
    {
        string registrateToken = "";

        public RegistrateSession()
        {
        }

        public RegistrateSession(string token) : base(token)
        {
        }

        /// <summary>
        /// Токен окружения
        /// </summary>
        public string RegistrateToken
        {
            get => registrateToken;
            set => registrateToken = value;
        }

        /// <summary>
        /// Токен сессии
        /// </summary>
        protected override string Token { get => RegistrateToken; set => RegistrateToken = value; }
    }
}
