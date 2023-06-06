using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    public abstract class AddressesList<T> : List<T> where T:Address
    {
        protected static Random random = new Random();

        public static Random Random
        {
            get => random;
            set => random = value;
        }

        public static int GetRandomNumber(int number = 10) => random.Next(number) + 1;

        public static int GetRandomMilliSeconds()
        {
            return GetRandomNumber() *
                GetRandomNumber() *
                GetRandomNumber() *
                GetRandomNumber(5);
        }
        public AddressesList()
        {
        }

        public AddressesList(int capacity) : base(capacity)
        {
        }

        public AddressesList(IEnumerable<T> collection) : base(collection)
        {
        }


        public AddressesList GetAddresses()
        {
            AddressesList addresses = new AddressesList();
            for (int i = 0; i < Count; i++)
            {
                addresses.Add(this[i]);
            }
            return addresses;
        }

        public object[] GetItems()
        {
            List<object> items = new List<object>(GetAddresses());
            return items.ToArray();
        }

        public List<T> GetListAddresses() => new List<T>(this);

        public AddressesList<T> GetThisAddresses() => this;

        public bool ContainsByID(int id) => GetThisAddresses().Any(t => t.ID == id);

        public bool Contains(string address) => GetThisAddresses().Any(t => t.Value == address);


        public T GetByID(int id) => Find(t => t.ID == id);

        public abstract void GetFromBD(int user, int count = 20);
        public abstract bool AddToDB(int user, T address);
        public abstract bool DeleteFromDB(int user, int telefon);
    }

    public class AddressesList : AddressesList<Address>
    {
        public AddressesList()
        {
        }

        public AddressesList(int capacity) : base(capacity)
        {
        }

        public AddressesList(IEnumerable<Address> collection) : base(collection)
        {
        }

        public override bool AddToDB(int user, Address address)
        {
            return true;
        }

        public override bool DeleteFromDB(int user, int telefon)
        {
            return true;
        }

        public override void GetFromBD(int user, int count = 20)
        {
            
        }


    }
}
