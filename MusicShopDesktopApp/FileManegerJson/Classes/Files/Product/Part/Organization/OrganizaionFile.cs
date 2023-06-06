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
    /// Файл с торговой сетью
    /// </summary>
    [DataContract]
    public class OrganizaionFile : ProductParameterFile<DisributingFacilities>
    {
        public OrganizaionFile()
        {
        }

        public OrganizaionFile(DisributingFacilities content) : base(content)
        {
        }

        public OrganizaionFile(ProductParameterFile<DisributingFacilities> file) : base(file)
        {
        }

        public OrganizaionFile(string name, bool file = true) : base(name, file)
        {
        }

        public OrganizaionFile(string name, string fileName) : base(name, fileName)
        {
        }

        public OrganizaionFile(string name, DisributingFacilities content) : base(name, content)
        {
        }

        public OrganizaionFile(string name, string fileName, DisributingFacilities content) : base(name, fileName, content)
        {
        }

        public override string TypesFileJson => "Organizaion Json (*.orgj)|*.orgj|"+ TypeFile;

        public override string TypesFileContent => "Organizaion content (*.orgc)|*.orgc|" + TypeFile;

        public string TypeFile => "Organizaion file (*.orgf)|*.orgf";

        public override string IndexClassName => "OrganizationFile";

        public override FileClass Copy() => Create(this);

        public override ProductParameterFile CreateNewFile() => new OrganizaionFile();

        public override void SetParametersContent(DisributingFacilities content)
        {
            Content = content.CopyOrganization();
        }

        protected override void CreateContent(DisributingFacilities content)
        {
            Content = content.CopyOrganization();
        }

        protected override DisributingFacilities PutContent() => new DisributingFacilities();


        public override Bitmap BitmapView
        {
            get
            {
                //try
                //{
                //    return new Bitmap(Content.LogotipImage);
                //}
                //catch
                //{
                //    return Properties.Resources.Organization;
                //}
                return Properties.Resources.Organization;
            }

        }


        public override void SetContentFile(FileClass file)
        {
            if (file.IsProductParameter)
            {
                Content = file.AsProductParameter.ParametrOrganizaion;
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
                    Content = fileClass.AsProductParameter.ParametrOrganizaion;
                }
            }
        }

        public static OrganizaionFile Load(string fileName)
        {

            try
            {
                OrganizaionFile dataBase = ((OrganizaionFile)JsonRead(fileName, typeof(OrganizaionFile)));
                if (dataBase.Content == null || dataBase.Content is null)
                    throw new Exception();
                return dataBase;
            }
            catch
            {
                OrganizaionFile dataBase = new OrganizaionFile(fileName, false)
                {
                    Content = ((DisributingFacilities)JsonRead(fileName, typeof(DisributingFacilities)))
                };
                return dataBase;
            }
        }

    }
}
