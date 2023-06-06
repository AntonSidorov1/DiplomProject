using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicShopDesktopApp
{
    public class ListWithNameItemEventArgs : DataGridViewCellEventArgs
    {
        public ListWithNameItemEventArgs(int index, ListWithName control) : base(0, index)
        {
            this.control = control;
        }

        public ListWithNameItemEventArgs(DataGridViewCellEventArgs e, ListWithName control) : this(e.RowIndex, control)
        {
        }

        public ListWithNameItemEventArgs(ListWithNameItemEventArgs e) : this(e.RowIndex, e.Control)
        {
        }

        public int SelectedIndex
        {
            get => Control.SelectedIndex;
            set => Control.SelectedIndex = value;
        }

        ListWithName control;

        public ListWithName Control => control;

        public string Text => Control.Text;

        public ListWithNameItem SelectedItem
        {
            get => Control.SelectedItem;
        }

    }
}
