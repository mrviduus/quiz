// <copyright file="QuizService.cs" company="Nilorn Group">
// Copyright (c) Nilorn Group. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApi.DataAccess;
using WebApi.Expansion;
using WebApi.Models;
using System;
using Microsoft.Extensions.Configuration;

namespace WebApi.Services
{
    public class QuizService : IQuizService
    {
        private readonly IConfiguration configuration;
        private List<Questions> questions = new List<Questions>();
        private List<Answers> variants = new List<Answers>();

        public QuizService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public List<int> RandomQuestionIds()
        {
            var initializeDb = new InitializeDB(this.configuration);
            var questionIds = initializeDb.InitializeQuestionsDB().Count;
            var RandomIds = new List<int>(Enumerable.Range(1, questionIds));
            RandomIds.Shuffle();

            return RandomIds;
        }

        public string GetNextQuestion(int questionId)
        {
            if (questionId != 0)
            {
                var inializeDb = new InitializeDB(this.configuration);
                this.questions = inializeDb.InitializeQuestionsDB();
                this.variants = inializeDb.InitializeAnswersDB();

                var question = this.questions.Where(x => x.Id == questionId).FirstOrDefault();
                var answers = this.variants.Where(x => x.QuestionsId == questionId)
                                    .Select(x => x.Answer).ToArray();
                return this.CreateJsonQuestion(question, answers);
            }

            return "Не верный id";
        }

        private string CreateJsonQuestion(Questions question, string[] answers)
        {
            JObject json =
                new JObject(
                    new JProperty("Id", question.Id),
                    new JProperty("Question", question.Name),
                    new JProperty("Variants", answers));

            return json.ToString();
        }

        public bool AnswerQuestion(string json)
        {
            try
            {
                var answer = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

                int question = 0;
                Int32.TryParse(answer["Question"], out question);
                string answers = answer["Answer"];

                var inializeDb = new InitializeDB(this.configuration);
                this.questions = inializeDb.InitializeQuestionsDB();
                this.variants = inializeDb.InitializeAnswersDB();

                var qId = this.questions.Where(x => x.Id == question)
                                   .Select(x => x.Id).FirstOrDefault();

                var qIdVariants = this.variants.Where(x => x.QuestionsId == qId)
                                .Select(x => new { Answer = x.Answer, Correct = x.Correct });

                var verdict = qIdVariants.Where(x => x.Answer == answers)
                                 .Select(x => x.Correct).FirstOrDefault();

                return verdict;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public string CompleteQuiz(bool[] answers)
        {
            int total = answers.Count();
            int rights = 0;
            answers.ToArray();

            for (int i = 0; i < answers.Length; i++)
            {
                if (answers[i])
                {
                    rights++;
                }
            }

            if (rights == 0)
            {
                return "Error, array is empty";
            }
            else
            {
                return ((rights * 100) / total).ToString();
            }
        }
    }
}
