using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MusicShopWebAPI
{
    public class LoginOptions
    {

        /// <summary>
        /// издатель токена
        /// </summary>
        public const string ISSUER = "MusicShopServer";

        /// <summary>
        /// потребитель токена
        /// </summary>
        public const string AUDIENCE = "MusicShopClient";

        /// <summary>
        /// ключ для шифрации
        /// </summary>
        public const string KEY = "mysupersecret_secretkey!123";

        /// <summary>
        /// время жизни токена - 1 минута
        /// </summary>
        public const int LIFETIME = 1;


        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
