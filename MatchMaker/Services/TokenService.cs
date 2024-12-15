using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MatchMaker.Services
{
    public class TokenService
    {
        private readonly string _secret;
        private readonly string _issuer;
        private readonly string _audience;

        public TokenService(IConfiguration configuration)
        {
            _secret = configuration["JWT_SECRET"];
            _issuer = "MatchMaker";
            _audience = "MatchMaker";
        }

        public string GenerateToken(string userId, string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim("userId", userId),
                new Claim(ClaimTypes.Email, email)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _issuer,
                Audience = _audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

}
