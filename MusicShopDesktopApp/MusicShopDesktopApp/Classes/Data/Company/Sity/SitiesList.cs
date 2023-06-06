using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Список организаций
    /// </summary>
    public class SitiesList : GeorafyPointList<Sity>
    {
        public SitiesList()
        {
        }

        public SitiesList(IEnumerable<Sity> collection) : base(collection)
        {
        }

        public SitiesList(int capacity) : base(capacity)
        {
        }


        public static SitiesList GetList() => new SitiesList();

        public static SitiesList GetListFromDB()
        {
            SitiesList products = GetList();
            products.GetFromBD();
            return products;
        }

        public SitiesList GetThis() => this;

        public void GetFromBD(int count = 20)
        {
            SqlConnection connection = new SqlConnection();
            connection = DataBaseConfiguration.GetSqlConnection();
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT " +
                    "[SityID], " +
                    "[SityName]" +
                    " FROM [Sity]";

                SqlDataReader reader = command.ExecuteReader();
                Clear();
                try
                {
                    while (reader.Read())
                    {
                        Sity organization = new Sity();

                        organization.ID = reader.GetInt32(0);
                        organization.Name = reader.GetString(1);

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


        public object[] GetObjectsList()
        {
            List<object> result = new List<object>();
            for (int i = 0; i < Count; i++)
            {
                result.Add(this[i].Name);
            }
            return result.ToArray();
        }

        public int IndexOfName(string name) => FindIndex(s => s.EqualsName(name));
        public Sity GetOfName(string name) => Get(IndexOfName(name));
        public bool ContainsOfName(string name) => GetThis().Any(s => s.EqualsName(name));

        public override Sity Get() => new Sity();

    }
}
