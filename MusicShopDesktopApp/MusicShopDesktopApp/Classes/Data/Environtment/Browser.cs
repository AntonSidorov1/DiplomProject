using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Браузер
    /// </summary>
    public class Browser : ApplicationProgram
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
