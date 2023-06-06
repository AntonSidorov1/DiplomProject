using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    public class OrderShoppingCart
    {
        ProductsInShoppingCartList products = new ProductsInShoppingCartList();

        public OrderShoppingCart()
        {
        }

        public OrderShoppingCart(ProductsInShoppingCartList products):this()
        {
            SetProducts(products);
        }

        public ProductsInShoppingCartList GetProducts()
        {
            return products;
        }

        public void SetProducts(ProductsInShoppingCartList value)
        {
            products = value;
        }

        public List<ProductInShoppingCart> ShoppingCarts => GetProducts().AbstractList();

        public OrderCart Info => GetProducts().GetOrderData();
    }
}
