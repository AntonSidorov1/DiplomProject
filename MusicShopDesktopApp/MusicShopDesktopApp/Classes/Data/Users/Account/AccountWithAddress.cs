using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Аккаунт с телефонами и адресами электронной почты
    /// </summary>
    public class AccountWithAddress : AccountWithRoles
    {
        TelefonsList telefons = new TelefonsList();

        /// <summary>
        /// Список телефонов у пользователя
        /// </summary>
        public TelefonsList Telefons
        {
            get => telefons;
            set => telefons = value;
        }

        EmailsList emails = new EmailsList();

        /// <summary>
        /// Список электронных почт у пользователя
        /// </summary>
        public EmailsList Emails
        {
            get => emails;
            set => emails = value;
        }

        public string GetAdresses()
        {
            string adresses = "Телефоны: \n";
            for(int i = 0; i <Telefons.Count; i++)
            {
                adresses += $"{i + 1}) {Telefons[i].Value} \n";
            }
            adresses += "\n";

            adresses += "Email-адреса: \n";
            for (int i = 0; i < Emails.Count; i++)
            {
                adresses += $"{i + 1}) {Emails[i].Value} \n";
            }
            adresses += "\n";

            return adresses;
        }
    }
}
