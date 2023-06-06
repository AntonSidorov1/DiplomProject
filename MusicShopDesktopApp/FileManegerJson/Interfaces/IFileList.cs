using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManegerJson
{
    public interface IFileList <T, K> : IList<T>, IFileParent<K> where T : AbstractFileClass where K : AbstractFileClass
    {
        
    }
}
