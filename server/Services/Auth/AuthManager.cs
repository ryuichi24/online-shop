using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Scrypt;
using server.Helpers;

namespace server.Services.Auth
{
    public class AuthManager : IAuthManager
    {
        private readonly AppSettings _appSettings;

        private readonly ScryptEncoder _encoder;

        public AuthManager(IOptions<AppSettings> appSettingsSection)
        {
            this._appSettings = appSettingsSection.Value;
            this._encoder = new ScryptEncoder();
        }

        public string EncryptPassword(string password)
        {
            string encrypted = this._encoder.Encode(password);
            return encrypted;
        }

        public bool ComparePassword(string password, string hashedPassword)
        {
            bool areEquals = this._encoder.Compare(password, hashedPassword);
            return areEquals;
        }

        public string GenerateJwt(string id, string email, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(this._appSettings.JwtSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Id", id),
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials
                (
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}