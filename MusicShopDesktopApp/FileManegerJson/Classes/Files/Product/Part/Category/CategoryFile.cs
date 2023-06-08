using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManegerJson
{
    public class CategoryFile : ProductParameterFile<CategoryClass>
    {
        public CategoryFile()
        {
        }

        public CategoryFile(CategoryClass content) : base(content)
        {
        }

        public CategoryFile(ProductParameterFile<CategoryClass> file) : base(file)
        {
        }

        public CategoryFile(string name, bool file = true) : base(name, file)
        {
        }

        public CategoryFile(string name, string fileName) : base(name, fileName)
        {
        }

        public CategoryFile(string name, CategoryClass content) : base(name, content)
        {
        }

        public CategoryFile(string name, string fileName, CategoryClass content) : base(name, fileName, content)
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

        public override void SetParametersContent(CategoryClass content)
        {
            Content = content.CopyCategory();
        }

        protected override void CreateContent(CategoryClass content)
        {
            Content = content.CopyCategory();
        }

        protected override CategoryClass PutContent() => new CategoryClass();

        public override Bitmap BitmapView
        {
            get
            {
                
                return Properties.Resources.Category;
            }

        }

        public override void SetContentFile(FileClass file)
        {
            if (file.IsProductParameter)
            {
                Content = file.AsProductParameter.ParameterCategory;
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
                    Content = fileClass.AsProductParameter.ParameterCategory;
                }
            }
        }

        public static CategoryFile Load(string fileName)
        {

            try
            {
                CategoryFile dataBase = ((CategoryFile)JsonRead(fileName, typeof(CategoryFile)));
                if (dataBase.Content == null || dataBase.Content is null)
                    throw new Exception();
                return dataBase;
            }
            catch
            {
                CategoryFile dataBase = new CategoryFile(fileName, false)
                {
                    Content = CategoryClass.LoadJsonFile(fileName)
                };
                return dataBase;
            }
        }


    }
}
