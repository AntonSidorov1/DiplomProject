using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace FileManegerJson
{
    public class PictureBoxTraidingPoint : PictureBoxFileClass<TraidingPointFile>, ITagInfoSecurity<TraidingPointFile>
    {
        TraidingPointFile imageFile = new TraidingPointFile();
        public TraidingPointFile TraidingPointFile
        { get
            {
                imageFile.PictureBox = this;
                return imageFile;
            }
            set
            {
                TraidingPointFile image = value;
                imageFile.SetFile(image);
                forderParent = image.Parent;
                imageFile.CopyFile = image;
                imageFile.Content = image.Content.CopyTraidingPoint();
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

        public PictureBoxTraidingPoint():base()
        {
            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            base.Image = TraidingPointFile.ImageView;
        }

        public PictureBoxTraidingPoint(PictureBox pictureBox) : this()
        {

            Image = pictureBox.Image;
        }

        public PictureBoxTraidingPoint(PictureBoxTraidingPoint pictureBox):this(pictureBox as PictureBox)
        {
            TraidingPointFile = pictureBox.TraidingPointFileInFolder();
        }


        public PictureBoxTraidingPoint(TraidingPointFile imageFile):this()
        {
            TraidingPointFile = imageFile.Copy().AsTraidingPoint;
        }

        

        public new Image Image
        {
            get => new Bitmap(TraidingPointFile.ImageView);
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
            get => TraidingPointFileInFolder().FileName;
            set => TraidingPointFileInFolder().FileName = value;
        }


        public override TraidingPointFile TagProperty { get => TraidingPointFile; set => TraidingPointFile = value; }

        public TraidingPointFile TraidingPointFileInFolder()
        {
            int index = TraidingPointFile.TemporaryIndex;
            return FolderParent[index].AsTraidingPoint;
        }

    }
}
