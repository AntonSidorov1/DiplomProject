using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    public abstract class GeorafyPointList<T> : AbstractCategoriesList<T> where T : GeographyPoint
    {
        public GeorafyPointList()
        {
        }

        public GeorafyPointList(int capacity) : base(capacity)
        {
        }

        public GeorafyPointList(IEnumerable<T> collection) : base(collection)
        {
        }

        public abstract T Get();


        public override void AddPart(int id, string name)
        {
            T part = Get();
            part.SetPoint(id, name);
            Add(part);
        }

        public override T GetByName(string articul) => GetAbstractThis().FirstOrDefault(p => p.Name.Trim() == articul.Trim());

        public override bool ContainsByName(string articul) => GetAbstractThis().Any(p => p.Name.Trim() == articul.Trim());

        public override int IndexByName(string articul) => GetAbstractThis().FindIndex(p => p.Name.Trim() == articul.Trim());


    }
}
