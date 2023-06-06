using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MusicShopWebAPI
{
    public class AppAuthService : IAppAuthService
    {
        /*
        List<UserWithRole> users = new List<UserWithRole>();

        public List<UserWithRole> Users { get { return users; } set => users = value; }
        public Token Authenticate(User user)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json");
                if(!users.Any(account => StringNormalize.Normalize(account.Login) == StringNormalize.Normalize(user.Login)))
            {
                throw new Exception("Данный логин не существует");
            }
            UserWithRole userWithRole = Users.Find(account => StringNormalize.Normalize(account.Login) == StringNormalize.Normalize(user.Login)) ??new UserWithRole();
            if(userWithRole.Password.Trim() != user.Password.Trim())
            {
                throw new Exception("Неверный пароль");
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(configuration.Build()["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userWithRole.Login),
                    new Claim(ClaimTypes.Role, userWithRole.RoleEng)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new Token { AuthToken = tokenHandler.WriteToken(token) };
        }
        */
        public Token Authenticate(string session, string role)
        {
            IConfigurationBuilder configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            if (!SessionsController.GetController().CheckActive(new Session(session)))
            {
                throw new Exception("Данная сессия больше неактивна");
            }
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            string key = "";
            key = configuration.Build()["JWT:Key"];
            //key = LoginOptions.KEY;

            byte[] tokenKey = Encoding.UTF8.GetBytes(key);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, session),
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddHours(1).AddHours(1),
                
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return new Token() { AuthToken = tokenHandler.WriteToken(token) };
        }
    }
}
