using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManegerJson
{
    public class ResizeScroolPanel : FlowLayoutPanel
    {
        public ResizeScroolPanel() : base()
        {
            SizeChanged += ResizePanel_SizeChanged;
        }

        private void ResizePanel_SizeChanged(object sender, EventArgs e)
        {
            SizeUpdate();
        }

        public void SizeUpdate()
        {
            ControlCollection controls = Controls;
            for (int i = 0; i < controls.Count; i++)
            {
                controls[i].Width = this.Width - DeltaWith;
                controls[i].Refresh();
            }
        }

        int deltaWith = 80;

        public int DeltaWith
        {
            get => deltaWith;
            set => deltaWith = value;
        }
    }
}
