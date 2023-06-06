using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    /// <summary>
    /// Сессия для возможностьи авторизироваться
    /// </summary>
    public abstract class AbstracSignInSession
    {
        public AbstracSignInSession()
        {

        }

        public AbstracSignInSession(string token) : this()
        {
            Token = token;
        }

        /// <summary>
        /// Токен сессии
        /// </summary>
        protected abstract string Token { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Session Copy() => new Session(Token);

        public RegistrateSession CopyRegistrate() => new RegistrateSession(Token);
        public EnvirontmentSession CopyEnvirontment() => new EnvirontmentSession(Token);
    }
}
