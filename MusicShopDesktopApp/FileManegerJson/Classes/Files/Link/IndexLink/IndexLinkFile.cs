using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManegerJson
{
    public class IndexLinkFile : LinkFile
    {
        public IndexLinkFile()
        {
        }

        public IndexLinkFile(string name, bool file = true) : base(name, file)
        {
        }

        public IndexLinkFile(string name, string fileName) : base(name, fileName)
        {
        }

        public IndexLinkFile(FileClass contentFile) : base(contentFile)
        {

        }

        public override string TypesFileJson => "Link File (*.linkf)|*.linkf|" +
            "Link File Json(*.linkf)|*.linkj|" +
            "Sidorov Link File (*.slink)|*.slink|" +
            "Anton Link File (*.alink)|*.alink";

        public override string TypesFileContent => TypesFileJson;

        public override string IndexClassName => "IndexLinkFile";

        public override FileClass FileContent => Folder[IndexContent];

        int indexContent;

        public int IndexContent
        {
            get => indexContent;
            set => indexContent = value;
        }

        public override FileClass Copy()
        {
            throw new NotImplementedException();
        }

        public static IndexLinkFile CraeteLink(FileClass file)
            => new IndexLinkFile(file);

        public override void SetContentFile(FileClass file)
        {
            try
            {
                if (file.IsLink)
                {
                    file.AsLink.Folder.Copy();
                    Folder = file.AsLink.Folder;
                }
            }
            catch
            {
                Folder = new FolderClass();
            }

            if(file.IsIndexLink)
            {
                IndexContent = file.AsIndexLink.IndexContent;
                
            }
        }

        public override void CreateContentFile(FileClass contentFile)
        {
            IndexContent = contentFile.Index;
        }

        public override Bitmap ImageDefault => Properties.Resources.IndexLink;
    }
}
