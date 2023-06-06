using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace FileManegerJson
{
    public class PictureBoxFile : PictureBoxFileClass<ImageFile>, ITagInfoSecurity<ImageFile>
    {
        ImageFile imageFile = new ImageFile();
        public new ImageFile ImageFile { get
            {
                imageFile.PictureBox = this;
                return imageFile;
            }
            set
            {
                ImageFile image = value;
                imageFile.SetImage(image);
                forderParent = image.Parent;
                imageFile.CopyFile = image;
                image.PictureBox = this;
                imageFile.PictureBox = this;
            }
        }

        public new void Dispose()
        {
            ImageFile.Dispose();
            base.Dispose();
            GC.Collect();
        }

        public PictureBoxFile():base()
        {
            ImageFile.ImageOutput = (FileClass file) =>
            {
                ImageFile image = file.AsImage;
                base.Image = image.Image;
            };
        }

        public PictureBoxFile(PictureBox pictureBox) : this()
        {

            Image = pictureBox.Image;
        }

        public PictureBoxFile(PictureBoxFile pictureBox):this(pictureBox as PictureBox)
        {
            ImageFile = pictureBox.ImageInFolder();
        }


        public PictureBoxFile(ImageFile imageFile):this()
        {
            ImageFile = imageFile.Copy().AsImage;
        }

        

        public new Image Image
        {
            get => new Bitmap(ImageFile.Image);
            set
            {
                Bitmap bit = new Bitmap(value);
                ImageFile.Image = bit;
                bit.Dispose();
            }
        }

        public string FileName
        {
            get => ImageFile.FileName;
            set => ImageFile.FileName = value;
        }

        public string FileName1
        {
            get => ImageInFolder().FileName;
            set => ImageInFolder().FileName = value;
        }


        public override ImageFile TagProperty { get => ImageFile; set => ImageFile = value; }

        public ImageFile ImageInFolder()
        {
            int index = ImageFile.TemporaryIndex;
            return FolderParent[index].AsImage;
        }

    }
}
