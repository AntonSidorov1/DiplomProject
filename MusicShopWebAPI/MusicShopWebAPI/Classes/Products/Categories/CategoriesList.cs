using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    /// <summary>
    /// Список категорий
    /// </summary>
    public class CategoriesList : AbstractCategoriesList<Category>
    {
        public override void AddPart(Part part)
        {
            if (part is Category)
            {
                Add((part as Category).CopyCategory());
                return;
            }
            base.AddPart(part);
        }

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
                    RealName = categoryRoot.Name
                });
                result.Add(new Category
                {
                    ID = category.ID,
                    Name = category.ID > 0 ? "Данная категория" : "Все категории",
                    RealName = category.Name
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
    }
}
