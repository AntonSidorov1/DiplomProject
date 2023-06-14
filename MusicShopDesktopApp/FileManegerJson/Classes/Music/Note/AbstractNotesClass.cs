using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FileManegerJson
{
    [DataContract]
    public abstract class AbstractNotesClass
    {
        public AbstractNotesClass()
        {
        }

        public abstract string GetName();
        public abstract void SetName(string name);

        public NoteInGammaClass CopyNoteInGamma() => new NoteInGammaClass(GetName());

        public AbstractNotesClass GetLoadJson(string fileName) => (AbstractNotesClass)FileClass.JsonRead(fileName, GetType());
    }
}
