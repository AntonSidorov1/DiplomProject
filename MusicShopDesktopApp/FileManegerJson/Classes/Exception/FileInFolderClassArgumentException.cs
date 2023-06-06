using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManegerJson
{
    public abstract class FileInFolderClassArgumentException : ArgumentException
    {


        public FileInFolderClassArgumentException(string message) : base(message)
        {

        }

        protected FolderClass folder;
        protected string indexName = "";

        public FolderClass Folder => folder;
        public string IndexName => indexName;


        public FileInFolderClassArgumentException(FolderClass folder, string indexName, string message) : this(message)
        {
            this.folder = folder;
            this.indexName = indexName;
        }

        protected FileClass fileClass;
        public FileClass FileClass => fileClass;

        public FileInFolderClassArgumentException(FileClass file, string message):this(message)
        {
            this.fileClass = file;
        }


    }
}
