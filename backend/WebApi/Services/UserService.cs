// <copyright file="UserService.cs" company="Nilorn Group">
// Copyright (c) Nilorn Group. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebApi.DataAccess;
using WebApi.Expansion;
using WebApi.Models;

namespace WebApi.Services
{
    public class UserService : IUserService
    {
        private static User user;

        private readonly AppSettings appSettings;
        private readonly IConfiguration configuration;

        private List<User> users = new List<User>();

        public UserService(IOptions<AppSettings> appSettings, IConfiguration configuration)
        {
            this.appSettings = appSettings.Value;
            this.configuration = configuration;
        }

        public User Authenticate(string code)
        {
            var initialize = new InitializeDB(this.configuration);
            this.users = initialize.GetUsers();

            user = this.users.SingleOrDefault(x => x.Code == code);
            if (user == null)
            {
                return null;
            }

            // аутентификация пройдена генерируем токен
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // удаляем код(пароль перед удалением)
            user.Code = null;
            return user;
        }

        public User GetUser()
        {
            return user;
        }
    }
}