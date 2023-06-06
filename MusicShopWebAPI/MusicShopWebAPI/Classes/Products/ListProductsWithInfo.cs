using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    public class ListProductsWithInfo<T> where T:Product
    {
        public ListProductsWithInfo()
        {

        }

        public ListProductsWithInfo(AbstractProductsList<T> products)
        {
            Products = products;
        }


        AbstractProductsList<T> products = new AbstractProductsList<T>();

        /// <summary>
        /// Список товаров
        /// </summary>
        public AbstractProductsList<T> Products
        {
            get => products;
            set
            {
                products = value;
                products.SetCounts();
            }
        }

        /// <summary>
        /// Количество товаров
        /// </summary>
        public string Count => Products.CountInfo();
    }
}
