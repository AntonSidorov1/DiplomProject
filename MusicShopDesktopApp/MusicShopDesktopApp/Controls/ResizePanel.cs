using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicShopDesktopApp
{
    public delegate void ControlSizeUpdate(Control control, Size size);
    public class ResizePanel : FlowLayoutPanel
    {
        public ResizePanel() : base()
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
            SizeUpdated?.Invoke(this, new EventArgs());
            ControlSizeUpdated?.Invoke(this, Size);
        }

        public event EventHandler SizeUpdated;
        public event ControlSizeUpdate ControlSizeUpdated;

        int deltaWith = 80;

        public int DeltaWith
        {
            get => deltaWith;
            set => deltaWith = value;
        }
    }
}
