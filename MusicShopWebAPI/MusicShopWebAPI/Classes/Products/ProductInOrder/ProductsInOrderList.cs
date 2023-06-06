using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    public class ProductsInOrderList : AbstractProductsList<ProductInOrder>
    {
        public ProductsInOrderList()
        {
        }

        public ProductsInOrderList(IEnumerable<ProductInOrder> collection) : base(collection)
        {
        }

        public ProductsInOrderList(int capacity) : base(capacity)
        {
        }

        public ProductsInOrderList GetThis() => this;

        public static ProductsInOrderList GetList() => new ProductsInOrderList();

        public static ProductsInOrderList GetListFromDB(int orderID)
        {
            ProductsInOrderList orders = GetList();
            orders.GetFromBD(orderID);
            return orders;
        }

        public void GetFromBD(int orderID, int count = 20)
        {

            ProductsList products = ProductsList.GetListFromDB();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = DataBaseConnectionStringController.GetConnectionString();
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Select * From [OrderProduct]";
                command.CommandText += $" where [OrderID]={orderID}";

                command.Parameters.Clear();

                SqlDataReader reader = command.ExecuteReader();
                Clear();
                List<OrderQuantity> quantities = new List<OrderQuantity>();
                try
                {
                    while (reader.Read())
                    {

                        OrderQuantity quantity = new OrderQuantity();
                        quantity.ProductID = reader.GetInt32(reader.GetOrdinal("ProductID"));
                        quantity.Quantity = reader.GetInt32(reader.GetOrdinal("ProductCount"));
                        quantities.Add(quantity);
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    reader.Close();
                    throw e;
                }
                connection.Close();

                for(int i = 0; i < quantities.Count; i++)
                {
                    int id = quantities[i].ProductID;
                    if(products.ContainsByID(id))
                    {
                        Add(products.GetByID(id).CopyProductToOrder(quantities[i].Quantity));
                    }
                    else
                    {
                        Add(new ProductInOrder
                        {
                            ID = id,
                            Name = "Товар больше не существует",
                            Quantity = quantities[i].Quantity
                        }) ;
                    }
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
                    GetFromBD(orderID, count - 1);
                    return;
                }

                throw e;
            }
        }

        public class OrderQuantity
        {
            public int ProductID = 0;
            public int Quantity = 0;
        }

        public List<ProductQuantity> GetProductQuantities()
        {
            List<ProductQuantity> products = new List<ProductQuantity>();
            for(int i = 0; i < Count; i++)
            {
                products.Add(new ProductQuantity
                {
                    ID = this[i].ID,
                    Quantity = this[i].Quantity
                });
            }
            return products;
        }
    }
}
