using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProiectIS_BE.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIS_BE.Common
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration config) {
            _configuration = config;
        }

        public string GenerateJwtToken(int id)
        {
            byte[] key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings").GetSection("Secret").Value);
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { 
                    new Claim("id", id.ToString()),  
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public string Encrypt(string encryptText)
        {
            SHA256 sha256 = SHA256.Create();
            StringBuilder hashValue = new StringBuilder();
            UTF8Encoding objUtf8 = new UTF8Encoding();

            byte[] crypto = sha256.ComputeHash(objUtf8.GetBytes(encryptText));

            foreach (byte b in crypto)
            {
                hashValue.Append(b.ToString("x2"));
            }

            return hashValue.ToString();
        }

        public string GetSalt(int length)
        {
            // Build the random bytes
            byte[] salt = RandomNumberGenerator.GetBytes(length);

            // Return the string encoded salt
            return Convert.ToBase64String(salt);
        }
    }
}
