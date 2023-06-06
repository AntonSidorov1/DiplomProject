using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Электронные почты
    /// </summary>
    public class EmailsController
    {
        /// <summary>
        /// Создать контроллер
        /// </summary>
        /// <returns></returns>
        public static EmailsController GetController() => new EmailsController();

        /// <summary>
        /// Получить список электронных почт
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public EmailsList Get(Session session)
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
            return EmailsList.GetListFromDB(id);
        }

        /// <summary>
        /// Получить электронную почту по её ID
        /// </summary>
        /// <param name="session"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Email Get(Session session, int id) => Get(session).GetByID(id);

        /// <summary>
        /// Удалить Email-адрес
        /// </summary>
        /// <param name="id"></param>
        /// <param name="telefon"></param>
        /// <returns></returns>
        public bool DeleteEmail(Session telefon, int id)
        {
            if (!SessionsController.GetController().CheckActive(telefon))
                return false;
            if (UserRolesController.GetController().IsGoest(telefon))
                return false;
            int user = AccountsController.GetController().GetAccount(telefon).ID;
            return EmailsList.GetList().DeleteFromDB(user, id);
        }

        /// <summary>
        /// Добавить Email-адрес
        /// </summary>
        /// <param name="telefon"></param>
        /// <returns></returns>
        public bool AddEmail(EmailSession telefon)
        {
            if (!SessionsController.GetController().CheckActive(telefon))
                return false;
            if (UserRolesController.GetController().IsGoest(telefon))
                return false;
            int user = AccountsController.GetController().GetAccount(telefon).ID;
            return EmailsList.GetList().AddToDB(user, telefon.CopyEmail());
        }

    }
}
