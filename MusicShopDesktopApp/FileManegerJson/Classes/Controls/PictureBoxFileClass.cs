using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManegerJson
{
    public abstract class PictureBoxFileClass<T> : FilePictureBox, ITagInfoSecurity<T> where T : FileClass
    {
        public PictureBoxFileClass() : base()
        {

        }

        public override FileClass GetFileNow()
        {
            return TagProperty;
        }


        public PictureBoxFile ImageFile => new PictureBoxFile(GetFile.ImageFileView);

        public override int Index{get => GetFile.TemporaryIndex; set => GetFile.TemporaryIndex = value;}
        public override string IndexText { get => GetFile.TemporaryIndexText; set => GetFile.TemporaryIndexText = value; }

        protected object tagObject = "";
        protected string tagString = "";
        protected int tagInt = 0;


        public object TagObject { get => tagObject; set => tagObject = value; }
        public string TagString { get => tagString; set => tagString = value; }
        public int TagInt { get => tagInt; set => tagInt = value; }

        public abstract T TagProperty { get; set; }

        public ref object RefTagObject => ref tagObject;

        public ref string RefTagString => ref tagString;

        public ref int RefTagInt => ref tagInt;

        public T GetFile => PropertyOfSecurity;

        public bool Security { get => GetFile.Security; set => GetFile.Security = value; }

        public T PropertyOfSecurity { get => TagProperty; set => TagProperty = value; }


        public string TypesFileJson => GetFile.TypesFileJson;

        public string TypesFileJsonWithTxt => GetFile.TypesFileJson;

        public string TypesFileContent => GetFile.TypesFileContent;

        public string TypesFileContentWithTxt => GetFile.TypesFileContentWithTxt;

        public string AllTypesFile => GetFile.AllTypesFile;


        public FileClass FileInFolder()
        {
            return FileInFolder(FolderParent);
        }

        public FileClass FileInFolder(FolderClass folderParent)
        {
            int index = GetFile.TemporaryIndex;
            return folderParent[index];
        }

        public string FileName2
        {
            get => FileInFolder().FileName;
            set => FileInFolder().FileName = value;
        }

    }
}
