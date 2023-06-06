using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    public class SuppliersList : AbstractCategoriesList<Supplier>
    {
        public SuppliersList()
        {
        }

        public SuppliersList(IEnumerable<Supplier> collection) : base(collection)
        {
        }

        public SuppliersList(int capacity) : base(capacity)
        {
        }

        public static SuppliersList GetList() => new SuppliersList();

        public SuppliersList GetThis() => this;

        public static SuppliersList GetListFromDB()
        {
            SuppliersList products = GetList();
            products.GetFromBD();
            return products;
        }


        public void GetFromBD(int count = 20)
        {
            SqlConnection connection = new SqlConnection();
            connection = DataBaseConfiguration.GetSqlConnection();
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Select * From [ProductSupplier]";

                SqlDataReader reader = command.ExecuteReader();
                Clear();
                try
                {
                    while (reader.Read())
                    {
                        Supplier product = new Supplier();
                        product.ID = reader.GetInt32(reader.GetOrdinal("SupplierID"));
                        product.Name = reader.GetString(reader.GetOrdinal("SupplierName"));

                        Add(product);
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

        public override Supplier GetByName(string name) => GetThis().FirstOrDefault(p => p.EqualsName(name));

        public override bool ContainsByName(string articul) => GetThis().Any(p => p.EqualsName(articul));

        public override int IndexByName(string articul) => GetThis().FindIndex(p => p.EqualsName(articul));

        public override void AddPart(int id, string name)
        {
            Add(new Supplier
            {
                ID = id,
                Name = name
            });
        }


        public bool AddToDB(Part supplier)
        {
            return AddToDB(supplier.Name);
        }

        public bool AddToDB(string supplierName, int count = 20)
        {
            if (supplierName.Length < 1)
                return false;

            SqlConnection connection = DataBaseConfiguration.GetSqlConnection();

            try
            {
                connection.Open();
                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = $"INSERT INTO [ProductSupplier] " +
                        $"([SupplierName]) " +
                        $"VALUES (@name)";
                    SqlParameterCollection parameters = command.Parameters;
                    parameters.Clear();
                    parameters.AddWithValue("@name", supplierName);
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    connection.Close();
                    throw e;
                }
                try
                {

                    connection.Close();
                }
                catch
                {

                }
            }
            catch
            {
                if (count > 0)
                {
                    Thread.Sleep(AddressesList.GetRandomMilliSeconds());
                    return AddToDB(supplierName, count - 1);
                }
                return false;
            }

            return true;
        }

        public bool DeleteFromDB(Part supplier) => DeleteFromDB(supplier.ID);

        public bool DeleteFromDB(int id, int count = 20)
        {
            SqlConnection connection = DataBaseConfiguration.GetSqlConnection();

            try
            {
                connection.Open();
                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = $"Delete From [ProductSupplier] "  +
                        $"WHERE [SupplierID] ={ id}";
                    SqlParameterCollection parameters = command.Parameters;
                    parameters.Clear();
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    connection.Close();
                    throw e;
                }
                try
                {

                    connection.Close();
                }
                catch
                {

                }
            }
            catch
            {
                if (count > 0)
                {
                    Thread.Sleep(AddressesList.GetRandomMilliSeconds());
                    return DeleteFromDB(id, count - 1);
                }
                return false;
            }

            return true;
        }


        public bool UpdateToDB(Part supplier)
            => UpdateToDB(supplier.ID, supplier.Name);

        public bool UpdateToDB(int id, string supplierName, int count = 20)
        {
            if (supplierName.Length < 1)
                return false;

            SqlConnection connection = DataBaseConfiguration.GetSqlConnection();

            try
            {
                connection.Open();
                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = $"UPDATE [ProductSupplier]" +
                        $" SET [SupplierName] = @name " +
                        $"WHERE [SupplierID] ={ id}";
                    SqlParameterCollection parameters = command.Parameters;
                    parameters.Clear();
                    parameters.AddWithValue("@name", supplierName);
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    connection.Close();
                    throw e;
                }
                try
                {

                    connection.Close();
                }
                catch
                {

                }
            }
            catch
            {
                if (count > 0)
                {
                    Thread.Sleep(AddressesList.GetRandomMilliSeconds());
                    return UpdateToDB(id, supplierName, count - 1);
                }
                return false;
            }

            return true;
        }

    }
}
