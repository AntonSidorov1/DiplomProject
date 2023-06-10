using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace FileManegerJson
{
    public class PictureBoxCategory : PictureBoxFileClass<CategoryFile>, ITagInfoSecurity<CategoryFile>
    {
        CategoryFile imageFile = new CategoryFile();
        public CategoryFile CategoryFile
        { get
            {
                imageFile.PictureBox = this;
                return imageFile;
            }
            set
            {
                CategoryFile image = value;
                imageFile.SetFile(image);
                forderParent = image.Parent;
                imageFile.CopyFile = image;
                imageFile.Content = image.Content.CopyCategory();
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

        public PictureBoxCategory():base()
        {
            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            base.Image = CategoryFile.ImageView;
        }

        public PictureBoxCategory(PictureBox pictureBox) : this()
        {

            Image = pictureBox.Image;
        }

        public PictureBoxCategory(PictureBoxCategory pictureBox):this(pictureBox as PictureBox)
        {
            CategoryFile = pictureBox.CategoryInFolder();
        }


        public PictureBoxCategory(CategoryFile imageFile):this()
        {
            CategoryFile = imageFile.Copy().AsCategory;
        }

        

        public new Image Image
        {
            get => new Bitmap(CategoryFile.ImageView);
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
            get => CategoryInFolder().FileName;
            set => CategoryInFolder().FileName = value;
        }


        public override CategoryFile TagProperty { get => CategoryFile; set => CategoryFile = value; }

        public CategoryFile CategoryInFolder()
        {
            int index = CategoryFile.TemporaryIndex;
            return FolderParent[index].AsCategory;
        }

    }
}
