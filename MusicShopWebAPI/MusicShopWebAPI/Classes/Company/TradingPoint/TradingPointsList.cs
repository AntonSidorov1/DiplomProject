using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    /// <summary>
    /// Список организаций
    /// </summary>
    public class TradingPointsList : GeorafyPointList<TradingPoint>
    {
        public TradingPointsList()
        {
        }

        public TradingPointsList(IEnumerable<TradingPoint> collection) : base(collection)
        {
        }

        public TradingPointsList(int capacity) : base(capacity)
        {
        }


        public static TradingPointsList GetList() => new TradingPointsList();

        public static TradingPointsList GetListFromDB()
        {
            TradingPointsList products = GetList();
            products.GetFromBD();
            return products;
        }

        public TradingPointsList GetThis() => this;

        public TradingPointsList SetWithAll()
        {
            if (!ContainsByID(0))
            {
                TradingPoint stock = new TradingPoint()
                {
                    ID = 0,
                    Name = "Все склады"
                };
                Insert(0, stock);
            }
            return this;
        }



        public void GetFromBD(int count = 20)
        {
            StocksList stocks = StocksList.GetListFromDB();
            OrganizationsList organizations = OrganizationsList.GetListFromDB();

            SqlConnection connection = new SqlConnection();
            connection = DataBaseConfiguration.GetSqlConnection();
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT " +
                    "[PounktID], " +
                    "[PounktName]," +
                    "[PounktTelephone]," +
                    "[PounktEmail]," +
                    "[PounktAddress]," +
                    "[PounktOrganizationID]," +
                    "[PounktStockID]," +
                    "[PounktSchedule]," +
                    "[SitePath]" +
                    " FROM [Pounkt]";

                SqlDataReader reader = command.ExecuteReader();
                Clear();
                Add(new TradingPoint
                {
                    ID = 0,
                    Name = "Все торговые пункты"
                });
                try
                {
                    while (reader.Read())
                    {
                        TradingPoint organization = new TradingPoint();

                        organization.ID = reader.GetInt32(0);
                        organization.Name = reader.GetString(1);
                        organization.Address = reader.GetString(4);
                        organization.OrganizationID = reader.GetInt32(5);
                        organization.StockID = reader.GetInt32(6);
                        organization.Schedule = reader.GetString(7);

                        try
                        {
                            organization.Contact.Telephone = reader.GetString(2);
                        }
                        catch
                        {

                        }
                        try
                        {
                            organization.Contact.Email = reader.GetString(3);
                        }
                        catch
                        {

                        }
                        try
                        {
                            organization.SitePath = reader.GetString(8);
                        }
                        catch
                        {

                        }

                        Add(organization);
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    reader.Close();
                    throw e;
                }
                connection.Close();

                for(int i = 0; i < Count; i++)
                {
                    TradingPoint point = this[i];

                    point.SetShopByID();
                    point.SetPounktOfIssueByID();
                    point.SetStockByID(stocks);
                    point.SetOrganizationByID(organizations);
                }
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
                if (count > 0)
                {
                    Thread.Sleep(AddressesList.GetRandomMilliSeconds());
                    GetFromBD(count - 1);
                    return;
                }

                throw e;
            }
        }

        public TradingPointsList GetShops() => new TradingPointsList(FindAll(p => p.Shop.Existence || p.ID < 1));

        public TradingPointsList GetPounktsOfIssue() => new TradingPointsList(FindAll(p => p.PounktOfIssue.Existence || p.ID < 1));
        public TradingPointsList GetBothType() => GetShops().GetPounktsOfIssue();


        public TradingPointsList GetBySityID(int sityID)
            => new TradingPointsList(sityID > 0 ? FindAll(p => p.Stock.SityID == sityID || p.ID < 1) : this);

        public TradingPointsList GetByStockID(int stockID)
            => new TradingPointsList(stockID > 0 ? FindAll(p => p.StockID == stockID || p.ID < 1) : this);

        public TradingPointsList GetByOrganizationID(int organizationID)
            => new TradingPointsList(organizationID > 0 ? FindAll(p => p.OrganizationID == organizationID || p.ID < 1) : this);

        public TradingPointsList GetWithSelection(int sityID = 0, int stockID = 0, int organizationID = 0)
            => GetBySityID(sityID).
            GetByStockID(stockID).
            GetByOrganizationID(organizationID);


        public override TradingPoint Get() => new TradingPoint();
    }
}
