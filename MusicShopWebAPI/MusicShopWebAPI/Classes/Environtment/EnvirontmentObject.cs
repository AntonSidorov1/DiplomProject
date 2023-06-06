using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    /// <summary>
    /// Объект окружени
    /// </summary>
    public class EnvirontmentObject
    {
        string name = "";

        /// <summary>
        /// Имя
        /// </summary>
        public string Name
        {
            get => name;
            set => name = value;
        }
    }
}
