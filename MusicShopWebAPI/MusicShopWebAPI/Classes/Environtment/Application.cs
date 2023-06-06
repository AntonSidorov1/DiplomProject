using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    /// <summary>
    /// иложение</summary>
    public class Application : EnvirontmentObject
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
