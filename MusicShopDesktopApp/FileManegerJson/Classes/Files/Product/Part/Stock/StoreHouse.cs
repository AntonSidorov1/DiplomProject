using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FileManegerJson
{
    [DataContract]
    class StoreHouse : DisributingFacilities
    {
        public StoreHouse()
        {
        }

        public StoreHouse(string name) : base(name)
        {
        }

        public StoreHouse(ProductParameter parameter) : base(parameter)
        {
        }

        public override void SetParameter(ProductParameter parameter)
        {
            base.SetParameter(parameter);
            if(parameter is StoreHouse)
            {
                Sity = (parameter as StoreHouse).Sity;
            }

        }

        Town sity = new Town();

        /// <summary>
        /// Город
        /// </summary>
        public Town Town
        {
            get => sity;
            set => sity = value;
        }

        /// <summary>
        /// Город
        /// </summary>
        [DataMember]
        public string Sity
        {
            get => Town.Name;
            set => Town.Name = value;
        }
    }
}
