using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    public class CheckToken
    {
        bool working = false;
        public bool Working
        {
            get => working;
            set => working = value;
        }

        bool allowEditConnection = false;
        public bool AllowEditConnection
        {
            get => allowEditConnection;
            set => allowEditConnection = value;
        }

        public CheckToken()
        {

        }

        public CheckToken(bool working):this()
        {
            Working = working;
        }
    }
}
