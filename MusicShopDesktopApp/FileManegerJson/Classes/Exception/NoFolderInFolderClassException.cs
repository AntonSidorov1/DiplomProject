using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FileManegerJson
{
    public class NoFolderInFolderClassException : FileInFolderClassArgumentException
    {

        public NoFolderInFolderClassException(string message) : base(message)
        {
        }

        public NoFolderInFolderClassException():this("Данный файл не является каталогом")
        {

        }

        protected FileClass file;
        protected FileClass File => file;

        public NoFolderInFolderClassException(FolderClass folder, string indexName, string message) : base(folder, indexName, message)
        {
            file = folder[indexName];
        }

        public NoFolderInFolderClassException(FolderClass folder, string indexName):this(folder, indexName, $"Файл {indexName} в каталоге {folder.IndexFileName} не является каталогом")
        {

        }

        public NoFolderInFolderClassException(FileClass file, string message) : base(file, message)
        {

        }

        public NoFolderInFolderClassException(FileClass file) : base(file, $"Файл {file.IndexFileName} не является каталогом")
        {

        }


    }
}
