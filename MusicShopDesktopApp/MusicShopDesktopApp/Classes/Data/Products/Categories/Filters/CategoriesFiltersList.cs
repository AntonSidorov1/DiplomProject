using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    public class CategoriesFiltersList : AbstractCategoriesList<CategoryFilter>
    {
        public CategoriesFiltersList()
        {
        }

        public CategoriesFiltersList(IEnumerable<CategoryFilter> collection) : base(collection)
        {
        }

        public CategoriesFiltersList(int capacity) : base(capacity)
        {
        }

        public static CategoriesFiltersList GetList() => new CategoriesFiltersList();

        public CategoriesFiltersList GetThis() => this;

        public static CategoriesFiltersList GetListFromDB()
        {
            CategoriesFiltersList products = GetList();
            products.GetFromBD();
            return products;
        }


        public void GetFromBD(int count = 20)
        {
            SqlConnection connection = new SqlConnection();
            connection = DataBaseConfiguration.GetSqlConnection();
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Select * From [CategoryFilter]";

                SqlDataReader reader = command.ExecuteReader();
                Clear();
                AddPart(0, "Все фильтры");
                try
                {
                    while (reader.Read())
                    {
                        CategoryFilter product = new CategoryFilter();
                        product.ID = reader.GetInt32(reader.GetOrdinal("CategoryFilterID"));
                        product.Name = reader.GetString(reader.GetOrdinal("categoryFilterName"));

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

        public override CategoryFilter GetByName(string name) => GetThis().FirstOrDefault(p => p.EqualsName(name));

        public override bool ContainsByName(string articul) => GetThis().Any(p => p.EqualsName(articul));

        public override int IndexByName(string articul) => GetThis().FindIndex(p => p.EqualsName(articul));

        public override void AddPart(int id, string name)
        {
            Add(new CategoryFilter
            {
                ID = id,
                Name = name
            });
        }
    }
}
