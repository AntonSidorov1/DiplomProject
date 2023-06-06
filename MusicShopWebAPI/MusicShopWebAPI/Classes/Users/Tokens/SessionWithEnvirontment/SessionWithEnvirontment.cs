using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    /// <summary>
    /// Сессия с окружением
    /// </summary>
    public class SessionWithEnvirontment : SessionActive
    {
        public SessionWithEnvirontment()
        {
        }

        public SessionWithEnvirontment(string token) : base(token)
        {
        }

        Environtment environtment = new Environtment();

        /// <summary>
        /// Окружение
        /// </summary>
        public Environtment Environtment
        {
            get => environtment;
            set => environtment = value;
        }

        public override string ToString()
        {
            return $"Логин: {Login} \n" +
                Environtment.ToString() + $"\n" +
                $"{Description} \n";
        }

    }
}
