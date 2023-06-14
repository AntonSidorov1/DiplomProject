using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace FileManegerJson
{
    /// <summary>
    /// Параметр товара
    /// </summary>
    [DataContract]
    public class ProductParameter : AbstractNotesClass
    {
        string name = "";

        public ProductParameter()
        {
        }

        public ProductParameter(string name):this()
        {
            Name = name;
        }

        public ProductParameter(ProductParameter parameter):this(parameter.Name)
        {
            SetParameter(parameter);
        }

        public virtual void SetParameter(ProductParameter parameter)
        {
            Name = parameter.Name;
        }

        /// <summary>
        /// Название
        /// </summary>
        [DataMember]
        public string Name
        {
            get => name;
            set => name = value;
        }

        public ProductParameter CopyParameter() => new ProductParameter(this);

        public NoteClass CopyNote() => new NoteClass(this);

        public Town CopyTown() => new Town(this);
        public Town CopySity() => CopyTown();


        public void SaveJson(string fileName)
        {
            fileName = fileName.Replace('/', '\\');
            string[] points = fileName.Split('.');
            int last = points.Length - 1;
            points[last] = points[last].Trim().ToLower();
            fileName = string.Join(".", points);
            JsonWrite(this, this.GetType(), fileName);
        }



        /// <summary>
        /// Сохраняет объект obj с типом type в Json-файл namefile
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <param name="namefile"></param>
        public static void JsonWrite(object obj, Type type, string namefile)
        {
            FileStream fileStream = new FileStream(namefile, FileMode.Create);
            try
            {
                namefile = namefile.Replace('/', '\\');
                DataContractJsonSerializer json = new DataContractJsonSerializer(type);
                json.WriteObject(fileStream, obj);
                fileStream.Close();
            }
            catch (Exception e)
            {
                try
                {
                    fileStream.Close();
                }
                catch
                {

                }
                throw e;
            }

        }


        public DisributingFacilities CopyOrganization()
        {
            return new DisributingFacilities(this);
        }

        public DistributingPoint CopyTraidingPoint()
        {
            return new DistributingPoint(this);
        }

        public Store CopyStore()
        {
            return new Store(this);
        }

        public StoreHouse CopyStock()
        {
            return new StoreHouse(this);
        }

        public SupplierClass CopySupplier()
        {
            return new SupplierClass(this);
        }

        public ManufactureClass CopyManufacture()
        {
            return new ManufactureClass(this);
        }

        public CategoryClass CopyCategory()
        {
            return new CategoryClass(this);
        }

        public ProductClass CopyProduct()
        {
            return new ProductClass(this);
        }


        public void LoadJson(string jsonFile) => SetParameter((ProductParameter)FileClass.JsonRead(jsonFile, GetType()));

        public override string GetName()
        {
            return Name;
        }

        public override void SetName(string name)
        {
            Name = name;
        }
    }
}
