using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    /// <summary>
    /// Аккаунт с гостевым токеном
    /// </summary>
    public class AccountWithGoestToken : Account
    {
        string goestToken = "";

        /// <summary>
        /// Гостевой токен
        /// </summary>
        public string GoestToken
        {
            get => goestToken;
            set => goestToken = value;
        }
    }
}
