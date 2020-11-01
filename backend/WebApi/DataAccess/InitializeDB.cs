// <copyright file="InitializeDB.cs" company="Nilorn Group">
// Copyright (c) Nilorn Group. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WebApi.Expansion;
using WebApi.Models;

namespace WebApi.DataAccess
{
    public class InitializeDB
    {
        private readonly IConfiguration configuration;

        public InitializeDB(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void InitializeData()
        {
            using (ApplicationContext db = new ApplicationContext(this.configuration))
            {
                // создать пользователя
                var user1 = new User { Name = "test", Code = Base64.Base64Encode("test") };
                var user2 = new User { Name = "test2", Code = Base64.Base64Encode("test2") };
                var user3 = new User { Name = "test3", Code = Base64.Base64Encode("test3") };
                var user4 = new User { Name = "test4", Code = Base64.Base64Encode("test4") };
                var user5 = new User { Name = "test5", Code = Base64.Base64Encode("test5") };

                // Добавим в базу
                db.Users.Add(user1);
                db.Users.Add(user2);
                db.Users.Add(user3);
                db.Users.Add(user4);
                db.Users.Add(user5);

                // создать вопросы
                var q1 = new Questions { Name = "2 + 2 = ?" };
                var q2 = new Questions { Name = "3 + 3 = ?" };
                var q3 = new Questions { Name = "4 + 4 = ?" };
                var q4 = new Questions { Name = "5 + 5 = ?" };
                var q5 = new Questions { Name = "10 - 4 = ?" };
                var q6 = new Questions { Name = "2 * 3 = ?" };
                var q7 = new Questions { Name = "7 * 8 = ?" };
                var q8 = new Questions { Name = "21 / 7 = ?" };
                var q9 = new Questions { Name = "12 + 12 = ?" };
                var q10 = new Questions { Name = "9 * 9 = ?" };

                // Добавим в базу
                db.Questions.Add(q1);
                db.Questions.Add(q2);
                db.Questions.Add(q3);
                db.Questions.Add(q4);
                db.Questions.Add(q5);
                db.Questions.Add(q6);
                db.Questions.Add(q7);
                db.Questions.Add(q8);
                db.Questions.Add(q9);
                db.Questions.Add(q10);

                // Создать вопросы
                var answer1 = new Answers { Questions = q1, Answer = "5", Correct = false };
                var answer2 = new Answers { Questions = q1, Answer = "6", Correct = false };
                var answer3 = new Answers { Questions = q1, Answer = "7", Correct = false };
                var answer4 = new Answers { Questions = q1, Answer = "4", Correct = true };

                var answer5 = new Answers { Questions = q2, Answer = "3", Correct = false };
                var answer6 = new Answers { Questions = q2, Answer = "4", Correct = false };
                var answer7 = new Answers { Questions = q2, Answer = "5", Correct = false };
                var answer8 = new Answers { Questions = q2, Answer = "6", Correct = true };

                var answer9 = new Answers { Questions = q3, Answer = "6", Correct = false };
                var answer10 = new Answers { Questions = q3, Answer = "10", Correct = false };
                var answer11 = new Answers { Questions = q3, Answer = "12", Correct = false };
                var answer12 = new Answers { Questions = q3, Answer = "8", Correct = true };

                //5+5
                var answer13 = new Answers { Questions = q4, Answer = "8", Correct = false };
                var answer14 = new Answers { Questions = q4, Answer = "1", Correct = false };
                var answer15 = new Answers { Questions = q4, Answer = "9", Correct = false };
                var answer16 = new Answers { Questions = q4, Answer = "10", Correct = true };

                //10 - 4
                var answer17 = new Answers { Questions = q5, Answer = "6", Correct = true };
                var answer18 = new Answers { Questions = q5, Answer = "7", Correct = false };
                var answer19 = new Answers { Questions = q5, Answer = "2", Correct = false };
                var answer20 = new Answers { Questions = q5, Answer = "3", Correct = false };

                //2 * 3
                var answer21 = new Answers { Questions = q6, Answer = "6", Correct = true };
                var answer22 = new Answers { Questions = q6, Answer = "1", Correct = false };
                var answer23 = new Answers { Questions = q6, Answer = "5", Correct = false };
                var answer24 = new Answers { Questions = q6, Answer = "4", Correct = false };

                //7*8
                var answer25 = new Answers { Questions = q7, Answer = "56", Correct = true };
                var answer26 = new Answers { Questions = q7, Answer = "22", Correct = false };
                var answer27 = new Answers { Questions = q7, Answer = "44", Correct = false };
                var answer28 = new Answers { Questions = q7, Answer = "64", Correct = false };

                //21/7
                var answer29 = new Answers { Questions = q8, Answer = "3", Correct = true };
                var answer30 = new Answers { Questions = q8, Answer = "1", Correct = false };
                var answer31 = new Answers { Questions = q8, Answer = "2", Correct = false };
                var answer32 = new Answers { Questions = q8, Answer = "4", Correct = false };

                //12+12
                var answer33 = new Answers { Questions = q9, Answer = "24", Correct = true };
                var answer34 = new Answers { Questions = q9, Answer = "23", Correct = false };
                var answer35 = new Answers { Questions = q9, Answer = "22", Correct = false };
                var answer36 = new Answers { Questions = q9, Answer = "21", Correct = false };

                //9*9
                var answer37 = new Answers { Questions = q10, Answer = "81", Correct = true };
                var answer38 = new Answers { Questions = q10, Answer = "82", Correct = false };
                var answer39 = new Answers { Questions = q10, Answer = "83", Correct = false };
                var answer40 = new Answers { Questions = q10, Answer = "84", Correct = false };

                // Добавим в базу
                db.Answers.Add(answer1);
                db.Answers.Add(answer2);
                db.Answers.Add(answer3);
                db.Answers.Add(answer4);

                db.Answers.Add(answer5);
                db.Answers.Add(answer6);
                db.Answers.Add(answer7);
                db.Answers.Add(answer8);

                db.Answers.Add(answer9);
                db.Answers.Add(answer10);
                db.Answers.Add(answer11);
                db.Answers.Add(answer12);

                db.Answers.Add(answer13);
                db.Answers.Add(answer14);
                db.Answers.Add(answer15);
                db.Answers.Add(answer16);

                db.Answers.Add(answer17);
                db.Answers.Add(answer18);
                db.Answers.Add(answer19);
                db.Answers.Add(answer20);

                db.Answers.Add(answer21);
                db.Answers.Add(answer22);
                db.Answers.Add(answer23);
                db.Answers.Add(answer24);

                db.Answers.Add(answer25);
                db.Answers.Add(answer26);
                db.Answers.Add(answer27);
                db.Answers.Add(answer28);

                db.Answers.Add(answer29);
                db.Answers.Add(answer30);
                db.Answers.Add(answer31);
                db.Answers.Add(answer32);

                db.Answers.Add(answer33);
                db.Answers.Add(answer34);
                db.Answers.Add(answer35);
                db.Answers.Add(answer36);

                db.Answers.Add(answer37);
                db.Answers.Add(answer38);
                db.Answers.Add(answer39);
                db.Answers.Add(answer40);

                db.SaveChanges();
            }
        }

        public List<Questions> InitializeQuestionsDB()
        {
            var questions = new List<Questions>();
            using (ApplicationContext db = new ApplicationContext(this.configuration))
            {
                questions = db.Questions.ToList();
            }

            return questions;
        }

        public List<Answers> InitializeAnswersDB()
        {
            var answers = new List<Answers>();
            using (ApplicationContext db = new ApplicationContext(this.configuration))
            {
                answers = db.Answers.ToList();
            }

            return answers;
        }

        public List<User> GetUsers()
        {
            var users = new List<User>();
            using (ApplicationContext db = new ApplicationContext(this.configuration))
            {
                users = db.Users.ToList();
            }

            if (!users.Any())
            {
                this.InitializeData();
            }

            return users;
        }

    }
}
