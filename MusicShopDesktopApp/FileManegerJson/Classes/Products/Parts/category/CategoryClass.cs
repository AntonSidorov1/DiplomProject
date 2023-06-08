using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FileManegerJson
{
    /// <summary>
    /// Категория
    /// </summary>
    [DataContract]
    public class CategoryClass : ProductParameter
    {
        public CategoryClass()
        {
        }

        public CategoryClass(string name) : base(name)
        {
        }

        public CategoryClass(ProductParameter parameter) : base(parameter)
        {
        }

        public override void SetParameter(ProductParameter parameter)
        {
            base.SetParameter(parameter);
            if(parameter is CategoryClass)
            {
                Filter = (parameter as CategoryClass).Filter;
            }

        }

        string filter = "";

        /// <summary>
        /// Применяемый фильтр к катгории
        /// </summary>
        [DataMember]
        public string Filter
        {
            get => filter;
            set => filter = value;
        }

        public static CategoryClass LoadJsonFile(string jsonName)
        {
            CategoryClass category = new CategoryClass();
            category.LoadJson(jsonName);
            return category;
        }

    }
}
