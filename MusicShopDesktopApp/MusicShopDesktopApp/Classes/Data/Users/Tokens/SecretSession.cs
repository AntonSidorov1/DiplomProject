using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    public class SecretSession : Secret
    {
        string token = "";

        public string Token
        {
            get => token;
            set => token = value;
        }

        public Session GetSession() => new Session(Token);
    }
}
