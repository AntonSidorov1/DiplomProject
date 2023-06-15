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
    public partial class FormIntNoteEdit : Form
    {
        public FormIntNoteEdit()
        {
            InitializeComponent();
        }


        public FormIntNoteEdit(int note) : this(note.ToString())
        {
            
        }


        public FormIntNoteEdit(NoteClass note) : this()
        {
            Note = note;
        }

        public FormIntNoteEdit(string name) : this(new NoteClass(name))
        {
            
        }

        public FormIntNoteEdit(ProductParameter parameter) : this(parameter.CopyNote())
        {

        }

        public FormIntNoteEdit(ProductParameterFile file) : this(file.Parameter)
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

        public int IntValue
        {
            get
            {
                try
                {
                    return Convert.ToInt32(Value);
                }
                catch
                {
                    return 0;
                }
            }
            set => Value = value.ToString();
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
            Value = textBoxWihSetNewValue.Value;
            buttonCancel_Click(sender, e);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormNoteEdit_Load(object sender, EventArgs e)
        {
            textBoxWihSetNewValue.Value = Value;
            //textInputNewValue.VirtualKeyBord = true;
        }

        private void buttonTextChange_Click(object sender, EventArgs e)
        {
            IntNoteFile textFile = new IntNoteFile();
            try
            {
                textFile.Content.Value = Convert.ToInt32(textBoxWihSetNewValue.Text);
            }
            catch
            {
                textFile.Content.Value = 0;
            }

            bool yes = false;
            DiskForm disk = new DiskForm(textFile, ref yes, this);
            Hide();
            disk.ShowDialog();
            Show();

            try
            {
                if (disk.YesChoose)
                {

                    textBoxWihSetNewValue.Text = textFile.Content.Value.ToString();
                }
            }
            catch
            {

            }
            disk.Dispose();

        }

        private void buttonSetDialog_Click(object sender, EventArgs e)
        {
            textBoxWihSetNewValue.Text = Interaction.InputBox("Введите значние", "Новое значение", textBoxWihSetNewValue.Text);
        }

        private void checkBoxKeyBord_CheckedChanged(object sender, EventArgs e)
        {
            textBoxWihSetNewValue.VirtualKeyBord = (sender as CheckBox).Checked;
        }


        private void buttonFewWindow_Click(object sender, EventArgs e)
        {
            FormIntNoteEdit form = new FormIntNoteEdit(textBoxWihSetNewValue.Text);
            Hide();
            form.ShowDialog();
            Show();
            if (form.Save)
            {
                textBoxWihSetNewValue.Text = form.Value;
            }
        }

        private void textBoxWihSetNewValue_UpdateText(ref string text)
        {
            if (text == "")
                return;
            if(!int.TryParse(text, out int number))
            {
                text = "";
            }
        }

        private void textBoxWihSetNewValue_InputKeyPress(object arg1, KeyPressEventArgs e)
        {
            if(e.KeyChar == '-')
            {
                e.Handled = true;
                try
                {
                    int number = Convert.ToInt32(textBoxWihSetNewValue.Value);
                    number *= (-1);
                    textBoxWihSetNewValue.Value = number.ToString();
                }
                catch
                {

                }
                return;
            }
            if (e.KeyChar == 8 || char.IsDigit(e.KeyChar))
                return;
            e.Handled = true;

            if(e.KeyChar == 27)
            {
                textBoxWihSetNewValue.Clear();
            }

        }

        private void textBoxWihSetNewValue_Load(object sender, EventArgs e)
        {

        }
    }
}
