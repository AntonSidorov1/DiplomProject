using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Сессия с Email-адресом
    /// </summary>
    public class EmailSession : Session
    {
        string email = "";

        public EmailSession()
        {
        }

        public EmailSession(string token) : base(token)
        {
        }

        /// <summary>
        /// Email-адрес
        /// </summary>
        public string Email
        {
            get => email;
            set => email = value;
        }

        /// <summary>
        /// Получить телефон
        /// </summary>
        /// <returns></returns>
        public Email CopyEmail() => new Email() { Value = Email };
    }
}
