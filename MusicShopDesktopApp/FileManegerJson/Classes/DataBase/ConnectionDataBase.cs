using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;
using System.Data.SqlClient;

namespace FileManegerJson
{
    [DataContract]
    public class ConnectionDataBase : ConnectionStringDataBase
    {

        public static ConnectionDataBase GetConnection(string connectionString)
        {
            return new ConnectionDataBase(connectionString);
        }

        public ConnectionDataBase(string DataSource, string InitialCatalog, bool IntegratedSecurity, bool PersistSecurityInfo, string UserID, string Password) : this()
        {
            this.DataSource = DataSource;
            this.InitialCatalog = InitialCatalog;
            this.IntegratedSecurity = IntegratedSecurity;
            this.PersistSecurityInfo = PersistSecurityInfo;
            this.UserID = UserID;
            this.Password = Password;
        }

        public ConnectionDataBase()
        {

        }

        public ConnectionDataBase(SqlConnectionStringBuilder builder)
        {
            Builder = builder;
        }

        public SqlConnectionStringBuilder Builder { get => new SqlConnectionStringBuilder(ConnectionString); set => ConnectionString = value.ConnectionString; }

        public ConnectionDataBase(string connectionString) : this()
        {
            ConnectionString = connectionString;
        }

        public ConnectionDataBase(ConnectionDataBase bulder) : this(bulder.ConnectionString)
        {

        }

        /// <summary>
        /// Возвращает стркоу подключения к базе данных
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Connection;

        public SqlConnection SqlConnection
        {
            get => new SqlConnection(ConnectionString);
            set => ConnectionString = value.ConnectionString;
        }


        /// <summary>
        /// Строка подключения к базе данных
        /// </summary>
        public string Connsection
        {
            get
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                try
                {
                    builder.DataSource = DataSource;
                }
                catch
                {
                    builder.DataSource = "";
                }
                try
                {
                    builder.InitialCatalog = InitialCatalog;
                }
                catch
                {
                    builder.InitialCatalog = "";
                }
                try
                {
                    builder.IntegratedSecurity = IntegratedSecurity;
                }
                catch
                {
                    builder.IntegratedSecurity = true;
                }
                try
                {
                    builder.PersistSecurityInfo = PersistSecurityInfo;
                }
                catch
                {
                    builder.PersistSecurityInfo = false;
                }
                try
                {
                    builder.UserID = UserID;
                }
                catch
                {
                    builder.UserID = "";
                }
                try
                {
                    builder.Password = Password;
                }
                catch
                {
                    builder.Password = "";
                }

                return builder.ConnectionString;
            }
            set
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(value);
                DataSource = builder.DataSource;
                InitialCatalog = builder.InitialCatalog;
                IntegratedSecurity = builder.IntegratedSecurity;
                PersistSecurityInfo = builder.PersistSecurityInfo;
                UserID = builder.UserID;
                Password = builder.Password;
            }
        }

        /// <summary>
        /// Строка подключения к базе данных
        /// </summary>
        public string Connection { get => Connsection; set => Connsection = value; }

        // <summary>
        /// Строка подключения к базе данных
        /// </summary>
        public string ConnectionString
        {
            get => Connection;
            set => Connection = value;
        }

        /// <summary>
        /// Сервер и база данных
        /// </summary>
        public string ServerDB => DataSource + "\\" + InitialCatalog;

        public void SaveJson(string fileName)
        {
            fileName = fileName.Replace('/', '\\');
            string[] points = fileName.Split('.');
            int last = points.Length - 1;
            points[last] = points[last].Trim().ToLower();
            fileName = string.Join(".", points);
            JsonWrite(this, this.GetType(), fileName);
        }



        /// <summary>
        /// Сохраняет объект obj с типом type в Json-файл namefile
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <param name="namefile"></param>
        public static void JsonWrite(object obj, Type type, string namefile)
        {
            FileStream fileStream = new FileStream(namefile, FileMode.Create);
            try
            {
                namefile = namefile.Replace('/', '\\');
                DataContractJsonSerializer json = new DataContractJsonSerializer(type);
                json.WriteObject(fileStream, obj);
                fileStream.Close();
            }
            catch(Exception e)
            {
                try
                {
                    fileStream.Close();
                }
                catch
                {

                }
                throw e;
            }

        }


        /// <summary>
        /// Чтение из Json-файла
        /// </summary>
        /// <param name="namefile"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object JsonRead(string namefile, Type type)
        {

            namefile = namefile.Replace('/', '\\');
            DataContractJsonSerializer json = new DataContractJsonSerializer(type);
            FileStream fileStream = new FileStream(namefile, FileMode.Open);
            try
            {
                object obj = json.ReadObject(fileStream);
                fileStream.Close();
                return obj;
            }
            catch(Exception e)
            {
                fileStream.Close();
                throw e;
            }


        }

        public static ConnectionDataBase Load(string fileName)
        {


            return (ConnectionDataBase)JsonRead(fileName, typeof(ConnectionDataBase));
        }

        public void Loadjson(string fileName)
        {
            ConnectionDataBase dataBase = Load(fileName);
            ConnectionString = dataBase.ConnectionString;
        }

    }
}

