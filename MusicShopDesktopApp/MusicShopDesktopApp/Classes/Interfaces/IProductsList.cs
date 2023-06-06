using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    interface IProductsList<T> : IList<T> where T : Product
    {
    }
}
