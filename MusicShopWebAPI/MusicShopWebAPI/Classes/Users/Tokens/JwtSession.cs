using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    /// <summary>
    /// Сессия с JWT-Токеном
    /// </summary>
    public class JwtSession : Session
    {
        string jwtToken = "";

        /// <summary>
        /// Jwt-токен
        /// </summary>
        public string JwtToken
        {
            get => jwtToken;
            set => jwtToken = value;
        }

    }
}
