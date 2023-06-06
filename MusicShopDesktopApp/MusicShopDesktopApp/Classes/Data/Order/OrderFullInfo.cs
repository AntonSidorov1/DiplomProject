using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    public class OrderFullInfo
    {
        public OrderFullInfo()
        {
        }

        public OrderFullInfo(OrderWithStatus order):this()
        {
            Order = order;
            GetProducts();
        }

        OrderWithStatus order = new OrderWithStatus();

        /// <summary>
        /// Заказ
        /// </summary>
        public OrderWithStatus Order
        {
            get => order;
            set => order = value;
        }

        ProductsInOrderList products = new ProductsInOrderList();

        /// <summary>
        /// Список товаров в заказе
        /// </summary>
        public ProductsInOrderList Products
        {
            get => products;
            set => products = value;
        }

        public void GetProducts()
        {
            Products = ProductsInOrderList.GetListFromDB(Order.ID);
        }
    }
}
