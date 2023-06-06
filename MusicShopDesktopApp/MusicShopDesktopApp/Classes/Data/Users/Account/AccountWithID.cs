using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Аккаунт с ID
    /// </summary>
    public class AccountWithID : Account
    {
        bool blocked = false;

        public string Data
        {
            get => $"Логин - {Login} \n" +
                $"Пароль - {Password} \n" +
                (Blocked ? $"Заблокирован" : "Разблокирован");
        }

        /// <summary>
        /// Заблокирован ли пользователь
        /// </summary>
        public bool Blocked
        {
            get => blocked;
            set => blocked = value;
        }

        /// <summary>
        /// Разблокирован ли пользователь
        /// </summary>
        public bool NoBlocked
        {
            get => !Blocked;
            set => Blocked = !value;
        }

        public override bool EqualsLogin(string login)
        {
            return base.EqualsLogin(login);
        }

        int id = 0;

        /// <summary>
        /// ID пользователя
        /// </summary>
        public int ID
        {
            get => id;
            set => id = value;
        }


        public virtual AccountWithAddress GetWithAddress()
        {
            return GetUserWithRoles().GetWithAddress();
        }

        public AccountWithRoles GetUserWithRoles()
        {
            AccountWithRoles account = new AccountWithRoles { Login = this.Login, Password = this.Password, ID = this.ID };
            RolesList roles = RolesList.GetDatasListFromDB();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = DataBaseConnectionEdit.GetConnectionString();
            connection.Open();

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"Select [UserFIO] From [UserInitials] where [UserID]={ID}";
                account.FIO.Initials = Convert.ToString(command.ExecuteScalar()) ?? "";
            }
            catch
            {
                account.FIO.Initials = "";
            }

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"Select [RoleID] From [UserRole] where [UserID]={ID}";
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int role = reader.GetInt32(0);
                            account.Roles.Add(roles.Find(r => r.ID == role));
                        }
                        reader.Close();
                    }
                    else
                    {
                        throw new UserException("Пользователь с данным логином не имеет ролей в системе") { Code = 406 }; ;
                    }
                }
                catch (Exception e)
                {
                    try
                    {
                        reader.Close();
                    }
                    catch
                    {

                    }
                    throw new UserException("Пользователь с данным логином не имеет ролей в системе") { Code = 406 }; ;
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
                throw e;
            }
            return account;
        }

        
    }
}
