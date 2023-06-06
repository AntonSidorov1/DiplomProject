
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Торговые пункты
    /// </summary>
    public class TradingPointsController
    {
        /// <summary>
        /// Создать контроллер
        /// </summary>
        /// <returns></returns>
        public static TradingPointsController GetController() => new TradingPointsController();


        /// <summary>
        /// Получить список магазинов
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public TradingPointsList GetShops(Session session, int sityID = 0, int stockID = 0, int organizationID = 0)
        {
            
            return GetTradingPoints(sityID, stockID, organizationID).GetShops();
        }

        /// <summary>
        /// Получить список пунктов выдачи
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public TradingPointsList GetPounktsOfIssue(Session session, int sityID = 0, int stockID = 0, int organizationID = 0)
        {
           
            return GetTradingPoints(sityID, stockID, organizationID).GetPounktsOfIssue();
        }


        /// <summary>
        /// Получить список торговых пунктов
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public TradingPointsList GetTradingPoints(Session session, int sityID = 0, int stockID = 0, int organizationID = 0)
        {
            if (!SessionsController.GetController().CheckActive(session))
                throw new Exception("Вы больше не авторизированы в системе");
            if (sityID != 0)
                if (!SitiesController.GetController().GetSities().ContainsByID(sityID))
                    throw new Exception("Данного города не существует");
            if (stockID != 0)
                if (!StocksController.GetController().GetStocks(sityID).ContainsByID(stockID))
                    throw new Exception("Данного склада не существует");
            if (organizationID != 0)
                if (!OrganizationsController.GetController().GetOrganizations().ContainsByID(organizationID))
                    throw new Exception("Данной организации не существует");
            return GetTradingPoints(sityID, stockID, organizationID);
        }

        /// <summary>
        /// Получить список торговых пунктов
        /// </summary>
        /// <returns></returns>
        public TradingPointsList GetTradingPoints(int sityID = 0, int stockID = 0, int organizationID = 0) 
            => TradingPointsList.GetListFromDB().GetWithSelection(sityID, stockID, organizationID);

        /// <summary>
        /// Получить торговый пункт по его ID
        /// </summary>
        /// <param name="session"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public TradingPoint GetTradingPoint(Session session, int id)
        {
            if (!SessionsController.GetController().CheckActive(session))
                throw new Exception("Вы больше не авторизированы в системе");
            return GetTradingPoints().GetByID(id);
        }

    }
}
