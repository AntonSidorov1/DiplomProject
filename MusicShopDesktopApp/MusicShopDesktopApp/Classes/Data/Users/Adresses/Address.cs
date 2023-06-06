using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Адрес
    /// </summary>
    public class Address : AddressValue
    {
        int id = 0;

        /// <summary>
        /// ID
        /// </summary>
        public int ID
        {
            get => id;
            set => id = value;
        }
    }
}
