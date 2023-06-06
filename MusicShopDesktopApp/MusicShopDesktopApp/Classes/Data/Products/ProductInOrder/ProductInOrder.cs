using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    public class ProductInOrder : ProductWithCount
    {
        public ProductInOrder() : base()
        {
        }


        public override string QuantityText => "Количество в заказе - "+Quantity;
    }
}
