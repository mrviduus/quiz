// <copyright file="InitializeDBTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WebApi.DataAccess.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using WebApi.DataAccess;

    /// <summary>
    /// Класс по тесту базы.
    /// </summary>
    [TestClass]
    public class InitializeDBTests
    {
        /// <summary>
        /// Тест на получение вариантов ответов.
        /// </summary>
        [TestMethod]
        public void InitializeAnswersDBTest()
        {
            InitializeDB initializeDB = new InitializeDB();
            var answers = initializeDB.InitializeAnswersDB();
            Assert.IsNotNull(answers);
        }

        /// <summary>
        /// Тест на подключение к базе и получения вопросов.
        /// </summary>
        [TestMethod]
        public void InitializeQuestionsDBTest()
        {
            // Arrange
            InitializeDB initializeDB = new InitializeDB();

            // Act
            var questions = initializeDB.InitializeQuestionsDB();

            // Assert
            Assert.IsNotNull(questions);
        }

        /// <summary>
        /// Тест на подключение к базе и получения юзеров.
        /// </summary>
        [TestMethod]
        public void GetUsersTest()
        {
            // Arrange
            InitializeDB initializeDB = new InitializeDB();

            // Act
            var users = initializeDB.GetUsers();

            // Assert
            Assert.IsNotNull(users);
        }
    }
}