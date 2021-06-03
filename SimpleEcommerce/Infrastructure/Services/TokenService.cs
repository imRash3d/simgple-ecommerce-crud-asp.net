using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SimpleEcommerce.Entities;
using SimpleEcommerce.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration config, IConfigurationService configurationService)
        {

            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configurationService.GetAppsettingValueByKey("TokenKey")));

        }
        public string createToken(User user)
        {
            var claims = new List<Claim> {

            new Claim(JwtRegisteredClaimNames.NameId,user.UserName)
            };

            var credintials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptior = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = credintials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptior);
            return tokenHandler.WriteToken(token);

        }
    }
}



