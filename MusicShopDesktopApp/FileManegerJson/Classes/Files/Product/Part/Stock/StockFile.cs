using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManegerJson
{
    public class StockFile : ProductParameterFile<StoreHouse>
    {
        public StockFile()
        {
        }

        public StockFile(StoreHouse content) : base(content)
        {
        }

        public StockFile(ProductParameterFile<StoreHouse> file) : base(file)
        {
        }

        public StockFile(string name, bool file = true) : base(name, file)
        {
        }

        public StockFile(string name, string fileName) : base(name, fileName)
        {
        }

        public StockFile(string name, StoreHouse content) : base(name, content)
        {
        }

        public StockFile(string name, string fileName, StoreHouse content) : base(name, fileName, content)
        {
        }

        public override string TypesFileJson => "Stock Json (*.stockj)|*.stockj|Stock File (*.stockf)|*.stockf";

        public override string TypesFileContent => "Stock Content (*.stockc)|*.stockc|Stock File (*.stockf)|*.stockf";

        public override string IndexClassName => "StockFile";

        public override FileClass Copy()
        {
            return Create(this);
        }

        public override ProductParameterFile CreateNewFile() => new StockFile();

        public override void SetParametersContent(StoreHouse content)
        {
            Content = content.CopyStock();
        }

        protected override void CreateContent(StoreHouse content)
        {
            Content = content.CopyStock();
        }

        protected override StoreHouse PutContent() => new StoreHouse();

        public override Bitmap BitmapView
        {
            get
            {
                
                return Properties.Resources.Stock;
            }

        }

        public override string FileType => "Склад";

        public override void SetContentFile(FileClass file)
        {
            if (file.IsProductParameter)
            {
                Content = file.AsProductParameter.ParameterStock;
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
                    Content = fileClass.AsProductParameter.ParameterStock;
                }
            }
        }

        public static StockFile Load(string fileName)
        {

            try
            {
                StockFile dataBase = ((StockFile)JsonRead(fileName, typeof(StockFile)));
                if (dataBase.Content == null || dataBase.Content is null)
                    throw new Exception();
                return dataBase;
            }
            catch
            {
                StockFile dataBase = new StockFile(fileName, false);
                dataBase.LoadContentJsonWihReturn(fileName);
                return dataBase;
            }
        }


    }
}
