using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Тогровая площадь
    /// </summary>
    public class TradeArea : GeographyPoint
    {
        bool existence = false;

        /// <summary>
        /// Существует ли объект
        /// </summary>
        public bool Existence
        {
            get => existence;
            set => existence = value;
        }

        public void UpdateExience()
        {
            Existence = Name.Length > 0;
        }

        public void UpdateData(string name)
        {
            Name = name;
            UpdateExience();
        }

        public string GetName() => Existence ? Name : "";
    }
}
