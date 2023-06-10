using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManegerJson
{
    public class SupplierFile : ProductParameterFile<SupplierClass>
    {
        public SupplierFile()
        {
        }

        public SupplierFile(ProductParameter content) : base(content.CopySupplier())
        {
        }

        public SupplierFile(ProductParameterFile<SupplierClass> file) : base(file)
        {
        }

        public SupplierFile(string name, bool file = true) : base(name, file)
        {
        }

        public SupplierFile(string name, string fileName) : base(name, fileName)
        {
        }

        public SupplierFile(string name, ProductParameter content) : base(name, content.CopySupplier())
        {
        }

        public SupplierFile(string name, string fileName, ProductParameter content) : base(name, fileName, content.CopySupplier())
        {
        }

        public override string TypesFileJson => "Supplier Json (*.suplj)|*.suplj|Supplier File (*.suplf)|*.suplf";

        public override string TypesFileContent => "Supplier Content (*.suplc)|*.suplc|Supplier File (*.suplf)|*.suplf";

        public override string IndexClassName => "SupplierFile";

        public override FileClass Copy()
        {
            return Create(this);
        }

        public override ProductParameterFile CreateNewFile() => new SupplierFile();

        public override void SetParametersContent(SupplierClass content)
        {
            Content = content.CopySupplier();
        }

        protected override void CreateContent(SupplierClass content)
        {
            Content = content.CopySupplier();
        }

        protected override SupplierClass PutContent() => new SupplierClass();

        public override Bitmap BitmapView
        {
            get
            {
                
                return Properties.Resources.Supplier;
            }

        }

        public override string FileType => "Поставщик товаров";

        public override void SetContentFile(FileClass file)
        {
            if (file.IsProductParameter)
            {
                Content = file.AsProductParameter.ParameterSupplier;
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
                    Content = fileClass.AsProductParameter.ParameterSupplier;
                }
            }
        }

        public static SupplierFile Load(string fileName)
        {

            try
            {
                SupplierFile dataBase = ((SupplierFile)JsonRead(fileName, typeof(SupplierFile)));
                if (dataBase.Content == null || dataBase.Content is null)
                    throw new Exception();
                return dataBase;
            }
            catch
            {
                SupplierFile dataBase = new SupplierFile(fileName, false);
                dataBase.LoadContentJsonWihReturn(fileName);
                return dataBase;
            }
        }


    }
}
