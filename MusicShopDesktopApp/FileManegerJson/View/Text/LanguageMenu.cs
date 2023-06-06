using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManegerJson
{
    public partial class LanguageMenuView : Form
    {

        public LanguageMenuView()
        {
            

            InitializeComponent();
        }

        int index = 0;
        LanguagesEditListClass languges = new LanguagesEditListClass();
        LangugeEditClass languge = new LangugeEditClass();
        Form form;

        public LanguageMenuView(int index, LanguagesEditListClass languges, LangugeEditClass languge, Form form) : this()
        {
            Text = languge.Name;
            this.index = index;
            this.languges = languges;
            this.languge = languge;
            this.form = form;
        }

        private void LanguageMenu_Load(object sender, EventArgs e)
        {

            Size size = this.Size;
            this.Font = new Font(new FontFamily("Times New Roman"), 12, FontStyle.Bold | FontStyle.Italic);
            this.Size = size;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            languges.RemoveAt(index);
            Close();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            Hide();
            LangugeEditForm form = new LangugeEditForm(languge);
            form.ShowDialog();
            Close();
        }
    }
}
