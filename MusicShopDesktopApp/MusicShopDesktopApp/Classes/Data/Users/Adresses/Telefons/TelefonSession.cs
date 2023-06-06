using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Сессия с номером телефона
    /// </summary>
    public class TelefonSession : Session
    {
        string telefon = "";

        public TelefonSession()
        {
        }

        public TelefonSession(string token) : base(token)
        {
        }

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string Telefon
        {
            get => telefon;
            set => telefon = value;
        }

        /// <summary>
        /// Получить телефон
        /// </summary>
        /// <returns></returns>
        public Telefon CopyTelefon() => new Telefon() { Value = Telefon };
    }
}
