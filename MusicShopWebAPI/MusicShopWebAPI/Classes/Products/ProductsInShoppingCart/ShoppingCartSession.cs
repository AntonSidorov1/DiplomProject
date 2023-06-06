using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopWebAPI
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

        public OrderSession CopyOrderSession(string authToken)
        {
            return new OrderSession
            {
                OrderToken = this.OrderToken,
                AuthorizeToken = authToken
            };
        }

        public OrderSession CopyOrderSession(Session authToken)
            => CopyOrderSession(authToken.Token);
    }
}
