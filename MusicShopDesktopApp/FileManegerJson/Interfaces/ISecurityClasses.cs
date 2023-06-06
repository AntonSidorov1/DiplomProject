using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManegerJson
{
    public interface ISecurityClasses<T>
    {
        bool Security { get; set; }
        T PropertyOfSecurity { get; set; }


        string TypesFileJson { get; }
        string TypesFileJsonWithTxt { get; }


        string TypesFileContent { get; }
        string TypesFileContentWithTxt { get; }

        string AllTypesFile { get; }
    }
}
