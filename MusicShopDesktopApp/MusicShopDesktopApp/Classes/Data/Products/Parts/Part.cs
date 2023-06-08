using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Параметр товара
    /// </summary>
    public class Part : PartValue
    {
        int id = 0;

        /// <summary>
        /// ID
        /// </summary>
        public int ID
        {
            get => id;
            set => id = value;
        }

        /// <summary>
        /// Создать копию объекта
        /// </summary>
        /// <returns></returns>
        public Part CopyPart() => new Part
        {
            ID = this.ID,
            Name = this.Name
        };


        public virtual bool EqualsNameInLower(string name)
        {
            string Login = Name;
            string login = name;
            if (Login == login)
                return true;
            if (StringNormalize.Normalize(Login, formatEnd: FormatEnd.None).ToLower() == StringNormalize.Normalize(login, formatEnd: FormatEnd.None).ToLower())
                return true;
            if (Login.ToLower() == login.ToLower())
                return true;
            if (StringNormalize.Normalize(Login, formatEnd: FormatEnd.None).ToLower() == login.ToLower())
                return true;
            if (Login.ToLower() == StringNormalize.Normalize(login, formatEnd: FormatEnd.None).ToLower())
                return true;

            if (StringNormalize.Normalize(Login, formatEnd: FormatEnd.None).ToLower() == StringNormalize.Normalize(login, snakeCase: false, formatEnd: FormatEnd.None).ToLower())
                return true;
            if (StringNormalize.Normalize(Login, snakeCase: false, formatEnd: FormatEnd.None).ToLower() == StringNormalize.Normalize(login, formatEnd: FormatEnd.None).ToLower())
                return true;
            if (Login.ToLower() == StringNormalize.Normalize(login, snakeCase: false, formatEnd: FormatEnd.None).ToLower())
                return true;
            if (StringNormalize.Normalize(Login, snakeCase: false, formatEnd: FormatEnd.None).ToLower() == login.ToLower())
                return true;
            if (StringNormalize.Normalize(Login, snakeCase: false, formatEnd: FormatEnd.None).ToLower() == StringNormalize.Normalize(login, snakeCase: false, formatEnd: FormatEnd.None).ToLower())
                return true;


            if (Login.ToLower() == StringNormalize.DropDefices(login).ToLower())
                return true;
            if (StringNormalize.DropDefices(Login).ToLower() == login.ToLower())
                return true;

            if (StringNormalize.Normalize(Login, formatEnd: FormatEnd.None).ToLower() == StringNormalize.DropDefices(login).ToLower())
                return true;
            if (StringNormalize.DropDefices(Login).ToLower() == StringNormalize.Normalize(login, formatEnd: FormatEnd.None).ToLower())
                return true;

            if (StringNormalize.DropDefices(Login).ToLower() == StringNormalize.Normalize(login, snakeCase: false, formatEnd: FormatEnd.None).ToLower())
                return true;
            if (StringNormalize.Normalize(Login, snakeCase: false, formatEnd: FormatEnd.None).ToLower() == StringNormalize.DropDefices(login).ToLower())
                return true;

            return false;
        }

    }
}
