using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FileManegerJson
{
    /// <summary>
    /// Заметка
    /// </summary>
    [DataContract]
    public class NoteClass : ProductParameter
    {
        public NoteClass()
        {
        }

        public NoteClass(string name) : base(name)
        {
        }

        public NoteClass(ProductParameter parameter) : base(parameter)
        {
        }



    }
}
