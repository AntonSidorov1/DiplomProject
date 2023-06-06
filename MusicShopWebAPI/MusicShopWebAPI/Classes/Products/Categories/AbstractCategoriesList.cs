using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    public abstract class AbstractCategoriesList<T> : PartList<T> where T:Part
    {
        public AbstractCategoriesList()
        {
        }

        public AbstractCategoriesList(int capacity) : base(capacity)
        {
        }

        public AbstractCategoriesList(IEnumerable<T> collection) : base(collection)
        {
        }

        public abstract T GetByName(string articul);

        public T GetByName(Part part) => GetByName(part.Name);

        public abstract bool ContainsByName(string articul);

        public bool ContainsByName(Part part) => ContainsByName(part.Name);

        public abstract int IndexByName(string articul);

        public int IndexByName(Part part) => IndexByName(part.Name);

        public abstract void AddPart(int id, string name);

        public virtual void AddPart(Part part)
        {
            AddPart(part.ID, part.Name);
        }

        public void SetList(IEnumerable<Part> parts)
        {

            Clear();
            AddPartsRange(parts);
        }

        public void AddPartsRange(IEnumerable<Part> parts)
        {
            List<Part> list = new List<Part>(parts);
            for (int i = 0; i < list.Count; i++)
            {
                AddPart(list[i]);
            }
        }

        public override void SetAbstractList(IEnumerable<T> parts)
        {
            SetList(parts);
        }
    }
}
