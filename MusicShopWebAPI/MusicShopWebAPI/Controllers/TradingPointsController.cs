using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    /// <summary>
    /// Торговые пункты
    /// </summary>
    [AppRoute("[controller]")]
    [ApiController]
    public class TradingPointsController : ControllerBase
    {
        /// <summary>
        /// Создать контроллер
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public static TradingPointsController GetController() => new TradingPointsController();


        /// <summary>
        /// Получить список магазинов
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        [HttpPut("Shops/Get")]
        public ActionResult<TradingPointsList> GetShops([FromBody] Session session, int sityID = 0, int stockID = 0, int organizationID = 0)
        {
            if (!SessionsController.GetController().CheckActive(session))
                return Unauthorized("Null");
            if (sityID != 0)
                if (!SitiesController.GetController().GetSities().ContainsByID(sityID))
                    return NoContent();
            if (stockID != 0)
                if (!StocksController.GetController().GetStocks(sityID).ContainsByID(stockID))
                    return NoContent();
            if (organizationID != 0)
                if (!OrganizationsController.GetController().GetOrganizations().ContainsByID(organizationID))
                    return NoContent();
            return GetTradingPoints(sityID, stockID, organizationID).GetShops();
        }

        /// <summary>
        /// Получить список магазинов
        /// </summary>
        /// <returns></returns>
        [HttpGet("Shops")]
        [Authorize]
        public ActionResult<TradingPointsList> GetShops(int sityID = 0, int stockID = 0, int organizationID = 0)
        {
            return GetShops(new Session(User.Identity.Name), sityID, stockID, organizationID);
        }

        /// <summary>
        /// Получить список торговых пунктов, которые и магазины и пункты выдачи одновременно
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        [HttpPut("Both-Type/Get")]
        public ActionResult<TradingPointsList> GetBothType([FromBody] Session session, int sityID = 0, int stockID = 0, int organizationID = 0)
        {
            if (!SessionsController.GetController().CheckActive(session))
                return Unauthorized("Null");
            if (sityID != 0)
                if (!SitiesController.GetController().GetSities().ContainsByID(sityID))
                    return NoContent();
            if (stockID != 0)
                if (!StocksController.GetController().GetStocks(sityID).ContainsByID(stockID))
                    return NoContent();
            if (organizationID != 0)
                if (!OrganizationsController.GetController().GetOrganizations().ContainsByID(organizationID))
                    return NoContent();
            return GetTradingPoints(sityID, stockID, organizationID).GetBothType();
        }

        /// <summary>
        /// Получить список торговых пунктов, которые и магазины и пункты выдачи одновременно
        /// </summary>
        /// <returns></returns>
        [HttpGet("Both-Type")]
        [Authorize]
        public ActionResult<TradingPointsList> GetBothType(int sityID = 0, int stockID = 0, int organizationID = 0)
        {
            return GetBothType(new Session(User.Identity.Name), sityID, stockID, organizationID);
        }

        /// <summary>
        /// Получить список пунктов выдачи
        /// </summary>
        /// <returns></returns>
        [HttpGet("Pounkts-Of-Issue")]
        [Authorize]
        public ActionResult<TradingPointsList> GetPounktsOfIssue(int sityID = 0, int stockID = 0, int organizationID = 0)
        {
            return GetPounktsOfIssue(new Session(User.Identity.Name), sityID, stockID, organizationID);
        }

        /// <summary>
        /// Получить список пунктов выдачи
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        [HttpPut("Pounkts-Of-Issue/Get")]
        public ActionResult<TradingPointsList> GetPounktsOfIssue([FromBody] Session session, int sityID = 0, int stockID = 0, int organizationID = 0)
        {
            if (!SessionsController.GetController().CheckActive(session))
                return Unauthorized("Null");
            if (sityID != 0)
                if (!SitiesController.GetController().GetSities().ContainsByID(sityID))
                    return NoContent();
            if (stockID != 0)
                if (!StocksController.GetController().GetStocks(sityID).ContainsByID(stockID))
                    return NoContent();
            if (organizationID != 0)
                if (!OrganizationsController.GetController().GetOrganizations().ContainsByID(organizationID))
                    return NoContent();
            return GetTradingPoints(sityID, stockID, organizationID).GetPounktsOfIssue();
        }


        /// <summary>
        /// Получить список торговых пунктов
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        [HttpPut("Get")]
        public ActionResult<TradingPointsList> GetTradingPoints([FromBody] Session session, int sityID = 0, int stockID = 0, int organizationID = 0)
        {
            if (!SessionsController.GetController().CheckActive(session))
                return Unauthorized("Null");
            if (sityID != 0)
                if (!SitiesController.GetController().GetSities().ContainsByID(sityID))
                    return NoContent();
            if (stockID != 0)
                if (!StocksController.GetController().GetStocks(sityID).ContainsByID(stockID))
                    return NoContent();
            if (organizationID != 0)
                if (!OrganizationsController.GetController().GetOrganizations().ContainsByID(organizationID))
                    return NoContent();
            return GetTradingPoints(sityID, stockID, organizationID);
        }

        /// <summary>
        /// Получить список торговых пунктов
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public ActionResult<TradingPointsList> GetTradingPointsByJwt(int sityID = 0, int stockID = 0, int organizationID = 0)
            => GetTradingPoints(new Session(User.Identity.Name), sityID, stockID, organizationID);

        /// <summary>
        /// Получить список торговых пунктов
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public TradingPointsList GetTradingPoints(int sityID = 0, int stockID = 0, int organizationID = 0) => TradingPointsList.GetListFromDB().GetWithSelection(sityID, stockID, organizationID);

        /// <summary>
        /// Получить торговый пункт по его ID
        /// </summary>
        /// <param name="session"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}/Get")]
        public ActionResult<TradingPoint> GetTradingPoint([FromBody] Session session, int id)
        {
            if (!SessionsController.GetController().CheckActive(session))
                return Unauthorized("Null");
            return GetTradingPoints().GetByID(id);
        }

        /// <summary>
        /// Получить торговый пункт по его ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<TradingPoint> GetTradingPoint(int id)
            => GetTradingPoint(new Session(User.Identity.Name), id);

    }
}
