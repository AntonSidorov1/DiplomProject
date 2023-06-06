using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    

    /// <summary>
    /// Аккаунт
    /// </summary>
    public class Account
    {
        string login = "";

        /// <summary>
        /// Логин
        /// </summary>
        public string Login
        {
            get => login;
            set => login = value;
        }

        string password = "";

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password
        {
            get => password;
            set => password = value;
        }

        public Account Copy() => new Account {Login = this.Login, Password = this.Password };

        public bool EqualsLogin(Account account)
            => EqualsLogin(account.Login);

        public bool NoEqualsLogin(Account account)
            => NoEqualsLogin(account.Login);

        public bool NoEqualsLogin(string login)
            => !EqualsLogin(login);

        public virtual bool EqualsLogin(string login)
        {
            if (this.Login == login)
                return true;
            if (StringNormalize.Normalize(this.Login, formatEnd: FormatEnd.None) == StringNormalize.Normalize(login, formatEnd: FormatEnd.None))
                return true;
            if (this.Login.ToLower() == login.ToLower())
                return true;
            if (StringNormalize.Normalize(this.Login, formatEnd: FormatEnd.None) == login.ToLower())
                return true;
            if (this.Login.ToLower() == StringNormalize.Normalize(login, formatEnd: FormatEnd.None))
                return true;

            if (StringNormalize.Normalize(this.Login, formatEnd: FormatEnd.None) == StringNormalize.Normalize(login, snakeCase: false, formatEnd: FormatEnd.None))
                return true;
            if (StringNormalize.Normalize(Login, snakeCase: false, formatEnd: FormatEnd.None) == StringNormalize.Normalize(login, formatEnd: FormatEnd.None))
                return true;
            if (Login.ToLower() == StringNormalize.Normalize(login, snakeCase: false, formatEnd: FormatEnd.None))
                return true;
            if (StringNormalize.Normalize(Login, snakeCase: false, formatEnd: FormatEnd.None) == login.ToLower())
                return true;
            if (StringNormalize.Normalize(Login, snakeCase: false, formatEnd: FormatEnd.None) == StringNormalize.Normalize(login, snakeCase: false, formatEnd: FormatEnd.None))
                return true;
            return false;
        }


        public static bool operator ==(Account user, string login) => user.Equals(login);

        public static bool operator !=(Account user, string login) => !user.Equals(login);

        public AccountEnvirontment CopyWithEnvirontment(string environtmentToken)
        {
            return new AccountEnvirontment {Login = this.Login, Password = this.Password, EnvirontmentToken = environtmentToken };
        }

        public AccountWithGoestToken CopyWithGosetToken(string goestToken)
        {
            return new AccountWithGoestToken { Login = this.Login, Password = this.Password, GoestToken = goestToken };
        }

    }
}
