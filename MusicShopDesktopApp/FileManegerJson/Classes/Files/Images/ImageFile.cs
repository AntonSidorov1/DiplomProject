using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FileManegerJson
{
    [DataContract]
    public class ImageFile : FileClass, IDisposable
    {
        Bitmap bit;

        public void SetImage(ImageFile file)
        {
            Bitmap = file.Bitmap;
            Name = file.Name;
            file.CopyIndex();
            TemporaryIndex = file.TemporaryIndex;
            SetAbstractFile(file);
        }

        public override void FromFile(AbstractFileClass file)
        {
            base.FromFile(file);
            if (file is FileClass)
            {
                FileClass fileClass = file as FileClass;
                if(fileClass.IsImage)
                {
                    ImageFile image = fileClass.AsImage;
                    Image = new Bitmap(image.Bitmap);
                    //Name = image.Name;
                }
            }
        }

        public override string Text1
        {
            get => text;
            set {
                text = value;
                string[] line = text.Split('/', '\\');
                text = line[line.Length - 1];
            }
        }

        [DataMember]
        public string Text { get => Name; set => Name = value; }

        [JsonIgnore]
        public Bitmap Bitmap
        {
            get => new Bitmap(bit);

            set
            {
                bit = new Bitmap(value);
                value.Dispose();
                try
                {
                    ImageOutput(this);
                }
                catch
                {

                }
            }
        }


        public FileContentOutput ImageOutput;

        [JsonIgnore]
        public Image Image
        {
            get
                { 
                Bitmap bit = new Bitmap(Bitmap);
                return bit;
            }
            set
            {
                Bitmap = new Bitmap(value);
                value.Dispose();
            }
        }

        public Image CopyImage() => new Bitmap(Image);

        public ImageFile() :base()
        {
            Image = new Bitmap(100, 100);
        }


        public ImageFile(string name) : this()
        {
            Name = name;
        }

        public ImageFile(Image image) : this()
        {
            Image = image;
        }

        public ImageFile(Image image, string name): this(name)
        {
            Image image1 = new Bitmap(image);
            Image = image1;
            image1.Dispose();
            GC.Collect();
        }

        public ImageFile(FileClass attachments):this()
        {

            FileClass image = attachments;
            Image = image.BitmapView;
            Name = attachments.Name;
            TemporaryIndex = image.TemporaryIndex;
        }

        public ImageFile(byte[] image) : this()
        {
            Photo = image;
        }

        public ImageFile(byte[] image, string name):this(name)
        {
            Photo = image;
        }

        public ImageFile(ImageFileJson image):this(image.Bitmap, image.FileName)
        {
            SetAbstractFile(image);
        }

        public ImageFile(ImageFile image):this(image.Bitmap, image.Name)
        {
            TemporaryIndex = image.TemporaryIndex;
            SetAbstractFile(image);
            CopyFile = image;
        }

        public ImageFile(BynaryImageFileJson bynaryImage):this()
        {
            BynaryImageFile = bynaryImage;
        }


        [DataMember]
        public byte[] Photo
        {
            get => BytesFromImage(Image);
            set => Bitmap = ImageFromBytes(value);
        }


        public Size Size => Image.Size;

        public override ref string RefName { get => ref text;}

        public override string TypesFileJson => "Image-Json (*.ImJs)|*.ImJs";

        public override string TypesFileContent => "JPG (*.jpg)|*.jpg|PNG (*.png)|*.png|BMP (*.bmp)|*.bmp|GIF (*.gif)|*.gif";

        public static ImageFile Load(string fileName)
        {
            
            try
            {

                return new ImageFile(Image.FromFile(fileName), fileName);
            }
            catch (Exception e)
            {
                try
                {
                    ImageFile file = ((ImageFile)JsonRead(fileName, typeof(ImageFile))).AsImage;
                    Bitmap bit = file.Bitmap;
                    Size size = bit.Size;

                    return file;
                }
                catch (Exception e2)
                {
                    try 
                    {
                        return ImageFileJson.Load(fileName).ImageFile;
                    }
                    catch (Exception e1)
                    {
                        throw new Exception(e1.Message, e1);
                    }
                }
            }
        }

        public Image ToImage() => Image;
        public byte[] ToByte() => Photo;

        public override FileClass Copy()
        {
            return new ImageFile(this);
        }

        protected override void GetProperty(FileClass file)
        {
            base.GetProperty(file);
            Image = new Bitmap(file.AsImage.CopyImage());
        }

        public ImageFileJson ImageJson
        {
            get => new ImageFileJson(this);
            set
            {
                ImageFileJson json = value;
                SetImage(json.ImageFile);
            }
        }

        [JsonIgnore]
        public override string AllTypesFile
        {
            get
            {
                string TypesFileJsonWithTxt = new ImageFileJson().TypesFileJson + "|" + new BynaryImageFileJson().TypesFileJson + "|" + this.TypesFileJsonWithTxt;
                string types = TypesFileContent;
                bool have = types != "" && types != null && !(types is null);
                bool have1 = false;
                if (have)
                    have1 = types.Remove(0, types.Length - 1) == "|";
                if (!have)
                    return TypesFileJsonWithTxt;
                else
                {
                    if (!have1)
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

        [JsonIgnore]
        public BynaryImageFileJson BynaryImageFile
        {
            get => new BynaryImageFileJson(this);
            set => ImageJson = value.ImageJson;
        }

        public override string IndexClassName => "ImageFile";


        //public static explicit operator Bitmap(ImageFile file)
        //{
        //    return file.Bitmap;
        //}

        public static explicit operator Bitmap(ImageFile file)
        {
            return file.Bitmap;
        }

        public static implicit operator ImageFile(Image image)
        {
            return new ImageFile(image ?? new Bitmap(height: 100, width: 100));
        }

        public Bitmap ToBitmap()
        {
            return (Bitmap)this;
        }

        public override void Dispose()
        {
            base.Dispose();
            bit.Dispose();
            //Bitmap.Dispose();
        }

        public override void SetContentFile(FileClass file)
        {
            
        }

        public static implicit operator ImageFileJson(ImageFile image)
        {
            return image.ImageJson;
        }

        public static implicit operator ImageFile(ImageFileJson image)
        {
            return image.ImageFile;
        }

        public override Bitmap BitmapView => new Bitmap(Image);

        public override string FileType => "Изображние";
    }
}
