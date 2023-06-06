using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using FileManegerJson;
using System.Threading;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Товар
    /// </summary>
    public class Product : Part
    {
        public byte[] BytesPhoto
        {
            get => Convert.FromBase64String(Photo);
            set => SetPhoto(value);
        }

        public virtual string GetNameInfo()
            => $"«{ID}»" + " - " + $"«{Articul.Trim()}»" + " - " + $"«{Name}»" + " - "+
            $"«{PriceWithDiscount.ToString("c2")}»" + $" («{PriceWithOutDiscount.ToString("C2")}»)";

        public string NameInfo => GetNameInfo();

        public Bitmap Bitmap
        {
            get
            {
                MemoryStream memory = new MemoryStream(BytesPhoto);
                Bitmap bitmap = new Bitmap(memory);
                memory.Close();
                return bitmap;
            }
            set
            {
                MemoryStream memory = new MemoryStream();
                value.Save(memory, ImageFormat.Jpeg);
                BytesPhoto = memory.ToArray();
                memory.Close();
            }
        }

        public Image Image
        {
            get => Bitmap;
            set => Bitmap = new Bitmap(value);
        }

        string articul = "";

        /// <summary>
        /// Артикул
        /// </summary>
        public string Articul
        {
            get => articul;
            set => articul = value;
        }

        string description = "";

        /// <summary>
        /// Описание
        /// </summary>
        public string Description
        {
            get => description;
            set => description = value;
        }

        Part category = new Part();

        /// <summary>
        /// Категория
        /// </summary>
        public Part Category
        {
            get => category;
            set => category = value;
        }

        Part supplier = new Part();

        /// <summary>
        /// Поставщик
        /// </summary>
        public Part Supplier
        {
            get => supplier;
            set => supplier = value;
        }

        Part manufacture = new Part();

        /// <summary>
        /// Производитель
        /// </summary>
        public Part Manufacture
        {
            get => manufacture;
            set => manufacture = value;
        }

        double priceWithOutDiscount = 0;

        /// <summary>
        /// Цена без скидки
        /// </summary>
        public double PriceWithOutDiscount
        {
            get => priceWithOutDiscount;
            set => priceWithOutDiscount = value;
        }

        int discount = 0;

        /// <summary>
        /// Скидка
        /// </summary>
        public int Discount
        {
            get => discount;
            set => discount = value;
        }

        /// <summary>
        /// Цена со скидкой
        /// </summary>
        public double PriceWithDiscount
        {
            get => Math.Round(PriceWithOutDiscount - PriceWithOutDiscount * (Discount / 100.0), 2);
            set => PriceWithOutDiscount = value / ((100 - Discount) / 100.0);
        }

        string photo = "";

        public string Photo
        {
            get => photo;
            set => photo = value;
        }

        public void SetPhoto(byte[] photo)
        {
            Photo = Convert.ToBase64String(photo);
        }

        /// <summary>
        /// Информация о товаре
        /// </summary>
        public string Information => ToString();

        public override string ToString() => GetData();

        public bool HaveImage
        {
            get
            {
                try
                {
                    Bitmap bitmap = new Bitmap(Image);
                    return true;
                }
                catch(ArgumentNullException e)
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

        public bool NoHaveImage => !HaveImage;

        public virtual string GetData()
        {
            string result = $"Название - {Name} \n";
            if (Description.Length > 30)
            {
                result += $"Описание - {Description.Substring(0, 30)}... \n";
            }
            else
            {
                result += $"Описание - {Description} \n";
            }
            result += $"Цена без скидки - {PriceWithOutDiscount.ToString("C2")}\n";
            result += $"Скидка - {(Discount / 100.0).ToString("0%")}\n";
            result += $"Цена со скидкой - {PriceWithDiscount.ToString("C2")}";

            return result;
        }

        public virtual Product CopyProduct()
        {
            Product product = new Product();
            product.ID = this.ID;
            product.Articul = this.Articul;
            product.Category = this.Category.CopyPart();
            product.Manufacture = this.Manufacture.CopyPart();
            product.Supplier = this.Supplier.CopyPart();
            product.PriceWithOutDiscount = this.PriceWithOutDiscount;
            product.Discount = this.Discount;
            product.Description = this.Description;
            product.Photo = this.Photo;

            return product;
        }

        public void SetProduct(Product product)
        {
            
            ID = product.ID;
            Articul = product.Articul;
            Category = product.Category.CopyPart();
            Manufacture = product.Manufacture.CopyPart();
            Supplier = product.Supplier.CopyPart();
            PriceWithOutDiscount = product.PriceWithOutDiscount;
            Discount = product.Discount;
            Description = product.Description;
            Photo = product.Photo;
            Name = product.Name;
        }

        public void SetProductByList(IEnumerable<Product> products)
        {
            ProductsList result = new ProductsList(products);
            if (result.ContainsByID(this))
            {
                SetProduct(result.GetByID(this));
            }
        }

        public virtual ProductInOrder CopyProductToOrder()
        {
            ProductInOrder product = new ProductInOrder();
            product.ID = this.ID;
            product.Articul = this.Articul;
            product.Name = this.Name;
            product.Category = this.Category.CopyPart();
            product.Manufacture = this.Manufacture.CopyPart();
            product.Supplier = this.Supplier.CopyPart();
            product.PriceWithOutDiscount = this.PriceWithOutDiscount;
            product.Discount = this.Discount;
            product.Description = this.Description;
            product.Photo = this.Photo;

            return product;
        }

        public virtual ProductInOrder CopyProductToOrder(int quantity)
        {
            ProductInOrder product = CopyProductToOrder();
            product.Quantity = quantity;
            return product;
        }

        public virtual ProductInPounkt CopyProductInPounkt(PounktType pounktType = PounktType.Shop)
        {
            ProductInPounkt product = new ProductInPounkt();
            product.ID = this.ID;
            product.Articul = this.Articul;
            product.Name = this.Name;
            product.Category = this.Category.CopyPart();
            product.Manufacture = this.Manufacture.CopyPart();
            product.Supplier = this.Supplier.CopyPart();
            product.PriceWithOutDiscount = this.PriceWithOutDiscount;
            product.Discount = this.Discount;
            product.Description = this.Description;
            product.Photo = this.Photo;
            product.SetPounktType(pounktType);

            return product;
        }

        public ProductInPounkt CopyProductInPounkt(int quantity, PounktType pounktType = PounktType.Shop)
        {
            ProductInPounkt product = CopyProductInPounkt(pounktType);
            product.Quantity = quantity;
            return product;
        }

        public ProductInPounkt CopyProductInPounkt(ProductWithCount product, PounktType pounktType = PounktType.Shop)
        {
            return CopyProductInPounkt(product.Quantity, pounktType);
        }

        public ProductInPounkt CopyProductInPounkt(ProductInPounkt product)
            => CopyProductInPounkt(product, product.GetPounktType());

        public ProductInPounkt CopyProductInPounkt(IEnumerable<ProductInPounkt> products, PounktType pounktType = PounktType.Shop)
        {
            ProductsInPounktList pounkts = new ProductsInPounktList(products);
            try
            {
                return CopyProductInPounkt(pounkts.GetByID(this));
            }
            catch
            {
                return CopyProductInPounkt(pounktType);
            }
            
       }

        public virtual ProductInShoppingCart CopyProductInShoppingCart()
        {
            ProductInShoppingCart product = new ProductInShoppingCart();
            product.ID = this.ID;
            product.Articul = this.Articul;
            product.Name = this.Name;
            product.Category = this.Category.CopyPart();
            product.Manufacture = this.Manufacture.CopyPart();
            product.Supplier = this.Supplier.CopyPart();
            product.PriceWithOutDiscount = this.PriceWithOutDiscount;
            product.Discount = this.Discount;
            product.Description = this.Description;
            product.Photo = this.Photo;

            return product;
        }


        public virtual ProductWithCount CopyProductWithCount()
        {
            ProductWithCount product = new ProductWithCount();
            product.ID = this.ID;
            product.Articul = this.Articul;
            product.Name = this.Name;
            product.Category = this.Category.CopyPart();
            product.Manufacture = this.Manufacture.CopyPart();
            product.Supplier = this.Supplier.CopyPart();
            product.PriceWithOutDiscount = this.PriceWithOutDiscount;
            product.Discount = this.Discount;
            product.Description = this.Description;
            product.Photo = this.Photo;

            return product;
        }




        public virtual ProductWithCount CopyProductWithCount(int quantity)
        {
            ProductWithCount product = CopyProductWithCount();
            product.Quantity = quantity;
            return product;
        }

        public virtual ProductInShoppingCart CopyProductInShoppingCart(int quantity)
        {
            ProductInShoppingCart product = CopyProductInShoppingCart();
            product.Quantity = quantity;
            return product;
        }

        public bool IsInPounkt() => this is ProductInPounkt;
        public ProductInPounkt AsInPounkt() => this as ProductInPounkt;

        public bool IsWithCounkt() => this is ProductWithCount;
        public ProductWithCount AsWithCounkt() => this as ProductWithCount;

        public bool UpdateInDB()
        {
            return UpdateInDB(this);
        }


        public static bool UpdateInDB(Product product)
        {
            
            try
            {
                SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
                connection.Open();
                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "UPDATE [Product]" +
                        $" SET[ProductArticle] = @articul" +
                        $",[ProductName] = @name" +
                        $",[ProductCost] = @price" +
                        $",[ProductDiscount] = @discount" +
                        $",[ProductManufactureID] = {product.Manufacture.ID}" +
                        $",[ProductCategoryID] = {product.Category.ID}" +
                        $",[ProductDescription] = @info" +
                        $",[ProductSupplierID] = {product.Supplier.ID}" +
                        $"WHERE [ProductID]={product.ID} ";
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@articul", product.Articul);
                    command.Parameters.AddWithValue("@name", product.Name);
                    command.Parameters.AddWithValue("@price", Convert.ToDecimal(product.PriceWithOutDiscount));
                    command.Parameters.AddWithValue("@info", product.Description);
                    command.Parameters.AddWithValue("@discount", (byte)product.Discount);
                    command.ExecuteNonQuery();

                    command = connection.CreateCommand();
                    try
                    {
                        try
                        {
                            if (product.HaveImage)
                            {
                                command.CommandText = $"UPDATE[Product]" +
                                $" SET [ProductPhoto]=@photo " +
                                $"WHERE [ProductID]={product.ID} ";
                                command.Parameters.Clear();
                                command.Parameters.AddWithValue("@photo", product.BytesPhoto);
                                command.ExecuteNonQuery();

                            }
                            else
                            {
                                throw new Exception();
                            }
                        }
                        catch
                        {
                            command.CommandText = $"UPDATE[Product]" +
                               $" SET [ProductPhoto]=NULL " +
                               $"WHERE [ProductID]={product.ID} ";
                            command.Parameters.Clear();
                            //command.Parameters.AddWithValue("@photo", SqlBinary.Null.Value);
                            command.ExecuteNonQuery();
                        }
                    }
                    catch(Exception e)
                    {

                    }
                }
                catch(Exception e)
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

        public bool AddToDB()
            => AddToDB(this);

        public static bool AddToDB(Product product)
        {
            try
            {
                SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
                connection.Open();
                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO [dbo].[Product]" +
                        " ([ProductArticle]" +
                        ",[ProductName]" +
                        ",[ProductCost]" +
                        ",[ProductDiscount]" +
                        ",[ProductManufactureID]" +
                        ",[ProductCategoryID]" +
                        ",[ProductDescription]" +
                        ",[ProductSupplierID])" +
                        " VALUES" +
                        "(@articul" +
                        ",@name" +
                        ",@price" +
                        ",@discount" +
                        $",{product.Manufacture.ID}" +
                        $",{product.Category.ID}" +
                        ",@info" +
                        $",{product.Supplier.ID})";
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@articul", product.Articul);
                    command.Parameters.AddWithValue("@name", product.Name);
                    command.Parameters.AddWithValue("@price", Convert.ToDecimal(product.PriceWithOutDiscount));
                    command.Parameters.AddWithValue("@info", product.Description);
                    command.Parameters.AddWithValue("@discount", (byte)product.Discount);
                    command.ExecuteNonQuery();

                    command = connection.CreateCommand();
                    try
                    {
                        try
                        {
                            if (product.HaveImage)
                            {
                                command.CommandText = $"UPDATE[Product]" +
                                $" SET [ProductPhoto]=@photo " +
                                $"WHERE [ProductArticle]=@articul ";
                                command.Parameters.Clear();
                                command.Parameters.AddWithValue("@photo", product.BytesPhoto);
                                command.Parameters.AddWithValue("@articul", product.Articul);
                                command.ExecuteNonQuery();

                            }
                            else
                            {
                                throw new Exception();
                            }
                        }
                        catch
                        {
                            command.CommandText = $"UPDATE[Product]" +
                               $" SET [ProductPhoto]=NULL " +
                               $"WHERE [ProductArticle]=@articul ";
                            command.Parameters.Clear();
                            //command.Parameters.AddWithValue("@photo", SqlBinary.Null.Value);
                            command.Parameters.AddWithValue("@articul", product.Articul);
                            command.ExecuteNonQuery();
                        }
                    }
                    catch(Exception e)
                    {

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

        public bool DeleteFromDB() => DeleteFromDB(this);

        public static bool DeleteFromDB(Product product) => DeleteFromDB(product.ID);

        public static bool DeleteFromDB(int id)
        {
            try
            {
                SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
                connection.Open();
                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM  [Product] " +
                        $"WHERE [ProductID]={id} ";
                    command.Parameters.Clear();
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
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool ContainsInShop(int id, int shopID, int count = 20)
        {
            try
            {
                SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
                connection.Open();

                try
                {
                    try
                    {
                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.Connection = connection;
                        sqlCommand.CommandText = $"Update [ProductInShop] Set [DateUpdate] = [DateUpdate]";
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch
                    {

                    }
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = $"SELECT Count(*) " +
                        $"FROM[ProductInShop]" +
                        $" where ProductID = {id} and ShopID = {shopID}";

                    int countDB = Convert.ToInt32(command.ExecuteScalar());
                    try
                    {
                        connection.Close();
                    }
                    catch
                    {

                    }
                    return countDB > 0;
                }
                catch (Exception e)
                {
                    connection.Close();
                    throw e;
                }
            }
            catch
            {
                if (count > 0)
                {
                    Thread.Sleep(AddressesList.GetRandomMilliSeconds());
                    return ContainsInShop(id, shopID, count - 1);
                }
                return false;
            }
        }

        public int GetCountInShop(int shopID, int count = 20)
            => GetCountInShop(this, shopID, count);
        public static int GetCountInShop(Product product, int shopID, int count = 20)
            => GetCountInShop(product.ID, shopID, count);
        public static int GetCountInShop(int productID, int shopID, int count = 20)
        {
            try
            {
                try
                {
                    SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
                    connection.Open();
                    int quantity = 0;

                    try
                    {

                        if (ContainsInShop(productID, shopID))
                        {
                            SqlCommand command = connection.CreateCommand();
                            command.CommandText = $"SELECT [QuantityInShop] " +
                                $"FROM[ProductInShop]" +
                                $" where ProductID = {productID} and ShopID = {shopID}";
                            quantity = Convert.ToInt32(command.ExecuteScalar());
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
                    return quantity;
                }
                catch (ArgumentException e)
                {
                    throw new Exception(e.Message, e);
                }
                catch (NullReferenceException e)
                {
                    throw new Exception(e.Message, e);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message, e);
                }
            }
            catch (Exception e)
            {
                if (count > 0)
                {
                    Thread.Sleep(AddressesList.GetRandomMilliSeconds());
                    return GetCountInShop(productID, shopID, count - 1);
                }
                throw e;
            }
        }

        public bool SetProductToShop(int shopID, int quantity)
            => SetProductToShop(this, shopID, quantity);
        public static bool SetProductToShop(Product product, int shopID, int quantity)
            => SetProductToShop(product.ID, shopID, quantity);
        public static bool SetProductToShop(int productID, int shopID, int quantity)
        {
            if (quantity < 0)
                return false;
            try
            {
                try
                {
                    SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
                    connection.Open();

                    try
                    {
                        if (ContainsInShop(productID, shopID))
                        {
                            SqlCommand command = connection.CreateCommand();
                            command.CommandText = $"Update[ProductInShop] " +
                                $"Set [QuantityInShop]={quantity}, [DateUpdate] = @now" +
                                $" where ProductID = {productID} and ShopID = {shopID}";
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@now", DateTime.Now);
                            command.ExecuteNonQuery();
                        }
                        else
                        {
                            SqlCommand command = connection.CreateCommand();
                            command.CommandText = $"INSERT INTO [ProductInShop]" +
                                $" ([ShopID]" +
                                $",[ProductID]" +
                                $",[QuantityInShop])" +
                                $" VALUES" +
                                $" ({shopID}" +
                                $",{productID}" +
                                $",{quantity})";
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
                catch (ArgumentException e)
                {
                    throw new Exception(e.Message, e);
                }
                catch (NullReferenceException e)
                {
                    throw new Exception(e.Message, e);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message, e);
                }
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public static bool ContainsInStock(int id, int stockID, int count = 20)
        {
            try
            {
                SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
                connection.Open();

                try
                {
                    try
                    {
                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.Connection = connection;
                        sqlCommand.CommandText = $"Update [ProductInStock] Set [DateUpdate]=[DateUpdate]";
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch
                    {

                    }
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = $"SELECT Count(*) " +
                        $"FROM[ProductInStock]" +
                        $" where ProductID={id} and StockID={stockID}";

                    int countDB = Convert.ToInt32(command.ExecuteScalar());
                    try
                    {
                        connection.Close();
                    }
                    catch
                    {

                    }
                    return countDB > 0;
                }
                catch (Exception e)
                {
                    connection.Close();
                    throw e;
                }
            }
            catch
            {
                if (count > 0)
                {
                    Thread.Sleep(AddressesList.GetRandomMilliSeconds());
                    return ContainsInStock(id, stockID, count - 1);
                }
                return false;
            }
        }

        public int GetCountInStock(int stockID, int count = 20)
            => GetCountInStock(this, stockID, count);
        public static int GetCountInStock(Product product, int stockID, int count = 20)
            => GetCountInStock(product.ID, stockID, count);
        public static int GetCountInStock(int productID, int stockID, int count = 20)
        {
            try
            {
                try
                {
                    SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
                    connection.Open();
                    int quantity = 0;

                    try
                    {
                        if(ContainsInStock(productID, stockID))
                        {
                            SqlCommand command = connection.CreateCommand();
                            command.CommandText = $"SELECT [QuantityInStock] " +
                                $"FROM[ProductInStock]" +
                                $" where ProductID={productID} and StockID={stockID}";
                            quantity = Convert.ToInt32(command.ExecuteScalar());
                        }

                    }
                    catch(Exception e)
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
                    return quantity;
                }
                catch (ArgumentException e)
                {
                    throw new Exception(e.Message, e);
                }
                catch (NullReferenceException e)
                {
                    throw new Exception(e.Message, e);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message, e);
                }
            }
            catch(Exception e)
            {
                if (count > 0)
                {
                    Thread.Sleep(AddressesList.GetRandomMilliSeconds());
                    return GetCountInStock(productID, stockID, count - 1);
                }
                throw e;
            }
        }


        public bool SetProductToStock(int stockID, int quantity)
            => SetProductToStock(this, stockID, quantity);
        public static bool SetProductToStock(Product product, int stockID, int quantity)
            => SetProductToStock(product.ID, stockID, quantity);
        public static bool SetProductToStock(int productID, int stockID, int quantity)
        {
            if (quantity < 0)
                return false;
            try
            {
                try
                {
                    SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
                    connection.Open();

                    try
                    {
                        if (ContainsInStock(productID, stockID))
                        {
                            SqlCommand command = connection.CreateCommand();
                            command.CommandText = $"Update [ProductInStock] " +
                                $"Set [QuantityInStock]={quantity}, [DateUpdate]=@now" +
                                $" where [ProductID]={productID} and [StockID]={stockID}";
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@now", DateTime.Now);
                            command.ExecuteNonQuery();
                        }
                        else
                        {
                            SqlCommand command = connection.CreateCommand();
                            command.CommandText = $"INSERT INTO [ProductInStock]" +
                                $" ([StockID]" +
                                $",[ProductID]" +
                                $",[QuantityInStock])" +
                                $" VALUES" +
                                $" ({stockID}" +
                                $",{productID}" +
                                $",{quantity})";
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
                catch (ArgumentException e)
                {
                    throw new Exception(e.Message, e);
                }
                catch (NullReferenceException e)
                {
                    throw new Exception(e.Message, e);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message, e);
                }
            }
            catch (Exception e)
            {
                
                return false;
            }
        }

        public bool AddToStock(int stockID, int quantity = 1)
        {
            if (quantity < 0)
                return false;
            int count = GetCountInStock(stockID);
            count += quantity;
            return SetProductToStock(stockID, count);
        }

        public bool SubToStock(int stockID, int quantity = 1)
        {
            if (quantity < 0)
                return false;
            int count = GetCountInStock(stockID);
            count -= quantity;
            if (count < 0)
                return false;
            return SetProductToStock(stockID, count);
        }

        public bool AddToShop(int shopID, int quantity = 1)
        {
            if (quantity < 0)
                return false;
            int count = GetCountInShop(shopID);
            count += quantity;
            return SetProductToShop(shopID, count);
        }

        public bool SubToShop(int shopID, int quantity = 1)
        {
            if (quantity < 0)
                return false;
            int count = GetCountInShop(shopID);
            count -= quantity;
            if (count < 0)
                return false;
            return SetProductToShop(shopID, count);
        }

        public bool RunFromStockToShop(int stockID, int shopID, int quantity = 1)
        {
            bool result = false;
            for(int i = 0; i < 20; i++)
            {
                result = SubToStock(stockID, quantity);
                if (result)
                    break;
                Thread.Sleep(AddressesList.GetRandomMilliSeconds());
            }
            if (!result)
                return false;

            for (int i = 0; i < 20; i++)
            {
                result = AddToShop(shopID, quantity);
                if (result)
                    break;
                Thread.Sleep(AddressesList.GetRandomMilliSeconds());
            }

            if(!result)
            {
                for (int i = 0; i < 20; i++)
                {
                   
                    if (AddToStock(stockID, quantity))
                        break;
                    Thread.Sleep(AddressesList.GetRandomMilliSeconds());
                }
            }

            return result;
        }

        public bool RunFromShopToStock(int shopID, int stockID, int quantity = 1)
        {
            bool result = false;
            for (int i = 0; i < 20; i++)
            {
                result = SubToShop(shopID, quantity);
                if (result)
                    break;
                Thread.Sleep(AddressesList.GetRandomMilliSeconds());
            }
            if (!result)
                return false;

            for (int i = 0; i < 20; i++)
            {
                result = AddToStock(stockID, quantity);
                if (result)
                    break;
                Thread.Sleep(AddressesList.GetRandomMilliSeconds());
            }

            if (!result)
            {
                for (int i = 0; i < 20; i++)
                {

                    if (SubToShop(shopID, quantity))
                        break;
                    Thread.Sleep(AddressesList.GetRandomMilliSeconds());
                }
            }

            return result;
        }

    }
}
