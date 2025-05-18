using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.SymbolStore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RepositoryPatternDemo.Utility.Auth
{

    public class JwtToken
    {
        private readonly IConfiguration _configuration;

        public JwtToken(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public string GenerateJwtToken(string? username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credendiatls = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256); ;

            var token = new JwtSecurityToken
                (
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: new[] { new Claim(ClaimTypes.Name, username) },
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: credendiatls
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }



}
