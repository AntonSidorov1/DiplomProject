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
    public partial class ComboBoxNameClear : UserControl
    {
        public ComboBoxNameClear()
        {
            InitializeComponent();

            width = tableLayoutPanelPole.ColumnStyles[1].Width;
            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Start();

        }

        public int DropDownWith
        {
            get => comboBoxValue.DropDownWidth;
            set => comboBoxValue.DropDownWidth = value;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            comboBoxValue.Enabled = NoReadOnly;
            buttonClear.Visible = NoReadOnly && ClearVisible;
        }

        public ComboBox.ObjectCollection Items => comboBoxValue.Items;

        public int SelectedIndex
        {
            get => comboBoxValue.SelectedIndex;
            set => comboBoxValue.SelectedIndex = value;
        }

        public ComboBoxStyle DropDownStyle
        {
            get => comboBoxValue.DropDownStyle;
            set => comboBoxValue.DropDownStyle = value;
        }
        private void ComboBoxnameClear_Load(object sender, EventArgs e)
        {
            
        }


        public void Clear()
        {
            buttonClear_VisibleChanged(buttonClear, new EventArgs());
        }


        public delegate void ClearControl(object sender,
            Control senderControl,
            ComboBox controlInput,
            object senderInput,
            ComboBoxNameClear textInputContol,
            EventArgs e,
            int selectedIndex, string text, ref int selectedIndexChanging);

        public event ClearControl Clearing;

        public ClearControl CliearingProperty
        {
            get => Clearing;
            set => Clearing = value;
        }

        public event ClearControl Cleared;

        public ClearControl ClearedProperty
        {
            get => Cleared;
            set => Cleared = value;
        }



        bool readOnly = false;

        public bool ReadOnly
        {
            get => readOnly;
            set => readOnly = value;
        }

        bool clearVisible = true;

        public bool ClearVisible
        {
            get => clearVisible;
            set => clearVisible = value;
        }

        public bool NoReadOnly
        {
            get => !ReadOnly;
            set => ReadOnly = !value;
        }


        public BorderStyle BorderStyleExternal
        {
            get => BorderStyle;
            set => BorderStyle = value;
        }

        public BorderStyle BorderStyleMiddle
        {
            get => panelMiddle.BorderStyle;
            set => panelMiddle.BorderStyle = value;
        }

        public BorderStyle BorderStyleInternal
        {
            get => panelInternal.BorderStyle;
            set => panelInternal.BorderStyle = value;
        }


        public string Title
        {
            get => groupBoxTitle.Text;
            set => groupBoxTitle.Text = value;
        }

        float width;

        private void buttonClear_VisibleChanged(object sender, EventArgs e)
        {
            bool visible = (sender as Button).Visible;
            float width = this.width;
            if (!visible)
                width = 5;
            tableLayoutPanelPole.ColumnStyles[1].Width = width;
        }

        private void comboBoxValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedIndexChanged?.Invoke(this, this, sender as ComboBox, sender, this, e, SelectedIndex, Value);
        }

        public string Value
        {
            get => comboBoxValue.Text;
            set => comboBoxValue.Text = value;
        }

        public delegate void ControlChanged(object sender,
            Control senderControl,
            ComboBox controlInput,
            object senderInput,
            ComboBoxNameClear textInputContol,
            EventArgs e,
            int selectedIndex, string text);

        public event ControlChanged SelectedIndexChanged;

        public ControlChanged SelectedIndexChangedProperty
        {
            get => SelectedIndexChanged;
            set => SelectedIndexChanged = value;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            int index = SelectedIndex;

            try
            {
                Clearing?.Invoke(this, this, comboBoxValue, comboBoxValue, this, e, SelectedIndex, Value, ref index);
            }
            catch
            {

            }

            try
            {
                SelectedIndex = index;
            }
            catch
            {

            }

            index = SelectedIndex;

            try
            {
                Cleared?.Invoke(this, this, comboBoxValue, comboBoxValue, this, e, SelectedIndex, Value, ref index);
            }
            catch
            {

            }

        }


        public static implicit operator ComboBox(ComboBoxNameClear control)
        {
            return control.comboBoxValue;
        }

    }
}
