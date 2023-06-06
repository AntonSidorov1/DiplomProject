using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Контроллер категорий
    /// </summary>
    public class CategoriesFiltersController
    {
        public static CategoriesFiltersController GetController() => new CategoriesFiltersController();



        /// <summary>
        /// Получить список фильтров категорий
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public CategoriesFiltersList GetCategoriesFilters(Session session)
        {
            if (!SessionsController.GetController().CheckActive(session))
                throw new ArgumentNullException("Вы не авторизированы");
            return GetCategoriesFilters();
        }

        /// <summary>
        /// Получить список фильтров категорий
        /// </summary>
        /// <returns></returns>
        public CategoriesFiltersList GetCategoriesFilters() => CategoriesFiltersList.GetListFromDB();

        /// <summary>
        /// Получить фильтр категории по его ID
        /// </summary>
        /// <param name="session"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public CategoryFilter GetCategoryFilter(Session session, int id)
        {
            if (!SessionsController.GetController().CheckActive(session))
                throw new ArgumentNullException("Вы не авторизированы");
            return GetCategoriesFilters().GetByID(id);
        }

        /// <summary>
        /// Получить фильтр категории по его названию
        /// </summary>
        /// <param name="session"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public CategoryFilter GetCategoryFilter(Session session, string name)
        {
            if (!SessionsController.GetController().CheckActive(session))
                throw new ArgumentNullException("Вы не авторизированы");
            return GetCategoriesFilters().GetByName(name);
        }

    }
}
