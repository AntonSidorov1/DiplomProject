using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FileManegerJson
{
    /// <summary>
    /// Заметка в виде целого числа
    /// </summary>
    [DataContract]
    public class IntNoteFile : NameFile
    {
        public IntNoteFile()
        {
        }

        public IntNoteFile(string name, bool file = true) : base(name, file)
        {
        }

        public IntNoteFile(string name, string fileName) : base(name, fileName)
        {
        }

        public override string FileType => "Заметка в виде целого числа";

        public override string TypesFileJson => "Int Note Json (*.intnj)|*.intnj|" + FewFileType;

        public string FewFileType => "Int Note File (*.intn)|*.intn|Int Note File (*.intnf)|*.intnf";

        public override string TypesFileContent => "Int Note Content (*.intnc)|*.intnc|" + FewFileType;

        public override string IndexClassName => "IntNoteFile";

        public override FileClass Copy()
        {
            return Create(this);
        }

        public override void SetContentFile(FileClass file)
        {
            if(file.IsIntNote)
            {
                Content = file.AsIntValue.Content.Copy();
            }
        }

        IntNote content = new IntNote();

        [DataMember]
        public IntNote Content
        {
            get => content;
            set => content = value;
        }


        public override void FromFile(AbstractFileClass file)
        {
            base.FromFile(file);
            if (file is FileClass)
            {
                FileClass fileClass = file as FileClass;
                if (fileClass.IsIntNote)
                {
                    Content = fileClass.AsIntNote.Content.Copy();
                }
            }
        }

        public void SetContent(IntNote content) => Content = content.Copy();

        protected void CreateContent(IntNote content) => Content = content.Copy();

        public static IntNoteFile Load(string fileName)
        {

            try
            {
                IntNoteFile dataBase = ((IntNoteFile)JsonRead(fileName, typeof(IntNoteFile)));
                if (dataBase.Content == null || dataBase.Content is null)
                    throw new Exception();
                int number = dataBase.Content.Value;
                number += 1;
                return dataBase;
            }
            catch
            {
                return LoadContent(fileName);
            }
        }

        public static IntNoteFile LoadContent(string fileName)
        {
            IntNoteFile dataBase = new IntNoteFile(fileName, false)
            {
                Content = IntNote.CreateFromJson(fileName)
            };
            return dataBase;
        }

        public override Bitmap BitmapView => Properties.Resources.NoteInt;
    }
}
