using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    /// <summary>
    /// Аккаунт с токеном окружени
    /// </summary>
    public class AccountEnvirontment : Account
    {
        string environtmentToken = "";

        /// <summary>
        /// Токен окружения
        /// </summary>
        public string EnvirontmentToken
        {
            get => environtmentToken;
            set => environtmentToken = value;
        }

        public EnvirontmentSession GetEnvirontment() => new EnvirontmentSession(EnvirontmentToken);
    }
}
