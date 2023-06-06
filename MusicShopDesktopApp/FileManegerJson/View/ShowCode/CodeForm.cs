using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FileManegerJson
{
    public partial class CodeForm : Form
    {
        public CodeForm()
        {
            InitializeComponent();
        }

        public CodeForm(string code) : this()
        {
            textBoxCode.Text = code;
            byte[] photo = Convert.FromBase64String(code);
            //textBoxByteCode.Text = photo.ToString();
            MemoryStream memory = new MemoryStream(photo);
            string byteCode = BitConverter.ToString(photo);
            textBoxByteCode.Text = byteCode;
            textBoxHCode.Text = "0x" + byteCode.Replace("-", "");
            Bitmap bit = new Bitmap(memory);
            pictureBoxImage.Image = bit;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CodeForm_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanelImage_SizeChanged(object sender, EventArgs e)
        {
            tableLayoutPanelImage.Width = (sender as Panel).Width - 40;
        }
    }
}
