using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    public static class DataBaseConfiguration 
    {
        static SessionEditList sessionsList = new SessionEditList();
        public static SessionEditList SessionsList
        {
            get => sessionsList;
            set => sessionsList = value;
        }

        static string connectionStringText = "";

        public static string ConnectionString
        {
            get => GetConnectionStringFromFile();
            set => GetConnectionStringFromFile(value);
        }

        static Secret password = new Secret();

        /// <summary>
        /// Пароль
        /// </summary>
        public static Secret Password
        {
            get
            {


                password = Secret.Load(Path + @"\Password.json");
                return password;
            }
            set
            {
                password = value;

                password.SaveJson(Path + @"\Password.json");

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
            if (connectionString != "")
                connectionStringText = connectionString;
            try
            {
                try
                {
                    ConnectionDataBase connection = ConnectionDataBase.Load(Path + @"\ConnectionString.json");
                    if (connectionString != "")
                    {
                        connectionStringText = connectionString;
                        try
                        {
                            connection.ConnectionString = connectionString;
                            connection.SaveJson(Path + @"\ConnectionString.json");
                            return GetConnectionStringFromFile("");
                        }
                        catch
                        {
                            return connectionStringText;
                        }
                    }
                    else
                    {
                        if(connectionStringText != "")
                        {
                            if (connectionStringText != connection.ConnectionString)
                            {
                                try
                                {
                                    connection.ConnectionString = connectionStringText;
                                    connection.SaveJson(Path + @"\ConnectionString.json");
                                    return GetConnectionStringFromFile("");
                                }
                                catch
                                {

                                }
                            }
                        }
                    }
                    connectionStringText = connection.ConnectionString;
                    return connectionStringText;
                }
                catch(Exception ex)
                {
                    if (connectionStringText != "")
                        return connectionStringText;
                    throw ex;
                }
            }
            catch
            {
                try
                {
                    ConnectionDataBase connection = ConnectionDataBase.Load(Path + @"\ConnectionStringDefault.json");
                    connection.SaveJson(Path + @"\ConnectionString.json");
                    return GetConnectionStringFromFile(connectionString);
                }
                catch (Exception ex)
                {
                    if (connectionStringText != "")
                        return connectionStringText;
                    throw ex;
                }
            }
            return "";
        }


        public static void Clear()
        {
            try
            {
                File.Delete(Path + @"\ConnectionString.json");
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
