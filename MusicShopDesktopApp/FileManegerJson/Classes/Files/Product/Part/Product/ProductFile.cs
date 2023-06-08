using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManegerJson
{
    public class ProductFile : ProductParameterFile<ProductClass>
    {
        public ProductFile()
        {
        }

        public ProductFile(ProductClass content) : base(content)
        {
        }

        public ProductFile(ProductParameterFile<ProductClass> file) : base(file)
        {
        }

        public ProductFile(string name, bool file = true) : base(name, file)
        {
        }

        public ProductFile(string name, string fileName) : base(name, fileName)
        {
        }

        public ProductFile(string name, ProductClass content) : base(name, content)
        {
        }

        public ProductFile(string name, string fileName, ProductClass content) : base(name, fileName, content)
        {
        }

        public override string TypesFileJson => "Goods Json (*.goodsj)|*.goodsj|Goods File (*.goodsf)|*.goodsf";

        public override string TypesFileContent => "Goods Content (*.goodsc)|*.goodsc|Goods File (*.goodsf)|*.goodsf";

        public override string IndexClassName => "ProductFile";

        public override FileClass Copy()
        {
            return Create(this);
        }

        public override ProductParameterFile CreateNewFile() => new ProductFile();

        public override void SetParametersContent(ProductClass content)
        {
            Content = content.CopyProduct();
        }

        protected override void CreateContent(ProductClass content)
        {
            Content = content.CopyProduct();
        }

        protected override ProductClass PutContent() => new ProductClass();

        public override Bitmap BitmapView
        {
            get
            {
                
                return Properties.Resources.Product;
            }

        }

        public override void SetContentFile(FileClass file)
        {
            if (file.IsProductParameter)
            {
                Content = file.AsProductParameter.ParameterProduct;
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
                    Content = fileClass.AsProductParameter.ParameterProduct;
                }
            }
        }

        public static ProductFile Load(string fileName)
        {

            try
            {
                ProductFile dataBase = ((ProductFile)JsonRead(fileName, typeof(ProductFile)));
                if (dataBase.Content == null || dataBase.Content is null)
                    throw new Exception();
                return dataBase;
            }
            catch
            {
                ProductFile dataBase = new ProductFile(fileName, false)
                {
                    Content = ProductClass.LoadJsonFile(fileName)
                };
                return dataBase;
            }
        }


    }
}
