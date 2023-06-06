
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Города
    /// </summary>
    public class SitiesController
    {
        /// <summary>
        /// Создать контроллер
        /// </summary>
        /// <returns></returns>
        public static SitiesController GetController() => new SitiesController();


        /// <summary>
        /// Получить список городов
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public SitiesList GetSities(Session session)
        {
            if (!SessionsController.GetController().CheckActive(session))
                throw new Exception("Вы больше не авторизированы в системе");
            return GetSities();
        }

        /// <summary>
        /// Получить список организаций
        /// </summary>
        /// <returns></returns>
        public SitiesList GetSities() => SitiesList.GetListFromDB();

        /// <summary>
        /// Получить город по его ID
        /// </summary>
        /// <param name="session"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Sity GetSity(Session session, int id)
        {
            if (!SessionsController.GetController().CheckActive(session))
                throw new Exception("Вы больше не авторизированы в системе");
            return GetSities().GetByID(id);
        }

    }
}
