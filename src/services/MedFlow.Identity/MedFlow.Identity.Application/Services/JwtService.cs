using MedFlow.Identity.Application.Interfaces.Services;
using MedFlow.Shared.Contracts.Configurations;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MedFlow.Identity.Application.Services
{
    public class JwtService : IJwtService
    {
        private readonly JwtSettings _jwtSettings;
        public JwtService(IOptions<JwtSettings> options)
        {
            _jwtSettings = options.Value ?? throw new ArgumentNullException("Value not found for Jwt Settings.");
        }

        public string GenerateToken(int userId, string userEmail, string role)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Email, userEmail),
                new Claim(ClaimTypes.Role, role)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.Key));

            var creds = new SigningCredentials(
                key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
