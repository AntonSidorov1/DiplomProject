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
    public class ProductsInPounktList : AbstractProductsList<ProductInPounkt>
    {
        public ProductsInPounktList()
        {
        }

        public ProductsInPounktList(IEnumerable<ProductInPounkt> collection) : base(collection)
        {
        }

        public ProductsInPounktList(int capacity) : base(capacity)
        {
        }

        public static ProductsInPounktList GetList() => new ProductsInPounktList();

        public static ProductsInPounktList GetListFromDB(Order byName = Order.None, Order byCost = Order.None, int category = 0, string name = "", PounktType pounktType = PounktType.Shop, int pounktID = 0,
            bool full = false)
        {


            ProductsInPounktList products = GetList();
            if (!full)
            {
                products.GetFromBD(byName, byCost, category, name, pounktType, pounktID);
            }
            else
            {
                ProductsInPounktList pounkts = GetListFromDB(pounktID: pounktID, pounktType: pounktType);
                ProductsList products1 = ProductsList.GetListFromDB(byName, byCost, category, name);
                for (int i = 0; i < products1.Count; i++)
                {
                    products.Add(products1[i].CopyProductInPounkt(pounkts, pounktType));
                }
            }
            return products;
        }

        public ProductsInPounktList GetThis() => this;

        public void GetFromBD(Order byName = Order.None, Order byCost = Order.None, int category = 0, string name = "", PounktType pounktType = PounktType.Shop, int pounktID = 0, int count = 20)
        {
            if(pounktID == 0)
            {
                pounktType = PounktType.All;
            }

            string pounktTypeText = pounktType.ToString();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = DataBaseConnectionStringController.GetConnectionString();
            connection.Open();

            if (pounktType != PounktType.All)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = connection;
                    sqlCommand.CommandText = $"Update [ProductIn{pounktTypeText}] Set [DateUpdate] = [DateUpdate]";
                    sqlCommand.ExecuteNonQuery();
                }
                catch
                {

                }
            }

            try
            {
                string table = pounktID > 0 ? $"ProductsIn{pounktTypeText}sInfo" : "ProductData";
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"Select * From [{table}]";
                command.CommandText += " where [Name] Like '%'+@name+'%'";

                if(category > 0)
                {
                    command.CommandText += " and [CategoryID]=" + category;
                }
                if(pounktID > 0)
                {
                    command.CommandText += $" and [{pounktTypeText}ID]=" + pounktID;
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
                        ProductInPounkt product = new ProductInPounkt();
                        product.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                        product.Articul = reader.GetString(reader.GetOrdinal("Article"));
                        product.Name = reader.GetString(reader.GetOrdinal("Name"));
                        product.SetPounktType(pounktType);
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
                        if (pounktID > 0)
                        {
                            product.Quantity = reader.GetInt32(reader.GetOrdinal($"QuantityIn{pounktTypeText}"));
                        }

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
                    GetFromBD(byName, byCost, category, name, pounktType, pounktID, count - 1);
                    return;
                }

                throw e;
            }
        }

        public ProductsInPounktList GetListByDiscount(int minDiscount = 0, int maxDiscount = 100)
            => new ProductsInPounktList(FindAll(p => p.Discount >= minDiscount).FindAll(p => p.Discount <= maxDiscount));


    }


}
