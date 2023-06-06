using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace FileManegerJson
{
    public class PictureBoxNote : PictureBoxFileClass<NoteFile>, ITagInfoSecurity<NoteFile>
    {
        NoteFile imageFile = new NoteFile();
        public NoteFile NoteFile
        { get
            {
                imageFile.PictureBox = this;
                return imageFile;
            }
            set
            {
                NoteFile image = value;
                imageFile.SetFile(image);
                forderParent = image.Parent;
                imageFile.CopyFile = image;
                imageFile.Content = image.Content.CopyNote();
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

        public PictureBoxNote():base()
        {
            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            base.Image = NoteFile.ImageView;
        }

        public PictureBoxNote(PictureBox pictureBox) : this()
        {

            Image = pictureBox.Image;
        }

        public PictureBoxNote(PictureBoxNote pictureBox):this(pictureBox as PictureBox)
        {
            NoteFile = pictureBox.NoteInFolder();
        }


        public PictureBoxNote(TextFile imageFile):this()
        {
            NoteFile = imageFile.Copy().AsNote;
        }

        

        public new Image Image
        {
            get => new Bitmap(NoteFile.ImageView);
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
            get => NoteInFolder().FileName;
            set => NoteInFolder().FileName = value;
        }


        public override NoteFile TagProperty { get => NoteFile; set => NoteFile = value; }

        public NoteFile NoteInFolder()
        {
            int index = NoteFile.TemporaryIndex;
            return FolderParent[index].AsNote;
        }

    }
}
