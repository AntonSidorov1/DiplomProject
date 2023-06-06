using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    public class ConnectionDataBaseWithToken : ConnectionStringDataBase
    {

        string token = "";

        public string Token
        {
            get => token;
            set => token = value;
        }
    }
}
