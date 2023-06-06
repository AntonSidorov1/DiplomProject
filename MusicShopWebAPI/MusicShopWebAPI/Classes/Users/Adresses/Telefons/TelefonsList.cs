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
    public class TelefonsList : AddressesList<Telefon>
    {
        public TelefonsList()
        {
        }

        public TelefonsList(IEnumerable<Telefon> collection) : base(collection)
        {
        }

        public TelefonsList(int capacity) : base(capacity)
        {
        }

        public static TelefonsList GetList() => new TelefonsList();
        public TelefonsList GetThis() => this;

        public static TelefonsList GetListFromDB(int user)
        {
            TelefonsList telefons = GetList();
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
                command.CommandText = $"Select * From [UserTelefon] where [UserID]={user}";

                SqlDataReader reader = command.ExecuteReader();
                Clear();
                try
                {
                    while (reader.Read())
                    {
                        Telefon product = new Telefon();
                        product.ID = reader.GetInt32(reader.GetOrdinal("TelefonID"));
                        product.Value = reader.GetString(reader.GetOrdinal("Telefon"));

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
                if (count > 0)
                {
                    Thread.Sleep(GetRandomMilliSeconds());
                    GetFromBD(user, count - 1);
                    return;
                }
                throw new Exception(e.Message, e);
            }
        }



        /// <summary>
        /// Добавить телефон в базу данных
        /// </summary>
        /// <param name="user"></param>
        /// <param name="telefon"></param>
        /// <returns></returns>
        public override bool AddToDB(int user, Telefon telefon)
        {
            TelefonsList telefons = GetListFromDB(user);
            if (telefons.Contains(telefon.Value))
            {
                return false;
            }

            SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Insert Into [UserTelefon] ([UserID], [Telefon]) Values (@login, @telefon)";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@login", user);
                command.Parameters.AddWithValue("@telefon", telefon.Value);

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
        /// Удалить телефон из базы данных
        /// </summary>
        /// <param name="user"></param>
        /// <param name="telefon"></param>
        /// <returns></returns>
        public override bool DeleteFromDB(int user, int telefon)
        {
            TelefonsList telefons = GetListFromDB(user);
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
                command.CommandText = $"Delete From [UserTelefon] where [TelefonID]={telefon}";

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
