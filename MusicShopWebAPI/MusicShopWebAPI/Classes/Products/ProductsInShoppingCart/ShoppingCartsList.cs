using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    public class ShoppingCartsList : List<ProductsInShoppingCartList>
    {
        public ShoppingCartsList()
        {
        }

        public ShoppingCartsList(IEnumerable<ProductsInShoppingCartList> collection) : base(collection)
        {
        }

        public ShoppingCartsList(int capacity) : base(capacity)
        {
        }

        public ShoppingCartsList GetThis() => this;

        public bool ContainsOrderToken(string token) => GetThis().Any(p => p.OrderSession.OrderToken == token);

        public bool ContainsToken(string token) => GetThis().Any(p => p.Session.Token == token);

        public bool ContainsOrderToken(ShoppingCartSession token) => ContainsOrderToken(token.OrderToken);

        public bool ContainsToken(Session token) => ContainsToken(token.Token);

        public ShoppingCartSession Add(Session session)
        {
            if(ContainsToken(session.Token))
            {
                return Get(session).OrderSession;
            }
            string token = "";
            while(token == "" || ContainsOrderToken(token))
            {
                SessionEdit sessionEdit = new SessionEdit();
                token = sessionEdit.Session;
            }
            ProductsInShoppingCartList products = new ProductsInShoppingCartList
            {
                OrderSession = new ShoppingCartSession
                {
                    OrderToken = token
                },
                Session = new Session(session.Token)
                
            };
            Add(products);
            return products.OrderSession;
        }

        public ProductsInShoppingCartList Get(ShoppingCartSession session)
            => Find(p => p.OrderSession.OrderToken == session.OrderToken);

        public ProductsInShoppingCartList Get(Session session)
            => Find(p => p.Session.Token == session.Token);
    }
}
