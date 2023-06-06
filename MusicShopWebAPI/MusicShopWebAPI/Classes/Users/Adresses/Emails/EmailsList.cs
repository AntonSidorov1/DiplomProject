using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    /// <summary>
    /// Список телефонов
    /// </summary>
    public class EmailsList : AddressesList<Email>
    {
        public EmailsList()
        {
        }

        public EmailsList(IEnumerable<Email> collection) : base(collection)
        {
        }

        public EmailsList(int capacity) : base(capacity)
        {
        }

        public static EmailsList GetList() => new EmailsList();
        public EmailsList GetThis() => this;

        public static EmailsList GetListFromDB(int user)
        {
            EmailsList telefons = GetList();
            telefons.GetFromBD(user);
            return telefons;
        }


        public override void GetFromBD(int user, int count = 20)
        {
            SqlConnection connection = new SqlConnection();
            connection = DataBaseConfiguration.GetSqlConnection();
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"Select * From [UserEmail] where [UserID]={user}";

                SqlDataReader reader = command.ExecuteReader();
                Clear();
                try
                {
                    while (reader.Read())
                    {
                        Email product = new Email();
                        product.ID = reader.GetInt32(reader.GetOrdinal("EmailID"));
                        product.Value = reader.GetString(reader.GetOrdinal("Email"));

                        Add(product);
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    reader.Close();
                    throw new Exception(e.Message, e);
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
                if(count > 0)
                {
                    Thread.Sleep(GetRandomMilliSeconds());
                    GetFromBD(user, count - 1);
                    return;
                }
                throw new Exception(e.Message, e);
            }
        }

        /// <summary>
        /// Добавить Email-адрес в базу данных
        /// </summary>
        /// <param name="user"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public override bool AddToDB(int user, Email address)
        {
            EmailsList telefons = GetListFromDB(user);
            if (telefons.Contains(address.Value))
            {
                return false;
            }

            SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Insert Into [UserEmail] ([UserID], [Email]) Values (@login, @telefon)";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@login", user);
                command.Parameters.AddWithValue("@telefon", address.Value);

                command.ExecuteNonQuery();

                connection.Close();

                return true;
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
                return false;
            }

        }

        /// <summary>
        /// Удалить Email-адрес из базы данных
        /// </summary>
        /// <param name="user"></param>
        /// <param name="telefon"></param>
        /// <returns></returns>
        public override bool DeleteFromDB(int user, int telefon)
        {
            EmailsList telefons = GetListFromDB(user);
            if (!telefons.ContainsByID(telefon))
            {
                return false;
            }

            SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"Delete From [UserEmail] where [EmailID]={telefon}";

                command.ExecuteNonQuery();

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
                return false;
            }


            return true;
        }
    }
}
