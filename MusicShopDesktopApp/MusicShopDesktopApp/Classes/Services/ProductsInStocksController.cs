
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Контроллер для работы с товарами
    /// </summary>
    public class ProductsInStocksController 
    {
        /// <summary>
        /// Создать контроллер
        /// </summary>
        /// <returns></returns>
        public static ProductsInStocksController GetController() => new ProductsInStocksController();

        public bool Contains(int id) => StocksController.GetController().GetStocks().ContainsByID(id);

        public static PounktType GetPounktType() => PounktType.Stock;

        /// <summary>
        /// Получить список товаров на складе с введённым id
        /// </summary>
        /// <param name="session"></param>
        /// <param name="sortByName"></param>
        /// <param name="sortByPrice"></param>
        /// <returns></returns>
        public ProductsInPounktList GetProducts(Session session, string sortByName = "None", string sortByPrice = "None", int category = 0, string nameFilter="", int id = 0
            , int minDiscount = 0, int maxDiscount = 100, bool listFull = false)
        {
            if (!SessionsController.GetController().CheckActive(session))
                throw new Exception("Вы больше не авторизированы в системе");
            if (id > 0)
            {
                if (!StocksController.GetController().GetStocks(session).ContainsByID(id))
                {
                    throw new Exception("склад не существует");
                }
            }

            Order byPrice, byName;
            if (StringNormalize.Normalize(sortByName) == StringNormalize.Normalize("Asc"))
            {
                byName = Order.Asc;
            }
            else if (StringNormalize.Normalize(sortByName) == StringNormalize.Normalize("Desc"))
            {
                byName = Order.Desc;
            }
            else
            {
                byName = Order.None;
            }

            if (StringNormalize.Normalize(sortByPrice) == StringNormalize.Normalize("Asc"))
            {
                byPrice = Order.Asc;
            }
            else if (StringNormalize.Normalize(sortByPrice) == StringNormalize.Normalize("Desc"))
            {
                byPrice = Order.Desc;
            }
            else
            {
                byPrice = Order.None;
            }

            return ProductsInPounktList.GetListFromDB(byName, byPrice, category, nameFilter, GetPounktType()
                , id, listFull).GetListByDiscount(minDiscount, maxDiscount);
        }

        public ProductsInPounktList GetProducts(int pounktID = 0) => ProductsInPounktList.GetListFromDB(pounktID: pounktID, pounktType: GetPounktType());

        /// <summary>
        /// Получить товар по его ID на складе с введённым pounktID
        /// </summary>
        /// <param name="session"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductInPounkt GetProduct(Session session, int id, int pounktID = 0)
        {
            if (!SessionsController.GetController().CheckActive(session))
                throw new Exception("Вы больше не авторизированы в системе");
            if (!Contains(pounktID))
                throw new Exception("склад не существует");
            ProductsInPounktList products = GetProducts(pounktID);
            if (!products.ContainsByID(id))
            {
                ProductsList products1 = ProductsController.GetController().GetProducts();
                if (!products1.ContainsByID(id))
                    throw new Exception("товар не существует");
                return products1.GetByID(id).CopyProductInPounkt(GetPounktType());
            }
            return products.GetByID(id);
        }

        /// <summary>
        /// Получить товар по его Артиклю на складе с введённым pounktID
        /// </summary>
        /// <param name="session"></param>
        /// <param name="articul"></param>
        /// <returns></returns>
        public Product GetProduct(Session session, string articul, int pounktID = 0)
        {
            if (!SessionsController.GetController().CheckActive(session))
                throw new Exception("Вы больше не авторизированы в системе");
            if (!Contains(pounktID))
                throw new Exception("склад не существует");
            ProductsInPounktList products = GetProducts(pounktID);
            if (!products.ContainsByArticul(articul))
            {
                ProductsList products1 = ProductsController.GetController().GetProducts();
                if (!products1.ContainsByArticul(articul))
                    throw new Exception("товар не существует");
                return products1.GetByArticul(articul).CopyProductInPounkt(GetPounktType());
            }
            return products.GetByArticul(articul);
        }

    }
}
