using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FileManegerJson
{
    /// <summary>
    /// Файл-ссылка
    /// </summary>
    [DataContract]
    public abstract class LinkFile : NameFile
    {
        public LinkFile()
        {
        }

        public LinkFile(string name, bool file = true) : base(name, file)
        {
        }

        public LinkFile(string name, string fileName) : base(name, fileName)
        {
        }


        public LinkFile(FileClass contentFile) : this()
        {
            CreateContentFile(contentFile);
            Folder = contentFile.Parent;
        }

        public abstract void CreateContentFile(FileClass contentFile);

        /// <summary>
        /// Файл с содержимым
        /// </summary>
        public abstract FileClass FileContent { get; }

        public virtual Bitmap ImageDefault => new Bitmap(100, 100);

        public override Bitmap BitmapView
        {
            get
            {
                try
                {
                    return new Bitmap(FileContent.ImageView);
                }
                catch
                {
                    return ImageDefault;
                }
            }
        }

        FolderClass folder = new FolderClass();

        public FolderClass Folder
        {
            get => folder;
            set => folder = value;
        }
    }
}
