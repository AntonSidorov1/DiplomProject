using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManegerJson
{
    public class FileEpsendInFolderClassException : FileInFolderClassArgumentException
    {
        public FileEpsendInFolderClassException() : this("Отсутствует заданный файл")
        {
        }

        public FileEpsendInFolderClassException(string message) : base(message)
        {
        }
        public FileEpsendInFolderClassException(FolderClass folder, string indexName) : this(folder, indexName, $"В катологе {folder.IndexFileName} отсутствует файл {folder.IndexFileName}")
        {
        }

        public FileEpsendInFolderClassException(FolderClass folder, string indexName, string message) : base(folder, indexName, message)
        {
        }
    }
}
