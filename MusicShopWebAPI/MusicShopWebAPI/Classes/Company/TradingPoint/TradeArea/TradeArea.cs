﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopWebAPI
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
    }
}
