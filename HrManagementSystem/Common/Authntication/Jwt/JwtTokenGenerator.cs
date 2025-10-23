using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Entities.Roles;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HrManagementSystem.Common.Authntication.Jwt
{
    public class  JwtTokenGenerator(IOptions<JwtSettings> jwtOptions)
    {
        private readonly JwtSettings _jwtOptions = jwtOptions.Value;

        public (string Token, int ExpiresIn) GenerateJwtToken(User user)
        {
            Claim[] claims = [
                new(ClaimTypes.NameIdentifier,user.Id),
                new(ClaimTypes.Name,user.Name),
                new(ClaimTypes.Email,user.Email),
                new(ClaimTypes.Role,user.Role.Name)
                ];

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));

            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddMinutes(_jwtOptions.ExpiryMinutes)
                );


            return (new JwtSecurityTokenHandler().WriteToken(token), _jwtOptions.ExpiryMinutes * 60);
        }
    }
}
