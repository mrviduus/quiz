// <copyright file="Questions.cs" company="Nilorn Group">
// Copyright (c) Nilorn Group. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Questions
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
