using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicShopWebAPI
{
    /// <summary>
    /// Роли
    /// </summary>
    [AppRoute("[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        

        /// <summary>
        /// Получить список ролей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RolesList Get()
        {
            return GetRoles();
        }

        [NonAction]
        public static RolesList GetRoles()
        {
            return RolesList.GetDatasListFromDB();
        }

        /// <summary>
        /// Получить роль по её ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<Role> Get(int id)
        {
            return Get().GetByID(id);
        }

        /// <summary>
        /// Получить роль по её имени
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        [HttpGet("By-Name/{roleName}")]
        public ActionResult<Role> GetByName(string roleName)
        {
            return Get().GetByName(roleName);
        }

    }
}
