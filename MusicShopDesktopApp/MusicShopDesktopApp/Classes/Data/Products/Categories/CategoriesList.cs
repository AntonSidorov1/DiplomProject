using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Список категорий
    /// </summary>
    public class CategoriesList : AbstractCategoriesList<Category>
    {
        public CategoriesList()
        {
        }

        public CategoriesList(IEnumerable<Category> collection) : base(collection)
        {
        }

        public CategoriesList(int capacity) : base(capacity)
        {
        }

        public static CategoriesList GetList() => new CategoriesList();

        public CategoriesList GetThis() => this;


        public static CategoriesList GetListFromDB(int filter = 0)
        {
            CategoriesList products = GetList();
            products.GetFromBD(filter);
            return products;
        }



        public void GetFromBD(int filter = 0, int count = 20)
        {
            SqlConnection connection = new SqlConnection();
            connection = DataBaseConfiguration.GetSqlConnection();
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Select * From [CategoriesWithFilter]";
                

                if (filter > 0)
                {
                    command.CommandText += " where [FilterID]=" + filter;
                }

                SqlDataReader reader = command.ExecuteReader();
                Clear();
                Add(new Category
                {
                    ID = 0,
                    Name = "Все категории",
                    RealName = "Все категории"
                }); ;
                try
                {
                    while (reader.Read())
                    {
                        Category product = new Category();
                        product.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                        product.Name = reader.GetString(reader.GetOrdinal("Category"));
                        
                        product.Filter.ID = reader.GetInt32(reader.GetOrdinal("FilterID"));
                        product.Filter.Name = reader.GetString(reader.GetOrdinal("Filter"));

                        try
                        {
                            product.RootCategoryID = reader.GetInt32(reader.GetOrdinal("RootCategoryID"));
                        }
                        catch
                        {

                        }
                        product.SetRealNameByName();

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
                    GetFromBD(filter, count - 1);
                    return;
                }
                throw e;
            }
        }

        public CategoriesList GetByFilterID(int filterID = 0)
        {
            if (filterID == 0)
                return new CategoriesList(this);
            else
                return new CategoriesList(FindAll(p => p.Filter.ID == filterID));
        }


        public CategoriesList GetSubCategories(int rootCategory = 0, int filter = 0)
        {
            
            if (rootCategory > 0)
                if (!ContainsByID(rootCategory))
                    return null;
            CategoriesList result = new CategoriesList();
            if (rootCategory > 0)
            {
                result.Add(new Category
                {
                    ID = 0,
                    Name = "Корень категорий",
                    RealName = "Все категории"
                });
                Category category = GetByID(rootCategory);
                Category categoryRoot = GetByID(category.RootCategoryID);

                result.Add(new Category
                {
                    ID = categoryRoot.ID,
                    Name = "Уровнем выше",
                    RealName = categoryRoot.Name,
                    Filter = categoryRoot.Filter,
                    RootCategoryID = categoryRoot.RootCategoryID
                });
                result.Add(new Category
                {
                    ID = category.ID,
                    Name = category.ID > 0 ? "Данная категория" : "Все категории",
                    RealName = category.Name,
                    Filter = category.Filter,
                    RootCategoryID = category.RootCategoryID
                });
            }
            else if (filter > 0)
            {
                result.Add(new Category
                {
                    ID = 0,
                    Name = "Все категории",
                    RealName = "Все категории"
                });
            }
            result.AddRange(GetByFilterID(filter).FindAll(p => p.RootCategoryID == rootCategory));
            return result;
        }

        

        public Category GetRootCategory(int id)
        {
            if (!ContainsByID(id))
                return null;
            int root = GetByID(id).RootCategoryID;
            return GetByID(root);
        }

        public override Category GetByName(string articul) => GetThis().FirstOrDefault(p => p.Name.Trim() == articul.Trim());

        public override bool ContainsByName(string articul) => GetThis().Any(p => p.Name.Trim() == articul.Trim());

        public override int IndexByName(string articul) => GetThis().FindIndex(p => p.Name.Trim() == articul.Trim());

        public override void AddPart(int id, string name)
        {
            Add(new Category
            {
                ID = id,
                Name = name
            });
        }

        public CategoriesList GetByFilter(int filtersID = 0)
        {
            if (filtersID < 1)
                return new CategoriesList(this);
            else
                return new CategoriesList(FindAll(c => c.Filter.ID == filtersID || c.ID == 0));
        }

        public CategoriesList GetCategoriesCheck(int filterID = 0, int categoryID = 0, bool subCategories = false)
        {
            if (subCategories)
                return GetSubCategories(categoryID, filterID);
            else
                return GetByFilter(filterID);
        }

        public void SetCategoriesCheck(int filterID = 0, int categoryID = 0, bool subCategories = false)
        {
            CategoriesList categories = GetCategoriesCheck(filterID, categoryID, subCategories);
            Clear();
            AddRange(categories);
        }

        public CategoriesList GetByFilter(Part part) => GetByFilter(part.ID);

        public override void AddPart(Part part)
        {
            if(part is Category)
            {
                Add((part as Category).CopyCategory());
                return;
            }
            base.AddPart(part);
        }

        public bool UpdateCategoryToDB(Category category, int rootCategoryID = 0)
            => UpdateCategoryToDB(category.ID, category.Name, category.Filter.ID, rootCategoryID);

        public bool UpdateCategoryToDB(Category category)
            => UpdateCategoryToDB(category, category.RootCategoryID);

        public bool UpdateCategoryToDB(int categoryID, string categoryName, int filterID, int rootCategoryID = 0, int count = 20)
        {
            if (categoryName.Length < 1)
                return false;
            if (categoryID == rootCategoryID)
                return false;
            bool subCategory = rootCategoryID > 0;
            rootCategoryID = subCategory ? rootCategoryID : 0;


            SqlConnection connection = DataBaseConfiguration.GetSqlConnection();

            try
            {
                connection.Open();
                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = $"UPDATE [ProductCategory]" +
                        $" SET[CategoryName] = @name, " +
                        $"[Subcategorie] = @sub, " +
                        $"[RootCategoryID] = { rootCategoryID}, " +
                        $"[CategoryFilterID] = {filterID} " +
                        $"WHERE [CategoryID] ={ categoryID}";
                    SqlParameterCollection parameters = command.Parameters;
                    parameters.Clear();
                    parameters.AddWithValue("@name", categoryName);
                    parameters.AddWithValue("@sub", subCategory);
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
                if(count > 0)
                {
                    Thread.Sleep(AddressesList.GetRandomMilliSeconds());
                    return UpdateCategoryToDB(categoryID, categoryName, filterID, rootCategoryID, count - 1);
                }
                return false;
            }

            return true;
        }

        public bool DeleteFromDB(int id)
        {
            int rootCategoryID = 0;
            try
            {
                GetFromBD();
                rootCategoryID = GetByID(id).RootCategoryID;
            }
            catch
            {

            }
            return DeleteFromDB(id, rootCategoryID);
        }

        public bool DeleteFromDB(int id, int rootCategoryID, int count = 20)
        {
            if (id < 1)
                return false;

            SqlConnection connection = DataBaseConfiguration.GetSqlConnection();

            try
            {
                GetFromBD();
                connection.Open();
                try
                {
                    SqlCommand command = connection.CreateCommand();
                    if (ContainsByID(id))
                    {
                        
                        command.CommandText = $"DELETE FROM [dbo].[ProductCategory]" +
                            $" WHERE [CategoryID] ={ id}";
                        SqlParameterCollection parameters = command.Parameters;
                        parameters.Clear();
                        command.ExecuteNonQuery();
                    }

                    command = connection.CreateCommand();
                    command.CommandText = $"UPDATE [ProductCategory]" +
                        $" SET  [RootCategoryID] = {rootCategoryID} " +
                        $"WHERE [RootCategoryID] ={ id}";
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
                if (count > 0)
                {
                    Thread.Sleep(AddressesList.GetRandomMilliSeconds());
                    return DeleteFromDB(id, rootCategoryID, count - 1);
                }
                return false;
            }

            return true;
        }

        public bool AddCategoryToDB(Category category, int rootCategoryID = 0)
        {
            return AddCategoryToDB(category.Name, category.Filter.ID, rootCategoryID);
        }

        public bool AddCategoryToDB(string categoryName, int filterID, int rootCategoryID = 0, int count = 20)
        {
            if (categoryName.Length < 1)
                return false;
            bool subCategory = rootCategoryID > 0;
            rootCategoryID = subCategory?rootCategoryID: 0;

            SqlConnection connection = DataBaseConfiguration.GetSqlConnection();

            try
            {
                connection.Open();
                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = $"INSERT INTO [ProductCategory] " +
                        $"([CategoryName]" +
                        $",[Subcategorie]" +
                        $",[RootCategoryID]"  +
                        $",[CategoryFilterID]) " +
                        $"VALUES (@name, @sub, {rootCategoryID}, {filterID})";
                    SqlParameterCollection parameters = command.Parameters;
                    parameters.Clear();
                    parameters.AddWithValue("@name", categoryName);
                    parameters.AddWithValue("@sub", subCategory);
                    command.ExecuteNonQuery();
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
                if (count > 0)
                {
                    Thread.Sleep(AddressesList.GetRandomMilliSeconds());
                    return AddCategoryToDB(categoryName, filterID, rootCategoryID, count - 1);
                }
                return false;
            }

            return true;
        }
    }
}
