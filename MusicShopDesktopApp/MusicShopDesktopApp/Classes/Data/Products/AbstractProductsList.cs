using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    public class AbstractProductsList<T> : PartList<T> where T:Product
    {
        int count = 0;

        public AbstractProductsList()
        {
        }

        public AbstractProductsList(IEnumerable<T> collection) : base(collection)
        {
        }

        public AbstractProductsList(int capacity) : base(capacity)
        {
        }

        public string CountInfo() => Count + " из " + count;

        public void SetCounts(IEnumerable<Product> products)
        {
            List<Product> result = new List<Product>(products);
            count = result.Count;
        }

        public void SetCounts() => SetCounts(ProductsList.GetListFromDB());


        public bool ContainsByArticul(string articul) => GetAbstractThis().Any(p => p.Articul.Trim() == articul.Trim());

        public bool ContainsByArticul(Product part) => ContainsByArticul(part.Articul);


        public int IndexOfByArticul(string articul) => FindIndex(p => p.Articul.Trim() == articul.Trim());

        public int IndexOfByArticul(Product part) => IndexOfByArticul(part.Articul);

        public T GetByArticul(string articul) => Find(p => p.Articul.Trim() == articul.Trim());

        public T GetByArticul(Product product) => GetByArticul(product.Articul);

        public virtual void SetList(List<Product> products)
        {
            
        }

        public void SetList(IEnumerable<Product> products)
        {
            SetList(new List<Product>(products));
        }


        public ProductsList GetProducts()
        {
            ProductsList products = new ProductsList();

            for (int i = 0; i < Count; i++)
            {
                products.Add(this[i].CopyProduct());
            }

            return products;
        }

        public override void SetAbstractList(IEnumerable<T> parts)
        {
            SetList(parts);
        }

        public void SetAbstractList(IEnumerable<Product> parts)
        {
            SetList(parts);
        }
    }
}
