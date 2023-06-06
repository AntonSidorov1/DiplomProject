using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace FileManegerJson
{
    public partial class FormNoteEdit : Form
    {
        public FormNoteEdit()
        {
            InitializeComponent();
        }

        public FormNoteEdit(NoteClass note) : this()
        {
            Note = note;
        }

        public FormNoteEdit(string name) : this(new NoteClass(name))
        {
            
        }

        public FormNoteEdit(ProductParameter parameter) : this(parameter.CopyNote())
        {

        }

        public FormNoteEdit(ProductParameterFile file) : this(file.Parameter)
        {

        }


        NoteClass note = new NoteClass();

        public NoteClass Note
        {
            get => note;
            set => note = value;
        }

        public string Value
        {
            get => Note.Name;
            set => Note.Name = value;
        }

        bool save = false;
        public bool Save
        {
            get => save;
            set => save = value;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Save = true;
            Value = textInputNewValue.Value;
            buttonCancel_Click(sender, e);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormNoteEdit_Load(object sender, EventArgs e)
        {
            textInputNewValue.Value = Value;
            //textInputNewValue.VirtualKeyBord = true;
        }

        private void buttonTextChange_Click(object sender, EventArgs e)
        {
            NoteFile textFile = new NoteFile();
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
            textInputNewValue.Text = Interaction.InputBox("Введите значние", "Новое значение", textInputNewValue.Text);
        }

        private void checkBoxKeyBord_CheckedChanged(object sender, EventArgs e)
        {
            textInputNewValue.VirtualKeyBord = (sender as CheckBox).Checked;
        }
    }
}
