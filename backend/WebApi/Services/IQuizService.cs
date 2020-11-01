// <copyright file="IQuizService.cs" company="Nilorn Group">
// Copyright (c) Nilorn Group. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public interface IQuizService
    {
        List<int> RandomQuestionIds();

     /// <summary>
     /// Возвращает вопрос с вариантами ответа в json
     /// </summary>
     /// <param name="questionId">Передает id вопроса</param>
     /// <returns>JSON c вопросом и вариантами ответа</returns>
        string GetNextQuestion(int questionId);

    /// <summary>
    /// Проверяет предыдущий ответ
    /// </summary>
    /// <param name="json">передается ответ</param>
    /// <returns>правильно или нет</returns>
        bool AnswerQuestion(string json);

     /// <summary>
    /// Вызывается в конце приложения, сколько правильных ответов
    /// </summary>
    /// <param name="answers">массив ответов bool</param>
    /// <returns>Возвращает %</returns>
        string CompleteQuiz(bool[] answers);
    }
}
