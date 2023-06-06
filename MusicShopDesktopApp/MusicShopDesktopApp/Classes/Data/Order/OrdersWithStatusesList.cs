using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    public class OrdersWithStatusesList : GeorafyPointList<OrderWithStatus>
    {
        public OrdersWithStatusesList()
        {
        }

        public OrdersWithStatusesList(int capacity) : base(capacity)
        {
        }

        public OrdersWithStatusesList(IEnumerable<OrderWithStatus> collection) : base(collection)
        {
        }


        public static OrdersWithStatusesList GetList() => new OrdersWithStatusesList();

        public OrdersWithStatusesList GetThis() => this;


        public static OrdersWithStatusesList GetListFromDB(string numberFilter = "", int clientID = 0)
        {
            OrdersWithStatusesList products = GetList();
            products.GetFromBD(numberFilter, clientID);
            return products;
        }

        public void GetFromBD(string numberFilter = "", int clientID = 0, int count = 20)
        {
            TradingPointsList tradingPoints = TradingPointsList.GetListFromDB();
            SqlConnection connection = new SqlConnection();
            connection = DataBaseConfiguration.GetSqlConnection();
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                if (clientID > 0)
                {
                    command.CommandText = "Select * From [OrderClient]" +
                        $" where [Number] Like '%'+@name+'%'";
                    if (clientID > 0)
                    {
                        command.CommandText += $" and [ClientID]={clientID}";
                    }
                }
                else
                {
                    command.CommandText = "Select * From [OrderPositionsQuantity]" +
                        $" where [Number] Like '%'+@name+'%'";
                }
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@name", numberFilter);

                SqlDataReader reader = command.ExecuteReader();
                Clear();
                try
                {
                    while (reader.Read())
                    {
                        OrderWithStatus product = new OrderWithStatus();
                        product.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                        product.Number = reader.GetString(reader.GetOrdinal("Number"));
                        product.Cost = Convert.ToDouble(reader.GetDecimal(reader.GetOrdinal("CostFull")));
                        product.CostWithDiscount = Convert.ToDouble(reader.GetDecimal(reader.GetOrdinal("CostEnd")));

                        product.DateCreate = reader.GetDateTime(reader.GetOrdinal("DateCreate"));
                        product.DateStatusChange = reader.GetDateTime(reader.GetOrdinal("DateStatusChange"));
                        product.StatusID = reader.GetInt32(reader.GetOrdinal("StatusID"));
                        product.Status = reader.GetString(reader.GetOrdinal("Status"));
                        product.PositionsCount = reader.GetInt32(reader.GetOrdinal("PositionsCount"));
                        product.ProductsQuantity = reader.GetInt32(reader.GetOrdinal("ProductsQuantity"));
                        Add(product);
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    reader.Close();
                    throw e;
                }
                connection.Close();

                for (int i = 0; i < Count; i++)
                {
                    this[i].SetPickupPoint(tradingPoints);
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
                    GetFromBD(numberFilter, clientID, count - 1);
                    return;
                }

                throw e;
            }
        }


        public override OrderWithStatus Get()
        {
            return new OrderWithStatus();
        }

        public OrderWithStatus GetByNumber(string number)
        {
            return GetByName(number);
        }

        public bool ContainsByNumber(string number)
        {
            return ContainsByName(number);
        }

        public int IndexByNumber(string number)
        {
            return IndexByName(number);
        }
    }
}
