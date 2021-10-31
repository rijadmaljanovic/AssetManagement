using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Models.Model;
using Models.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApi.Helpers;
using WebApi.Services;

namespace WebApi
{
    public class JWTAuthenticationManager:IJWTAuthenticationManager
    {
        static UserRepository userRepository = new UserRepository();
        UserService userService=new UserService(userRepository);

        private readonly AppSettings _appSettings;

        public JWTAuthenticationManager(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public string Authenticate(string username, string password)
        {
            IEnumerable<User> users = userService.GetAll();
            var user = users.FirstOrDefault(x => x.Username == username);
            if (user != null)
            {
                var newHash =userService.GenerateHash(user.PasswordSalt, password);
                if (newHash == user.Hash)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                         new Claim(ClaimTypes.Name, username),
                         new Claim("id",user.RowKey)
                        }),
                        Expires = DateTime.UtcNow.AddHours(1),
                        SigningCredentials = new SigningCredentials(
                            new SymmetricSecurityKey(key),
                            SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    return tokenHandler.WriteToken(token);
                }
                return null;
            }
            return null;
        }
    }
}

