using FileManegerJson;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Организация
    /// </summary>
    public class Organization : OrganizationValue
    {
        public Organization CopyOrganization()
        {
            try
            {
                Organization organization = new Organization
                {
                    ID = this.ID,
                    Name = this.Name,
                    Address = this.Address,
                    Contact = this.Contact.CopyContact(),
                    Site = this.Site,
                    Logotip = this.Logotip
                };
                return organization;
            }
            catch (ArgumentNullException e)
            {
                throw new Exception(e.Message, e);
            }
            catch (NullReferenceException e)
            {
                throw new Exception(e.Message, e);
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new Exception(e.Message, e);
            }
            catch (ArithmeticException e)
            {
                throw new Exception(e.Message, e);
            }
            catch (ArgumentException e)
            {
                throw new Exception(e.Message, e);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public DisributingFacilities CopyOrganizationEdit()
        {
            try
            {
                DisributingFacilities organization = new DisributingFacilities
                {
                    Name = this.Name,
                    Address = this.Address,
                    Telephone = this.Contact.Telephone,
                    Email = this.Contact.Email,
                    Site = this.Site,
                    Logotip = this.Logotip
                };
                return organization;
            }
            catch (ArgumentNullException e)
            {
                throw new Exception(e.Message, e);
            }
            catch (NullReferenceException e)
            {
                throw new Exception(e.Message, e);
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new Exception(e.Message, e);
            }
            catch (ArithmeticException e)
            {
                throw new Exception(e.Message, e);
            }
            catch (ArgumentException e)
            {
                throw new Exception(e.Message, e);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }


        string logotip = "";

        /// <summary>
        /// Логотип
        /// </summary>
        public string Logotip
        {
            get => logotip;
            set => logotip = value;
        }

        /// <summary>
        /// Установить логотип
        /// </summary>
        /// <param name="photo"></param>
        public void SetLogotip(byte[] photo)
        {
            Logotip = Convert.ToBase64String(photo);
        }

        public byte[] LogotipBytes
        {
            get => Convert.FromBase64String(Logotip);
            set => SetLogotip(value);
        }


        public Bitmap LogotipImage
        {
            get
            {
                MemoryStream memory = new MemoryStream(LogotipBytes);
                Bitmap bitmap = new Bitmap(memory);
                memory.Close();
                return bitmap;
            }
            set
            {
                MemoryStream memory = new MemoryStream();
                value.Save(memory, System.Drawing.Imaging.ImageFormat.Jpeg);
                LogotipBytes = memory.ToArray();
            }
        }



        public bool DeleteFromDB() => DeleteFromDB(this);
        public static bool DeleteFromDB(Part organization)
            => DeleteFromDB(organization.ID);

        public static bool DeleteFromDB(int id)
        {
            try
            {
                SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
                connection.Open();

                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = $"Delete From [Organization] " +
                        $"where [OrganizationID]={id}";
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

        public bool NoHaveImage => !HaveImage;

        public bool HaveImage
        {
            get
            {
                try
                {
                    Bitmap bitmap = new Bitmap(LogotipImage);
                    return true;
                }
                catch (ArgumentNullException e)
                {
                    return false;
                }
                catch (NullReferenceException e)
                {
                    return false;
                }
                catch (ArgumentException e)
                {
                    return false;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool AddToDB()
            => AddToDB(this);

        public static bool AddToDB(Organization organization)
        {
            if(!organization.Saving())
            {
                return false;
            }
            try
            {
                SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
                connection.Open();

                try
                {
                    SqlCommand command = connection.CreateCommand();

                    string columnName = $"[OrganizationName]" +
                        $",[OrganizationTelephone]" +
                        $",[OrganizationEmail]" +
                        $",[OrgamizationAddress]" +
                        $",[OrganizationSite]";
                    string values = $"@name, @telefone, @email, @address, @site";
                    if(organization.HaveImage)
                    {
                        columnName += ",[OrganizationLogotip]";
                        values += ",@image";
                    }
                    command.CommandText = $"Insert Into [Organization]({columnName}) " +
                        $"Output INSERTED.OrganizationID " +
                        $"Values({values})";
                    SqlParameterCollection parameters = command.Parameters;
                    parameters.AddWithValue("@name", organization.Name);
                    parameters.AddWithValue("@telefone", organization.Contact.Telephone);
                    parameters.AddWithValue("@email", organization.Contact.Email);
                    parameters.AddWithValue("@site", organization.Site);
                    parameters.AddWithValue("@address", organization.Address);
                    if (organization.HaveImage)
                    {
                        parameters.AddWithValue("@image", organization.LogotipBytes);
                    }

                    try
                    {
                        organization.ID = Convert.ToInt32(command.ExecuteScalar());
                    }
                    catch (Exception e)
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

                    command.CommandText = $"Update [Organization] set [OrganizationName]=@name " +
                        $"where [OrganizationID]={id}";
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

                    command.CommandText = $"Update [Organization] set [OrgamizationAddress]=@name " +
                        $"where [OrganizationID]={id}";
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

        public bool UpdateSiteAtDB() => UpdateSiteAtDB(this);

        public static bool UpdateSiteAtDB(Organization organization) => UpdateSiteAtDB(organization.ID, organization.Site);
        public static bool UpdateSiteAtDB(int id, string site)
        {
            string name = site;
            try
            {
                SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
                connection.Open();

                try
                {
                    SqlCommand command = connection.CreateCommand();

                    command.CommandText = $"Update [Organization] set [OrganizationSite]=@name " +
                        $"where [OrganizationID]={id}";
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

                    command.CommandText = $"Update [Organization] set [OrganizationTelephone]=@name " +
                        $"where [OrganizationID]={id}";
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

                    command.CommandText = $"Update [Organization] set [OrganizationEmail]=@name " +
                        $"where [OrganizationID]={id}";
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

        public bool UpdateLogotipAtDB()
        {
            return UpdateLogotipAtDB(this);
        }

        public static bool UpdateLogotipAtDB(Organization organization)
        {
            Organization product = organization;
            try
            {
                SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                try
                {
                    try
                    {
                        if (product.HaveImage)
                        {
                            command.CommandText = $"UPDATE[Organization]" +
                            $" SET [OrganizationLogotip]=@photo " +
                            $"WHERE [OrganizationID]={organization.ID} ";
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@photo", product.LogotipBytes);
                            command.ExecuteNonQuery();

                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    catch
                    {
                        command.CommandText = $"UPDATE[Organization]" +
                           $" SET [OrganizationLogotip]=NULL " +
                           $"WHERE [OrganizationID]={organization.ID} ";
                        command.Parameters.Clear();
                        //command.Parameters.AddWithValue("@photo", SqlBinary.Null.Value);
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
            }
            catch
            {
                return false;
            }



            return true;
        }

    }
}
