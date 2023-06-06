using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManegerJson
{
    public class TextBoxPoleView: TextBox, KeyBordControlView
    {
        protected TextBox TextBox => this;

        public TextBoxPoleView():base()
        {
            base.KeyPress += TextBox_KeyPress;
            TextBox.Enter += TextBox_Enter;
            TextBox.Leave += TextBox_Leave;

            //DefaultPadding

            
        }

        

        bool virtalKeyBord = false;
        protected bool VirtualKeyBord1 { get => virtalKeyBord; set => virtalKeyBord = value; }
        public bool ValueInputToPole { get => !ReadOnly; set => ReadOnly = !value; }

        protected KeyBordEditForm KeyBordForm1 { get => KeyBord; set
            {
                KeyBord = value;
                HaveKeyBord1 = true;
            }
        }


        bool haveKeyBord = false;

        protected bool HaveKeyBord1
        {
            get
            {
                if (KeyBord is null || KeyBord == null)
                {
                    HaveKeyBord1 = false;
                }
                return haveKeyBord;
            }
            set
            {
                if (KeyBord is null || KeyBord == null)
                {
                    haveKeyBord = false;
                    return;
                }
                haveKeyBord = value;
            }
        }


        protected void TextBox_Leave(object sender, EventArgs e)
        {

            //TextPole.Font = new Font(TextPole.Font.FontFamily, font, TextPole.Font.Style);
            //this.Height = height;
            try
            {
                if (HaveKeyBord1)
                    KeyBord.Hide();
                else
                    KeyBord.Close();
            }
            catch
            {

            }
        }

        public bool InputPole { get => !ReadOnly; set => ReadOnly = !value; }

        protected void TextBox_Enter(object sender, EventArgs e)
        {
            //font = TextBox.Font.Height; height = this.Height;
            //TextPole.Font = new Font(TextPole.Font.FontFamily, (int)(TextPole.Font.Size * 1.5f), TextPole.Font.Style);
            //this.Height = (int)(this.Height * 1.5);

            if (VirtualKeyBord1 && InputPole)
            {
                KeyBordEditForm keyBord = new KeyBordEditForm(this);
                if (HaveKeyBord1)
                {
                    try
                    {
                        keyBord = KeyBord;
                        keyBord.Show();
                    }
                    catch
                    {
                        keyBord = new KeyBordEditForm(this);
                        keyBord.Show();
                    }
                }
                else
                    keyBord.Show();
                KeyBord = keyBord;
            }

        }

        KeyBordEditForm KeyBord;

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                try
                {
                    TextBoxPress(sender, e);
                }
                catch
                {

                }

                KeyPress(this, e);
            }
            catch
            {

            }
        }

        public new event KeyPressEventHandler KeyPress;
        protected KeyPressEventHandler TextBoxPress;

        protected void SetTextBox(TextBoxBase textBox)
        {
            Text = textBox.Text;
            Dock = textBox.Dock;
            Multiline = textBox.Multiline;
            BackColor = textBox.BackColor;
            ForeColor = textBox.ForeColor;
            Font = textBox.Font;
            ReadOnly = textBox.ReadOnly;
            Tag = textBox.Tag;
            //Visible = textBox.Visible;
            Enabled = textBox.Enabled;
            if (textBox is TextBox)
                ScrollBars = (textBox as TextBox).ScrollBars;
        }

        protected void SetTextBox(ITextValueControlView textBox)
        {
            Text = textBox.Text;
            Dock = textBox.Dock;
            Multiline = textBox.Multiline;
            BackColor = textBox.BackColor;
            ForeColor = textBox.ForeColor;
            Font = textBox.Font;
            ReadOnly = textBox.ReadOnly;
            Tag = textBox.Tag;
            TagString = textBox.TagString;
            //Visible = textBox.Visible;
            Enabled = textBox.Enabled;
            ScrollBars = textBox.ScrollBars;
        }

        public TextBoxPoleView(TextBoxBase textBox):this()
        {
            SetTextBox(textBox);
        }

        public TextBoxPoleView(ITextValueControlView textBox) :this()
        {
            SetTextBox(textBox);
        }

        public int SelectionEnd
        {
            get => Math.Abs(SelectionStart) + SelectionLength;
            set
            {
                try
                {
                    SelectionLength = value - SelectionStart;
                }
                catch
                {
                    int selectionStart = SelectionStart;
                    SelectionStart = value;
                    SelectionEnd = selectionStart;
                }
            }
        }

        public bool SelectionsStartEqualEnd => SelectionStart == SelectionEnd;

        bool StartBigEnd = false;

        public bool SelectionsStartBigEnd { get => StartBigEnd; set => StartBigEnd = value; }
        public string ValueInPole { get => TextInPole; set => TextInPole = value; }

        public int ValueInPoleLength => ValueInPole.Length;

        public bool MultiLine { get => Multyline; set => Multyline = value; }
        public bool MultyLine { get => MultiLine; set => MultiLine = value; }
        public bool Multyline { get => Multiline; set => Multiline = value; }

        public bool IsTextBoxBase => this is TextBoxBase;

        string tagString = "0";
        public string TagString { get => tagString; set => tagString = value; }
        public string TextInPole { get => Text; set => Text = value; }

        public new Padding DefaultPadding => base.DefaultPadding;

        public new Padding Padding
        {
            get => (this as Control).Padding;
            set => (this as Control).Padding = value;
        }
        public EditTextByFile EditText { get => new EditTextByFile(TextInPole); set => TextInPole = value.Text; }
        public Region TextRegion { get => Region; set => Region = value; }
        Region ITextValueControlView.ClearRegion { get => region1; set { region1 = value; } }
        Region region1 = new Region();

        public Rectangle TextClientRectangle => ClientRectangle;

        Rectangle rectangle = new Rectangle();
         Rectangle ITextValueControlView.ClearClientRectangle => rectangle;

        public Padding TextMargin { get => Margin; set => Margin = value; }
        Padding ITextValueControlView.ClearMargin { get => padding; set => padding = value; }
        Padding ITextValueControlView.ClearPadding { get => padding; set => padding = value; }
        public Padding TextPadding { get => Padding; set => Padding = value; }


        public string TextWidthPole
        {
            get => TextInPole;
            protected set => TextInPole = value;
        }
        //public string TextWithPole { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        string ITextValueControlView.TextWidthPole { get => TextWidthPole; set => TextWidthPole = value; }

        Padding padding = new Padding();

        public void KeyRun(char sign)
        {
            KeyPressEventArgs e = new KeyPressEventArgs(sign);
            TextBox_KeyPress(TextBox, e);
            if (!e.Handled)
            {
                string left = ValueInPole.Substring(0, SelectionStart);
                string right = ValueInPole.Substring(SelectionStart, ValueInPole.Length - SelectionStart);
                if (e.KeyChar == 8)
                {
                    try
                    {
                        int selectionStart = SelectionStart;
                        if (SelectionStart == SelectionEnd)
                        {
                            left = ValueInPole.Substring(0, SelectionStart - 1);
                            selectionStart = SelectionStart - 1;
                        }
                        else
                            right = ValueInPole.Substring(SelectionEnd, ValueInPole.Length - SelectionEnd);
                        //right = ValueInPole.Substring(SelectionStart, ValueInPole.Length - SelectionStart);
                        ValueInPole = left + right;
                        SelectionStart = selectionStart;
                    }
                    catch
                    {
                        try
                        {
                            ValueInPole = right;
                        }
                        catch
                        {

                        }
                    }
                }
                else if (e.KeyChar == 27)
                {
                    ValueInPole = "";
                }
                else if(e.KeyChar == 13)
                {
                    int selectionStart = SelectionStart;
                    ValueInPole = left + Environment.NewLine + right;
                    SelectionStart = selectionStart + 2;
                }
                else
                {
                    try
                    {
                        int selectionStart = SelectionStart;
                        ValueInPole = left + e.KeyChar + right;
                        SelectionStart = selectionStart + 1;
                    }
                    catch
                    {
                        ValueInPole = left + e.KeyChar;

                    }
                }
            }
        }


        public void KeyRun(int v)
        {
            KeyRun((char)v);
        }

        public void KeyRun(string s)
        {
            KeyRun(s[0]);
        }



        public void MinesSelection()
        {
            int selectionStart = SelectionStart;
            int selectionEnd = SelectionEnd;

            if (!StartBigEnd)
            {
                SelectionEnd--;
                SelectionStart = selectionStart;
            }
            else
            {
                SelectionStart--;
                SelectionEnd = selectionEnd;
            }
            if (SelectionsStartEqualEnd)
            {
                StartBigEnd = !StartBigEnd;
                MinesSelection();
            }
        }



        public void PlusSelection()
        {
            int selectionStart = SelectionStart;
            int selectionEnd = SelectionEnd;

            if (!StartBigEnd)
            {
                SelectionEnd++;
                SelectionStart = selectionStart;
            }
            else
            {
                SelectionStart++;
                SelectionEnd = selectionEnd;
            }


            if (SelectionsStartEqualEnd)
            {
                StartBigEnd = !StartBigEnd;
                PlusSelection();
            }
        }



        public void SetSelection(int index, bool plus = false)
        {
            int start = SelectionStart;
            int end = SelectionEnd;
            if (index < start)
            {
                SelectionStart = index;
            }
            else if (index > end)
            {
                SelectionEnd = index;
            }
            else
            {
                if (plus)
                {
                    SelectionStart = index;
                }
                else
                {
                    SelectionEnd = index;
                }
            }


        }



        public void ShiftMinesSelection()
        {
            while (SelectionStart > 0)
                MinesSelection();
        }
        public void ShiftPlusSelection()
        {
            while (SelectionEnd < ValueInPoleLength)
                PlusSelection();
        }

        public new string ToString() => $"Type: \"{GetType()}\"; Name: \"" + Name + "\"; Text: \"" + Text + "\"";


        public int MarginAll
        {
            get => Margin.All; set
            {
                Padding margin = Margin;
                margin.All = value;
                Margin = margin;
            }
        }
        public int MarginRight
        {
            get => Margin.Right; set
            {
                Padding margin = Margin;
                margin.Right = value;
                Margin = margin;
            }
        }
        public int MarginLeft
        {
            get => Margin.Left; set
            {
                Padding margin = Margin;
                margin.Left = value;
                Margin = margin;
            }
        }
        public int MarginTop
        {
            get => Margin.Top; set
            {
                Padding margin = Margin;
                margin.Top = value;
                Margin = margin;
            }
        }
        public int MarginBottom
        {
            get => Margin.Bottom; set
            {
                Padding margin = Margin;
                margin.Bottom = value;
                Margin = margin;
            }
        }

    }
}
