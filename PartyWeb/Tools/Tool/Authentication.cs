using BusinessObjects.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Tools.Tool
{
    public class Authentication
    {
        private readonly IConfiguration _configuration;
        private static Authentication instance;

        public Authentication(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static Authentication Instance
        {
            get
            {
                if (instance == null)
                {
                    throw new Exception("Authentication instance has not been initialized.");
                }
                return instance;
            }
        }

        public static void Initialize(IConfiguration configuration)
        {
            instance = new Authentication(configuration);
        }

        public string CreateToken(Account user)
        {
            DateTime now = DateTime.Now;
            List<Claim> claims = new List<Claim>
            {
                new Claim("user", JsonSerializer.Serialize(user)),
                new Claim("exp", now.Ticks.ToString()),
                new Claim("role", "user")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JwtSettings:SecretKey").Value ?? ""));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                issuer: _configuration.GetSection("JwtSettings:Issuer").Value,
                audience: _configuration.GetSection("JwtSettings:Audience").Value,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
        public string GetUserIdFromHttpContext(HttpContext httpContext)
        {
            if (!httpContext.Request.Headers.ContainsKey("Authorization"))
            {
                throw new("Need Authorization");
            }
            string? authorizationHeader = httpContext.Request.Headers["Authorization"];

            if (string.IsNullOrWhiteSpace(authorizationHeader) || !authorizationHeader.StartsWith("Bearer "))
            {
                throw new($"Invalid authorization header: {authorizationHeader}");
            }
            string jwtToken = authorizationHeader["Bearer ".Length..];
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(jwtToken);
            var idClaim = token.Claims.FirstOrDefault(claim => claim.Type == "user");
            return idClaim?.Value ?? throw new($"Can not get userId from token");
        }
    }
}