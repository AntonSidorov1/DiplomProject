using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    /// <summary>
    /// Браузер
    /// </summary>
    public class Browser : Application
    {
        bool use = false;

        /// <summary>
        /// Используется
        /// </summary>
        public bool Use
        {
            get => use;
            set => use = value;
        }
    }
}
