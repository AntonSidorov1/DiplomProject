using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Drawing;

namespace FileManegerJson
{
   [DataContract]
    public class ImageFileJson : SecurityFile<ImageFileJson, FolderClass>, ISecurityClasses<byte[]>
    {
        public Bitmap Bitmap
        {
            get => ImageFile.Bitmap;
            set => ImageFile = new ImageFile(value, FileName);
        }


        public ImageFile ImageFile { get
            {
                ImageFile image = new ImageFile(Image, FileName);
                image.Security = Security;
                image.SetAbstractFile(this);
                return image;
            }
            set
            {
                ImageFile image = value;
                FileName = image.FileName;
                Image = image.Photo;
                Security = image.Security;
                SetAbstractFile(image);
            } }

        [DataMember]
        public string FileName { get => NameFile; set => NameFile = value; }
        [DataMember]
        public byte[] Image { get; set; }

        //bool security = false;

        //[DataMember]
        //public bool Security { get => security; set => security = true; }
        public new byte[] PropertyOfSecurity { get => Image; set => Image = value; }

        public override string TypesFileJson => "Image-Json (*.ImJsj)|*.ImJsj";

        //public string TypesFileJsonWithTxt => TypesFileJson + "|Json (.json)|*.json|Txt (*.txt)|*.txt|STXT (*.stxt)|*.stxt|All Files (*.*)|*.*";

        public override string TypesFileContent => new ImageFile().TypesFileContent;

        //public string TypesFileContentWithTxt => new ImageFile().TypesFileContentWithTxt;

        public override string AllTypesFile
        {
            get
            {
                string types = TypesFileContent;
                bool have = types != "" && types != null && !(types is null);
                bool have1 = false;
                if (have)
                    have1 = types.Remove(0, types.Length - 1) == "|";
                if (!have)
                    return TypesFileJsonWithTxt;
                else
                {
                    if (have1)
                    {
                        return TypesFileContent + "|" + TypesFileJsonWithTxt;
                    }
                    else
                    {
                        return TypesFileContent + TypesFileJsonWithTxt;
                    }
                }

            }
        }

        public ImageFileJson()
        {

        }

        public ImageFileJson(ImageFile image) : this()
        {
            ImageFile = image;
        }


        /// <summary>
        /// Чтение из Json-файла
        /// </summary>
        /// <param name="namefile"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object JsonRead(string namefile, Type type)
        {

            namefile = namefile.Replace('/', '\\');
            DataContractJsonSerializer json = new DataContractJsonSerializer(type);
            FileStream fileStream = new FileStream(namefile, FileMode.Open);
            try
            {
                object obj = json.ReadObject(fileStream);
                fileStream.Close();
                return obj;
            }
            catch (Exception e)
            {
                fileStream.Close();
                throw new Exception(e.Message, e);
            }


        }


        public static ImageFileJson Load(string fileName)
        {


            try
            {
                ImageFileJson image = (ImageFileJson)JsonRead(fileName, typeof(ImageFileJson));
                int count = image.Image.Length;
                return image;
            }
            catch (Exception e2)
            {
                try
                {
                    BynaryImageFileJson bynaryImage = BynaryImageFileJson.Load(fileName);
                    ImageFileJson imageFile = bynaryImage.ImageJson;
                    imageFile.DateCreate = bynaryImage.DateCreate;
                    imageFile.IndexFileName = bynaryImage.IndexFileName;
                    return imageFile;
                }
                catch (Exception e1)
                {
                    throw new Exception(e1.Message, e1);
                }
            }
        }


        /// <summary>
        /// Сохраняет объект obj с типом type в Json-файл namefile
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <param name="namefile"></param>
        public static void JsonWrite(object obj, Type type, string namefile)
        {
            namefile = namefile.Replace('/', '\\');
            DataContractJsonSerializer json = new DataContractJsonSerializer(type);
            FileStream fileStream = new FileStream(namefile, FileMode.Create);
            json.WriteObject(fileStream, obj);
        }

        public void SaveJson(string fileName)
        {
            fileName = fileName.Replace('/', '\\');
            string[] points = fileName.Split('.');
            int last = points.Length - 1;
            points[last] = points[last].Trim().ToLower();
            fileName = string.Join(".", points);
            JsonWrite(this, this.GetType(), fileName);
        }


        public BynaryImageFileJson BynaryImageFile
        {
            get => new BynaryImageFileJson(this);
            set => ImageFile = value.ImageFile;
        }

        //public override string TypesFileJson => throw new NotImplementedException();

        //public override string TypesFileContent => throw new NotImplementedException();

        public override FolderClass Parent => throw new NotImplementedException();

        public override FolderClass Root => Parent.Root;

        public override ImageFileJson TagProperty { get => this; set => ImageFile = new ImageFile(value); }

        public ImageFileJson(BynaryImageFileJson bynaryImage) : this()
        {
            BynaryImageFile = bynaryImage;
        }

        public ImageFileJson(string name) : this(new ImageFile(name))
        {
            
        }

        public ImageFileJson(Bitmap image, string name = "") : this(new ImageFile(image, name))
        {

        }

        public ImageFileJson(ImageFileJson image) : this(new ImageFile(image))
        {

        }

        public void NameFileOutputRun()
        {
            try
            {
                NameFileOutput(this);
            }
            catch
            {

            }
        }


        public override string NameFile 
        { get => base.NameFile;
            set
            {
                base.NameFile = value;
                NameFileOutputRun();
            }
        }

        public override string IndexClassName => "IndexFileJson";
    }
}
