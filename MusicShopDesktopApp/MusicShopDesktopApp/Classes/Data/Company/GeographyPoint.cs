using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    public abstract class GeographyPoint : Part
    {
        public void SetPoint(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public void SetPoint(Part part)
        {
            SetPoint(part.ID, part.Name);
        }
    }
}
