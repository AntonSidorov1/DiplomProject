using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace FileManegerJson
{
    public class PictureBoxProduct : PictureBoxFileClass<ProductFile>, ITagInfoSecurity<ProductFile>
    {
        ProductFile imageFile = new ProductFile();
        public ProductFile ProductFile
        { get
            {
                imageFile.PictureBox = this;
                return imageFile;
            }
            set
            {
                ProductFile image = value;
                imageFile.SetFile(image);
                forderParent = image.Parent;
                imageFile.CopyFile = image;
                imageFile.Content = image.Content.CopyProduct();
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

        public PictureBoxProduct():base()
        {
            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            base.Image = ProductFile.ImageView;
        }

        public PictureBoxProduct(PictureBox pictureBox) : this()
        {

            Image = pictureBox.Image;
        }

        public PictureBoxProduct(PictureBoxProduct pictureBox):this(pictureBox as PictureBox)
        {
            ProductFile = pictureBox.ProductPointFileInFolder();
        }


        public PictureBoxProduct(ProductFile imageFile):this()
        {
            ProductFile = imageFile.Copy().AsProduct;
        }

        

        public new Image Image
        {
            get => new Bitmap(ProductFile.ImageView);
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
            get => ProductPointFileInFolder().FileName;
            set => ProductPointFileInFolder().FileName = value;
        }


        public override ProductFile TagProperty { get => ProductFile; set => ProductFile = value; }

        public ProductFile ProductPointFileInFolder()
        {
            int index = ProductFile.TemporaryIndex;
            return FolderParent[index].AsProduct;
        }

    }
}
