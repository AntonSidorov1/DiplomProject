using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicShopDesktopApp.Controls
{
    public partial class PictureBoxWithName : UserControl
    {
        public PictureBoxWithName()
        {
            InitializeComponent();
        }

        private void PictureBoxWithName_Load(object sender, EventArgs e)
        {

        }

        public Image Image
        {
            get => pictureBoxImage.Image;
            set => pictureBoxImage.Image = value;
        }

        public string Title
        {
            get => groupBoxMain.Text;
            set => groupBoxMain.Text = value;
        }
    }
}
