using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    public class OrderSession : ShoppingCartSession
    {
        public OrderSession()
        {
        }



        string authorizeToken = "";

        /// <summary>
        /// Токен авторизации
        /// </summary>
        public string AuthorizeToken
        {
            get => authorizeToken;
            set => authorizeToken = value;
        }


        public Session CopySession() => new Session
        {
            Token = AuthorizeToken
        };
    }
}
