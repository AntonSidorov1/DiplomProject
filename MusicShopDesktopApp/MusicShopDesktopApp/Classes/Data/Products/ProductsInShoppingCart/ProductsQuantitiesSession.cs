using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    public class ProductsQuantitiesSession
    {
        public ProductsQuantitiesSession()
        {
            Products = new ProductQuantity[1];
        }

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

        public ShoppingCartSession CopySession()
        {
            return new ShoppingCartSession
            {
                OrderToken = this.OrderToken
            };
        }

        public OrderSession CopyOrderSession(Session authToken)
            => CopyOrderSession(authToken.Token);

        ProductQuantity[] products;

        public ProductQuantity[] Products
        {
            get => products;
            set => products = value;
        }
    }
}
