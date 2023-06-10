using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManegerJson
{
    public class StoreFile : ProductParameterFile<Store>
    {
        public StoreFile()
        {
        }

        public StoreFile(Store content) : base(content)
        {
        }

        public StoreFile(ProductParameterFile<Store> file) : base(file)
        {
        }

        public StoreFile(string name, bool file = true) : base(name, file)
        {
        }

        public StoreFile(string name, string fileName) : base(name, fileName)
        {
        }

        public StoreFile(string name, Store content) : base(name, content)
        {
        }

        public StoreFile(string name, string fileName, Store content) : base(name, fileName, content)
        {
        }

        public override string TypesFileJson => "Store Json (*.storej)|*.storej|Store File (*.storef)|*.storef";

        public override string TypesFileContent => "Store Content (*.storec)|*.storec|Store File (*.storef)|*.storef";

        public override string IndexClassName => "StoreFile";

        public override FileClass Copy()
        {
            return Create(this);
        }

        public override ProductParameterFile CreateNewFile() => new StoreFile();

        public override void SetParametersContent(Store content)
        {
            Content = content.CopyStore();
        }

        protected override void CreateContent(Store content)
        {
            Content = content.CopyStore();
        }

        protected override Store PutContent() => new Store();

        public override Bitmap BitmapView
        {
            get
            {
                
                return Properties.Resources.Store;
            }

        }

        public override string FileType => "Торговая точка с режимом работы";

        public override void SetContentFile(FileClass file)
        {
            if (file.IsProductParameter)
            {
                Content = file.AsProductParameter.ParameterStore;
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
                    Content = fileClass.AsProductParameter.ParameterStore;
                }
            }
        }

        public static StoreFile Load(string fileName)
        {

            try
            {
                StoreFile dataBase = ((StoreFile)JsonRead(fileName, typeof(StoreFile)));
                if (dataBase.Content == null || dataBase.Content is null)
                    throw new Exception();
                return dataBase;
            }
            catch
            {
                StoreFile dataBase = new StoreFile(fileName, false)
                {
                    Content = ((Store)JsonRead(fileName, typeof(Store)))
                };
                return dataBase;
            }
        }


    }
}
