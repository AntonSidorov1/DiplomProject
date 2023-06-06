using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    public class Session
    {
        public string token = "";

        public string Token
        {
            get => token;
            set => token = value;
        }

        public Session()
        {

        }

        public Session(string token) : this()
        {
            Token = token;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual EnvirontmentSession Copy() => new EnvirontmentSession { EnvirontmentToken = Token };

        public virtual JwtSession CopyJWT() => new JwtSession { Token = this.Token };

        /// <summary>
        /// Создаёт копию с окружением
        /// </summary>
        /// <param name="environtment"></param>
        /// <returns></returns>
        public virtual SessionWithEnvirontment CopyWithEnvirontment(Environtment environtment)
        {
            return CopyWithActive().CopyWithEnvirontment(environtment);
        }

        /// <summary>
        /// Создаёт копию с окружением из базы данных
        /// </summary>
        /// <returns></returns>
        public SessionWithEnvirontment CopyWithEnvirontment()
        {
            string environtmentToken = EnvirontmentTokenController.GetEnvirontmantByToken(Token, false);
            Environtment environtment = EnvirontmentTokenController.GetController().Get(new EnvirontmentSession(environtmentToken)).Value;
            return CopyWithEnvirontment(environtment);
        }

        public virtual SessionActive CopyWithActive()
        {
            return new SessionActive(Token);
        }

    }
}
