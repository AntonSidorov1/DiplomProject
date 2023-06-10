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
    /// Файл заметок
    /// </summary>
    [DataContract]
    public class NoteFile : ProductParameterFile<NoteClass>
    {
        public NoteFile()
        {
        }

        public NoteFile(string name, bool file = true) : base(name, file)
        {
        }

        public NoteFile(string name, string fileName) : base(name, fileName)
        {
        }

        public override string TypesFileContent => "Note Content (*.notec)|*.notec|Note File (*.notef)|*.notef";

        public override string TypesFileJson => "Note json (*.notej)|*.notej|Note File (*.notef)|*.notef";

        public override string IndexClassName => "NoteFile";

        public override FileClass Copy()
        {
            NoteFile image = this;
            NoteFile file = image;
            NoteFile result = new NoteFile
            {
                TemporaryIndex = this.TemporaryIndex,
                Name = Name,
                Content = Content.CopyNote(),

                CopyFile = image,
                DateCreateText = file.DateCreateText,
                IndexFileName = file.IndexFileName
            };
            result.SetFile(this);
            return result;
        }

        public override ProductParameterFile CreateNewFile() => new NoteFile();

        public override void SetContentFile(FileClass file)
        {
            if(file.IsProductParameter)
            {
                Content = file.AsProductParameter.ParametrNote;
            }
        }

        public override void SetParametersContent(NoteClass content) => Content = content.CopyNote();

        protected override void CreateContent(NoteClass content) => Content = content.CopyNote();

        protected override NoteClass PutContent() => new NoteClass();

        public override Bitmap BitmapView => Properties.Resources.Note;

        public override string FileType => "Заметка";

        public override void FromFile(AbstractFileClass file)
        {
            base.FromFile(file);
            if (file is FileClass)
            {
                FileClass fileClass = file as FileClass;
                if (fileClass.IsProductParameter)
                {
                    Content = fileClass.AsProductParameter.ParametrNote;
                }
            }
        }

        public static NoteFile Load(string fileName)
        {

            try
            {
                NoteFile dataBase = ((NoteFile)JsonRead(fileName, typeof(NoteFile))).AsNote;
                if (dataBase.Content == null || dataBase.Content is null)
                    throw new Exception();
                return dataBase;
            }
            catch
            {
                NoteFile dataBase = new NoteFile(fileName, false)
                {
                    Content = ((NoteClass)JsonRead(fileName, typeof(NoteClass)))
                };
                return dataBase;
            }
        }

    }
}
