using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManegerJson
{
    public class ManufactureFile : ProductParameterFile<ManufactureClass>
    {
        public ManufactureFile()
        {
        }

        public ManufactureFile(ProductParameter content) : base(content.CopyManufacture())
        {
        }

        public ManufactureFile(ProductParameterFile<ManufactureClass> file) : base(file)
        {
        }

        public ManufactureFile(string name, bool file = true) : base(name, file)
        {
        }

        public ManufactureFile(string name, string fileName) : base(name, fileName)
        {
        }

        public ManufactureFile(string name, ProductParameter content) : base(name, content.CopyManufacture())
        {
        }

        public ManufactureFile(string name, string fileName, ProductParameter content) : base(name, fileName, content.CopyManufacture())
        {
        }

        public override string TypesFileJson => "Fabricator Json (*.fabrj)|*.fabrj|Fabricator File (*.fabrf)|*.fabrf";

        public override string TypesFileContent => "Fabricator Content (*.fabrc)|*.fabrc|Fabricator File (*.fabrf)|*.fabrf";

        public override string IndexClassName => "ManufactureFile";

        public override FileClass Copy()
        {
            return Create(this);
        }

        public override ProductParameterFile CreateNewFile() => new ManufactureFile();

        public override void SetParametersContent(ManufactureClass content)
        {
            Content = content.CopyManufacture();
        }

        protected override void CreateContent(ManufactureClass content)
        {
            Content = content.CopyManufacture();
        }

        protected override ManufactureClass PutContent() => new ManufactureClass();

        public override Bitmap BitmapView
        {
            get
            {
                
                return Properties.Resources.Manufacure;
            }

        }

        public override string FileType => "Производитель товаров";

        public override void SetContentFile(FileClass file)
        {
            if (file.IsProductParameter)
            {
                Content = file.AsProductParameter.ParameterManufacture;
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
                    Content = fileClass.AsProductParameter.ParameterManufacture;
                }
            }
        }

        public static ManufactureFile Load(string fileName)
        {

            try
            {
                ManufactureFile dataBase = ((ManufactureFile)JsonRead(fileName, typeof(ManufactureFile)));
                if (dataBase.Content == null || dataBase.Content is null)
                    throw new Exception();
                return dataBase;
            }
            catch
            {
                ManufactureFile dataBase = new ManufactureFile(fileName, false);
                dataBase.LoadContentJsonWihReturn(fileName);
                return dataBase;
            }
        }


    }
}
