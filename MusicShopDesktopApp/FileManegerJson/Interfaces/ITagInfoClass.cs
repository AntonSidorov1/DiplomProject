using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManegerJson
{
    public interface ITagInfoClass<T>
    {
        object Tag { get; set; }
        object TagObject { get; set; }
        string TagString { get; set; }
        int TagInt { get; set; }
        T TagProperty { get; set; }

         ref object RefTagObject { get;  }
        ref string RefTagString { get; }
        ref int RefTagInt { get;  }

    }
}
