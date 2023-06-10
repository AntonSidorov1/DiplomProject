using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManegerJson;

namespace MusicShopDesktopApp
{
    public class Supplier : CategoryFilter
    {
        public Supplier CopySupplier()
            => new Supplier
            {
                ID = this.ID,
                Name = this.Name
            };

        public SupplierClass CopyEdit() => new SupplierClass(Name);
    }
}
