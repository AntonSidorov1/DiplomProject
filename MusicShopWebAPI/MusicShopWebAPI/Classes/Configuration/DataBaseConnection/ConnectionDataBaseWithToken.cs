using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopWebAPI
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
