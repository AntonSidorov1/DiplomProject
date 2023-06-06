using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    public class PartValue
    {
        string name = "";

        /// <summary>
        /// Название
        /// </summary>
        public string Name
        {
            get => name;
            set => name = value;
        }

    }
}
