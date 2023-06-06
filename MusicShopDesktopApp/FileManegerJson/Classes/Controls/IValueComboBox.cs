using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManegerJson
{
    public interface IValueComboBoxView: ITagStringControlView
    {
        ComboBox.ObjectCollection Items { get; }
        int SelectedIndex { get; set; }

        void SelectedIndexPlus();
        void SelectedIndexPlus(bool weel);
        void SelectedIndexMines();
        void SelectedIndexMines(bool weel);

        bool WeelChangeIndexRound { get; set; }
        bool WheelChangeIndexRound { get; set; }
    }
}
