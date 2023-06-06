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
    public partial class ListWithName : UserControl
    {
        public ListWithName()
        {
            InitializeComponent();
        }

        private void ListWithName_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Заголовок списка
        /// </summary>
        public string Title
        {
            get => dataGridViewList.Columns[0].HeaderText;
            set => dataGridViewList.Columns[0].HeaderText = value;
        }

        public int SelectedIndex
        {
            get
            {
                try
                {
                    return dataGridViewList.CurrentCell.RowIndex;
                }
                catch(ArgumentNullException e)
                {
                    return -1;
                }
                catch (NullReferenceException e)
                {
                    return -1;
                }
                catch
                {
                    return -1;
                }
            }
            set
            {
                try
                {
                    dataGridViewList.CurrentCell = dataGridViewList.Rows[value].Cells[0];
                }
                catch
                {
                    dataGridViewList.CurrentCell = dataGridViewList.Columns[0].HeaderCell;
                }
            }
        }

        public Action<object, ListWithNameItemEventArgs> SelectedIndexChanged;

        private void dataGridViewList_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            SelectedIndexChanged?.Invoke(this, new ListWithNameItemEventArgs(e, this));
        }

        public ListWithNameItemsCollection Items => new ListWithNameItemsCollection(dataGridViewList.Rows);

        public ListWithNameItem SelectedItem
        {
            get
            {
                try
                {
                    return Items[SelectedIndex];
                }
                catch (ArgumentNullException e)
                {
                    return new ListWithNameItem();
                }
                catch (NullReferenceException e)
                {
                    return new ListWithNameItem() ;
                }
                catch
                {
                    return new ListWithNameItem(); 
                }
            }
            set
            {
                try
                {
                    Items[SelectedIndex] = value;
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

        public new string Text
        {
            get => Title;
            set => Title = value;
        }


    }
}
