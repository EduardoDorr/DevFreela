using System.Text;
using System.Security.Claims;
using System.Security.Cryptography;
using System.IdentityModel.Tokens.Jwt;

using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

using DevFreela.Domain.Services;

namespace DevFreela.Infrastructure.Auth;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;

    public AuthService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string ComputeSha256Hash(string password)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));

        var stringBuilder = new StringBuilder();

        for (int i = 0; i < bytes.Length; i++)
            stringBuilder.Append(bytes[i].ToString("x2"));

        return stringBuilder.ToString();
    }

    public string GenerateJwtToken(string email, string role)
    {
        var key = _configuration["Jwt:Key"];
        var issuer = _configuration["Jwt:Issuer"];
        var audience = _configuration["Jwt:Audience"];

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>()
        {
            new("userName", email),
            new(ClaimTypes.Role, role)
        };

        var token =
            new JwtSecurityToken(issuer: issuer,
                                 audience: audience,
                                 expires: DateTime.Now.AddHours(8),
                                 signingCredentials: credentials,
                                 claims: claims);

        var tokenHandler = new JwtSecurityTokenHandler();
        var stringToken = tokenHandler.WriteToken(token);

        return stringToken;
    }
}