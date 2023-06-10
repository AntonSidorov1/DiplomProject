using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FileManegerJson
{

    [DataContract]
    public abstract class ProductParameterFile : NameFile
    {
        protected ProductParameterFile()
        {
        }

        protected ProductParameterFile(string name, bool file = true) : base(name, file)
        {
        }

        protected ProductParameterFile(string name, string fileName) : base(name, fileName)
        {
        }

        public abstract ProductParameterFile CreateNewFile();

        public abstract ProductParameter Parameter { get; }
        public NoteClass ParametrNote => Parameter.CopyNote();
        public Town ParametrSity => Parameter.CopySity();
        public DisributingFacilities ParametrOrganizaion => Parameter.CopyOrganization();
        public DistributingPoint ParameterTraidingPoint => Parameter.CopyTraidingPoint();
        public Store ParameterStore => Parameter.CopyStore();
        public CategoryClass ParameterCategory => Parameter.CopyCategory();
        public ManufactureClass ParameterManufacture => Parameter.CopyManufacture();
        public SupplierClass ParameterSupplier => Parameter.CopySupplier();
        public ProductClass ParameterProduct => Parameter.CopyProduct();


        public void LoadContentJson(string jsonFile) => Parameter.LoadJson(jsonFile);

        public ProductParameterFile LoadContentJsonWihReturn(string jsonFile)
        {
            LoadContentJson(jsonFile);
            return this;
        }


    }


    [DataContract]
    public abstract class ProductParameterFile<T> : ProductParameterFile where T : ProductParameter
    {


        public override ProductParameter Parameter => Content;

        public ProductParameterFile()
        {
        }

        public ProductParameterFile(string name, bool file = true) : base(name, file)
        {
        }

        public ProductParameterFile(string name, string fileName) : base(name, fileName)
        {
        }

        public ProductParameterFile(T content):this()
        {
            CreateContent(content);
        }

        public ProductParameterFile(string name, T content) : this(name)
        {
            CreateContent(content);
        }

        public ProductParameterFile(string name, string fileName, T content) : this(name, fileName)
        {
            CreateContent(content);
        }

        public ProductParameterFile(ProductParameterFile<T> file) : this(file.Name, file.FileName, file.Content)
        {

        }

        public override void SetContentFile(FileClass file)
        {
            if(file is ProductParameterFile<T>)
            {
                Content.Name = (file as ProductParameterFile<T>).Content.Name;
                SetParametersContent((file as ProductParameterFile<T>).Content);
            }
        }

        public abstract void SetParametersContent(T content);


        protected override void Create()
        {
            Content = PutContent();
            base.Create();
        }

        protected abstract void CreateContent(T content);

        protected abstract T PutContent();

        T content;

        public void SetContent(T content)
        {
            this.content = content;
        }

        public T GetContent()
        {
            return content;
        }

        [DataMember]
        public T Content
        {
            get => GetContent();
            set => SetContent(value);
        }


    }
}
