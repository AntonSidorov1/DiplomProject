using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace FileManegerJson
{
    public class PictureBoxIntNote : PictureBoxFileClass<IntNoteFile>, ITagInfoSecurity<IntNoteFile>
    {
        IntNoteFile imageFile = new IntNoteFile();
        public IntNoteFile NoteFile
        { get
            {
                imageFile.PictureBox = this;
                return imageFile;
            }
            set
            {
                IntNoteFile image = value;
                imageFile.SetFile(image);
                forderParent = image.Parent;
                imageFile.CopyFile = image;
                imageFile.Content = image.Content.Copy();
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

        public PictureBoxIntNote():base()
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

        public PictureBoxIntNote(PictureBox pictureBox) : this()
        {

            Image = pictureBox.Image;
        }

        public PictureBoxIntNote(PictureBoxIntNote pictureBox):this(pictureBox as PictureBox)
        {
            NoteFile = pictureBox.NoteInFolder();
        }


        public PictureBoxIntNote(IntNoteFile imageFile):this()
        {
            NoteFile = imageFile.Copy().AsIntNote;
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


        public override IntNoteFile TagProperty { get => NoteFile; set => NoteFile = value; }

        public IntNoteFile IntNoteFile { get => NoteFile; set => NoteFile = value; }

        public IntNoteFile IntNoteInFolder() => NoteInFolder();
        public IntNoteFile NoteInFolder()
        {
            int index = NoteFile.TemporaryIndex;
            return FolderParent[index].AsIntNote;
        }

    }
}
