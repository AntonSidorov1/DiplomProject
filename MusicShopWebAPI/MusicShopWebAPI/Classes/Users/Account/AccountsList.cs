using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    /// <summary>
    /// Список аккаунтов
    /// </summary>
    public class AccountsList : List<AccountWithID>
    {
        public AccountsList()
        {
        }

        public AccountsList(IEnumerable<AccountWithID> collection) : base(collection)
        {
        }

        public AccountsList(int capacity) : base(capacity)
        {
        }


        public AccountsList GetThis() => this;

        public static AccountsList GetDatasList() => new AccountsList();

        public void GetDatasFromDB(bool checkBlocked = true, int count = 20)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = DataBaseConnectionStringController.GetConnectionString();
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Select * From [User]";
                command.Parameters.Clear();
                if(checkBlocked)
                {
                    command.CommandText += " where [UserBlocked]=@blocked";
                    command.Parameters.AddWithValue("@blocked", false);
                }
                SqlDataReader reader = command.ExecuteReader();
                Clear();
                try
                {
                    while (reader.Read())
                    {
                        AccountWithID account = new AccountWithID();
                        account.ID = reader.GetInt32(reader.GetOrdinal("UserID"));
                        account.Login = reader.GetString(reader.GetOrdinal("UserLogin"));
                        account.Password = reader.GetString(reader.GetOrdinal("UserPassword"));
                        Add(account);
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
                if(count > 0)
                {
                    Thread.Sleep(AddressesList.GetRandomMilliSeconds());
                    GetDatasFromDB(checkBlocked, count - 1);
                    return;
                }
                throw e;
            }

        }

        public static AccountsList GetDatasListFromDB(bool checkBlocked = true)
        {
            AccountsList roles = GetDatasList();
            roles.GetDatasFromDB(checkBlocked);
            return roles;
        }


        public AccountWithID GetByID(int id)
        {
            return Find(r => r.ID == id);
        }

        public AccountWithID GetByLogin(string login)
        {
            return Find(r => r.EqualsLogin(login));
        }

        public bool Contains(string login)
        {
            return GetThis().Any(r => r.EqualsLogin(login));
        }

        public AccountWithID GetByParams(string login, string password)
        {
            return Find(r => r.EqualsLogin(login) && r.Password.Trim() == password.Trim());
        }

        public AccountWithID GetByParams(Account account) => GetByParams(account.Login, account.Password);

        public bool Contains(string login, string password)
        {
            return GetThis().Any(r => r.EqualsLogin(login) && r.Password.Trim() == password.Trim());
        }

        public bool ContainsAccount(Account account) => Contains(account.Login, account.Password);

        public int AddUserToDB(Account account)
        {
            AccountsList accounts = GetDatasListFromDB(false);

            accounts.Add(new AccountWithID() { ID = 0, Login = "" });
            accounts.Add(new AccountWithID() { ID = 0, Login = "Goest" });
            accounts.Add(new AccountWithID() { ID = 0, Login = "Гость" });

            if (accounts.Contains(account.Login))
            {
                return 0;
            }

            

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = DataBaseConnectionStringController.GetConnectionString();
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Insert Into [User] ([UserLogin], [UserPassword]) Values (@login, @password)";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@login", account.Login);
                command.Parameters.AddWithValue("@password", account.Password);

                command.ExecuteNonQuery();

                int id = GetDatasListFromDB().GetByLogin(account.Login).ID;

                connection.Close();

                return id;
            }
            catch (Exception e)
            {
                connection.Close();
                throw e;
            }

        }

        public bool AddRoleForUserInDB(int user, int role)
        {
            if (user == 0)
                return false;


            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = DataBaseConnectionStringController.GetConnectionString();
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"Insert Into [UserRole] ([UserID], [RoleID]) Values ({user}, {role})";
                command.Parameters.Clear();

                command.ExecuteNonQuery();

                connection.Close();

                return true;
            }
            catch (Exception e)
            {
                connection.Close();
                return false;
            }

        }

        public bool ChangePassword(string login, string newPassword)
        {
            AccountsList accounts = GetDatasListFromDB(false);

            if (!accounts.Contains(login))
            {
                return false;
            }

            login = accounts.GetByLogin(login).Login;

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = DataBaseConnectionStringController.GetConnectionString();
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Update [User] Set [UserPassword]=@password where [UserLogin]=@login";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", newPassword);

                command.ExecuteNonQuery();

                connection.Close();

                return true;
            }
            catch (Exception e)
            {
                connection.Close();
                return false;
            }

        }

        public bool AddUserWithRoleToDB(Account account, int role)
        {
            return AddRoleForUserInDB(AddUserToDB(account), role);
        }

        public bool AddClientToDB(Account account)
        {
            return AddUserWithRoleToDB(account, RolesList.GetDatasListFromDB().GetByName("Client").ID);
        }

        public bool ContainsByID(int id)
        {
            return GetThis().Any(r => r.ID == id);
        }

        /// <summary>
        /// Удалить пользователя из базы данных
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteFromDB(int id)
        {
            AccountsList telefons = GetDatasListFromDB();
            if (!telefons.ContainsByID(id))
            {
                return false;
            }

            SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"Delete From [User] where [UserID]={id}";

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
