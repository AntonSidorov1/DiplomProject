using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using FileManegerJson;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// торговый пункт
    /// </summary>
    public class TradingPoint : Pounkt
    {
        Stock stock = new Stock();

        public override bool Saving()
        {
            return base.Saving() && Schedule.Length > 0;
        }

        /// <summary>
        /// Склад
        /// </summary>
        public Stock Stock
        {
            get => stock;
            set => stock = value;
        }

        /// <summary>
        /// Установить склад из базы данных, по его идентификатору
        /// </summary>
        /// <param name="id"></param>
        public void SetStockByID(int id)
        {
            SetStockByID(id, StocksList.GetListFromDB());
        }

        /// <summary>
        /// Установить склад из базы данных, по идентификатору StockID
        /// </summary>
        public void SetStockByID()
        {
            SetStockByID(StockID);
        }

        /// <summary>
        /// Установить склад из базы данных, по его идентификатору
        /// </summary>
        /// <param name="id"></param>
        public void SetStockByID(int id, StocksList stocks)
        {
            if (stocks.ContainsByID(id))
                Stock = stocks.GetByID(id).CopyStock();
        }

        /// <summary>
        /// Установить склад из базы данных, по идентификатору StockID
        /// </summary>
        public void SetStockByID(StocksList stocks)
        {
            SetStockByID(StockID, stocks);
        }

        OrganizationValue organization = new OrganizationValue();

        /// <summary>
        /// Организация
        /// </summary>
        public OrganizationValue Organization
        {
            get => organization;
            set => organization = value;
        }

        /// <summary>
        /// ID организации
        /// </summary>
        public int OrganizationID
        {
            get => Organization.ID;
            set => Organization.ID = value;
        }

        /// <summary>
        /// ID склада
        /// </summary>
        public int StockID
        {
            get => Stock.ID;
            set => Stock.ID = value;
        }

        /// <summary>
        /// Установить огранизацию из базы данных, по его идентификатору
        /// </summary>
        /// <param name="id"></param>
        public void SetOrganizationByID(int id)
        {
            SetOrganizationByID(id, OrganizationsList.GetListFromDB());
        }

        /// <summary>
        /// Установить огранизацию из базы данных, по идентификатору OrganizationID
        /// </summary>
        public void SetOrganizationByID()
        {
            SetOrganizationByID(OrganizationID);
        }

        /// <summary>
        /// Установить огранизацию из базы данных, по его идентификатору
        /// </summary>
        /// <param name="id"></param>
        public void SetOrganizationByID(int id, OrganizationsList organizations)
        {
            if (organizations.ContainsByID(id))
                Organization = organizations.GetByID(id).CopyValue();
        }

        /// <summary>
        /// Установить огранизацию из базы данных, по идентификатору OrganizationID
        /// </summary>
        public void SetOrganizationByID(OrganizationsList organizations)
        {
            SetOrganizationByID(OrganizationID, organizations);
        }

        string schedule = "";

        /// <summary>
        /// Режим работы
        /// </summary>
        public string Schedule
        {
            get => schedule;
            set => schedule = value;
        }

        TradeArea shop = new TradeArea();

        /// <summary>
        /// Магазин
        /// </summary>
        public TradeArea Shop
        {
            get => shop;
            set => shop = value;
        }

        TradeArea pounktOfIssue = new TradeArea();

        /// <summary>
        /// Пункт выдачи
        /// </summary>
        public TradeArea PounktOfIssue
        {
            get => pounktOfIssue;
            set => pounktOfIssue = value;
        }

        /// <summary>
        /// Существует ли магазин
        /// </summary>
        /// <returns></returns>
        public bool ExistenceShop
        {
            get => Shop.Existence;
            set => Shop.Existence = value;
        }

        /// <summary>
        /// Существует ли пункт выдачи
        /// </summary>
        /// <returns></returns>
        public bool ExistencePounktOfIssue
        {
            get => PounktOfIssue.Existence;
            set => PounktOfIssue.Existence = value;
        }


        public void UpdatePointData()
        {
            Shop.UpdateExience();
            PounktOfIssue.UpdateExience();
        }

        /// <summary>
        /// Установить магазин по ID из базы данных
        /// </summary>
        /// <param name="id"></param>
        public void SetShopByID(int id)
        {
            try
            {
                SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "SELECT [PounktID], [ShopName] " +
                        "FROM [Shop] " +
                        $"where [PounktID] = {id}";
                    SqlDataReader reader = command.ExecuteReader();

                    try
                    {
                        if(reader.Read())
                        {
                            Shop.ID = reader.GetInt32(0);
                            Shop.Name = reader.GetString(1);
                            Shop.Existence = true;
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    catch (Exception e)
                    {
                        reader.Close();
                        throw e;
                    }

                    reader.Close();
                }
                catch(Exception e)
                {
                    connection.Close();
                    throw e;
                }

                connection.Close();
            }
            catch
            {
                Shop.Existence = false;
                Shop.Name = "";
                Shop.ID = id;
            }
        }

        /// <summary>
        /// Установить магазин по ID данного торгового пункта из базы данных
        /// </summary>
        public void SetShopByID()
        {
            SetShopByID(ID);
        }

        /// <summary>
        /// Установить пункт выдачи по ID из базы данных
        /// </summary>
        /// <param name="id"></param>
        public void SetPounktOfIssueByID(int id)
        {
            try
            {
                SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "SELECT [PounktID], [PounktOfIssoueName] " +
                        "FROM [PounktOfIssue] " +
                        $"where [PounktID] = {id}";
                    SqlDataReader reader = command.ExecuteReader();

                    try
                    {
                        if (reader.Read())
                        {
                            PounktOfIssue.ID = reader.GetInt32(0);
                            PounktOfIssue.Name = reader.GetString(1);
                            PounktOfIssue.Existence = true;
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    catch (Exception e)
                    {
                        reader.Close();
                        throw e;
                    }

                    reader.Close();
                }
                catch (Exception e)
                {
                    connection.Close();
                    throw e;
                }

                connection.Close();
            }
            catch
            {
                PounktOfIssue.Existence = false;
                PounktOfIssue.Name = "";
                PounktOfIssue.ID = id;
            }
        }

        /// <summary>
        /// Установить пункт выдачи по ID данного торгового пункта из базы данных
        /// </summary>
        public void SetPounktOfIssueByID()
        {
            SetPounktOfIssueByID(ID);
        }

        /// <summary>
        /// Установить магазин и пункт выдачи по ID пункта из базы данных
        /// </summary>
        /// <param name="id"></param>
        public void SetPointByID(int id)
        {
            SetShopByID(id);
            SetPounktOfIssueByID(id);
        }

        /// <summary>
        /// Установить магазин и пункт выдачи по данного торгового ID пункта из базы данных
        /// </summary>
        public void SetPointByID()
        {
            SetPointByID();
        }

        /// <summary>
        /// Установить полные данные из базы данных, по их идентификаторам
        /// </summary>
        public void SetDataByIDs()
        {
            SetStockByID();
            SetOrganizationByID();
            SetPointByID();
        }

        /// <summary>
        /// Получить данные
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() + "\n" +
                $"Организация - {Organization.Name} \n\n" +
                "Склад:" +
                $"{Stock} \n" +
                (ExistenceShop ? $"Магазин - {Shop.Name}" : "Магазин отсутствует") + "\n" +
                (ExistencePounktOfIssue ? $"Пункт выдачи - {PounktOfIssue.Name}" : "Пункт выдачи отсутствует") + "\n" +
                $"Сайт {(Site != "" ? "- " + Site : "отсутствует")} \n" +
                $"Режим работы - {Schedule}";
        }

        string sitePath = "";

        /// <summary>
        /// Путь на сайте организации
        /// </summary>
        public string SitePath
        {
            get => sitePath;
            set => sitePath = value;
        }

        public TradingPoint CopyPoint()
        {
            return new TradingPoint
            {
                ID = this.ID,
                Name = this.Name,
                Stock = this.Stock.CopyStock(),
                Organization = this.Organization,
                Shop = this.Shop,
                PounktOfIssue = this.PounktOfIssue,
                SitePath = this.SitePath,
                Contact = this.Contact,
                Address = this.AddressData
            };
        }

        /// <summary>
        /// Сайт
        /// </summary>
        public string Site
        {
            get
            {
                if (Organization.Site == "")
                    return "";
                if (SitePath == "")
                    return Organization.Site;
                string site = Organization.Site.Trim().Trim('/').Trim();
                string path = sitePath.Trim().Trim('/').Trim();
                return site + "/" + path;
            }
        }


        public override string AddressData => Stock.Sity.Name + ", " + Address;

        public override string RegistrateData
        {
            get
            {
                string data = $"Название - «{Name}» \n" +
                    $"Организация - «{Organization.Name}» \n" +
                    $"Адрес - «{AddressData}»";

                return data;
            }
        }

        public bool DeleteFromDB() => DeleteFromDB(this);
        public static bool DeleteFromDB(TradingPoint point) => DeleteFromDB(point.ID);
        public static bool DeleteFromDB(int id)
        {
            try
            {
                SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
                connection.Open();

                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = $"Delete From [Pounkt] " +
                        $"where [PounktID]={id}";
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


        public bool AddToDB() => AddToDB(this);
        public static bool AddToDB(TradingPoint shop)
        {
            shop.UpdatePointData();
            TradingPoint stock = shop;
            try
            {
                SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
                connection.Open();

                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = $"Insert Into [Pounkt] " +
                        $"([PounktAddress]," +
                        $"[PounktOrganizationID]," +
                        $"[PounktName]," +
                        $"[PounktSchedule]," +
                        $"[PounktStockID]," +
                        $"[PounktTelephone]," +
                        $"[PounktEmail]," +
                        $"[SitePath]) " +
                        $"Output INSERTED.PounktID " +
                        $" Values (@address, {stock.OrganizationID}, @name, @schedule, {stock.StockID}, @phone, @email, @site)";
                    SqlParameterCollection parameters = command.Parameters;
                    parameters.AddWithValue("@name", stock.Name);
                    parameters.AddWithValue("@address", stock.Address);
                    parameters.AddWithValue("@schedule", stock.Schedule);
                    parameters.AddWithValue("@phone", stock.Contact.Telephone);
                    parameters.AddWithValue("@email", stock.Contact.Email);
                    parameters.AddWithValue("@site", stock.SitePath);
                    try
                    {
                        stock.ID = Convert.ToInt32(command.ExecuteScalar());
                    }
                    catch
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

                try
                {

                    stock.SetShopAtDB();
                    stock.SetPounktOfIssueAtDB();
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

                    command.CommandText = $"Update [Pounkt] set [PounktName]=@name " +
                        $"where [PounktID]={id}";
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

                    command.CommandText = $"Update [Pounkt] set [PounktAddress]=@name " +
                        $"where [PounktID]={id}";
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

                    command.CommandText = $"Update [Pounkt] set [PounktTelephone]=@name " +
                        $"where [PounktID]={id}";
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

                    command.CommandText = $"Update [Pounkt] set [PounktEmail]=@name " +
                        $"where [PounktID]={id}";
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

        public static bool UpdateSiteAtDB(TradingPoint organization) => UpdateSiteAtDB(organization.ID, organization.SitePath);
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

                    command.CommandText = $"Update [Pounkt] set [SitePath]=@name " +
                        $"where [PounktID]={id}";
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

        public bool UpdateScheduleAtDB() => UpdateScheduleAtDB(this);

        public static bool UpdateScheduleAtDB(TradingPoint organization) => UpdateScheduleAtDB(organization.ID, organization.Schedule);
        public static bool UpdateScheduleAtDB(int id, string schedule)
        {
            string name = schedule;
            if (schedule.Length < 1)
                return false;
            try
            {
                SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
                connection.Open();

                try
                {
                    SqlCommand command = connection.CreateCommand();

                    command.CommandText = $"Update [Pounkt] set [PounktSchedule]=@name " +
                        $"where [PounktID]={id}";
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


        public bool SetShopAtDB() => SetShopAtDB(this);
        public bool SetShopAtDB(string name) => SetShopAtDB(this, name);
        public static bool SetShopAtDB(Part shop, string name) => SetShopAtDB(shop.ID, name);
        public static bool SetShopAtDB(TradingPoint shop) => SetShopAtDB(shop.ID, shop.Shop.Name);
        public static bool SetShopAtDB(int id, string name)
        {
            
            if (name.Length < 1 || id < 1)
                return false;
            try
            {
                SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
                connection.Open();

                try
                {
                    SqlCommand command = connection.CreateCommand();
                    try
                    {
                        command.CommandText = $"Update [Shop] set [ShopName]=@name " +
                            $"where [PounktID]={id}";
                        SqlParameterCollection parameters = command.Parameters;
                        parameters.Clear();
                        parameters.AddWithValue("@name", name);
                        int count = Convert.ToInt32(command.ExecuteNonQuery());
                        if (count < 1)
                            throw new Exception();
                    }
                    catch
                    {
                        command.CommandText = $"Insert Into [Shop] ([PounktID],[ShopName]) Values({id},@name) " ;
                        SqlParameterCollection parameters = command.Parameters;
                        parameters.Clear();
                        parameters.AddWithValue("@name", name);
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

        public bool SetPounktOfIssueAtDB() => SetPounktOfIssueAtDB(this);
        public bool SetPounktOfIssueAtDB(string name) => SetPounktOfIssueAtDB(this, name);
        public static bool SetPounktOfIssueAtDB(Part shop, string name) => SetPounktOfIssueAtDB(shop.ID, name);

        public static bool SetPounktOfIssueAtDB(TradingPoint shop) => SetPounktOfIssueAtDB(shop.ID, shop.PounktOfIssue.Name);

        public static bool SetPounktOfIssueAtDB(int id, string name)
        {

            if (name.Length < 1 || id < 1)
                return false;
            try
            {
                SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
                connection.Open();

                try
                {
                    SqlCommand command = connection.CreateCommand();
                    try
                    {
                        command.CommandText = $"Update [PounktOfIssue] set [PounktOfIssoueName]=@name " +
                            $"where [PounktID]={id}";
                        SqlParameterCollection parameters = command.Parameters;
                        parameters.Clear();
                        parameters.AddWithValue("@name", name);
                        int count = Convert.ToInt32(command.ExecuteNonQuery());
                        if (count < 1)
                            throw new Exception();
                    }
                    catch
                    {
                        command.CommandText = $"Insert Into [PounktOfIssue] ([PounktID],[PounktOfIssoueName]) Values({id},@name) ";
                        SqlParameterCollection parameters = command.Parameters;
                        parameters.Clear();
                        parameters.AddWithValue("@name", name);
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


        public bool DeleteShopFromDB() => DeleteShopFromDB(this);
        public static bool DeleteShopFromDB(Part shop)
            => DeleteShopFromDB(shop.ID);

        public static bool DeleteShopFromDB(int id)
        {
            try
            {
                SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
                connection.Open();

                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = $"Delete From [Shop] " +
                        $"where [PounktID]={id}";
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

        public bool UpdateShopAtDB() => UpdateShopAtDB(this);

        public static bool UpdateShopAtDB(TradingPoint point)
        {
            point.UpdatePointData();
            if (point.Shop.Existence)
                return point.SetShopAtDB();
            else
                return point.DeleteShopFromDB();
        }

        public bool DeletePounktOfIssueFromDB() => DeletePounktOfIssueFromDB(this);
        public static bool DeletePounktOfIssueFromDB(Part shop)
            => DeletePounktOfIssueFromDB(shop.ID);

        public static bool DeletePounktOfIssueFromDB(int id)
        {
            try
            {
                SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
                connection.Open();

                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = $"Delete From [PounktOfIssue] " +
                        $"where [PounktID]={id}";
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


        public bool UpdatePickupPointAtDB() => UpdatePickupPointAtDB(this);

        public static bool UpdatePickupPointAtDB(TradingPoint point)
        {
            point.UpdatePointData();
            if (point.PounktOfIssue.Existence)
                return point.SetPounktOfIssueAtDB();
            else
                return point.DeletePounktOfIssueFromDB();
        }


        public Store CopyStore()
            => new Store()
            {
                Name = Name,
                Address = Address,
                Telephone = Contact.Telephone,
                Email = Contact.Email,
                Schedule = Schedule,
                SitePath = SitePath,
                Shop = Shop.Name,
                PounktOfIssue = PounktOfIssue.Name
            };

    }
}
