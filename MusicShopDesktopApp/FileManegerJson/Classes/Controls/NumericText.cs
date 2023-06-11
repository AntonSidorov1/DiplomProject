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
    public partial class NumericText : UserControl
    {
        public NumericText()
        {
            InitializeComponent();
        }

        private void NumericText_Load(object sender, EventArgs e)
        {

        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            textBoxInput.Text = Values.Value.ValueText;
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

        public string Title
        {
            get => groupBoxTitle.Text;
            set => groupBoxTitle.Text = value;
        }

        ValuesInConrol values = new ValuesInConrol();

        public ValuesInConrol Values
        {
            get => values;
            set => values = value;
        }

        public event GetControlText GetText;

        public GetControlText GetTextProperty
        {
            get => GetText;
            set => GetText = value;
        }

        private void textBoxInput_GetText(string text)
        {
            Values.Value = new ValueNumber(text);
            GetText?.Invoke(text);
        }

        private void buttonpPlus_Click(object sender, EventArgs e)
        {
            Values.Plus();
        }

        private void buttonpMines_Click(object sender, EventArgs e)
        {
            Values.Mines();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Values.Clear();
        }

        private void textBoxInput_Enter(object sender, EventArgs e)
        {
            //timerUpdate.Stop();
        }

        private void textBoxInput_Leave(object sender, EventArgs e)
        {
            textBoxInput.GetTextEvent();
            timerUpdate.Start();
        }

        public void Change(object sender, EventArgs e)
        {
            textBoxInput_Leave(sender, e);
            textBoxInput_Enter(sender, e);
        }

        private void textBoxInput_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                Change(sender, e);
            }
        }

        private void textBoxInput_MouseEnter(object sender, EventArgs e)
        {

        }
    }
}
