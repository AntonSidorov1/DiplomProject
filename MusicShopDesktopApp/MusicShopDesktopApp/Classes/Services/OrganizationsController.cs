
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Организации
    /// </summary>
    public class OrganizationsController
    {
        /// <summary>
        /// Создать контроллер
        /// </summary>
        /// <returns></returns>
        public static OrganizationsController GetController() => new OrganizationsController();


        /// <summary>
        /// Получить список организаций
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public OrganizationsList GetOrganizations(Session session)
        {
            if (!SessionsController.GetController().CheckActive(session))
                throw new Exception("Вы больше не авторизированы в системе");
            return GetOrganizations();
        }

        /// <summary>
        /// Получить список организаций
        /// </summary>
        /// <returns></returns>
        public OrganizationsList GetOrganizations() => OrganizationsList.GetListFromDB();

        /// <summary>
        /// Получить организацию по его ID
        /// </summary>
        /// <param name="session"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Organization GetOrganization(Session session, int id)
        {
            if (!SessionsController.GetController().CheckActive(session))
                throw new Exception("Вы больше не авторизированы в системе");
            return GetOrganizations().GetByID(id);
        }

    }
}
