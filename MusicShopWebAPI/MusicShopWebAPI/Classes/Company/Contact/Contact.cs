using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    /// <summary>
    /// Контактные данные
    /// </summary>
    public class Contact
    {

        string telephone = "";

        /// <summary>
        /// Телефон
        /// </summary>
        public string Telephone
        {
            get => telephone;
            set => telephone = value;
        }

        string email = "";

        /// <summary>
        /// Email-адрес
        /// </summary>
        public string Email
        {
            get => email;
            set => email = value;
        }

        /// <summary>
        /// Получить полностью контактые данные
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Телефон - " + (Telephone != "" ? $"{Telephone} " : "Нет!") + "\n" +
                 $"Email - " + (Email != "" ? $"{Email}" : "Нет!"); ;
        }


        /// <summary>
        /// Создать копию объекта
        /// </summary>
        /// <returns></returns>
        public Contact CopyContact() => new Contact
        {
            Telephone = this.Telephone,
            Email = this.Email
        };
    }
}
