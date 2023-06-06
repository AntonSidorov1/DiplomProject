using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace FileManegerJson
{
    public class PictureBoxDataBaseFile : PictureBoxFileClass<DataBaseFile>, ITagInfoSecurity<DataBaseFile>
    {
        DataBaseFile imageFile = new DataBaseFile();
        public DataBaseFile DataBaseFile
        { get
            {
                imageFile.PictureBox = this;
                return imageFile;
            }
            set
            {
                DataBaseFile image = value;
                imageFile.SetFile(image);
                forderParent = image.Parent;
                imageFile.CopyFile = image;
                imageFile.DataBase = image.DataBase.CopyWithFull();
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

        public PictureBoxDataBaseFile():base()
        {
            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            base.Image = DataBaseFile.ImageView;
        }

        public PictureBoxDataBaseFile(PictureBox pictureBox) : this()
        {

            Image = pictureBox.Image;
        }

        public PictureBoxDataBaseFile(PictureBoxDataBaseFile pictureBox):this(pictureBox as PictureBox)
        {
            DataBaseFile = pictureBox.DataBaseInFolder();
        }


        public PictureBoxDataBaseFile(DataBaseFile imageFile):this()
        {
            DataBaseFile = imageFile.Copy().AsDataBase;
        }

        

        public new Image Image
        {
            get => new Bitmap(DataBaseFile.ImageView);
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
            get => DataBaseInFolder().FileName;
            set => DataBaseInFolder().FileName = value;
        }


        public override DataBaseFile TagProperty { get => DataBaseFile; set => DataBaseFile = value; }

        public DataBaseFile DataBaseInFolder()
        {
            int index = DataBaseFile.TemporaryIndex;
            return FolderParent[index].AsDataBase;
        }

    }
}
