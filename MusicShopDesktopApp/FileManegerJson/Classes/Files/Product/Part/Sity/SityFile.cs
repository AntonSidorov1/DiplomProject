using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManegerJson
{
    public class SityFile : ProductParameterFile<Town>
    {
        public SityFile()
        {
        }

        public SityFile(Town content) : base(content)
        {
        }

        public SityFile(ProductParameterFile<Town> file) : base(file)
        {
        }

        public SityFile(string name, bool file = true) : base(name, file)
        {
        }

        public SityFile(string name, string fileName) : base(name, fileName)
        {
        }

        public SityFile(string name, Town content) : base(name, content)
        {
        }

        public SityFile(string name, string fileName, Town content) : base(name, fileName, content)
        {
        }

        public override string TypesFileJson => "Sity Files Json (*.sityj)|*.sityj|Sity Files (*.sityf)|*.sityf";

        public override string TypesFileContent => "Sity Files Content (*.sityc)|*.sityc|Sity Files (*.sityf)|*.sityf";

        public override string IndexClassName => "SityFile";

        public override FileClass Copy()
        {
            return Create(this);

        }

        public override ProductParameterFile CreateNewFile() => new SityFile();

        public override void SetParametersContent(Town content)
        {
            Content = content.CopySity();
        }

        protected override void CreateContent(Town content)
        {
            Content = content.CopySity();
        }

        protected override Town PutContent() => new Town();


        public static SityFile Load(string fileName)
        {

            try
            {
                SityFile dataBase = ((SityFile)JsonRead(fileName, typeof(SityFile)));
                if (dataBase.Content == null || dataBase.Content is null)
                    throw new Exception();
                return dataBase;
            }
            catch
            {
                SityFile dataBase = new SityFile(fileName, false)
                {
                    Content = ((Town)JsonRead(fileName, typeof(Town)))
                };
                return dataBase;
            }
        }

        public override Bitmap BitmapView => Properties.Resources.Sity;

        public override string FileType => "Город";

        public override void SetContentFile(FileClass file)
        {
            if (file.IsProductParameter)
            {
                Content = file.AsProductParameter.ParametrSity;
            }
        }

        public override void FromFile(AbstractFileClass file)
        {
            base.FromFile(file);
            if (file is FileClass)
            {
                FileClass fileClass = file as FileClass;
                if (fileClass.IsProductParameter)
                {
                    Content = fileClass.AsProductParameter.ParametrSity;
                }
            }
        }

    }
}
