// <copyright file="QuizServiceTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WebApi.Services.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using Microsoft.Extensions.Configuration;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using WebApi.Models;
    using WebApi.Services;

    /// <summary>
    /// тестирование логики приложения.
    /// </summary>
    [TestClass]
    public class QuizServiceTests
    {
        private readonly IConfiguration configuration;

        public QuizServiceTests(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// Проверка на ответ.
        /// </summary>
        [TestMethod]
        public void GetNextQuestionTest()
        {
            // Arrange
            int questionId = 1;
            QuizService quiz = new QuizService(this.configuration);

            // Act
            var example = @"{'Question':'2+2?','Variants':['5','6','7','4']}}";
            var question = quiz.GetNextQuestion(questionId);

            // Assert
            Assert.AreEqual(example, question);
        }

    }
}