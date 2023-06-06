using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManegerJson
{
    public abstract class FilePictureBox : PictureBox
    {
        public FilePictureBox()
        {
        }

        public abstract int Index { get; set; }
        public abstract string IndexText { get; set; }

        public abstract FileClass GetFileNow();


        protected FolderClass forderParent;
        protected FolderClass FolderParent => forderParent;


        public FileClass FileNowInFolder()
        {
            int index = GetFileNow().TemporaryIndex;
            return FolderParent[index];
        }


    }
}
