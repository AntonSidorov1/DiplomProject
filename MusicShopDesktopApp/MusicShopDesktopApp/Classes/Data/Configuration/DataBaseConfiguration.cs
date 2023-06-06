using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    public static class DataBaseConfiguration 
    {
        static SessionEditList sessionsList = new SessionEditList();
        public static SessionEditList SessionsList
        {
            get => sessionsList;
            set => sessionsList = value;
        }

        public static string ConnectionString
        {
            get => GetConnectionStringFromFile();
            set => GetConnectionStringFromFile(value);
        }

        public static Secret Password
        {
            get => new Secret(Properties.Settings.Default.Password);
            set
            {
                Properties.Settings.Default.Password = value.Password;
                Properties.Settings.Default.Save();
            }
        }


        static string path = "";

        public static string Path
        {
            get => path;
            set => path = value;
        }

        public static string GetConnectionStringFromFile(string connectionString = "")
        {
            try
            {
                ConnectionDataBase connection = new ConnectionDataBase(Properties.Settings.Default.ConnectionString);
                if(connectionString != "")
                {
                    connection.ConnectionString = connectionString;
                    Properties.Settings.Default.ConnectionString = connection.ConnectionString;
                    Properties.Settings.Default.Save();
                    return GetConnectionStringFromFile("");
                }
                return connection.ConnectionString;
            }
            catch
            {
                ConnectionDataBase connection = new ConnectionDataBase(Properties.Settings.Default.ConnectionStringDefault);
                Properties.Settings.Default.ConnectionString = connection.ConnectionString;
                Properties.Settings.Default.Save();
                return GetConnectionStringFromFile(connectionString);
            }
            return "";
        }


        public static void Clear()
        {
            try
            {
                string connectionString = Properties.Settings.Default.ConnectionStringDefault;
                Properties.Settings.Default.ConnectionString = connectionString;
            }
            catch
            {

            }
        }

        public static ConnectionStringDataBase GetConnection()
        {
            return ConnectionDataBase.GetConnection(ConnectionString).Copy();
        }

        public static SqlConnection GetSqlConnection()
        {
            
                return GetConnection().CopyWithFull().SqlConnection;
        }

        public static bool Check()
        {
            SqlConnection sql = ConnectionDataBase.GetConnection(ConnectionString).SqlConnection;
            try
            {
                sql.Open();
                sql.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
