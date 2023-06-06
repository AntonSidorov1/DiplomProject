using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    /// <summary>
    /// Категория
    /// </summary>
    public class Category : Part
    {
        CategoryFilter filter = new CategoryFilter();

        /// <summary>
        /// Фильтр категории
        /// </summary>
        public CategoryFilter Filter
        {
            get => filter;
            set => filter = value;
        }

        int rootCategoryID = 0;

        public int RootCategoryID
        {
            get => rootCategoryID;
            set => rootCategoryID = value;
        }

        string realName = "";

        public string RealName
        {
            get => realName;
            set => realName = value;
        }

        public void SetRealNameByName()
        {
            RealName = Name;
        }


        public Category CopyCategory()
        {
            return new Category
            {
                ID = this.ID,
                Name = this.Name,
                RealName = this.RealName
            };
        }
    }
}
