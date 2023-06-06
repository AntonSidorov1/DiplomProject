using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    /// <summary>
    /// Склад
    /// </summary>
    public class Stock : Pounkt
    {
        Sity sity = new Sity();

        /// <summary>
        /// Город
        /// </summary>
        public Sity Sity
        {
            get => sity;
            set => sity = value;
        }

        /// <summary>
        /// Установить город из базы данных, по его идентификатору
        /// </summary>
        /// <param name="id"></param>
        public void SetSityByID(int id)
        {
            SetSityByID(id, SitiesList.GetListFromDB());
        }

        public void SetSityByID(int id, SitiesList sities)
        {
            if (sities.ContainsByID(id))
                Sity = sities.GetByID(id).CopySity();
        }

        public void SetSityByID(SitiesList sities)
        {
            SetSityByID(SityID, sities);
        }

        /// <summary>
        /// ID города
        /// </summary>
        public int SityID
        {
            get => Sity.ID;
            set => Sity.ID = value;
        }

        /// <summary>
        /// Установить город из базы данных, по идентификатору SityID
        /// </summary>
        public void SetSityByID()
        {
            SetSityByID(SityID);
        }

        /// <summary>
        /// Вывести данные склада
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ID == 0 ? Name : (base.ToString() + "\n" +
                $"Город - {Sity.Name} \n");
        }


        /// <summary>
        /// Создать копию объекта
        /// </summary>
        /// <returns></returns>
        public Stock CopyStock() => new Stock
        {
            ID = this.ID,
            Name = this.Name,
            Contact = this.Contact.CopyContact(),
            Address = this.Address,
            Sity = this.Sity.CopySity()
        };

        public override string AddressData => Sity.Name + ", " + Address;
    }
}
