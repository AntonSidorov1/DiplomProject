using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FileManegerJson
{
    /// <summary>
    /// Торговый пункт
    /// </summary>
    [DataContract]
    public class DistributingPoint : ProductParameter
    {
        public DistributingPoint()
        {
        }

        public DistributingPoint(string name) : base(name)
        {
        }

        public DistributingPoint(ProductParameter parameter) : base(parameter)
        {
        }

        public override void SetParameter(ProductParameter parameter)
        {
            base.SetParameter(parameter);
            if(parameter is DistributingPoint)
            {
                DistributingPoint point = (parameter as DistributingPoint);
                Address = point.Address;
                Telephone = point.Telephone;
                Email = point.Email;
            }
        }

        string address = "";

        /// <summary>
        /// Адрес
        /// </summary>
        [DataMember]
        public string Address
        {
            get => address;
            set => address = value;
        }

        string telephone = "";

        /// <summary>
        /// Телефон
        /// </summary>
        [DataMember]
        public string Telephone
        {
            get => telephone;
            set => telephone = value;
        }

        string email = "";

        /// <summary>
        /// E-mail
        /// </summary>
        [DataMember]
        public string Email
        {
            get => email;
            set => email = value;
        }

    }
}
