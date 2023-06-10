using FileManegerJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    public class Manufacture : CategoryFilter
    {
        public Manufacture CopyManufacture()
            => new Manufacture
            {
                ID = this.ID,
                Name = this.Name
            };

        public ManufactureClass CopyEdit() => new ManufactureClass(Name);
    }
}
