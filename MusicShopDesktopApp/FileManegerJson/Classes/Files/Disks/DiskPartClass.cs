using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace FileManegerJson
{
    /// <summary>
    /// Раздел диска
    /// </summary>
    [DataContract]
    public class DiskPartClass : FolderClass
    {
        DiskClass disk;

        /// <summary>
        /// Примонтирован ли раздел к каталогу
        /// </summary>
        public bool Mount => Parent != null && !(Parent is null);

        public string MontPoint
        {
            get
            {
                if (Mount)
                    return "";
                else
                    return IndexNamePart + ":\\";
            }
        }

        /// <summary>
        /// Диск, которому принадлежит раздел
        /// </summary>
        public override DiskClass Disk => disk;

        /// <summary>
        /// Данный раздел
        /// </summary>
        public override DiskPartClass DiskPart => this;

        public int IndexPart => Disk.IndexOf(this);
        public string IndexNamePart => String.Join("-", disk.IndexDisk, IndexPart + ":");
        public override string IndexNameFile => base.IndexNameFile + $" ({IndexNamePart})";

        public DiskPartClass(DiskClass disk):base()
        {
            this.disk = disk;
            Disk.Add(this);
        }


    }
}
