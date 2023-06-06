using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    /// <summary>
    /// Организация
    /// </summary>
    public class Organization : OrganizationValue
    {
        

        string logotip = "";

        /// <summary>
        /// Логотип
        /// </summary>
        public string Logotip
        {
            get => logotip;
            set => logotip = value;
        }

        /// <summary>
        /// Установить логотип
        /// </summary>
        /// <param name="photo"></param>
        public void SetLogotip(byte[] photo)
        {
            Logotip = Convert.ToBase64String(photo);
        }

    }
}
