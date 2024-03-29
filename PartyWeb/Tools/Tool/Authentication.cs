﻿using BusinessObjects.Models;
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
        private static Authentication instance = default;

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
                new Claim("id", user.Id.ToString()),
                new Claim("exp", now.Ticks.ToString())
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
        
    }
}