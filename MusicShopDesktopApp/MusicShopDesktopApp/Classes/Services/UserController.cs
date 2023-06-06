using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    class UserController
    {

        Func<Account, bool> checkAccount;

        /// <summary>
        /// Проверка аккаунты
        /// </summary>
        public Func<Account, bool> CheckAccount
        {
            get => checkAccount;
            set => checkAccount = value;
        }

    }
}
