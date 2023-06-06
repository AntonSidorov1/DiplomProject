using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicShopDesktopApp
{
    public class ListWithNameItem
    {
        DataGridViewCell cell;

        public ListWithNameItem()
        {
        }

        public ListWithNameItem(DataGridViewCell cell) : this()
        {
            Cell = cell;
        }

        public ListWithNameItem(DataGridViewRow cell) : this(cell.Cells[0])
        {
        }

        public ListWithNameItem(object item)
        {
            Value = item;
        }

        public DataGridViewCell Cell
        {
            get => cell;
            set => cell = value;
        }

        public void SetToRow(DataGridViewRow row)
        {
            row.Cells[0] = Cell;
        }

        public object Value
        {
            get
            {
                try
                {
                    return Cell.Value;
                }
                catch (ArgumentNullException e)
                {
                    return "";
                }
                catch (NullReferenceException e)
                {
                    return "";
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                try
                {
                    cell.Value = value;

                }
                catch (ArgumentNullException e)
                {
                }
                catch (NullReferenceException e)
                {
                }
                catch
                {
                }
            }
        }

        public int Index => Cell.RowIndex;

    }
}
