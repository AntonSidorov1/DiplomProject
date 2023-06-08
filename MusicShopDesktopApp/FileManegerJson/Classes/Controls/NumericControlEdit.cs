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
    public partial class NumericControlEdit : UserControl
    {
        public NumericControlEdit()
        {
            InitializeComponent();
        }

        public event Action<object, EventArgs> ValueChanged, ReadOnlyChanged;

        private void NumericControlWithName_Load(object sender, EventArgs e)
        {

            width = tableLayoutPanelPole.ColumnStyles[1].Width;
            textBoxInput.ValueChanged += (s, ea) => ValueChanged?.Invoke(s, ea);
            textBoxInput.EnabledChanged += (s, ea) => ReadOnlyChanged?.Invoke(s, ea);
            
            
        }

        float width;
        public new BorderStyle BorderStyle
        {
            get => panelBorder.BorderStyle;
            set => panelBorder.BorderStyle = value;
        }

        public string Title
        {
            get => groupBoxTitle.Text;
            set => groupBoxTitle.Text = value;
        }

        public void Clear()
        {
            textBoxInput.Value = 0;
        }

        public decimal Value
        {
            get => textBoxInput.Value;
            set => textBoxInput.Value = value;
        }

        public decimal Minimum
        {
            get => textBoxInput.Minimum;
            set => textBoxInput.Minimum = value;
        }

        public decimal Maximum
        {
            get => textBoxInput.Maximum;
            set => textBoxInput.Maximum = value;
        }

        public int DecimalPlaces
        {
            get => textBoxInput.DecimalPlaces;
            set => textBoxInput.DecimalPlaces = value;
        }


        public bool ReadOnly
        {
            //get => readOnly;
            //set
            //{
            //    readOnly = value;
            //}
            get => !textBoxInput.InterceptArrowKeys;
            set => textBoxInput.InterceptArrowKeys = !value;
        }

        public bool InputReadOnly
        {
            get => textBoxInput.ReadOnly;
            set => textBoxInput.ReadOnly = value;
        }

        public bool InputNoReadOnly
        {
            get => !InputReadOnly;
            set => InputReadOnly = !value;
        }


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

        public bool InputEnebled
        {
            get => textBoxInput.Enabled;
            set => textBoxInput.Enabled = value;
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

        private void buttonClear_Click(object sender, EventArgs e)
        {

            Clear();

        }

        private void textBoxInput_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void textBoxInput_EnabledChanged(object sender, EventArgs e)
        {
            buttonClear.Visible = InputNoReadOnly && InputEnebled;
        }

        private void buttonClear_VisibleChanged(object sender, EventArgs e)
        {
            bool visible = (sender as Button).Visible;
            float width = this.width;
            if (!visible)
                width = 5;
            tableLayoutPanelPole.ColumnStyles[1].Width = width;
            
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            if (ReadOnly)
            {
                Incriment = 0;
                
                InputReadOnly = true;
            }
            buttonClear.Visible = InputNoReadOnly && InputEnebled;
        }

        private void textBoxInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (InputReadOnly)
            {

                return;
            }

            if (e.KeyChar == 27)
            {

                e.Handled = true;
                Value = 0;
                return;
            }

            if (e.KeyChar == '.')
                e.KeyChar = ',';
            if (char.IsDigit(e.KeyChar) || e.KeyChar == ',' || e.KeyChar == '-' || e.KeyChar == 8)
                InputKeyPressToBox?.Invoke(this, e);
            else
                e.Handled = true;
        }

        public decimal Incriment
        {
            get => textBoxInput.Increment;
            set => textBoxInput.Increment = value;
        }


        public event Action<object, KeyPressEventArgs> InputKeyPress;

        public Action<object, KeyPressEventArgs> InputKeyPressToBox
        {
            get => InputKeyPress;
            set => InputKeyPress = value;
        }

        private void textBoxInput_ValueChanged(object sender, EventArgs e)
        {
            GetValue?.Invoke(Value);
        }

        public delegate void GetControl(decimal number);

        public event GetControl GetValue;


        public void SetReadOnly(bool readOnly, decimal incriment = 1)
        {
            ReadOnly = readOnly;
            InputReadOnly = readOnly;
            Incriment = incriment;
        }
    }
}
