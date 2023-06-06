using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManegerJson
{
    class PanelTagString : Panel, ITagStringControlView
    {
        public PanelTagString():base()
        {

        }

        string tagString = "";
        public string TagString { get => tagString; set => tagString = value; }
    }
}
