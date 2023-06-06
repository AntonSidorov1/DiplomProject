using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicShopDesktopApp
{
    public class ListWithNameItemsCollection : IList<ListWithNameItem>, IList<object>
    {
        DataGridViewRowCollection rows;

        public ListWithNameItemsCollection()
        {
        }

        public ListWithNameItemsCollection(DataGridViewRowCollection rows) : this()
        {
            Rows = rows;
        }

        public DataGridViewRowCollection Rows
        {
            get => rows;
            set => rows = value;
        }

        object IList<object>.this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ListWithNameItem this[int index] { get => new ListWithNameItem(Rows[index]); set => value.SetToRow(Rows[index]); }

        public List<ListWithNameItem> ToList()
        {
            List<ListWithNameItem> lists = new List<ListWithNameItem>();
            for(int i =0; i < Count; i++)
            {
                lists.Add(this[i]);
            }
            return lists;
        }

        public List<object> ToObjectList()
        {
            List<object> lists = new List<object>();
            for (int i = 0; i < Count; i++)
            {
                lists.Add(this[i].Value);
            }
            return lists;
        }

        public int Count => Rows.Count;

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(ListWithNameItem item)
        {
            int row = Rows.Add();
            item.SetToRow(rows[row]);
        }

        public void Add(object item)
        {
            Add(new ListWithNameItem(item));
        }

        public void AddRange(IEnumerable<ListWithNameItem> items)
        {
            List<ListWithNameItem> lists = new List<ListWithNameItem>(items);
            for(int i = 0; i < lists.Count; i++)
            {
                Add(lists[i]);
            }
        }

        public void AddRange(IEnumerable<object> items)
        {
            List<object> lists = new List<object>(items);
            for (int i = 0; i < lists.Count; i++)
            {
                Add(lists[i]);
            }
        }

        public void Clear()
        {
            rows.Clear();
        }

        public bool Contains(ListWithNameItem item)
        {
            return ToList().Contains(item);
        }

        public bool Contains(object item)
        {
            return ToList().Any(i => i.Value == item);
        }

        public void CopyTo(ListWithNameItem[] array, int arrayIndex)
        {
            ToList().CopyTo(array, arrayIndex);
        }

        public void CopyTo(object[] array, int arrayIndex)
        {
            ToObjectList().CopyTo(array, arrayIndex);
        }

        public IEnumerator<ListWithNameItem> GetEnumerator()
        {
            return ToList().GetEnumerator();
        }

        public int IndexOf(ListWithNameItem item)
        {
            return ToList().IndexOf(item);
        }

        public int IndexOf(object item)
        {
            return ToObjectList().IndexOf(item);
        }

        public void Insert(int index, ListWithNameItem item)
        {
            if(index == Count)
            {
                Add(item);
                return;
            }
            Rows.Insert(index, new DataGridViewRow());
            this[index] = item;
        }

        public void Insert(int index, object item)
        {
            Insert(index, new ListWithNameItem(item));
        }

        public void InsertRange(int index, IEnumerable<ListWithNameItem> item)
        {
            List<ListWithNameItem> items = new List<ListWithNameItem>(item);
            for (int i = 0; i < items.Count; i++)
            {
                Insert(index, items[i]);
                index++;
            }
        }

        public void Insert(int index, IEnumerable<object> item)
        {
            List<object> items = new List<object>(item);
            for (int i = 0; i < items.Count; i++)
            {
                Insert(index, items[i]);
                index++;
            }
        }

        public bool Remove(ListWithNameItem item)
        {
            try
            {
                int index = ToList().IndexOf(item);
                RemoveAt(index);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Remove(object item)
        {
            try
            {
                int index = ToObjectList().IndexOf(item);
                RemoveAt(index);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void RemoveAt(int index)
        {
            Rows.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator<object> IEnumerable<object>.GetEnumerator()
        {
            return ToObjectList().GetEnumerator();
        }
    }
}
