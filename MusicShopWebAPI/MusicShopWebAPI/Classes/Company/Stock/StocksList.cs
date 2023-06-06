using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    /// <summary>
    /// Список организаций
    /// </summary>
    public class StocksList : GeorafyPointList<Stock>
    {
        public StocksList()
        {
        }

        public StocksList(IEnumerable<Stock> collection) : base(collection)
        {
        }

        public StocksList(int capacity) : base(capacity)
        {
        }


        public static StocksList GetList() => new StocksList();

        public static StocksList GetListFromDB()
        {
            StocksList products = GetList();
            products.GetFromBD();
            return products;
        }

        public StocksList GetThis() => this;

        public void GetFromBD(int count = 20)
        {
            SitiesList sities = SitiesList.GetListFromDB();

            SqlConnection connection = new SqlConnection();
            connection = DataBaseConfiguration.GetSqlConnection();
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT " +
                    "[StockID], " +
                    "[StockName]," +
                    "[StockTelephone]," +
                    "[StockEmail]," +
                    "[StockAddress]," +
                    "[StockSityID]" +
                    " FROM [Stock]";

                SqlDataReader reader = command.ExecuteReader();
                Clear();
                Add(new Stock
                {
                    ID = 0,
                    Name = "Все склады"
                });
                try
                {
                    while (reader.Read())
                    {
                        Stock organization = new Stock();

                        organization.ID = reader.GetInt32(0);
                        organization.Name = reader.GetString(1);
                        organization.Address = reader.GetString(4);
                        organization.SityID = reader.GetInt32(5);
                        
                        try
                        {
                            organization.Contact.Telephone = reader.GetString(2);
                        }
                        catch
                        {

                        }
                        try
                        {
                            organization.Contact.Email = reader.GetString(3);
                        }
                        catch
                        {

                        }

                        Add(organization);
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    reader.Close();
                    throw e;
                }
                connection.Close();

                for(int i = 0; i < Count; i++)
                {
                    this[i].SetSityByID(sities);
                }
            }
            catch (Exception e)
            {
                try
                {
                    connection.Close();
                }
                catch
                {

                }
                if (count > 0)
                {
                    Thread.Sleep(AddressesList.GetRandomMilliSeconds());
                    GetFromBD(count - 1);
                    return;
                }

                throw e;
            }
        }

        public StocksList GetBySityID(int sityID)
            => new StocksList(sityID > 0 ? FindAll(p => p.SityID == sityID || p.ID < 1) : this);

        public StocksList SetWithAll()
        {
            if (!ContainsByID(0))
            {
                Stock stock = new Stock()
                {
                    ID = 0,
                    Name = "Все склады"
                };
                Insert(0, stock);
            }
            return this;
        }

        public object[] GetObjectsList()
        {
            List<object> result = new List<object>();
            for (int i = 0; i < Count; i++)
            {
                result.Add(this[i].RegistrateData);
            }
            return result.ToArray();
        }


        public override Stock Get() => new Stock();
    }
}
