using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    public class RolesList : List<Role>
    {
        public RolesList()
        {
        }

        public RolesList(IEnumerable<Role> collection) : base(collection)
        {
        }

        public RolesList(int capacity) : base(capacity)
        {
        }

        public RolesList GetThis() => this;

        public static RolesList GetDatasList() => new RolesList();

        public void GetDatasFromDB(int count = 20)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = DataBaseConnectionStringController.GetConnectionString();
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Select * From [Role]";
                SqlDataReader reader = command.ExecuteReader();
                Clear();
                Add(new Role
                {
                    ID = 0,
                    RoleEng = "Goest",
                    RoleRus = "Гость"
                }) ;
                try
                {
                    while(reader.Read())
                    {
                        Role role = new Role();
                        role.ID = reader.GetInt32(reader.GetOrdinal("RoleID"));
                        role.RoleRus = reader.GetString(reader.GetOrdinal("RoleName"));
                        role.RoleEng = reader.GetString(reader.GetOrdinal("RoleNameEng"));
                        Add(role);
                    }
                    reader.Close();
                }
                catch(Exception e)
                {
                    try
                    {
                        reader.Close();
                    }
                    catch
                    {

                    }
                    throw e;
                }
                connection.Close();
            }
            catch(Exception e)
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
                    GetDatasFromDB(count - 1);
                    return;
                }
                throw e;
            }

        }

        public static RolesList GetDatasListFromDB()
        {
            RolesList roles = GetDatasList();
            roles.GetDatasFromDB();
            return roles;
        }

        public Role GetByID(int id)
        {
            return Find(r => r.ID == id);
        }

        public Role GetByName(string name)
        {
            return Find(r => r == name);
        }

        public bool Contains(string name)
        {
            return GetThis().Any(r => r.Equals(name));
        }



        /// <summary>
        /// Получить список ролей по заданному условию
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public RolesList Get(Predicate<Role> predicate) => new RolesList(FindAll(predicate));

        public string GetRolesName()
        {
            List<string> roles = new List<string>();
            for (int i = 0; i < Count; i++)
            {
                roles.Add(this[i].RoleEng);
            }
            return string.Join(",", roles);
        }
    }
}
