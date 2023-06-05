using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KuzminaSA_backend.Models
{
    public class auth
    {
        public static string Issuer => "KuzminaSA"; //идентификатор токена
        public static string Audience => "ApiClient"; // аудитория (для кого предназначен)
        public static int LifetimeInYears => 1; // срок действия токена в годах
        public static SecurityKey SigningKey => new SymmetricSecurityKey(Encoding.ASCII.GetBytes("qwerty")); //ключ для шифрования

        internal static object GenerateToken(bool is_admin = false)
        {
            var now = DateTime.UtcNow;
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, "user"),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, is_admin?"admin":"guest")
            };
            ClaimsIdentity identity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            //создаем JWT-токен
            var jwt = new JwtSecurityToken(
                issuer: Issuer,
                audience: Audience,
                notBefore: now,
                expires: now.AddYears(LifetimeInYears),
                claims: identity.Claims,
                signingCredentials: new SigningCredentials(SigningKey, SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return new { roken = encodedJwt };
        }
    }
}


