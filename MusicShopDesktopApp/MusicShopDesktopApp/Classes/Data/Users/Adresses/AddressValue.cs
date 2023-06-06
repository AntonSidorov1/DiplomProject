using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Адрес
    /// </summary>
    public class AddressValue
    {

        string valueText = "";

        /// <summary>
        /// Значение адреса
        /// </summary>
        public string Value
        {
            get => valueText;
            set => valueText = value;
        }


        public override string ToString()
        {
            return Value;
        }
    }
}
