using Servicios.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Options;

namespace Servicios
{
    public class TokenHandlerService : ITokenHandlerService
    {
        private readonly JwtConfig _jwtConfig;

        public TokenHandlerService(IOptionsMonitor<JwtConfig> optionMonitor)
        {
            _jwtConfig = optionMonitor.CurrentValue;
        }

        /*
         * LA CADENA DE SECRET LLEGA NULLA O NO LLEGA NADA POR LO QUE NO TOMA NADA
         * 
         * 
         * 
         * 
         * 
        */
        public string GenerateJwtToken(ITokenParameters pars)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
               {
                    new Claim("Id", pars.Id),
                    new Claim(JwtRegisteredClaimNames.Sub, pars.Usuario),
                    new Claim(JwtRegisteredClaimNames.Email, pars.Usuario),

                }),
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }
    }
}
