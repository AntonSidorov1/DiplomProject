using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicShopWebAPI
{
    /// <summary>
    /// Строка подключения к базе данных
    /// </summary>
    [AppRoute("[controller]")]
    [ApiController]
    public class DataBaseConnectionStringController : ControllerBase
    {
        /// <summary>
        /// Получить строку подключения к базе данных
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPut("Get-String")]
        public ActionResult<string> Get([FromBody] Session token)
        {
            if(!Contains(token))
            {
                return Unauthorized("Null");
            }
            return GetConnectionString();
        }

        [NonAction]
        public bool AllowEdit(Session token) => GetLogin().CheckAllowEditConnection(token);

        [NonAction]
        public bool Contains(Session token) => GetLogin().CheckWorking(token);

        [NonAction]
        public static string GetConnectionString() => DataBaseConfiguration.ConnectionString;

        [NonAction]
        public LoginForEditConnectionParametersController GetLogin() => new LoginForEditConnectionParametersController();


        /// <summary>
        /// Получить отдельные параметры из строки подключения к базе данных
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPut("Get-Parts")]
        public ActionResult<ConnectionStringDataBase> GetParts([FromBody] Session token)
        {
            
                if (!Contains(token))
                {
                    return Unauthorized("Null");
                }
                return ConnectionDataBase.GetConnection(Get(token).Value).Copy();
        }

        /// <summary>
        /// Изменить строку подключения к базе данных
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] ConnectionDataBaseWithToken value)
        {
            if (!AllowEdit(new Session(value.Token)))
                return Unauthorized(false);
            DataBaseConfiguration.ConnectionString = value.CopyWithFull().ConnectionString;
            return Ok(true);
        }

        /// <summary>
        /// Установить строку подключения к базе данных По-умолчанию
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPut("Set-Default")]
        public ActionResult<ConnectionStringDataBase> Delete([FromBody] Session token)
        {
            if (!AllowEdit(token))
            {
                return Unauthorized("Null");
            }
            DataBaseConfiguration.Clear();
            return DataBaseConfiguration.GetConnection();
        }

        /// <summary>
        /// Рабочая ли строка подключения к базе данных
        /// </summary>
        /// <returns></returns>
        [HttpGet("Check")]
        public ActionResult<bool> Check()
        {
            return DataBaseConfiguration.Check() ? Ok(true) : StatusCode(500, false);
        }
    }
}
