using FileManegerJson;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Склад
    /// </summary>
    public class Stock : Pounkt
    {
        Sity sity = new Sity();

        /// <summary>
        /// Город
        /// </summary>
        public Sity Sity
        {
            get => sity;
            set => sity = value;
        }

        /// <summary>
        /// Установить город из базы данных, по его идентификатору
        /// </summary>
        /// <param name="id"></param>
        public void SetSityByID(int id)
        {
            SetSityByID(id, SitiesList.GetListFromDB());
        }

        public void SetSityByID(int id, SitiesList sities)
        {
            if (sities.ContainsByID(id))
                Sity = sities.GetByID(id).CopySity();
        }

        public void SetSityByID(SitiesList sities)
        {
            SetSityByID(SityID, sities);
        }

        /// <summary>
        /// ID города
        /// </summary>
        public int SityID
        {
            get => Sity.ID;
            set => Sity.ID = value;
        }

        /// <summary>
        /// Установить город из базы данных, по идентификатору SityID
        /// </summary>
        public void SetSityByID()
        {
            SetSityByID(SityID);
        }

        /// <summary>
        /// Вывести данные склада
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() + "\n" +
                $"Город - {Sity.Name} \n";
        }


        /// <summary>
        /// Создать копию объекта
        /// </summary>
        /// <returns></returns>
        public Stock CopyStock() => new Stock
        {
            ID = this.ID,
            Name = this.Name,
            Contact = this.Contact.CopyContact(),
            Address = this.Address,
            Sity = this.Sity.CopySity()
        };

        public override string AddressData => Sity.Name + ", " + Address;

        public bool DeleteFromDB() => DeleteFromDB(this);
        public static bool DeleteFromDB(Part stock)
            => DeleteFromDB(stock.ID);

        public static bool DeleteFromDB(int id)
        {
            try
            {
                SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
                connection.Open();

                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = $"Delete From [Stock] " +
                        $"where [StockID]={id}";
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
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AddToDB() => AddToDB(this);
        public static bool AddToDB(Stock stock)
        {
            try
            {
                SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
                connection.Open();

                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = $"Insert Into [Stock] " +
                        $"([StockName],[StockAddress],[StockSityID],[StockTelephone],[StockEmail]) " +
                        $"Output INSERTED.StockID " +
                        $" Values (@name, @address, {stock.SityID}, @phone, @email)";
                    SqlParameterCollection parameters = command.Parameters;
                    parameters.AddWithValue("@name", stock.Name);
                    parameters.AddWithValue("@address", stock.Address);
                    parameters.AddWithValue("@phone", stock.Contact.Telephone);
                    parameters.AddWithValue("@email", stock.Contact.Email);
                    try
                    {
                        stock.ID = Convert.ToInt32(command.ExecuteScalar());
                    }
                    catch
                    {
                        command.ExecuteNonQuery();
                    }
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
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool UpdateNameAtDB() => UpdateNameAtDB(this);

        public static bool UpdateNameAtDB(Part organization) => UpdateNameAtDB(organization.ID, organization.Name);
        public static bool UpdateNameAtDB(int id, string name)
        {
            if (name.Length < 1)
                return false;
            try
            {
                SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
                connection.Open();

                try
                {
                    SqlCommand command = connection.CreateCommand();

                    command.CommandText = $"Update [Stock] set [StockName]=@name " +
                        $"where [StockID]={id}";
                    SqlParameterCollection parameters = command.Parameters;
                    parameters.AddWithValue("@name", name);
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
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateAddressAtDB() => UpdateAddressAtDB(this);

        public static bool UpdateAddressAtDB(Pounkt organization) => UpdateAddressAtDB(organization.ID, organization.Address);
        public static bool UpdateAddressAtDB(int id, string address)
        {
            string name = address;
            if (name.Length < 1)
                return false;
            try
            {
                SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
                connection.Open();

                try
                {
                    SqlCommand command = connection.CreateCommand();

                    command.CommandText = $"Update [Stock] set [StockAddress]=@name " +
                        $"where [StockID]={id}";
                    SqlParameterCollection parameters = command.Parameters;
                    parameters.AddWithValue("@name", name);
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
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateSityAtDB() => UpdateSityAtDB(this);

        public static bool UpdateSityAtDB(Stock organization) => UpdateSityAtDB(organization.ID, organization.SityID);
        public static bool UpdateSityAtDB(int id, int sityID)
        {
            
            if (sityID < 1)
                return false;
            try
            {
                SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
                connection.Open();

                try
                {
                    SqlCommand command = connection.CreateCommand();

                    command.CommandText = $"Update [Stock] set [StockSityID]={sityID} " +
                        $"where [StockID]={id}";
                    SqlParameterCollection parameters = command.Parameters;
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
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdatePhoneAtDB() => UpdatePhoneAtDB(this);

        public static bool UpdatePhoneAtDB(Pounkt organization) => UpdatePhoneAtDB(organization.ID, organization.Contact.Telephone);
        public static bool UpdatePhoneAtDB(int id, string telephone)
        {
            string name = telephone;
            try
            {
                SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
                connection.Open();

                try
                {
                    SqlCommand command = connection.CreateCommand();

                    command.CommandText = $"Update [Stock] set [StockTelephone]=@name " +
                        $"where [StockID]={id}";
                    SqlParameterCollection parameters = command.Parameters;
                    parameters.AddWithValue("@name", name);
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
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateEmailAtDB() => UpdateEmailAtDB(this);

        public static bool UpdateEmailAtDB(Pounkt organization) => UpdateEmailAtDB(organization.ID, organization.Contact.Email);
        public static bool UpdateEmailAtDB(int id, string email)
        {
            string name = email;
            try
            {
                SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
                connection.Open();

                try
                {
                    SqlCommand command = connection.CreateCommand();

                    command.CommandText = $"Update [Stock] set [StockEmail]=@name " +
                        $"where [StockID]={id}";
                    SqlParameterCollection parameters = command.Parameters;
                    parameters.AddWithValue("@name", name);
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
                return true;
            }
            catch
            {
                return false;
            }
        }


        public StoreHouse CopyEdit() => new StoreHouse()
        {
            Name = Name,
            Address = Address,
            Email = Contact.Email,
            Telephone = Contact.Telephone,
            Sity = Sity.Name
        };

    }
}
