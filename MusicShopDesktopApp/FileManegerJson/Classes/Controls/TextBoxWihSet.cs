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
    public partial class TextBoxWihSet : UserControl
    {
        public TextBoxWihSet()
        {
            InitializeComponent();
        }

        private void TextBoxWihSet_Load(object sender, EventArgs e)
        {

        }


        public bool VirtualKeyBord
        {
            get => textBoxInput.VirtualKeyBord;
            set => textBoxInput.VirtualKeyBord = value;
        }

        public bool HaveKeyBord
        {
            get => textBoxInput.HaveKeyBord;
            set => textBoxInput.HaveKeyBord = value;
        }


        public static bool NullText(string text)
        {
            return text == "" || text.Equals("") || text is null || text == null;
        }

        public int MaxLength
        {
            get => textBoxInput.MaxLength;
            set => textBoxInput.MaxLength = value;
        }

        public HorizontalAlignment TextAlign
        {
            get => textBoxInput.TextAlign;
            set => textBoxInput.TextAlign = value;
        }

        public bool NullValue => NullText(Value);


        public ScrollBars ScrollBars
        {
            get => textBoxInput.ScrollBars;
            set => textBoxInput.ScrollBars = value;
        }

        public bool ReadOnly
        {
            get => textBoxInput.ReadOnly;
            set
            {
                textBoxInput.ReadOnly = value;
            }
        }

        public string Title
        {
            get => textBoxInput.Title;
            set => textBoxInput.Title = value;
        }

        public override string Text { get => textBoxInput.Text; set => textBoxInput.Text = value; }

        public string Value { get => Text; set => Text = value; }

        public string InputText { get => Text; set => Text = value; }

        public bool MultiLine
        {
            get => textBoxInput.MultiLine;
            set => textBoxInput.MultiLine = value;
        }

        public ScrollBars TextScrollBar
        {
            get => textBoxInput.ScrollBars;
            set => textBoxInput.ScrollBars = value;

        }

        public HorizontalAlignment InputTextAlign
        {
            get => textBoxInput.TextAlign;
            set => textBoxInput.TextAlign = value;
        }


        public void Clear()
        {
            textBoxInput.Text = "";
        }

        public bool UseSystemPasswordChar
        {
            get => textBoxInput.UseSystemPasswordChar;
            set => textBoxInput.UseSystemPasswordChar = value;
        }

        public char PasswordChar
        {
            get => textBoxInput.PasswordChar;
            set => textBoxInput.PasswordChar = value;
        }



        public event Action<object, KeyPressEventArgs> InputKeyPress;

        public Action<object, KeyPressEventArgs> InputKeyPressToBox
        {
            get => InputKeyPress;
            set => InputKeyPress = value;
        }


        public event Action<object, EventArgs> InputLeave;

        private void textBoxInput_Leave(object sender, EventArgs e)
        {
            InputLeave?.Invoke(sender, e);
        }

        public event Action<object, EventArgs> InputEnter;

        private void textBoxInput_Enter(object sender, EventArgs e)
        {
            InputEnter?.Invoke(sender, e);

        }


        public event Action<object, KeyEventArgs> InputKeyDown;

        private void textBoxInput_KeyDown(object sender, KeyEventArgs e)
        {
            InputKeyDown?.Invoke(sender, e);
        }

        public event Action<object, KeyEventArgs> InputKeyUp;

        private void textBoxInput_KeyUp(object sender, KeyEventArgs e)
        {
            InputKeyUp?.Invoke(sender, e);
        }

        private void textBoxInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            InputKeyPressToBox?.Invoke(this, e);
        }


        public event Action<object, EventArgs> ReadOnlyChanged;

        public bool NoReadOnly
        {
            get => !ReadOnly;
            set => ReadOnly = !value;
        }

        public Color InputBackColor
        {
            get => textBoxInput.BackColor;
            set => textBoxInput.BackColor = value;
        }

        public Color InputForeColor
        {
            get => textBoxInput.ForeColor;
            set => textBoxInput.ForeColor = value;
        }

        public void SetReadOnlyOrNoReadOnly()
        {
            bool readOnly = ReadOnly;
            NoReadOnly = readOnly;
            readOnly = ReadOnly;
            NoReadOnly = readOnly;
        }

        private void textBoxInput_ReadOnlyChanged(object sender, EventArgs e)
        {
            buttonSet.Visible = NoReadOnly;
            ReadOnlyChanged?.Invoke(sender, e);
        }

        public event Action<object, EventArgs> InputText_Changed;

        private void TextBoxInput_TextChanged(object sender, EventArgs e)
        {
            InputText_Changed?.Invoke(sender, e);
            TextInputChanged?.Invoke(this, this, sender as TextInputEdit, sender, this, e, Text);

        }

        public delegate void ControlChanged(object sender,
            Control senderControl,
            TextInputEdit controlInput,
            object senderInput,
            TextBoxWihSet textInputContol,
            EventArgs e,
            string text);

        public event ControlChanged TextInputChanged;

        private void buttonSet_Click(object sender, EventArgs e)
        {
            if (!MultiLine)
            {
                FormNoteEdit form = new FormNoteEdit(Value);
                Hide();
                form.ShowDialog();
                Show();
                if (form.Save)
                {
                    Value = form.Value;
                }
            }
            else
            {
                TextForm form = new TextForm(Value);
                Hide();
                form.ShowDialog();
                Show();
                if (form.Save)
                {
                    Value = form.Value;
                }
            }
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Value, Title);
        }

        private void buttonSet_VisibleChanged(object sender, EventArgs e)
        {
            Button set = (sender as Button);
            tableLayoutPanelEdit.ColumnStyles[0].SizeType = set.Visible ? SizeType.Percent : SizeType.Absolute;
            tableLayoutPanelEdit.ColumnStyles[0].Width = !set.Visible ? 5 : 50;
            tableLayoutPanelEdit.ColumnStyles[1].Width = 50;

        }
    }
}
