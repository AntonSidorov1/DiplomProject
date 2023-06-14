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
    public class OrganizationsList : GeorafyPointList<Organization>
    {
        public OrganizationsList()
        {
        }

        public OrganizationsList(IEnumerable<Organization> collection) : base(collection)
        {
        }

        public OrganizationsList(int capacity) : base(capacity)
        {
        }


        public static OrganizationsList GetList() => new OrganizationsList();

        public static OrganizationsList GetListFromDB()
        {
            OrganizationsList products = GetList();
            products.GetFromBD();
            return products;
        }

        public OrganizationsList GetThis() => this;

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
                    "[OrganizationID], " +
                    "[OrganizationName]," +
                    "[OrganizationLogotip]," +
                    "[OrganizationTelephone]," +
                    "[OrganizationEmail]," +
                    "[OrgamizationAddress]," +
                    "[OrganizationSite]" +
                    " FROM [Organization]";

                SqlDataReader reader = command.ExecuteReader();
                Clear();
                try
                {
                    while (reader.Read())
                    {
                        Organization organization = new Organization();

                        organization.ID = reader.GetInt32(0);
                        organization.Name = reader.GetString(1);
                        organization.Address = reader.GetString(5);
                        try
                        {
                            organization.SetLogotip((byte[])reader[2]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            organization.Contact.Telephone = reader.GetString(3);
                        }
                        catch
                        {

                        }
                        try
                        {
                            organization.Contact.Email = reader.GetString(4);
                        }
                        catch
                        {

                        }

                        try
                        {
                            organization.Site = reader.GetString(6);
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

        public override Organization Get() => new Organization();


        public static Organization GetByIDFromDB(int id)
        {
            return GetListFromDB().GetByID(id);
        }

        public static Organization GetByIDFromDB(Part id)
        {
            return GetListFromDB().GetByID(id);
        }


    }
}
