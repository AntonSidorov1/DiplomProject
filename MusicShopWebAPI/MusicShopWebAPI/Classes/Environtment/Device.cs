using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    /// <summary>
    /// Устройство
    /// </summary>
    public class Device : EnvirontmentObject
    {
        string operationSystem = "";

        /// <summary>
        /// Операционная система
        /// </summary>
        public string OperationSystem
        {
            get => operationSystem;
            set => operationSystem = value;
        }

    }
}
