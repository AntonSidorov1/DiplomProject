using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Контроллер для работы с товарами
    /// </summary>
    public class ProductsController
    {
        public static ProductsController GetController() => new ProductsController();

        /// <summary>
        /// Получить список товаров
        /// </summary>
        /// <param name="session"></param>
        /// <param name="sortByName"></param>
        /// <param name="sortByPrice"></param>
        /// <returns></returns>
        public ProductsList GetProducts(Session session, Order sortByName = Order.None, Order sortByPrice = Order.None, int category = 0, string nameFilter = "", int minDiscount = 0, int maxDiscount = 100)
        {
            if (!SessionsController.GetController().CheckActive(session))
                throw new ArgumentNullException("Вы не авторизированы");

            return ProductsList.GetListFromDB(sortByName, sortByPrice, category, nameFilter).GetListByDiscount(minDiscount, maxDiscount);
        }

        public ProductsList GetProducts() => ProductsList.GetListFromDB();

        /// <summary>
        /// Получить товар по его ID
        /// </summary>
        /// <param name="session"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product GetProduct(Session session, int id)
        {
            if (!SessionsController.GetController().CheckActive(session))
                throw new ArgumentNullException("Вы не авторизированы");
            return GetProducts().FirstOrDefault(p => p.ID == id);
        }

        /// <summary>
        /// Получить товар по его Артиклю
        /// </summary>
        /// <param name="session"></param>
        /// <param name="articul"></param>
        /// <returns></returns>
        public Product GetProduct(Session session, string articul)
        {
            if (!SessionsController.GetController().CheckActive(session))
                throw new ArgumentNullException("Вы не авторизированы");
            return GetProducts().FirstOrDefault(p => p.Articul.Trim() == articul.Trim());
        }

    }
}
