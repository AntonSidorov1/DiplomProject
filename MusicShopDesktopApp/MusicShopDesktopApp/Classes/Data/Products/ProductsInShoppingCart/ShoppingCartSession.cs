using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Сессия для формирования заказа
    /// </summary>
    public class ShoppingCartSession
    {
        string orderToken = "";

        /// <summary>
        /// Токен для формирования заказа
        /// </summary>
        public string OrderToken
        {
            get => orderToken;
            set => orderToken = value;
        }

    }
}
