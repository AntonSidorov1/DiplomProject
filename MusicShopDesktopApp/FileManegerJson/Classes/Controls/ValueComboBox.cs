using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManegerJson
{
    public class ValueComboBoxView :ComboBox, IValueComboBoxView
    {
        string tagString = "0";
        public string TagString { get => tagString; set => tagString = value; }
        protected ComboBox Combo => this as ComboBox;

        public ComboBox ComboBox => Combo;

        bool weelChangeIndexRound = true;
        public bool WeelChangeIndexRound { get => weelChangeIndexRound; set => weelChangeIndexRound = value; }
        public bool WheelChangeIndexRound { get => WeelChangeIndexRound; set => WeelChangeIndexRound = value; }

        public ValueComboBoxView():base()
        {
            ComboBox.MouseWheel += ComboBox_MouseWheel;
        }

        private void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!WeelChangeIndexRound)
                return;
            int delta = e.Delta;
            if(delta < 0)
            {
                SelectedIndexPlus(true);
            }
            else if(delta > 0)
            {
                SelectedIndexMines(true);
            }
        }

        public void SelectedIndexPlus() => SelectedIndexPlus(false);

        public void SelectedIndexPlus (bool weel)
        {
            int count = base.Items.Count - 1;
            if(SelectedIndex < count)
            {
                if (!weel)
                    SelectedIndex++;
            }
            else
            {
                SelectedIndex = 0;
            }
        }

        public void SelectedIndexMines() => SelectedIndexMines(false);

        public void SelectedIndexMines(bool weel)
        {
            int count = base.Items.Count - 1;
            if (SelectedIndex > 0)
            {
                if (!weel)
                    SelectedIndex--;
            }
            else
            {
                SelectedIndex = count;
            }
        }
    }
}
