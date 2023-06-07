using Microsoft.VisualBasic;
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
    public partial class SityEditForm : Form
    {
        public SityEditForm()
        {
            InitializeComponent();
        }

        public SityEditForm(string sity):this()
        {
            Value = sity;

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSity_Click(object sender, EventArgs e)
        {
            SityFile textFile = new SityFile();
            textFile.Content.Name = textInputNewValue.Text;

            bool yes = false;
            DiskForm disk = new DiskForm(textFile, ref yes, this);
            Hide();
            disk.ShowDialog();
            Show();

            try
            {
                if (disk.YesChoose)
                {

                    textInputNewValue.Text = textFile.Content.Name;
                }
            }
            catch
            {

            }
            disk.Dispose();
        }

        private void buttonSetDialog_Click(object sender, EventArgs e)
        {
            textInputNewValue.Text = Interaction.InputBox("Введите новое название города", "Новое название города", textInputNewValue.Text);
        }

        private void checkBoxKeyBord_CheckedChanged(object sender, EventArgs e)
        {
            textInputNewValue.VirtualKeyBord = (sender as CheckBox).Checked;
        }

        private void buttonTexInput_Click(object sender, EventArgs e)
        {
            FormNoteEdit form = new FormNoteEdit(textInputNewValue.Text);
            Hide();
            form.ShowDialog();
            Show();
            if (!form.Save)
            {
                return;
            }
            textInputNewValue.Text = form.Value;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Save = true;
            Value = textInputNewValue.Value;
            buttonBack_Click(sender, e);
        }

        bool save = false;


        public bool Save
        {
            get => save;
            set => save = value;
        }

        string text = "";

        public string Value
        {
            get => text;
            set => text = value;
        }

        private void SityEditForm_Load(object sender, EventArgs e)
        {
            textInputNewValue.Value = Value;
        }

        private void buttonFewWindow_Click(object sender, EventArgs e)
        {
            SityEditForm form = new SityEditForm(textInputNewValue.Text);
            Hide();
            form.ShowDialog();
            Show();
            if (form.Save)
            {
                textInputNewValue.Text = form.Value;
            }
        }
    }
}
