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
    public partial class ComboBoxWithName : UserControl
    {
        public ComboBoxWithName()
        {
            InitializeComponent();
        }

        ToolTip tool = new ToolTip();

        /// <summary>
        /// Возвращает или задаёт ширину раскрывающегося списка
        /// </summary>
        public int DropDownWith
        {
            get => comboBoxValues.DropDownWidth;
            set => comboBoxValues.DropDownWidth = value;
        }

        public event Action<object, EventArgs> SelectedIndexChanged;

        public event Action<object, EventArgs> ReadOnlyChanged;


        private void ComboBoxWithName_Load(object sender, EventArgs e)
        {

            comboBoxValues.SelectedIndexChanged += ComboBoxValues_SelectedIndexChanged;
            comboBoxValues.SelectedIndexChanged += (s, ea) => SelectedIndexChanged?.Invoke(this, ea);
            comboBoxValues.EnabledChanged += (s, ea) => ReadOnlyChanged?.Invoke(this, ea);
        }

        private void ComboBoxValues_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (sender as ComboBox);
            if (ToolTipTextVisible)
            {
                tool.SetToolTip(comboBox, Convert.ToString(comboBox.SelectedItem));
            }
            else
            {

                tool.SetToolTip(comboBoxValues, "");
            }
        
        }

        public object SelectedItem
        {
            get => comboBoxValues.SelectedItem;
            set => comboBoxValues.SelectedItem = value;
        }

        bool toolTipTextVisible = true;

        public bool ToolTipTextVisible
        {
            get => toolTipTextVisible;
            set
            {
                toolTipTextVisible = value;
                if(!value)
                {
                    tool.SetToolTip(comboBoxValues, "");
                }
            }
        }

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

        public bool ReadOnly
        {
            get => !comboBoxValues.Enabled;
            set => comboBoxValues.Enabled = !value;
        }

        public ComboBox.ObjectCollection Items => comboBoxValues.Items;

        public int SelectedIndex
        {
            get => comboBoxValues.SelectedIndex;
            set => comboBoxValues.SelectedIndex = value;
        }

        public bool NoReadOnly
        {
            get => !ReadOnly;
            set => ReadOnly = !value;
        }

        public ComboBoxStyle DropDownStyle
        {
            get => comboBoxValues.DropDownStyle;
            set => comboBoxValues.DropDownStyle = value;
        }


    }
}
