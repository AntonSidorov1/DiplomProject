using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManegerJson
{
    public delegate void GetNumberByControl(int number);
    public class NumberIntEditTextWithSet : TextBoxWihSet
    {
        public NumberIntEditTextWithSet() : base()
        {
            InputKeyPress += NumberIntEditTextWithSet_InputKeyPress;
            InputText_Changed += NumberIntEditTextWithSet_InputText_Changed;

            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
        }

        private void NumberIntEditTextWithSet_InputText_Changed(object arg1, EventArgs arg2)
        {
            try
            {
                GetNumber?.Invoke(ValueNumber);
            }
            catch
            {

            }
        }

        public event GetNumberByControl GetNumber;

        public GetNumberByControl GetNumberProperty
        {
            get => GetNumber;
            set => GetNumber = value;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                int number = Convert.ToInt32(Value);
                if(!AllowNegative && ValueNumber < 0)
                {
                    number *= (-1);
                    ValueNumber = number;
                }
            }
            catch
            {
                if(Value != "")
                {
                    ValueNumber = 0;
                }
            }
        }

        bool allowNegative = false;

        /// <summary>
        /// Можно ли отрицательные?
        /// </summary>
        public bool AllowNegative
        {
            get => allowNegative;
            set => allowNegative = value;
        }

        public int ValueNumber
        {
            get
            {
                try
                {
                    return Value != "" ? Convert.ToInt32(Value) : 0;
                }
                catch
                {
                    return 0;
                }
            }
            set => Value = value.ToString();
        }

        private void NumberIntEditTextWithSet_InputKeyPress(object arg1, System.Windows.Forms.KeyPressEventArgs arg2)
        {
            if(arg2.KeyChar == '-')
            {
                arg2.Handled = true;
                try
                {
                    int number = ValueNumber;
                    if (AllowNegative)
                    {
                        number *= (-1);
                        ValueNumber = number;
                    }
                    else if (!AllowNegative && ValueNumber < 0)
                    {
                        number *= (-1);
                        ValueNumber = number;
                    }
                }
                catch
                {
                    if (Value != "")
                    {
                        ValueNumber = 0;
                    }
                }
                return;
            }
            if(arg2.KeyChar == 8)
            {
                return;
            }
            if(char.IsDigit(arg2.KeyChar))
            {
                return;
            }
            arg2.Handled = true;

            if (arg2.KeyChar == 27)
            {
                Clear();
            }
        }
    }
}
