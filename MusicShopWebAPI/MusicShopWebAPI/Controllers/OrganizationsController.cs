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
    /// Организации
    /// </summary>
    [AppRoute("[controller]")]
    [ApiController]
    public class OrganizationsController : ControllerBase
    {
        /// <summary>
        /// Создать контроллер
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public static OrganizationsController GetController() => new OrganizationsController();


        /// <summary>
        /// Получить список организаций
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        [HttpPut("Get")]
        public ActionResult<OrganizationsList> GetOrganizations([FromBody] Session session)
        {
            if (!SessionsController.GetController().CheckActive(session))
                return Unauthorized("Null");
            return GetOrganizations();
        }

        /// <summary>
        /// Получить список организаций
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public ActionResult<OrganizationsList> GetOrganizationsByJwt() => GetOrganizations(new Session(User.Identity.Name));

        /// <summary>
        /// Получить список организаций
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public OrganizationsList GetOrganizations() => OrganizationsList.GetListFromDB();

        /// <summary>
        /// Получить организацию по его ID
        /// </summary>
        /// <param name="session"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}/Get")]
        public ActionResult<Organization> GetOrganization([FromBody] Session session, int id)
        {
            if (!SessionsController.GetController().CheckActive(session))
                return Unauthorized("Null");
            return GetOrganizations().GetByID(id);
        }

        /// <summary>
        /// Получить организацию по его ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<Organization> GetOrganization(int id)
            => GetOrganization(new Session(User.Identity.Name), id);
    }
}
