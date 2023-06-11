using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace FileManegerJson
{
    public class PictureBoxCatalog : PictureBoxFileClass<FolderClass>, ITagInfoSecurity<FolderClass>
    {
        FolderClass imageFile = new FolderClass();
        public FolderClass Catalog
        { get
            {
                imageFile.PictureBox = this;
                return imageFile;
            }
            set
            {
                FolderClass image = value;
                imageFile.SetFile(image);
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

        public PictureBoxCatalog():base()
        {
            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            base.Image = Catalog.ImageView;
        }

        public PictureBoxCatalog(PictureBox pictureBox) : this()
        {

            Image = pictureBox.Image;
        }

        public PictureBoxCatalog(PictureBoxCatalog pictureBox):this(pictureBox as PictureBox)
        {
            Catalog = pictureBox.CatalogInFolder();
        }


        public PictureBoxCatalog(FolderClass imageFile):this()
        {
            Catalog = imageFile.Copy().AsFolder;
        }

        

        public new Image Image
        {
            get => new Bitmap(Catalog.ImageView);
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
            get => CatalogInFolder().FileName;
            set => CatalogInFolder().FileName = value;
        }


        public override FolderClass TagProperty { get => Catalog; set => Catalog = value; }

        public FolderClass CatalogInFolder()
        {
            int index = Catalog.TemporaryIndex;
            return FolderParent[index].AsFolder;
        }

    }
}
