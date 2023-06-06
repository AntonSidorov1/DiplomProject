using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace FileManegerJson
{
    public class PictureBoxOrg : PictureBoxFileClass<OrganizaionFile>, ITagInfoSecurity<OrganizaionFile>
    {
        OrganizaionFile imageFile = new OrganizaionFile();
        public OrganizaionFile OrganizaionFile
        { get
            {
                imageFile.PictureBox = this;
                return imageFile;
            }
            set
            {
                OrganizaionFile image = value;
                imageFile.SetFile(image);
                forderParent = image.Parent;
                imageFile.CopyFile = image;
                imageFile.Content = image.Content.CopyOrganization();
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

        public PictureBoxOrg():base()
        {
            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            base.Image = OrganizaionFile.ImageView;
        }

        public PictureBoxOrg(PictureBox pictureBox) : this()
        {

            Image = pictureBox.Image;
        }

        public PictureBoxOrg(PictureBoxOrg pictureBox):this(pictureBox as PictureBox)
        {
            OrganizaionFile = pictureBox.OrganizaionInFolder();
        }


        public PictureBoxOrg(SityFile imageFile):this()
        {
            OrganizaionFile = imageFile.Copy().AsOrganizaion;
        }

        

        public new Image Image
        {
            get => new Bitmap(OrganizaionFile.ImageView);
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
            get => OrganizaionInFolder().FileName;
            set => OrganizaionInFolder().FileName = value;
        }


        public override OrganizaionFile TagProperty { get => OrganizaionFile; set => OrganizaionFile = value; }

        public OrganizaionFile OrganizaionInFolder()
        {
            int index = OrganizaionFile.TemporaryIndex;
            return FolderParent[index].AsOrganizaion;
        }

    }
}
