using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    /// <summary>
    /// Список заказов
    /// </summary>
    public class OrdersList : GeorafyPointList<OrderValue>
    {
        public OrdersList()
        {
        }

        public OrdersList(int capacity) : base(capacity)
        {
        }

        public OrdersList(IEnumerable<OrderValue> collection) : base(collection)
        {
        }

        public override OrderValue Get() => new OrderValue();


        public static OrdersList GetListFromDB()
        {
            OrdersList products = GetList();
            products.GetFromBD();
            return products;
        }

        public static OrdersList GetList() => new OrdersList();

        public OrdersList GetThis() => this;

        public void GetFromBD(int count = 20)
        {
            SqlConnection connection = new SqlConnection();
            connection = DataBaseConfiguration.GetSqlConnection();
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Select * From [Order]";

                SqlDataReader reader = command.ExecuteReader();
                Clear();
                try
                {
                    while (reader.Read())
                    {
                        OrderValue product = new OrderValue();
                        product.ID = reader.GetInt32(reader.GetOrdinal("OrderID"));
                        product.Number = reader.GetString(reader.GetOrdinal("OrderNumber"));
                        product.Cost = Convert.ToDouble(reader.GetDecimal(reader.GetOrdinal("OrderCostWithoutDiscount")));
                        product.CostWithDiscount = Convert.ToDouble(reader.GetDecimal(reader.GetOrdinal("OrderCostWithDiscount")));
                        
                        product.DateCreate = reader.GetDateTime(reader.GetOrdinal("OrderDateCreate"));
                        product.DateStatusChange = reader.GetDateTime(reader.GetOrdinal("OrderDateStatusChange"));
                        product.StatusID = reader.GetInt32(reader.GetOrdinal("OrderStatusID"));
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
                    GetFromBD(count - 1);
                    return;
                }

                throw e;
            }
        }


        public static OrderValue AddToDB(OrderWithOutNumber order, int count = 20)
        {
            SqlConnection connection = new SqlConnection();
            connection = DataBaseConfiguration.GetSqlConnection();
            OrdersList orders = GetListFromDB();
            string orderNumber = "";
            Random random = new Random();
            do
            {
                for(int i = 0; i < 20; i++)
                {
                    orderNumber += $"{random.Next(0, 10) % 10}";
                }
            }
            while (orders.ContainsByName(orderNumber));
            OrderValue orderValue = new OrderValue();
            orderValue.Number = orderNumber;
            orderValue.Value = order;
            try
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = $"Insert Into [Order] ([OrderNumber], [OrderCostWithoutDiscount], [OrderCostWithDiscount])" +
                        $" Values (@number, @cost, @withDiscount)";
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@number", orderValue.Number);
                    command.Parameters.AddWithValue("@cost", Convert.ToDecimal(orderValue.Cost));
                    command.Parameters.AddWithValue("@withDiscount", Convert.ToDecimal(orderValue.CostWithDiscount));
                    command.ExecuteNonQuery();
                }
                catch(Exception e)
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
                connection.Close();

            }
            catch(Exception e)
            {
                if (count > 0)
                    return AddToDB(order, count - 1);
                throw e;
            }
            orders.GetFromBD();
            return orders.GetByName(orderNumber);
        }

        public static bool DeleteFromDB(int id, int count = 20)
        {
            SqlConnection connection = new SqlConnection();
            connection = DataBaseConfiguration.GetSqlConnection();
            OrdersList orders = GetListFromDB();
            if (!orders.ContainsByID(id))
                return false;
            try
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = $"Delete From [Order] where [OrderID] = {id}";
                    command.Parameters.Clear();
                    command.ExecuteNonQuery();
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
                connection.Close();

            }
            catch (Exception e)
            {
                if (count > 0)
                    return DeleteFromDB(id, count - 1);
                return false;
            }
            return true;
        }

        public static bool AddInShopInDB(int shopID, int orderID, int count = 20)
        {
            SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
            try
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = $"Insert Into [OrderInShop] ([OrderID], [OrderShopID]) Values({orderID}, {shopID})";
                    command.Parameters.Clear();
                    command.ExecuteNonQuery();
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
                connection.Close();

            }
            catch (Exception e)
            {
                if (count > 0)
                    return AddInShopInDB(shopID, orderID, count - 1);
                return false;
            }
            return true;
        }

        public static bool AddInPounktOfIssueInDB(int pounktOfIssueID, int orderID, int count = 20)
        {
            SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
            try
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = $"Insert Into [OrderInPounktOfIssue] ([OrderID], [PounktOfIssoeID]) Values({orderID}, {pounktOfIssueID})";
                    command.Parameters.Clear();
                    command.ExecuteNonQuery();
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
                connection.Close();

            }
            catch (Exception e)
            {
                if (count > 0)
                    return AddInShopInDB(pounktOfIssueID, orderID, count - 1);
                return false;
            }
            return true;
        }

        public static bool AddClientDB(int clientID, int orderID, int count = 20)
        {
            SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
            try
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = $"Insert Into [ClientOrder] ([OrderID], [ClientID]) Values({orderID}, {clientID})";
                    command.Parameters.Clear();
                    command.ExecuteNonQuery();
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
                connection.Close();

            }
            catch (Exception e)
            {
                if (count > 0)
                    return AddInShopInDB(clientID, orderID, count - 1);
                return false;
            }
            return true;
        }

        public static bool AddProductToOrderInDB(ProductInShoppingCart product, int orderID = 0, int count = 20)
        {
            if (!product.Mayby)
                return false;
            SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
            try
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = $"Insert Into [OrderProduct] ([OrderID], [ProductID], [ProductCount]) " +
                        $"Values({orderID}, {product.ID}, {product.Quantity})";
                    command.Parameters.Clear();
                    command.ExecuteNonQuery();
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
                connection.Close();

            }
            catch (Exception e)
            {
                if (count > 0)
                    return AddProductToOrderInDB(product, orderID, count - 1);
                return false;
            }
            return true;
        }

        public static bool AddProductsToOrderInDB(ProductsInShoppingCartList products, int orderID)
        {
            products.SetListChange();
            if (!products.Mayby)
                return false;
            for(int i = 0; i < products.Count; i++)
            {
                if (!AddProductToOrderInDB(products[i], orderID))
                    return false;
            }
            return true;
        }

        public static bool ChangeProductsCountInShop(int shopID, ProductInShoppingCart product, int count =20)
        {
            try
            {

                ProductsInPounktList products = new ProductsInPounktList();
                try
                {
                    products = ProductsInShopsController.GetController().GetProducts(shopID);
                    if (!products.ContainsByID(product))
                        return false;
                }
                catch
                {
                    return false;
                }
                ProductInPounkt productInPounkt = products.GetByID(product);
                int quantity = productInPounkt.Quantity - product.Quantity;
                quantity = Math.Max(quantity, 0);
                SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
                try
                {
                    connection.Open();
                    try
                    {
                        SqlCommand command = new SqlCommand();
                        command.Connection = connection;
                        command.CommandText = $"Update [ProductInShop] Set [QuantityInShop] = {quantity}, [DateUpdate]=@date " +
                            $"where [ProductID]={product.ID} and [ShopID]={shopID}";

                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@date", DateTime.Now);
                        command.ExecuteNonQuery();
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

                    connection.Close();
                }
                catch
                {
                    if (count > 0)
                        return ChangeProductsCountInShop(shopID, product, count - 1);
                    return false;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool ChangeProductsCountInShop(int shopID, ProductsInShoppingCartList products)
        {
            bool result = true;
            for(int i = 0; i < products.Count; i++)
            {
                result = result && ChangeProductsCountInShop(shopID, products[i]);
            }
            return result;
        }


        public static bool ChangeProductsCountInStock(int stockID, ProductInShoppingCart product, int count = 20)
        {
            try
            {

                ProductsInPounktList products = new ProductsInPounktList();
                try
                {
                    products = ProductsInStocksController.GetController().GetProducts(stockID);
                    if (!products.ContainsByID(product))
                        return false;
                }
                catch
                {
                    return false;
                }
                ProductInPounkt productInPounkt = products.GetByID(product);
                int quantity = productInPounkt.Quantity - product.Quantity;
                quantity = Math.Max(quantity, 0);
                SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
                try
                {
                    connection.Open();
                    try
                    {
                        SqlCommand command = new SqlCommand();
                        command.Connection = connection;
                        command.CommandText = $"Update [ProductInStock] Set [QuantityInStock] = {quantity}, [DateUpdate]=@date " +
                            $"where [ProductID]={product.ID} and [StockID]={stockID}";

                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@date", DateTime.Now);
                        command.ExecuteNonQuery();
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

                    connection.Close();
                }
                catch
                {
                    if (count > 0)
                        return ChangeProductsCountInStock(stockID, product, count - 1);
                    return false;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool ChangeProductsCountInStock(int stockID, ProductsInShoppingCartList products)
        {
            bool result = true;
            for (int i = 0; i < products.Count; i++)
            {
                result = result && ChangeProductsCountInStock(stockID, products[i]);
            }
            return result;
        }


        public static bool CancelOrder(int orderID, int count = 20)
        {

            SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
            try
            {
                connection.Open();
                bool result = true;
                try
                {
                    SqlCommand command = new SqlCommand("Update [Order]" +
                        $"Set [OrderStatusID]=6, [OrderDateStatusChange]=@now " +
                        $"where [OrderID]={orderID}", connection);
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@now", DateTime.Now);
                    command.ExecuteNonQuery();
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

                connection.Close();

                return result;
            }
            catch
            {
                if (count > 0)
                    return CancelOrder(orderID, count - 1);
                return false;
            }
        }

        public static bool CancelOrder(string orderNumber, int count = 20)
        {

            SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
            try
            {
                connection.Open();
                bool result = true;
                try
                {
                    SqlCommand command = new SqlCommand("Update [Order]" +
                        $"Set [OrderStatusID]=6, [OrderDateStatusChange]=@now " +
                        $"where [OrderNumber]=@number", connection);
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@number", orderNumber);
                    command.Parameters.AddWithValue("@now", DateTime.Now);
                    command.ExecuteNonQuery();
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

                connection.Close();

                return result;
            }
            catch
            {
                if (count > 0)
                    return CancelOrder(orderNumber, count - 1);
                return false;
            }

        }
    }
}
