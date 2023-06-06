using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManegerJson
{
    public interface ITagStringControlView
    {
        string TagString { get; set; }
        object Tag { get; set; }

        string ToString();

        string Name { get; set; }
    }
}
