using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// E-mail
    /// </summary>
    public class Email : Address
    {
        public EmailSession CopySession(string token) => new EmailSession(token) { Email = Value };
    }
}
