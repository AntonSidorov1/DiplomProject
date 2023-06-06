using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace FileManegerJson
{
    [DataContract]
    public abstract class AbstractFile<T, K>: AbstractFileClass, IFileParent<K>, ITagInfoClass<T> where K: AbstractFileClass
        //, ITagInfoClass<T>
    {
        public AbstractFile() : base()
        {

        }

        public delegate void FileContentOutput(T file);

        public FileContentOutput NameFileOutput;

        public abstract K Parent { get; }

        public abstract K Root { get; }

        public abstract T TagProperty { get; set; }

        
    }
}
