using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FileManegerJson
{
    /// <summary>
    /// Поставщик товара
    /// </summary>
    [DataContract]
    public class SupplierClass : ProductParameter
    {
        public SupplierClass()
        {
        }

        public SupplierClass(string name) : base(name)
        {
        }

        public SupplierClass(ProductParameter parameter) : base(parameter)
        {
        }

        //public override void SetParameter(ProductParameter parameter)
        //{
        //    base.SetParameter(parameter);

        //}

        public static SupplierClass LoadJsonFile(string jsonName)
        {
            SupplierClass category = new SupplierClass();
            category.LoadJson(jsonName);
            return category;
        }

    }
}
