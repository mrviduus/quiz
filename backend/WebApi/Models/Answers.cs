// <copyright file="Answers.cs" company="Nilorn Group">
// Copyright (c) Nilorn Group. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Answers
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Answer { get; set; }

        [Required]
        public bool Correct { get; set; }

        [Required]
        public int QuestionsId { get; set; }

        [Required]
        public Questions Questions { get; set; }
    }
}
