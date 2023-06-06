using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManegerJson
{
    class FolderButon : Button
    {
        public FolderButon()
        {
            Click += FolderButon_Click;
        }

        private void FolderButon_Click(object sender, EventArgs e)
        {
            UpdaeFloder?.Invoke(Folder);
        }

        FolderClass folder;

        public FolderClass Folder
        {
            get => folder;
            set => folder = value;
        }

        public delegate void GetFolder(FolderClass folder);

        public event GetFolder UpdaeFloder;

        public GetFolder UpdaeFloderProperty
        {
            get => UpdaeFloder;
            set => UpdaeFloder = value;
        }

        public void UpdateContent() => UpdaeFloderProperty?.Invoke(Folder);
    }
}
