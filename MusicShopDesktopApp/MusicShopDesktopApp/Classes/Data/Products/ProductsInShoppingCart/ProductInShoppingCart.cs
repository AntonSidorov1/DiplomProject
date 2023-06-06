using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    public class ProductInShoppingCart : ProductWithCount
    {
        AbstractProductsList<ProductInShoppingCart> products = new ProductsInShoppingCartList();

        public ProductInShoppingCart()
        {
        }

        public ProductInShoppingCart(AbstractProductsList<ProductInShoppingCart> products)
        {
            SetProducts(products);
        }

        public AbstractProductsList<ProductInShoppingCart> GetProducts()
        {
            return products;
        }

        public void SetProducts(AbstractProductsList<ProductInShoppingCart> value)
        {
            products = value;
        }

        public int Index
        {
            get
            {
                try
                {
                    return GetProducts().IndexOfByID(this);
                }
                catch
                {
                    return -1;
                }
            }
        }

        public bool Have
        {
            get
            {
                try
                {
                    return GetProductsCheck().ContainsByID(this);
                }
                catch
                {
                    return false;
                }
            }
        }

        public override int Quantity { get => base.Quantity;
            set
            {
                base.Quantity = value;
                NullIndexChange();
            }
        }

        public void NullIndexChange()
        {
            if(Quantity < 1)
            {
                SetNullChange?.Invoke(Index);
            }
        }

        public delegate void DoIndex(int index);
        public DoIndex SetNullChange;

        ProductsList productsCheck = new ProductsList();

        public override string GetData()
        {
            return base.GetData() + "\n" +
                 QuantityText + "\n"+
                 QuaontityInfo;
        }

        public override string QuantityText => "Колличество в заказе - " + Quantity + "\n" +
            QuaontityInfo;

        public ProductsList GetProductsCheck()
        {
            return productsCheck;
        }

        public string QuaontityInfo
        {
            get
            {
                try
                {
                    if (!Have)
                        return "Нет в наличии";
                    Product product = GetProductsCheck().GetByID(this);
                    if (!product.IsWithCounkt())
                        return "Нет в наличии";
                    else
                        return Quantity + " из "+ product.AsWithCounkt().Quantity;
                }
                catch
                {
                    return "Нет в наличии";
                }
            }
        }

        public void SetProductsCheck(ProductsList value)
        {
            productsCheck = value;
        }

        public bool Mayby
        {
            get
            {
                try
                {
                    if (!Have)
                        return false;
                    Product product = GetProductsCheck().GetByID(this);
                    if (!product.IsWithCounkt())
                        return false;
                    else
                        return Quantity <= product.AsWithCounkt().Quantity;
                }
                catch
                {
                    return false;
                }
            }
        }

        public override string GetNameInfo()
        {
            return base.GetNameInfo() + "\n" +
                QuaontityInfo;
        }

        public override ProductWithCount CopyProductWithCount()
        {
            return CopyProductInShoppingCart();
        }


        public override ProductInShoppingCart CopyProductInShoppingCart()
        {
            ProductInShoppingCart product = base.CopyProductInShoppingCart();
            return product;
        }

        public override Product CopyProduct()
        {
            return CopyProductInShoppingCart();
        }

        public double CoestWithOutDiscount => Math.Round(PriceWithOutDiscount * Quantity, 2);
        public double CoestWithDiscount => Math.Round(PriceWithDiscount * Quantity, 2);
    }
}
