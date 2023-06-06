using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManegerJson
{
    public class LanguagesEditListClass : List<LangugeEditClass>
    {
        void listCanged(object sender, EventArgs e)
        {
            if (change)
                ListChanged(sender, e);
        }

        public EventHandler ListChanged;

        public LanguagesEditListClass() :base()
        {
            
        }

        bool change = true;

        LanguagesEditListClass changeFew;
        public void FewAdd(LanguagesEditListClass languges)
        {
            try
            {
                FewRemove();
            }
            catch
            {

            }

            changeFew = languges;
            changeFew.ListChanged += changeFew_ListChanged;
        }

        public void FewRemove()
        {
            try
            {
                changeFew.ListChanged -= changeFew_ListChanged;
                changeFew = null;
            }
            catch
            {

            }
        }

        void changeFew_ListChanged(object sender, EventArgs e)
        {
            this.Clear();
            Add(sender as LanguagesEditListClass);
        }

        public LanguagesEditListClass ChangeFew
        {
            get => changeFew;
            set
            {
                try
                {
                    LanguagesEditListClass languges = value;

                    if (languges == null || languges is null)
                        throw new Exception();
                    FewAdd(languges);
                }
                catch
                {
                    FewRemove();
                }
            }
        }

        public LanguagesEditListClass(IEnumerable<LangugeEditClass> classes) : this()
        {
            AddRange(classes);
        }

        bool save = false;
        public bool Save { get => save; set => save = value; }


        public new LangugeEditClass Add(LangugeEditClass languge)
        {
            base.Add(languge);
            try
            {
                listCanged(this, new EventArgs());
            }
            catch
            {

            }
            return languge;
        }


        public new void InsertRange(int index, IEnumerable<LangugeEditClass> languges)
        {
            change = false;
            base.InsertRange(index, languges);
            change = true;
            try
            {
                listCanged(this, new EventArgs());
            }
            catch
            {

            }
        }

        public LangugeEditClass GetItem(int index) => base[index];
        public LangugeEditClass SetItem(int index, LangugeEditClass languge)
        {
            //LangugeClass languge1 = GetItem(index);
            base[index] = languge;

            //if (languge == languge1)
            //    return languge;

            try
            {
                listCanged(this, new EventArgs());
            }
            catch
            {

            }

            return languge;
        }

        public new LangugeEditClass this[int index] { get => GetItem(index); set => SetItem(index, value); }

        public void Insert(int index, IEnumerable<LangugeEditClass> languges) => InsertRange(index, languges);

        public void Add(int index, IEnumerable<LangugeEditClass> languges) => Insert(index, languges);
        public void AddRange(int index, IEnumerable<LangugeEditClass> languges) => Add(index, languges);

        public new LangugeEditClass Insert(int index, LangugeEditClass languge)
        {
            base.Insert(index, languge);
            try
            {
                listCanged(this, new EventArgs());
            }
            catch
            {

            }
            return languge;
        }

        public LangugeEditClass Add(int index, LangugeEditClass languge) => Insert(index, languge);


        public void Add(IEnumerable<LangugeEditClass> languges) => AddRange(languges);
        

        public new void AddRange(IEnumerable<LangugeEditClass> languges)
        {
            change = false;
            base.AddRange(languges);
            change = true;
            try
            {
                listCanged(this, new EventArgs());
            }
            catch
            {

            }
        }

        public new void RemoveAt(int index)
        {
            change = false;
            base.RemoveAt(index);
            change = true;

            try
            {
                listCanged(this, new EventArgs());
            }
            catch
            {

            }
        }

        public new bool Remove (LangugeEditClass languge)
        {
            if (IndexOf(languge) == -1)
                return false;
            //change = false;
            base.Remove(languge);
            //change = true;

            try
            {
                listCanged(this, new EventArgs());
            }
            catch
            {

            }
            return true;
        }

        public void Clear()
        {
            //change = false;
            base.Clear();

            //change = true;
            try
            {
                listCanged(this, new EventArgs());
            }
            catch
            {

            }

            
        }

        public new int RemoveAll(Predicate<LangugeEditClass> predicate)
        {
            change = false;
            int count = FindAll(predicate).Count;
            base.RemoveAll(predicate);
            change = true;

            try
            {
                listCanged(this, new EventArgs());
            }
            catch
            {

            }
            return count;
        }

        public new void RemoveRange(int index, int count)
        {
            base.RemoveRange(index, count);

            try
            {
                listCanged(this, new EventArgs());
            }
            catch
            {

            }
        }

        public int RemoveRange(IEnumerable<LangugeEditClass> languges)
        {
            List<LangugeEditClass> languges1 = new List<LangugeEditClass>(languges);
            int count = 0;

            change = false;
            for (int i = 0; i < languges1.Count; i++) 
            {
                try
                {
                    if (Remove(languges1[i]))
                        count++;
                }
                catch
                {

                }
            }
            change = true;

            return count;
        }
    }
}
