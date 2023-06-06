using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FileManegerJson
{
    [DataContract]
    public abstract class NameFile : FileClass
    {
        protected NameFile()
        {
        }

        protected NameFile(string name, bool file = true) : base(name, file)
        {
        }

        protected NameFile(string name, string fileName) : base(name, fileName)
        {
        }

        [DataMember]
        public new string Name
        {
            get => base.Name;
            set => base.Name = value;
        }


        protected override void GetProperty(FileClass file)
        {
            base.GetProperty(file);
            Name = file.AsName.Name;
        }


    }
}
