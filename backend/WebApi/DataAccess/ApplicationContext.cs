// <copyright file="ApplicationContext.cs" company="Nilorn Group">
// Copyright (c) Nilorn Group. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApi.Models;

namespace WebApi
{
    public class ApplicationContext : DbContext
    {
        private readonly IConfiguration configuration;

        public ApplicationContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Answers> Answers { get; set; }

        public DbSet<Questions> Questions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.configuration[Constants.ConnectionString]);
        }
    }
}
