using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace FileManegerJson
{
    public class PictureBoxManufacture : PictureBoxFileClass<ManufactureFile>, ITagInfoSecurity<ManufactureFile>
    {
        ManufactureFile imageFile = new ManufactureFile();
        public ManufactureFile ManufactureFile
        { get
            {
                imageFile.PictureBox = this;
                return imageFile;
            }
            set
            {
                ManufactureFile image = value;
                imageFile.SetFile(image);
                forderParent = image.Parent;
                imageFile.CopyFile = image;
                imageFile.Content = image.Content.CopyManufacture();
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

        public PictureBoxManufacture():base()
        {
            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            base.Image = ManufactureFile.ImageView;
        }

        public PictureBoxManufacture(PictureBox pictureBox) : this()
        {

            Image = pictureBox.Image;
        }

        public PictureBoxManufacture(PictureBoxManufacture pictureBox):this(pictureBox as PictureBox)
        {
            ManufactureFile = pictureBox.ManufactureInFolder();
        }


        public PictureBoxManufacture(ManufactureFile imageFile):this()
        {
            ManufactureFile = imageFile.Copy().AsManufacture;
        }

        

        public new Image Image
        {
            get => new Bitmap(ManufactureFile.ImageView);
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
            get => ManufactureInFolder().FileName;
            set => ManufactureInFolder().FileName = value;
        }


        public override ManufactureFile TagProperty { get => ManufactureFile; set => ManufactureFile = value; }

        public ManufactureFile ManufactureInFolder()
        {
            int index = ManufactureFile.TemporaryIndex;
            return FolderParent[index].AsManufacture;
        }

    }
}
