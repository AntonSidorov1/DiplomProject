using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    /// <summary>
    /// Телефон
    /// </summary>
    public class TelefonValue
    {
        string telefon = "";

        /// <summary>
        /// Номер телефоны
        /// </summary>
        public string Telefon
        {
            get => telefon;
            set => telefon = value;
        }

        public Telefon CopyTelefon() => new Telefon { Value = Telefon };

        public TelefonSession CopySession(string token) => CopyTelefon().CopySession(token);
    }
}
