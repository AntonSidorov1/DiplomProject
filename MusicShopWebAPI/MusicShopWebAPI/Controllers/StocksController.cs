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
    /// Склады
    /// </summary>
    [AppRoute("[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        /// <summary>
        /// Создать контроллер
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public static StocksController GetController() => new StocksController();


        /// <summary>
        /// Получить список складов
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        [HttpPut("Get")]
        public ActionResult<StocksList> GetStocks([FromBody] Session session, int sityID = 0)
        {
            if (!SessionsController.GetController().CheckActive(session))
                return Unauthorized("Null");
            if (sityID != 0)
                if (!SitiesController.GetController().GetSities().ContainsByID(sityID))
                    return NoContent();
            return GetStocks(sityID).SetWithAll();
        }

        /// <summary>
        /// Получить список складов
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public ActionResult<StocksList> GetStocksByJwt(int sityID = 0) => GetStocks(new Session(User.Identity.Name), sityID);

        /// <summary>
        /// Получить список складов
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public StocksList GetStocks(int sityID = 0) => StocksList.GetListFromDB().GetBySityID(sityID);

        /// <summary>
        /// Получить склад по его ID
        /// </summary>
        /// <param name="session"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}/Get")]
        public ActionResult<Stock> GetStock([FromBody] Session session, int id)
        {
            if (!SessionsController.GetController().CheckActive(session))
                return Unauthorized("Null");
            return GetStocks().GetByID(id);
        }

        /// <summary>
        /// Получить склад по его ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<Stock> GetStock(int id)
            => GetStock(new Session(User.Identity.Name), id);

    }
}
