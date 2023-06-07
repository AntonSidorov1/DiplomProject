using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FileManegerJson
{
    [DataContract]
    public class Store : DistributingPoint
    {
        public Store()
        {
        }

        public Store(string name) : base(name)
        {
        }

        public Store(ProductParameter parameter) : base(parameter)
        {
        }

        public override void SetParameter(ProductParameter parameter)
        {
            base.SetParameter(parameter);
            if(parameter is Store)
            {
                Store store = parameter as Store;
                SitePath = store.SitePath;
                Schedule = store.Schedule;
                Shop = store.Shop;
                PounktOfIssue = store.PounktOfIssue;
            }
        }

        string sitePath = "";

        /// <summary>
        /// Путь на сайте
        /// </summary>
        [DataMember]
        public string SitePath
        {
            get => sitePath;
            set => sitePath = value;
        }

        string schedule = "";

        /// <summary>
        /// Режим работы
        /// </summary>
        [DataMember]
        public string Schedule
        {
            get => schedule;
            set => schedule = value;
        }

        string shop = "";

        /// <summary>
        /// Магазин
        /// </summary>
        [DataMember]
        public string Shop
        {
            get => shop;
            set => shop = value;
        }

        string pounktOfIssue = "";

        /// <summary>
        /// Пункт выдачи
        /// </summary>
        [DataMember]
        public string PounktOfIssue
        {
            get => pounktOfIssue;
            set => pounktOfIssue = value;
        }

        /// <summary>
        /// Пункт выдачи
        /// </summary>
        public string PickupPoint
        {
            get => PounktOfIssue;
            set => PounktOfIssue = value;
        }
    }
}
