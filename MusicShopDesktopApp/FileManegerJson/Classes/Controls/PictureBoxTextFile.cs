using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace FileManegerJson
{
    public class PictureBoxTextFile : PictureBoxFileClass<TextFile>, ITagInfoSecurity<TextFile>
    {
        TextFile imageFile = new TextFile();
        public TextFile TextFile
        { get
            {
                imageFile.PictureBox = this;
                return imageFile;
            }
            set
            {
                TextFile image = value;
                imageFile.SetFile(image);
                forderParent = image.Parent;
                imageFile.CopyFile = image;
                imageFile.Text = image.Text;
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

        public PictureBoxTextFile():base()
        {
            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            base.Image = TextFile.ImageView;
        }

        public PictureBoxTextFile(PictureBox pictureBox) : this()
        {

            Image = pictureBox.Image;
        }

        public PictureBoxTextFile(PictureBoxTextFile pictureBox):this(pictureBox as PictureBox)
        {
            TextFile = pictureBox.TextInFolder();
        }


        public PictureBoxTextFile(TextFile imageFile):this()
        {
            TextFile = imageFile.Copy().AsText;
        }

        

        public new Image Image
        {
            get => new Bitmap(TextFile.ImageView);
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
            get => TextInFolder().FileName;
            set => TextInFolder().FileName = value;
        }


        public override TextFile TagProperty { get => TextFile; set => TextFile = value; }

        public TextFile TextInFolder()
        {
            int index = TextFile.TemporaryIndex;
            return FolderParent[index].AsText;
        }

    }
}
