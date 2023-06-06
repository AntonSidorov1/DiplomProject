using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    public class ProductWithCount : Product
    {
        int quantity = 0;

        public virtual string QuantityText => quantity.ToString();
        

        /// <summary>
        /// Количество
        /// </summary>
        public virtual int Quantity
        {
            get => quantity;
            set => quantity = value;
        }

        public override ProductWithCount CopyProductWithCount()
        {
            ProductWithCount product = base.CopyProductWithCount();
            product.Quantity = Quantity;
            return product;
        }

        public override ProductInShoppingCart CopyProductInShoppingCart()
        {
            ProductInShoppingCart product = base.CopyProductInShoppingCart();
            product.Quantity = Quantity;
            return product;
        }

        public override ProductInPounkt CopyProductInPounkt(PounktType pounktType = PounktType.Shop)
        {
            ProductInPounkt product = base.CopyProductInPounkt(pounktType);
            product.Quantity = Quantity;
            return product;
        }

        public override Product CopyProduct()
        {
            return CopyProductWithCount();
        }


        public override string GetNameInfo()
        {
            return base.GetNameInfo() + "\n" +
                QuantityText;
        }

    }
}
