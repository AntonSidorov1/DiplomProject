using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    public abstract class PartList<T> : List<T> where T : Part
    {
        public PartList()
        {
        }

        public PartList(int capacity) : base(capacity)
        {
        }

        public PartList(IEnumerable<T> collection) : base(collection)
        {
        }


        public int IndexOfByID(int id) => FindIndex(p => p.ID == id);

        public int IndexOfByID(Part part) => IndexOfByID(part.ID);


        public T GetByID(int id) => Find(p => p.ID == id);

        public T GetByID(Part part) => GetByID(part.ID);

        public T Get(int index) => this[index];
        public void Set(int index, T part) => this[index] = part;


        public bool ContainsID(Part part) => ContainsByID(part);
        public bool ContainsID(int id) => ContainsByID(id);
        public bool ContainsByID(int id) => GetAbstractThis().Any(p => p.ID == id);

        public bool ContainsByID(Part part) => ContainsByID(part.ID);


        public PartList<T> GetAbstractThis() => this;


        public List<T> AbstractList()
        {
            List<T> products = new List<T>();

            for (int i = 0; i < Count; i++)
            {
                products.Add(this[i]);
            }

            return products;
        }

        public abstract void SetAbstractList(IEnumerable<T> parts);

    }
}
