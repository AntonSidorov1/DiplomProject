using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManegerJson
{
    /// <summary>
    /// Диск
    /// </summary>
    public abstract class DiskClass : FileClass, IList<DiskPartClass>
    {
        List<DiskPartClass> diskParts = new List<DiskPartClass>();
        public bool IsHardDisk() => this is HardDiskClass;
        public HardDiskClass AsHardDisk() => this as HardDiskClass;

        DisksFew few;
        public override DisksFew DisksFew => few;

        /// <summary>
        /// Данный диск
        /// </summary>
        public override DiskClass Disk => this;

        public void SetFew(DisksFew few)
        {
            this.few = few;
        }

        public void SetFew()
        {
            SetFew(DisksFew.Disks);
        }

        public DiskClass(DisksFew few) : base()
        {
            SetFew(few);
            few.AddDisk(this);
        }

        public DiskClass() : this(DisksFew.Disks)
        {

        }

        public int IndexPortDisk => few.IndexDisk(this);

        public string PortDisk
        {
            get => few.PortDisk(this);
            //set => base.IndexFileName = value;
        }

        public abstract string TypeDisk { get; }

        public virtual string DiskText => "d";

        public new string IndexFileName
        {
            get => String.Join("-", TypeDisk, DiskText, PortDisk);
        }

        public string IndexDisk => IndexFileName;


        public override string TypesFileJson => "";

        public override string TypesFileContent => "";

        public override string IndexClassName => "";

        public int Count => diskParts.Count;

        public bool IsReadOnly => throw new NotImplementedException();

        DiskPartClass IList<DiskPartClass>.this[int index] { get => diskParts[index]; set => diskParts[index] = value; }
        public DiskPartClass this[int index] { get => diskParts[index];  }

        public override FileClass Copy()
        {
            return this;
        }

        public int IndexOf(DiskPartClass part)
        {
            return diskParts.IndexOf(part);
        }

        public void Insert(int index, DiskPartClass item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public void Add(DiskPartClass diskPart)
        {
            if (NoContains(diskPart))
                diskParts.Add(diskPart);
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(DiskPartClass diskPart)
        {
            return diskParts.Contains(diskPart);
        }

        public bool NoContains(DiskPartClass diskPart)
        {
            return !Contains(diskPart);
        }

        public void CopyTo(DiskPartClass[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(DiskPartClass item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<DiskPartClass> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
