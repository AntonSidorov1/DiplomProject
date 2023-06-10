using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace FileManegerJson
{
    public class PictureBoxSupplier : PictureBoxFileClass<SupplierFile>, ITagInfoSecurity<SupplierFile>
    {
        SupplierFile imageFile = new SupplierFile();
        public SupplierFile SupplierFile
        { get
            {
                imageFile.PictureBox = this;
                return imageFile;
            }
            set
            {
                SupplierFile image = value;
                imageFile.SetFile(image);
                forderParent = image.Parent;
                imageFile.CopyFile = image;
                imageFile.Content = image.Content.CopySupplier();
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

        public PictureBoxSupplier():base()
        {
            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            base.Image = SupplierFile.ImageView;
        }

        public PictureBoxSupplier(PictureBox pictureBox) : this()
        {

            Image = pictureBox.Image;
        }

        public PictureBoxSupplier(PictureBoxSupplier pictureBox):this(pictureBox as PictureBox)
        {
            SupplierFile = pictureBox.SuplierInFolder();
        }


        public PictureBoxSupplier(SupplierFile imageFile):this()
        {
            SupplierFile = imageFile.Copy().AsSupplier;
        }

        

        public new Image Image
        {
            get => new Bitmap(SupplierFile.ImageView);
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
            get => SuplierInFolder().FileName;
            set => SuplierInFolder().FileName = value;
        }


        public override SupplierFile TagProperty { get => SupplierFile; set => SupplierFile = value; }

        public SupplierFile SuplierInFolder()
        {
            int index = SupplierFile.TemporaryIndex;
            return FolderParent[index].AsSupplier;
        }

    }
}
