using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    /// <summary>
    /// Аккаунт с нобором ролей
    /// </summary>
    public class AccountWithRoles : AccountWithID
    {
        public override bool EqualsLogin(string login)
        {
            return base.EqualsLogin(login);
        }

        RolesList roles = new RolesList();

        /// <summary>
        /// Роли пользователя в системе
        /// </summary>
        public RolesList Roles
        {
            get => roles;
            set => roles = value;
        }

        FIO fio = new FIO();

        /// <summary>
        /// ФИО
        /// </summary>
        public FIO FIO
        {
            get => fio;
            set => fio = value;
        }

        /// <summary>
        /// Пользователь - Гость?
        /// </summary>
        /// <returns></returns>
        public bool IsGoest() => Roles.Any(r => r.ID == 0) || Roles.Count < 1;

        /// <summary>
        /// Пользователь - Клиент?
        /// </summary>
        /// <returns></returns>
        public bool IsClient() => Roles.Any(r => r.ID == 1);
    }
}
