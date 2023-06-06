using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManegerJson
{
    public class HardDiskClass : DiskClass
    {
        public HardDiskClass() : base()
        {
        }

        public HardDiskClass(DisksFew few) : base(few)
        {
        }

        public override string TypeDisk => "h";

        public override void SetContentFile(FileClass file)
        {
            
        }
    }
}
