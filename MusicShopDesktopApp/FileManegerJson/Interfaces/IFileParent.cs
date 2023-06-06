using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManegerJson
{
    public interface IFileParent<T> where T : AbstractFileClass
    {
        T Parent { get; }
        T Root { get; }
    }
}
