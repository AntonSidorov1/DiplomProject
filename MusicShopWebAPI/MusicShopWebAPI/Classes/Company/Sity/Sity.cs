using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    /// <summary>
    /// Город
    /// </summary>
    public class Sity : GeographyPoint
    {
        /// <summary>
        /// Получить данные
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ID == 0 ? Name : ("Название - " + Name);
        }

        /// <summary>
        /// Данные
        /// </summary>
        public string Data => ToString();


        /// <summary>
        /// Создать копию объекта
        /// </summary>
        /// <returns></returns>
        public Sity CopySity() => new Sity
        {
            ID = this.ID,
            Name = this.Name
        };

    }
}
