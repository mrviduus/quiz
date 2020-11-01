// <copyright file="IUserService.cs" company="Nilorn Group">
// Copyright (c) Nilorn Group. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Services
{
    public interface IUserService
    {
        User Authenticate(string code);

        User GetUser();
    }
}
