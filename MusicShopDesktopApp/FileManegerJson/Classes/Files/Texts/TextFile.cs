using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileManegerJson
{
    [DataContract]
    public class TextFile : NameFile
    {
        public TextFile() : base()
        {

        }

        public TextFile(string name, bool file = true) : base(name, file)
        {
        }

        public TextFile(string name, string fileName) : base(name, fileName)
        {
        }



        public override string TypesFileJson => "Text-json (*.txtJs)|*.txtJs|Text-json (*.stxtJs)|*.stxtJs";

        public override string TypesFileContent => "Text-File(*.txt)|*.txt|Stxt-File (*.stxt)|*.stxt";

        public override string IndexClassName => "TextFile";

        public override FileClass Copy()
        {
            TextFile image = this;
            TextFile file = image;
            TextFile result = new TextFile
            {
                TemporaryIndex = this.TemporaryIndex,
                Name = Name,
                Text = Text,

                CopyFile = image,
                DateCreateText = file.DateCreateText,
                IndexFileName = file.IndexFileName
            };
            result.SetFile(this);
            return result;
        }

        public override void FromFile(AbstractFileClass file)
        {
            base.FromFile(file);
            if (file is FileClass)
            {
                FileClass fileClass = file as FileClass;
                if (fileClass.IsText)
                {
                    Text = fileClass.AsText.Text;
                }
            }
        }

        protected override void GetProperty(FileClass file)
        {
            base.GetProperty(file);
            Text = file.AsText.Text;
        }

        string textValue = "";

        [DataMember]
        public string Text
        {
            get => textValue;
            set => textValue = value;
        }


        public EditTextByFile EditText
        {
            get => new EditTextByFile(Text);
            set => Text = value.Text;
        }

        public override Bitmap BitmapView => Properties.Resources.NotePad;


        public static TextFile Load(string fileName)
        {

            try
            {
                return ((TextFile)JsonRead(fileName, typeof(TextFile))).AsText;
            }
            catch
            {
                return new TextFile(fileName, false)
                {
                    Text = System.IO.File.ReadAllText(fileName)
                };
            }
        }

        public override void SetContentFile(FileClass file)
        {
            
        }
    }
}
