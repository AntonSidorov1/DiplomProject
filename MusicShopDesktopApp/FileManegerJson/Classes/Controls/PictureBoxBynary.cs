using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace FileManegerJson
{
    public class PictureBoxBynary : PictureBox, ITagInfoSecurity<BynaryImageFileJson>
    {
        BynaryImageFileJson imageFile = new BynaryImageFileJson();
        public BynaryImageFileJson ImageFile
        {
            get => imageFile; set
            {
                BynaryImageFileJson image = value;
                imageFile.SetImage(image);
                //forderParent = image.Parent;
            }
        }

        public new Bitmap Image
        {
            get => new Bitmap(ImageFile.Bitmap);
            set => ImageFile.Bitmap = new Bitmap(value);
        }

        public PictureBoxBynary():base()
        {
            ImageFile.ImageOutput = (BynaryImageFileJson file) =>
            {
                BynaryImageFileJson image = file;
                base.Image = image.Bitmap;
            };
        }

        object tagObject = "";
        string tagString = "";
        int tagInt = 0;
        public object TagObject { get => tagObject; set => tagObject = value; }
        public string TagString { get => tagString; set => tagString = value; }
        public int TagInt { get => tagInt; set => tagInt = value; }
        public BynaryImageFileJson TagProperty { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ref object RefTagObject => ref tagObject;

        public ref string RefTagString => ref tagString;

        public ref int RefTagInt => ref tagInt;

        public bool Security { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public BynaryImageFileJson PropertyOfSecurity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string TypesFileJson => throw new NotImplementedException();

        public string TypesFileJsonWithTxt => throw new NotImplementedException();

        public string TypesFileContent => throw new NotImplementedException();

        public string TypesFileContentWithTxt => throw new NotImplementedException();

        public string AllTypesFile => throw new NotImplementedException();
    }
}
