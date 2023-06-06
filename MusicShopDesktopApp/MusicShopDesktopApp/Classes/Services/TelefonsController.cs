using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Телефоны
    /// </summary>
    public class TelefonsController
    {
        /// <summary>
        /// Создать контроллер
        /// </summary>
        /// <returns></returns>
        public static TelefonsController GetController() => new TelefonsController();

        /// <summary>
        /// Получить список телефонов
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public TelefonsList Get(Session session)
        {
            SessionsController controller = SessionsController.GetController();
            if(!controller.CheckActive(session))
            {
                throw new ArgumentException("Вы больше не авторизированы");
            }
            if(UserRolesController.GetController().IsGoest(session))
            {
                throw new ArgumentException("Вы больше не авторизированы");
            }
            int id = AccountsController.GetController().GetAccount(session).ID;
            return TelefonsList.GetListFromDB(id);
        }

        /// <summary>
        /// Получить телефон по его ID
        /// </summary>
        /// <param name="session"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Telefon Get(Session session, int id) => Get(session).GetByID(id);

        /// <summary>
        /// Удалить номер телефона
        /// </summary>
        /// <param name="id"></param>
        /// <param name="telefon"></param>
        /// <returns></returns>
        public bool DeleteTelefon(Session telefon, int id)
        {
            if (!SessionsController.GetController().CheckActive(telefon))
                return false;
            if (UserRolesController.GetController().IsGoest(telefon))
                return false;
            try
            {
                int user = Helper.ID;
                return TelefonsList.GetList().DeleteFromDB(user, id);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Добавить номер телефона
        /// </summary>
        /// <param name="telefon"></param>
        /// <returns></returns>
        public bool AddTelefon(TelefonSession telefon)
        {
            if (!SessionsController.GetController().CheckActive(telefon))
                return false;
            if (UserRolesController.GetController().IsGoest(telefon))
                return false;
            try
            {
                int user = Helper.ID;
                return TelefonsList.GetList().AddToDB(user, telefon.CopyTelefon());
            }
            catch
            {
                return false;
            }
        }

    }
}
