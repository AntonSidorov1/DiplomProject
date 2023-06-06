using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    public class SessionActive : Session
    {
        public SessionActive()
        {
            DateOpen = DateTime.Now;
        }

        public SessionActive(string token) : base(token)
        {
            DateOpen = DateTime.Now;
        }


        /// <summary>
        /// Создаёт копию с окружением
        /// </summary>
        /// <param name="environtment"></param>
        /// <returns></returns>
        public override SessionWithEnvirontment CopyWithEnvirontment(Environtment environtment)
        {
            return new SessionWithEnvirontment(Token)
            {
                Environtment = environtment,
                Active = this.Active,
                Successfully = this.Successfully,
                Login = this.Login,
                This = this.This,
                DateOpen = this.DateOpen
            };
        }


        bool active = true;

        /// <summary>
        /// Активна ли сессия
        /// </summary>
        public bool Active
        {
            get => active;
            set => active = value;
        }

        bool successfully = true;

        /// <summary>
        /// Удачно ли открыта сессия
        /// </summary>
        public bool Successfully
        {
            get => successfully;
            set => successfully = value;
        }

        string login = "";

        /// <summary>
        /// Логин
        /// </summary>
        public string Login
        {
            get => login;
            set => login = value;
        }

        bool use = false;

        /// <summary>
        /// Является ли сессия текущей
        /// </summary>
        public bool This
        {
            get => use;
            set => use = value;
        }

        public bool EqualsLogin(Account account)
        {
            return account.EqualsLogin(Login);
        }

        /// <summary>
        /// Устанавливает, является ли сессия session данной сессией. Результат - This
        /// </summary>
        /// <param name="session"></param>
        public void SetThisUseEquals(Session session)
        {
            This = Token == session.Token;
        }


        /// <summary>
        /// Описание
        /// </summary>
        public string Description
        {
            get
            {
                return (This ? "Текущая сессия \n" : "") +
                     (Active ? "Сессия Активна" : "Сессия не активна")  + "\n"+
                     (Successfully ? "Вход удачен" : "Вход не удачен") + "\n" +
                     $"Дата открытия: {DateOpen}";
            }
            set
            {
                string[] description = value.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    This = description[0].ToLower().Trim() == "Текущая сессия".ToLower().Trim();
                }
                catch
                {

                }
                try
                {
                    Active = (description[1].ToLower().Trim() == "Активна".ToLower().Trim() || description[1].ToLower().Trim() == "Сессяи Активна".ToLower().Trim());
                }
                catch
                {
                    return;
                }
                try
                {
                    Successfully = (description[2].ToLower().Trim() == "Удачно".ToLower().Trim() || description[2].ToLower().Trim() == "Вход удачен".ToLower().Trim());
                }
                catch
                {
                    return;
                }
                try
                {
                    string[] values = description[3].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                    List<string> listValues = new List<string>(values);
                    listValues.RemoveAt(0);
                    string dateOpen = string.Join(":", listValues).Trim();
                    DateOpen = Convert.ToDateTime(dateOpen);
                }
                catch
                {

                }
            }
        }

        DateTime dateOpen;
        
        /// <summary>
        /// Дата открытия сессиии
        /// </summary>
        public DateTime DateOpen
        {
            get => dateOpen;
            set => dateOpen = value;
        }

        /// <summary>
        /// Дата открытия сессиии
        /// </summary>
        public string DateTimeText
        {
            get => DateOpen.ToString();
            set => DateOpen = Convert.ToDateTime(value);
        }

        /// <summary>
        /// Полное описание
        /// </summary>
        public string FullDescription
        {
            get => ToString();
            set { }
        }
    }
}
