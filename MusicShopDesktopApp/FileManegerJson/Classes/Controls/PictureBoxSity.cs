using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace FileManegerJson
{
    public class PictureBoxSity : PictureBoxFileClass<SityFile>, ITagInfoSecurity<SityFile>
    {
        SityFile imageFile = new SityFile();
        public SityFile SityFile
        { get
            {
                imageFile.PictureBox = this;
                return imageFile;
            }
            set
            {
                SityFile image = value;
                imageFile.SetFile(image);
                forderParent = image.Parent;
                imageFile.CopyFile = image;
                imageFile.Content = image.Content.CopySity();
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

        public PictureBoxSity():base()
        {
            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            base.Image = SityFile.ImageView;
        }

        public PictureBoxSity(PictureBox pictureBox) : this()
        {

            Image = pictureBox.Image;
        }

        public PictureBoxSity(PictureBoxSity pictureBox):this(pictureBox as PictureBox)
        {
            SityFile = pictureBox.SityInFolder();
        }


        public PictureBoxSity(SityFile imageFile):this()
        {
            SityFile = imageFile.Copy().AsSity;
        }

        

        public new Image Image
        {
            get => new Bitmap(SityFile.ImageView);
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
            get => SityInFolder().FileName;
            set => SityInFolder().FileName = value;
        }


        public override SityFile TagProperty { get => SityFile; set => SityFile = value; }

        public SityFile SityInFolder()
        {
            int index = SityFile.TemporaryIndex;
            return FolderParent[index].AsSity;
        }

    }
}
