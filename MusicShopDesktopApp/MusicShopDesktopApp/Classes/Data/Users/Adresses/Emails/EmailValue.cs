using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Email-адрес
    /// </summary>
    public class EmailValue
    {
        string email = "";

        /// <summary>
        /// Email-адрес
        /// </summary>
        public string Email
        {
            get => email;
            set => email = value;
        }

        public Email CopyEmail() => new Email { Value = Email };

        public EmailSession CopySession(string token) => CopyEmail().CopySession(token);
    }
}
