// <copyright file="User.cs" company="Nilorn Group">
// Copyright (c) Nilorn Group. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Token { get; set; }
    }
}