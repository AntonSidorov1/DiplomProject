using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
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

        public override AccountWithAddress GetWithAddress()
        {
            AccountWithAddress account = new AccountWithAddress();
            account.ID = ID;
            account.Login = Login;
            account.Password = Password;
            account.FIO.Initials = FIO.Initials;
            account.Roles.AddRange(Roles);

            account.Telefons = TelefonsList.GetListFromDB(ID);
            account.Emails = EmailsList.GetListFromDB(ID);

            return account;
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

        /// <summary>
        /// Пользователь - Менеджер по заказам?
        /// </summary>
        /// <returns></returns>
        public bool IsOrdersManager() => Roles.Any(r => r.ID == 5 || r.ID == 3);

        /// <summary>
        /// Пользователь - Продавец?
        /// </summary>
        /// <returns></returns>
        public bool IsSalesMan() => Roles.Any(r => r.ID == 7 || r.ID == 3);

        /// <summary>
        /// Пользователь - Оператор?
        /// </summary>
        /// <returns></returns>
        public bool IsOperator() => Roles.Any(r => r.ID == 6 || r.ID == 3);

        /// <summary>
        /// Пользователь - Директор?
        /// </summary>
        /// <returns></returns>
        public bool IsDirector() => Roles.Any(r => r.ID == 2 || r.ID == 3);

        /// <summary>
        /// Может ли пользователь просматривать заказы
        /// </summary>
        /// <returns></returns>
        public bool IsShowOrdersUser() => IsOrdersManager() || IsOperator() || IsDirector();

        /// <summary>
        /// Пользователь - Менеджер по складу?
        /// </summary>
        /// <returns></returns>
        public bool IsStockManager() => Roles.Any(r => r.ID == 4 || r.ID == 3);

        /// <summary>
        /// Пользователь - Администратор?
        /// </summary>
        /// <returns></returns>
        public bool IsAdmin() => Roles.Any(r => r.ID == 3);

        public bool IsSalemanAndFewRoles()
        {
            bool result = IsClient() || IsOrdersManager() || IsOperator();
            return result && IsSalesMan();
        }

        public bool IsClientAndFewRoles()
        {
            bool result = IsOrderCreater();
            return result && IsClient();
        }

        public bool IsOrderCreater()
            => IsOperator() || IsSalesMan() || IsOrdersManager();

        public bool IsOrder() => IsOrderCreater() || IsClient();

        public bool IsOrderCanceler() => IsOrder();

        public bool IsOrderGive() => IsSalesMan() || IsOrdersManager();

        public bool IsOnlyRole() => Roles.Count == 1;

        public bool IsNoOnlyRole() => !IsOnlyRole();

        public bool IsGiveOredr() => IsSalesMan() || IsOrdersManager();
    }
}
