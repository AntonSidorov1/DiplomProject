
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Роли
    /// </summary>
    public class RolesController
    {
        

        /// <summary>
        /// Получить список ролей
        /// </summary>
        /// <returns></returns>
        public RolesList Get()
        {
            return GetRoles();
        }

        public static RolesList GetRoles()
        {
            return RolesList.GetDatasListFromDB();
        }

        /// <summary>
        /// Получить роль по её ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Role Get(int id)
        {
            return Get().GetByID(id);
        }

        /// <summary>
        /// Получить роль по её имени
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public Role GetByName(string roleName)
        {
            return Get().GetByName(roleName);
        }

    }
}
