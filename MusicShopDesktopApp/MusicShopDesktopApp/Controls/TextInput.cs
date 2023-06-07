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
    public partial class TextInput : UserControl
    {
        public TextInput()
        {
            InitializeComponent();
            PasswordChar = '\0';
            width = tableLayoutPanelPole.ColumnStyles[1].Width;
            
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

        private void TextInput_Load(object sender, EventArgs e)
        {
            textBoxInput.TextChanged += (s, ea) => InputText_Changed?.Invoke(this, ea);
        }

        public bool ShortcutsEnabled
        {
            get => textBoxInput.ShortcutsEnabled;
            set => textBoxInput.ShortcutsEnabled = value;
        }

        float width;

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
            get => groupBoxTitle.Text;
            set => groupBoxTitle.Text = value;
        }

        public override string Text { get => textBoxInput.Text; set => textBoxInput.Text = value; }

        public string Value { get => Text; set => Text = value; }

        public string InputText { get => Text; set => Text = value; }

        public event Action<object, EventArgs> InputText_Changed;
        

        public bool MultiLine
        {
            get => textBoxInput.Multiline;
            set => textBoxInput.Multiline = value;
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

        private void buttonClear_Click(object sender, EventArgs e)
        {

            Clear();
            
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


        private void textBoxInput_TextChanged(object sender, EventArgs e)
        {
            GetText?.Invoke(Text);
        }

        public delegate void GetTextControl(string text);

        public event GetTextControl GetText;

        public GetTextControl GetTextProperty
        {
            get => GetText;
            set => GetText = value;
        }

        private void groupBoxTitle_Enter(object sender, EventArgs e)
        {

        }

        private void buttonClear_VisibleChanged(object sender, EventArgs e)
        {
            bool visible = (sender as Button).Visible;
            float width = this.width;
            if (!visible)
                width = 5;
            tableLayoutPanelPole.ColumnStyles[1].Width = width;
        }

        private void textBoxInput_ReadOnlyChanged(object sender, EventArgs e)
        {
            buttonClear.Visible = NoReadOnly;
            ReadOnlyChanged?.Invoke(sender, e);
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

        private void textBoxInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ReadOnly)
            {
                
                return;
            }

            if (e.KeyChar == 27)
            {
                
                e.Handled = true;
                Text = "";
                return;
            }
            InputKeyPressToBox?.Invoke(this, e);
        }

        public event Action<object, KeyPressEventArgs> InputKeyPress;

        public Action<object, KeyPressEventArgs> InputKeyPressToBox
        {
            get => InputKeyPress;
            set => InputKeyPress = value;
        }
    }
}
