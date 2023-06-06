using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Город
    /// </summary>
    public class Sity : GeographyPoint
    {
        /// <summary>
        /// Получить данные
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Название - " + Name;
        }

        /// <summary>
        /// Данные
        /// </summary>
        public string Data => ToString();


        /// <summary>
        /// Создать копию объекта
        /// </summary>
        /// <returns></returns>
        public Sity CopySity() => new Sity
        {
            ID = this.ID,
            Name = this.Name
        };


        public bool AddToDB() => AddToDB(this);

        public static bool AddToDB(Sity sity) => AddToDB(sity.Name);

        public static bool AddToDB(string name)
        {
            try
            {
                SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
                connection.Open();

                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = $"Insert Into [Sity] ([SityName]) values(@name)";
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@name", name);
                    command.ExecuteNonQuery();
                }
                catch(Exception e)
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

        public bool UpdateAtDB() => UpdateAtDB(this);
        public static bool UpdateAtDB(Part sity)
            => UpdateAtDB(sity.ID, sity.Name);

        public static bool UpdateAtDB(int id, string name)
        {
            try
            {
                SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
                connection.Open();

                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = $"Update [Sity] Set [SityName]=@name " +
                        $"where [SityID]={id}";
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@name", name);
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

        public bool DeleteFromDB() => DeleteFromDB(this);
        public static bool DeleteFromDB(Part sity)
            => DeleteFromDB(sity.ID);

        public static bool DeleteFromDB(int id)
        {
            try
            {
                SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
                connection.Open();

                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = $"Delete From [Sity] " +
                        $"where [SityID]={id}";
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


        public virtual bool EqualsName(string name)
        {
            string Login = Name;
            string login = name;
            if (Login == login)
                return true;
            if (StringNormalize.Normalize(Login, formatEnd: FormatEnd.None).ToLower() == StringNormalize.Normalize(login, formatEnd: FormatEnd.None).ToLower())
                return true;
            if (Login.ToLower() == login.ToLower())
                return true;
            if (StringNormalize.Normalize(Login, formatEnd: FormatEnd.None).ToLower() == login.ToLower())
                return true;
            if (Login.ToLower() == StringNormalize.Normalize(login, formatEnd: FormatEnd.None).ToLower())
                return true;

            if (StringNormalize.Normalize(Login, formatEnd: FormatEnd.None).ToLower() == StringNormalize.Normalize(login, snakeCase: false, formatEnd: FormatEnd.None).ToLower())
                return true;
            if (StringNormalize.Normalize(Login, snakeCase: false, formatEnd: FormatEnd.None).ToLower() == StringNormalize.Normalize(login, formatEnd: FormatEnd.None).ToLower())
                return true;
            if (Login.ToLower() == StringNormalize.Normalize(login, snakeCase: false, formatEnd: FormatEnd.None).ToLower())
                return true;
            if (StringNormalize.Normalize(Login, snakeCase: false, formatEnd: FormatEnd.None).ToLower() == login.ToLower())
                return true;
            if (StringNormalize.Normalize(Login, snakeCase: false, formatEnd: FormatEnd.None).ToLower() == StringNormalize.Normalize(login, snakeCase: false, formatEnd: FormatEnd.None).ToLower())
                return true;


            if (Login.ToLower() == StringNormalize.DropDefices(login).ToLower())
                return true;
            if (StringNormalize.DropDefices(Login).ToLower() == login.ToLower())
                return true;

            if (StringNormalize.Normalize(Login, formatEnd: FormatEnd.None).ToLower() == StringNormalize.DropDefices(login).ToLower())
                return true;
            if (StringNormalize.DropDefices(Login).ToLower() == StringNormalize.Normalize(login, formatEnd: FormatEnd.None).ToLower())
                return true;

            if (StringNormalize.DropDefices(Login).ToLower() == StringNormalize.Normalize(login, snakeCase: false, formatEnd: FormatEnd.None).ToLower())
                return true;
            if (StringNormalize.Normalize(Login, snakeCase: false, formatEnd: FormatEnd.None).ToLower() == StringNormalize.DropDefices(login).ToLower())
                return true;

            return false;
        }

    }
}
