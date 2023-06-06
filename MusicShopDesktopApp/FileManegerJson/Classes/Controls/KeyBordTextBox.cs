using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManegerJson
{
    public class KeyBordTextView : TextBoxPoleView, IKeyBordControlView
    {
        protected virtual void TextBoxCreate()
        {

        }

        public KeyBordTextView():base()
        {
            TextBoxCreate();
        }


        public KeyBordTextView(TextBoxBase textBox) : this()
        {
            //TextBoxCreate();
            SetTextBox(textBox);
            
        }

        public KeyBordTextView(IKeyBordControlView textBox) : this(textBox as ITextValueControlView)
        {
            VirtualKeyBord = textBox.VirtualKeyBord;
            if (textBox.HaveKeyBord)
                KeyBordForm = textBox.KeyBordForm;
        }

        public KeyBordTextView(KeyBordTextView textBox) : this(textBox as KeyBordControlView)
        {

        }

        public KeyBordTextView(ITextValueControlView textBox) : this()
        {
            //TextBoxCreate();
            SetTextBox(textBox);

        }




        public bool VirtualKeyBord { get => VirtualKeyBord1; set => VirtualKeyBord1 = value; }

        public KeyBordEditForm KeyBordForm { get => KeyBordForm1; set => KeyBordForm1 = value; }

        public bool HaveKeyBord { get => HaveKeyBord1; set => HaveKeyBord1 = value; }

    }
}
