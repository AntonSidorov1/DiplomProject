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
    public abstract class SecurityFile<T, K> : AbstractFile<T, K>, ITagInfoSecurity<T> where K : AbstractFileClass
    {
        public SecurityFile():base()
        {

        }

        protected bool security = false;

        [DataMember]
        public virtual bool Security
        {
            get => security;
            set => security = value;
        }
        public T PropertyOfSecurity { get => TagProperty; set => TagProperty = value; }

        public abstract string TypesFileJson { get; }


        public string TypesJsonTXT => "|Json (.json)|*.json|Txt (*.txt)|*.txt|STXT (*.stxt)|*.stxt|Atxt-Files(*.atxt)|*.atxt|All Files (*.*)|*.*";
        public string TypesFileJsonWithTxt => TypesFileJson + TypesJsonTXT;

        public abstract string TypesFileContent { get; }

        public string TypesFileContentWithTxt => TypesFileContent + TypesJsonTXT;


        public virtual string AllTypesFile
        {
            get
            {
                string types = TypesFileContent;
                bool have = types != "" && types != null && !(types is null);
                bool have1 = false;
                if (have)
                    have1 = types.Remove(0, types.Length - 1) == "|";
                if (!have)
                    return TypesFileJsonWithTxt;
                else
                {
                    if (!have1)
                    {
                        return TypesFileContent + "|" + TypesFileJsonWithTxt;
                    }
                    else
                    {
                        return TypesFileContent + TypesFileJsonWithTxt;
                    }
                }

            }
        }


    }
}
