using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MusicShopWebAPI
{
    /// <summary>
    /// торговый пункт
    /// </summary>
    public class TradingPoint : Pounkt
    {
        Stock stock = new Stock();

        /// <summary>
        /// Склад
        /// </summary>
        public Stock Stock
        {
            get => stock;
            set => stock = value;
        }

        /// <summary>
        /// ID города
        /// </summary>
        public int SityID
        {
            get => Stock.SityID;
            set => Stock.SityID = value;
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
            return ID == 0? Name : (base.ToString() + "\n" +
                $"Организация - {Organization.Name} \n\n" +
                "Склад:" +
                $"{Stock} \n" +
                (ExistenceShop ? $"Магазин - {Shop.Name}" : "Магазин отсутствует") + "\n" +
                (ExistencePounktOfIssue ? $"Пункт выдачи - {PounktOfIssue.Name}" : "Пункт выдачи отсутствует") + "\n" +
                $"Сайт {(Site != "" ? "- " + Site : "отсутствует")} \n" +
                $"Режим работы - {Schedule}");
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

                return ID != 0? data : Name;
            }
        }
    }
}
