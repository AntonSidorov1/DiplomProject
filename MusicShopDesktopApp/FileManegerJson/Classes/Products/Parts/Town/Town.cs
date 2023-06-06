using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FileManegerJson
{
    /// <summary>
    /// Город
    /// </summary>
    [DataContract]
    public class Town : ProductParameter
    {
        public Town()
        {
        }

        public Town(string name) : base(name)
        {
        }

        public Town(ProductParameter parameter) : base(parameter)
        {
        }

        //public override void SetParameter(ProductParameter parameter)
        //{
        //    base.SetParameter(parameter);

        //}
    }
}
