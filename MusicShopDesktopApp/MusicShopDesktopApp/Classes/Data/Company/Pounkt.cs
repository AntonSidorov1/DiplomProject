using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Торговый пункт
    /// </summary>
    public class Pounkt : GeographyPoint
    {
        string address = "";

        /// <summary>
        /// Адрес
        /// </summary>
        public string Address
        {
            get => address;
            set => address = value;
        }

        Contact contact = new Contact();

        /// <summary>
        /// Контактные данные
        /// </summary>
        public Contact Contact
        {
            get => contact;
            set => contact = value;
        }

        /// <summary>
        /// Получить данные
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Название - {Name} \n" +
                $"Адрес - {Address} \n\n" +
                $"Контактные данные: \n" +
                $"{Contact} \n";
        }

        /// <summary>
        /// Данные
        /// </summary>
        public string Data
        {
            get => ToString();
        }


        /// <summary>
        /// Создать копию объекта
        /// </summary>
        /// <returns></returns>
        public Pounkt CopyPounkt() => new Pounkt
        {
            ID = this.ID,
            Name = this.Name,
            Contact = this.Contact.CopyContact(),
            Address = this.Address
        };


        public virtual string RegistrateData
        {
            get
            {
                string data = $"Название - «{Name}» \n" +
                    $"Адрес - «{AddressData}»";

                return data;
            }
        }

        public virtual bool Saving() => Name.Length > 0 && Address.Length > 0;

        public virtual string AddressData => Address;

        public string ItemData => $"«{Name}», «{AddressData}»";
    }
}
