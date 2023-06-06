using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopWebAPI.Controllers
{
    /// <summary>
    /// Параметры сортировки
    /// </summary>
    [AppRoute("[controller]")]
    [ApiController]
    public class SortParamsController : ControllerBase
    {
        /// <summary>
        /// Список параметров сортировки
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string[] Get()
        {
            return Enum.GetNames(typeof(Order));
        }

        /// <summary>
        /// Параметр сортировки с данным id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            string[] sort = Get();
            if (id < 0 || id >= sort.Length)
                return NoContent();
            return sort[id];
        }
    }
}
