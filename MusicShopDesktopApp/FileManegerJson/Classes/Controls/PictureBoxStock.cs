using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace FileManegerJson
{
    public class PictureBoxStock : PictureBoxFileClass<StockFile>, ITagInfoSecurity<StockFile>
    {
        StockFile imageFile = new StockFile();
        public StockFile StockFile
        { get
            {
                imageFile.PictureBox = this;
                return imageFile;
            }
            set
            {
                StockFile image = value;
                imageFile.SetFile(image);
                forderParent = image.Parent;
                imageFile.CopyFile = image;
                imageFile.Content = image.Content.CopyStock();
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

        public PictureBoxStock():base()
        {
            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            base.Image = StockFile.ImageView;
        }

        public PictureBoxStock(PictureBox pictureBox) : this()
        {

            Image = pictureBox.Image;
        }

        public PictureBoxStock(PictureBoxStock pictureBox):this(pictureBox as PictureBox)
        {
            StockFile = pictureBox.StockInFolder();
        }


        public PictureBoxStock(StoreFile imageFile):this()
        {
            StockFile = imageFile.Copy().AsStock;
        }

        

        public new Image Image
        {
            get => new Bitmap(StockFile.ImageView);
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
            get => StockInFolder().FileName;
            set => StockInFolder().FileName = value;
        }


        public override StockFile TagProperty { get => StockFile; set => StockFile = value; }

        public StockFile StockInFolder()
        {
            int index = StockFile.TemporaryIndex;
            return FolderParent[index].AsStock;
        }

    }
}
