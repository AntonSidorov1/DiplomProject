using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Телефон
    /// </summary>
    public class Telefon : Address
    {
        public TelefonSession CopySession(string token) => new TelefonSession(token) { Telefon = Value };

    }
}
