using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopWebAPI
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
            return ID > 0 ? $"Название - {Name} \n" +
                $"Адрес - {Address} \n\n" +
                $"Контактные данные: \n" +
                $"{Contact} \n" : Name;
        }

        /// <summary>
        /// Данные
        /// </summary>
        public string Data
        {
            get => ID != 0 ? ToString() : Name;
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

                return ID != 0? data : Name;
            }
        }

        public virtual string AddressData => Address;


        public string ItemData => ID > 0 ? $"«{Name}», «{AddressData}»" : Name;

    }
}
