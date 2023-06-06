using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManegerJson
{
    public class DisksFew : FileClass
    {
        public static DisksFew Disks => GetDisks();
        static DisksFew disks;

        HardDiskClass[] hardDisks;
        DiskClass[] cDs;
        DiskClass[] sdCards;
        DiskClass[] flashDisks;

        void SetHardDisks()
        {
            hardDisks = new HardDiskClass[GetPorts().Length];
        }

        public void AddHardDisk(HardDiskClass hardDisk)
        {
            HardDisks()[IndexHardDiskPlace()] = hardDisk;
        }

        public int IndexHardDisk(HardDiskClass hardDisk)
        {
            return hardDisksList().IndexOf(hardDisk);
        }

        public int IndexDisk(DiskClass disk)
        {
            if(disk.IsHardDisk())
            {
                return IndexHardDisk(disk.AsHardDisk());
            }
            return -1;
            
        }

        public string GetPort(int index) => GetPorts()[index];

        public string PortDisk(DiskClass disk)
        {
            int index = IndexDisk(disk);
            return GetPort(index);
        }

        List<string> PortsList() => new List<string>(GetPorts());

        HardDiskClass[] HardDisks()
        {
            try
            {
                if (hardDisks.Length < 1)
                    throw new Exception();
            }
            catch
            {
                hardDisks = new HardDiskClass[GetPorts().Length];
            }
            return hardDisks;
        }

        List<HardDiskClass>hardDisksList()
        {
            try
            {
                return new List<HardDiskClass>(hardDisks);
            }
            catch
            {
                hardDisks = new HardDiskClass[GetPorts().Length];
                return new List<HardDiskClass>(hardDisks);
            }
        }

        

        public HardDiskClass[] GetHardDisks()
        {
            return hardDisksList().FindAll(p => p != null && !(p is null)).ToArray();
        }

        public HardDiskClass GetHardDisk(int index)
        {
            return hardDisksList()[index];
        }

        public void AddDisk(DiskClass disk)
        {
            if (disk.IsHardDisk())
                AddHardDisk(disk.AsHardDisk());
        }

        public DiskClass GetDisk(string indexDisk)
        {
            string[] parts = indexDisk.Split('-');
            string type = parts[1];
            if (type == "h" || type.Equals("-"))
                return GetHardDisk(parts[2]);
            throw new ArgumentException("Такой диск отсутствует");

        }

        public HardDiskClass GetHardDisk(string port)
        {
            return GetHardDisk(PortsList().IndexOf(port));
        }

        public int IndexHardDiskPlace()
        {
            int count = 0;
            try
            {
                count = hardDisks.Length;
                if (count < 1)
                    throw new Exception();
            }
            catch
            {
                SetHardDisks();
                count = hardDisks.Length;

            }

            for(int i = 0; i < count; i++)
            {
                if(hardDisks[i] == null || hardDisks[i] is null)
                {
                    return i;
                }
            }
            return -1;
        }

        public bool HaveHardDiskPlace() => IndexHardDiskPlace() > -1;

        public string PortFromIndex(int index) => GetPorts()[index];

        public string GetPortHardDiskPort() => PortFromIndex(IndexHardDiskPlace());

        public string[] GetPorts()
        {
            

            string[] portsList = new string[] {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

            List<string> ports = new List<string>();
            for(int i = 0; i < portsList.Length; i++)
            {
                ports.Add(portsList[i]);
            }
            for(int i = 0; i < portsList.Length; i++)
            {
                for(int j = 0; j < portsList.Length; j++)
                {
                    ports.Add(portsList[i] + portsList[j]);
                }
            }

            return ports.ToArray();
        }


        public DisksFew() : base()
        {

        }

        public static DisksFew GetDisks()
        {
            try
            {
                if (disks == null || disks is null)
                    throw new Exception();
                return disks;
            }
            catch(Exception ex)
            {
                disks = new DisksFew();
                return GetDisks();
            }
        }

        public override string TypesFileJson => "";

        public override string TypesFileContent => "";

        public override string IndexClassName => "";

        public override FileClass Copy()
        {
            return this;
        }

        public override void SetContentFile(FileClass file)
        {
            
        }
    }
}
