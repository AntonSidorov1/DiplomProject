using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManegerJson
{
    public class TraidingPointFile : ProductParameterFile<DistributingPoint>
    {
        public TraidingPointFile()
        {
        }

        public TraidingPointFile(DistributingPoint content) : base(content)
        {
        }

        public TraidingPointFile(ProductParameterFile<DistributingPoint> file) : base(file)
        {
        }

        public TraidingPointFile(string name, bool file = true) : base(name, file)
        {
        }

        public TraidingPointFile(string name, string fileName) : base(name, fileName)
        {
        }

        public TraidingPointFile(string name, DistributingPoint content) : base(name, content)
        {
        }

        public TraidingPointFile(string name, string fileName, DistributingPoint content) : base(name, fileName, content)
        {
        }

        public override string TypesFileJson => "Traiding Point Json (*.trpj)|*.trpj|Traiding Point File (*.trpf)|*.trpf";

        public override string TypesFileContent => "Traiding Point Content (*.trpc)|*.trpc|Traiding Point File (*.trpf)|*.trpf";

        public override string IndexClassName => "TraidingPointFile";

        public override FileClass Copy()
        {
            return Create(this);
        }

        public override void SetContentFile(FileClass file)
        {
            if (file.IsProductParameter)
            {
                Content = file.AsProductParameter.ParameterTraidingPoint;
            }
        }

        public override ProductParameterFile CreateNewFile()
        {
            return new TraidingPointFile();
        }

        public override void SetParametersContent(DistributingPoint content)
        {
            Content = content.CopyTraidingPoint();
        }

        protected override void CreateContent(DistributingPoint content)
        {
            Content = content.CopyTraidingPoint();
        }

        protected override DistributingPoint PutContent()
        {
            return new DistributingPoint();
        }


        public static TraidingPointFile Load(string fileName)
        {

            try
            {
                TraidingPointFile dataBase = ((TraidingPointFile)JsonRead(fileName, typeof(TraidingPointFile))).AsTraidingPoint;
                if (dataBase.Content == null || dataBase.Content is null)
                    throw new Exception();
                return dataBase;
            }
            catch
            {
                TraidingPointFile dataBase = new TraidingPointFile(fileName, false)
                {
                    Content = ((DistributingPoint)JsonRead(fileName, typeof(DistributingPoint)))
                };
                return dataBase;
            }
        }

        public override void FromFile(AbstractFileClass file)
        {
            base.FromFile(file);
            if (file is FileClass)
            {
                FileClass fileClass = file as FileClass;
                if (fileClass.IsProductParameter)
                {
                    Content = fileClass.AsProductParameter.ParameterTraidingPoint;
                }
            }
        }


        public override Bitmap BitmapView => Properties.Resources.TraidingPoint;

        public override string FileType => "Торговая точка";
    }
}
