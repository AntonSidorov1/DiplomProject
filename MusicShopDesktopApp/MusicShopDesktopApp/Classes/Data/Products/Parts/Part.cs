using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Параметр товара
    /// </summary>
    public class Part : PartValue
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

        /// <summary>
        /// Создать копию объекта
        /// </summary>
        /// <returns></returns>
        public Part CopyPart() => new Part
        {
            ID = this.ID,
            Name = this.Name
        };
    }
}
