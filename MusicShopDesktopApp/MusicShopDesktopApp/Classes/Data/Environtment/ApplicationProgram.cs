using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Приложение
    /// </summary>
    public class ApplicationProgram : EnvirontmentObject
    {
        string version = "";

        /// <summary>
        /// Версия
        /// </summary>
        public string Version
        {
            get => version;
            set => version = value;
        }
    }
}
