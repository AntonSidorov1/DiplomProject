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
    public class BynaryImageFileJson : SecurityFile<BynaryImageFileJson, FolderClass>, ISecurityClasses<string>
    {
        ImageFileJson image;

        public BynaryImageFileJson():base()
        {
            Image = new ImageFileJson();
            Image.NameFileOutput = (ImageFileJson imageJson) =>
                {
                    NameFile = imageJson.NameFile;
                };
        }

        public BynaryImageFileJson(ImageFileJson image) : this()
        {
            Image = image;
        }

        public BynaryImageFileJson(ImageFile image) : this()
        {
            ImageFile = image;
        }

        public BynaryImageFileJson(BynaryImageFileJson image) : this(new ImageFile(image))
        {
            
        }

        public BynaryImageFileJson(string name) : this(new ImageFile(name))
        {

        }

        public BynaryImageFileJson(Bitmap image, string name = "") : this(new ImageFile(image, name))
        {

        }

        public ImageFileJson Image { get => image; set => image = value; }

        public ImageFileJson ImageJson { get => Image; set => Image = value; }

        public ImageFile ImageFile { get => Image.ImageFile;
            set
            {
                try
                {
                    Image.ImageFile = value;
                }
                catch
                {
                    Image = new ImageFileJson(value);
                }
            }
        }


        public Bitmap Bitmap
        {
            get => ImageFile.Bitmap;
            set
            {
                ImageFile = new ImageFile(value, FileName);
                OutputImage();
            }
        }

        [DataMember]
        public string FileName { get => Image.FileName;
            set
            {
                try
                {
                    Image.FileName = value;
                }
                catch
                {
                    Image = new ImageFileJson() { FileName = value };
                }
            }
        }

        public byte[] Photo { 
            get => Image.Image;
            set
            {
                try
                {
                    Image.Image = value;
                }
                catch
                {
                    Image = new ImageFileJson();
                    Image.Image = value;
                    OutputImage();
                }
            }
        }

        [DataMember]
        public string PhotoText
        {
            get
            {
                return Convert.ToBase64String(Photo);
            }
            set
            {
                try
                {

                    Photo = Convert.FromBase64String(value);
                }
                catch (Exception e1)
                {
                    try
                    {
                        Photo = Encoding.UTF8.GetBytes(value);
                    }
                    catch (Exception e2)
                    {
                        try
                        {
                            Photo = Encoding.ASCII.GetBytes(value);
                        }
                        catch (Exception e3)
                        {
                            try
                            {
                                Photo = Encoding.Unicode.GetBytes(value);
                            }
                            catch (Exception e4)
                            {
                                Photo = Encoding.UTF32.GetBytes(value);
                            }
                        }
                    }
                }
            }
        }

        
        public override bool Security { get => Image.Security;
            set
            {
                try
                {
                    Image.Security = value;
                }
                catch
                {
                    Image = new ImageFileJson();
                    Image.Security = value;
                }
            }
        }
        public new string PropertyOfSecurity { get => PhotoText; set => PhotoText = value; }


        public override string TypesFileJson => "Image-Json-Bynary (*.ImJsb)|*.ImJsb";

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


        public static BynaryImageFileJson Load(string fileName)
        {


            try
            {
                return (BynaryImageFileJson)JsonRead(fileName, typeof(BynaryImageFileJson));
            }
            catch (Exception e1)
            {
                throw new Exception(e1.Message, e1);
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

        public BynaryImageFileJson BynaryImage
        {
            get => this;
            set
            {
                BynaryImageFileJson bynaryImage = value;
                ImageFile = new ImageFile(bynaryImage);
            }
        }

        public override FolderClass Parent => throw new NotImplementedException();

        public override FolderClass Root => Parent.Root;

        public override BynaryImageFileJson TagProperty { get => BynaryImage; set => BynaryImage = value; }

        public void SetImage(BynaryImageFileJson bynaryImage)
        {
            BynaryImage = bynaryImage;
        }

        //public delegate void FileContentOutput(BynaryImageFileJson bynaryImage);
        public FileContentOutput ImageOutput;

        public void OutputImage()
        {
            try
            {
                ImageOutput(this);
            }
            catch
            {

            }
        }

        public override string NameFile { 
            get => base.NameFile;
            set
            {
                base.NameFile = value;
                if (FileName != NameFile)
                    FileName = NameFile;
            }
        }

        public override string IndexClassName => "BynaryImageFileJson";
    }
}
