using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    public class ProductQuantity
    {
        int id = 0;
        public int ID
        {
            get => id;
            set => id = value;
        }
        int quantity = 0;
        public int Quantity
        {
            get => quantity;
            set => quantity = value;
        }
    }
}
