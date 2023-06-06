using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Контроллер категорий
    /// </summary>
    public class CategoriesController
    {

        public CategoriesList GetCategoriesCheck(int filterID = 0, int categoryID = 0, bool subCategories = false)
        {
            if (subCategories)
                return GetSubCategories(Helper.GetSession(), categoryID, filterID);
            else
                return GetCategories(filterID);
        }

        public static CategoriesController GetController() => new CategoriesController();

        /// <summary>
        /// Получить подкатегории в категории по её ID
        /// </summary>
        /// <param name="session"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public CategoriesList GetSubCategories(Session session, int id = 0, int filterID = 0)
        {
            if (!SessionsController.GetController().CheckActive(session))
                throw new Exception("Вы больше не авторизированы");
            return GetCategories().GetSubCategories(id, filterID);
        }

        /// <summary>
        /// Получить надкатегорию для категории по её ID
        /// </summary>
        /// <param name="session"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Category GetRootCategory(Session session, int id = 0)
        {
            if (!SessionsController.GetController().CheckActive(session))
                throw new Exception("Вы больше не авторизированы");
            return GetCategories().GetRootCategory(id);
        }

        /// <summary>
        /// Получить список категорий
        /// </summary>
        /// <param name="session"></param>
        /// <param name="filterID"></param>
        /// <returns></returns>
        public CategoriesList GetCategories(Session session, int filterID = 0)
        {
            if (!SessionsController.GetController().CheckActive(session))
                throw new ArgumentNullException("Вы не авторизированы");
            return GetCategories(filterID);
        }

        /// <summary>
        /// Получить список категорий
        /// </summary>
        /// <param name="filterID"></param>
        /// <returns></returns>
        public CategoriesList GetCategories(int filterID = 0) => CategoriesList.GetListFromDB(filterID);

        /// <summary>
        /// Получить категорию по её ID
        /// </summary>
        /// <param name="session"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Category GetCategory(Session session, int id)
        {
            if (!SessionsController.GetController().CheckActive(session))
                throw new ArgumentNullException("Вы не авторизированы");
            return GetCategories().GetByID(id);
        }

        /// <summary>
        /// Получить категорию по её названию
        /// </summary>
        /// <param name="session"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public Category GetCategory(Session session, string name)
        {
            if (!SessionsController.GetController().CheckActive(session))
                throw new ArgumentNullException("Вы не авторизированы");
            return GetCategories().GetByName(name);
        }

    }
}
