
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Склады
    /// </summary>
    public class StocksController
    {
        /// <summary>
        /// Создать контроллер
        /// </summary>
        /// <returns></returns>
        public static StocksController GetController() => new StocksController();


        /// <summary>
        /// Получить список складов
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public StocksList GetStocks(Session session, int sityID = 0)
        {
            if (!SessionsController.GetController().CheckActive(session))
                throw new Exception("Вы больше не авторизированы в системе");
            if (sityID != 0)
                if (!SitiesController.GetController().GetSities().ContainsByID(sityID))
                    throw new Exception("Данного города не существует");
            return GetStocks(sityID);
        }

        /// <summary>
        /// Получить список складов
        /// </summary>
        /// <returns></returns>
        public StocksList GetStocks(int sityID = 0) => StocksList.GetListFromDB().GetBySityID(sityID);

        /// <summary>
        /// Получить склад по его ID
        /// </summary>
        /// <param name="session"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Stock GetStock(Session session, int id)
        {
            if (!SessionsController.GetController().CheckActive(session))
                throw new Exception("Вы больше не авторизированы в системе");
            return GetStocks().GetByID(id);
        }


    }
}
