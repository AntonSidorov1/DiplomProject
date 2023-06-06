using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    public class OrganizationValue : Pounkt
    {
        string site = "";

        /// <summary>
        /// Сайт
        /// </summary>
        public string Site
        {
            get => site;
            set => site = value;
        }



        /// <summary>
        /// Создать копию объекта
        /// </summary>
        /// <returns></returns>
        public OrganizationValue CopyValue() => new OrganizationValue
        {
            ID = this.ID,
            Name = this.Name,
            Contact = this.Contact.CopyContact(),
            Address = this.Address,
            Site = this.Site
        };


        public override string ToString()
        {
            return base.ToString() +
                $"Сайт {(Site != "" ? "- " + Site : "отсутствует")}";
        }


        public Organization GetOrganization(OrganizationsList organizations)
        {
            return organizations.GetByID(ID);
        }
    }
}
