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
    public partial class NumericControlWithSet : UserControl
    {
        public NumericControlWithSet()
        {
            InitializeComponent();
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {

        }

        public event NumericControlEdit.GetControl GetValue;

        private void textBoxInput_GetValue(decimal number)
        {
            GetValue?.Invoke(number);
        }


        public decimal Incriment
        {
            get => textBoxInput.Incriment;
            set => textBoxInput.Incriment = value;
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

        public new BorderStyle BorderStyle
        {
            get => textBoxInput.BorderStyle;
            set => textBoxInput.BorderStyle = value;
        }

        public string Title
        {
            get => textBoxInput.Title;
            set => textBoxInput.Title = value;
        }

    }
}
