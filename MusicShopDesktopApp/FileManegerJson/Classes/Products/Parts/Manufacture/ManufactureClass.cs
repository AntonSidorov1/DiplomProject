using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FileManegerJson
{
    /// <summary>
    /// Производитель товара
    /// </summary>
    [DataContract]
    public class ManufactureClass : ProductParameter
    {
        public ManufactureClass()
        {
        }

        public ManufactureClass(string name) : base(name)
        {
        }

        public ManufactureClass(ProductParameter parameter) : base(parameter)
        {
        }

        //public override void SetParameter(ProductParameter parameter)
        //{
        //    base.SetParameter(parameter);

        //}

        public static ManufactureClass LoadJsonFile(string jsonName)
        {
            ManufactureClass category = new ManufactureClass();
            category.LoadJson(jsonName);
            return category;
        }

    }
}
