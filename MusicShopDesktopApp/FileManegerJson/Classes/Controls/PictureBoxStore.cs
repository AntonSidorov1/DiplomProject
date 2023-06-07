using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace FileManegerJson
{
    public class PictureBoxStore : PictureBoxFileClass<StoreFile>, ITagInfoSecurity<StoreFile>
    {
        StoreFile imageFile = new StoreFile();
        public StoreFile StoreFile
        { get
            {
                imageFile.PictureBox = this;
                return imageFile;
            }
            set
            {
                StoreFile image = value;
                imageFile.SetFile(image);
                forderParent = image.Parent;
                imageFile.CopyFile = image;
                imageFile.Content = image.Content.CopyStore();
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

        public PictureBoxStore():base()
        {
            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            base.Image = StoreFile.ImageView;
        }

        public PictureBoxStore(PictureBox pictureBox) : this()
        {

            Image = pictureBox.Image;
        }

        public PictureBoxStore(PictureBoxStore pictureBox):this(pictureBox as PictureBox)
        {
            StoreFile = pictureBox.StoreInFolder();
        }


        public PictureBoxStore(StoreFile imageFile):this()
        {
            StoreFile = imageFile.Copy().AsStore;
        }

        

        public new Image Image
        {
            get => new Bitmap(StoreFile.ImageView);
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
            get => StoreInFolder().FileName;
            set => StoreInFolder().FileName = value;
        }


        public override StoreFile TagProperty { get => StoreFile; set => StoreFile = value; }

        public StoreFile StoreInFolder()
        {
            int index = StoreFile.TemporaryIndex;
            return FolderParent[index].AsStore;
        }

    }
}
