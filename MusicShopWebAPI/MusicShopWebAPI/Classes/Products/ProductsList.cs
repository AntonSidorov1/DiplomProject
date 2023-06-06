using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    /// <summary>
    /// Список товаров
    /// </summary>
    public class ProductsList : AbstractProductsList<Product>
    {
        public override void SetList(List<Product> products)
        {
            Clear();
            for(int i = 0; i < products.Count; i++)
            {
                Add(products[i].CopyProduct());
            }
        }

        public ProductsList()
        {
        }

        public ProductsList(IEnumerable<Product> collection) : base(collection)
        {
        }

        public ProductsList(int capacity) : base(capacity)
        {
        }

        public static ProductsList GetList() => new ProductsList();

        public static ProductsList GetListFromDB(Order byName = Order.None, Order byCost = Order.None, int category = 0, string name = "")
        {
            ProductsList products = GetList();
            products.GetFromBD(byName, byCost, category, name);
            return products;
        }

        public ProductsList GetThis() => this;

        public void GetFromBD(Order byName = Order.None, Order byCost = Order.None, int category = 0, string name = "", int count = 20)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = DataBaseConnectionStringController.GetConnectionString();
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Select * From [ProductData]";
                command.CommandText += " where [Name] Like '%'+@name+'%'";

                if(category > 0)
                {
                    command.CommandText += " and [CategoryID]=" + category;
                }

                if (byName != Order.None || byCost != Order.None)
                {
                    command.CommandText += " Order by";
                    if (byName != Order.None)
                    {
                        command.CommandText += $" [Name] {byName} ";
                    }
                    if (byCost != Order.None)
                    {
                        if (byName != Order.None)
                            command.CommandText += ",";
                        command.CommandText += $"[Cost] {byCost} ";
                    }
                }
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@name", name);
               
                SqlDataReader reader = command.ExecuteReader();
                Clear();
                try
                {
                    while (reader.Read())
                    {
                        Product product = new Product();
                        product.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                        product.Articul = reader.GetString(reader.GetOrdinal("Article"));
                        product.Name = reader.GetString(reader.GetOrdinal("Name"));
                        try
                        {
                            product.Description = reader.GetString(reader.GetOrdinal("Description"));
                        }
                        catch
                        {
                            product.Description = "";
                        }
                        product.PriceWithOutDiscount = Convert.ToDouble(reader.GetDecimal(reader.GetOrdinal("Cost")));
                        try
                        {
                            product.Discount = reader.GetByte(reader.GetOrdinal("Discount"));
                        }
                        catch
                        {
                            product.Discount = 0;
                        }
                        product.Category.ID = reader.GetInt32(reader.GetOrdinal("CategoryID"));
                        product.Category.Name = reader.GetString(reader.GetOrdinal("Category"));
                        product.Supplier.ID = reader.GetInt32(reader.GetOrdinal("SupplierID"));
                        product.Supplier.Name = reader.GetString(reader.GetOrdinal("Supplier"));
                        product.Manufacture.ID = reader.GetInt32(reader.GetOrdinal("ManufactureID"));
                        product.Manufacture.Name = reader.GetString(reader.GetOrdinal("Manufacture"));

                        try
                        {
                            product.SetPhoto((byte[])reader["Photo"]);
                        }
                        catch
                        {

                        }
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
                    GetFromBD(byName, byCost, category, name, count - 1);
                    return;
                }

                throw e;
            }
        }



        public ProductsList GetListByDiscount(int minDiscount = 0, int maxDiscount = 100)
            => new ProductsList(FindAll(p => p.Discount >= minDiscount).FindAll(p => p.Discount <= maxDiscount));

        

    }

    /// <summary>
    /// Параметры стортировки
    /// </summary>
    public enum Order
    {
        /// <summary>
        /// Нет
        /// </summary>
        None,
        /// <summary>
        /// По возрастанию
        /// </summary>
        Asc,
        /// <summary>
        /// По убыванию
        /// </summary>
        Desc
    }
}
