using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicShopDesktopApp
{
    public partial class Pattern : Form
    {

        public new void Show()
        {
            base.Show();
            timerUpdate.Start();
        }

        public new void Hide()
        {
            timerUpdate.Stop();
            base.Hide();
        }

        public new void Close()
        {
            Hide();
            base.Close();
        }

        public Pattern()
        {
            InitializeComponent();
        }


        string text = "";

        string textID => text;

        private void Model_Load(object sender, EventArgs e)
        {
            text = Text;
            this.Text = textID + " - " + Application.ProductName + " - " + Application.ProductVersion;

            notifyIconApp.Text = Text;

            UpdateView();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            string date = now.ToLongDateString();
            string time = now.ToLongTimeString();
            toolStripStatusLabelDate.Text = date;
            toolStripStatusLabelTime.Text = time;
        }

        bool UpdateView()
        {
            timerUpdate.Stop();

            if (!UpdateForm())
                return false;

            timerUpdate.Start();
            return true;
        }

        bool UpdateForm()
        {
            this.Text = textID+ " - " + Application.ProductName + " - " + Application.ProductVersion;
            notifyIconApp.Text = Text;
            labelTitle.Text = textID;


            return true;
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            UpdateView();
        }
    }
}
