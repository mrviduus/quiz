// <copyright file="OuizController.cs" company="Nilorn Group">
// Copyright (c) Nilorn Group. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class OuizController : ControllerBase
    {
        private readonly IQuizService quizService;

        /// <summary>
        /// Initializes a new instance of the <see cref="OuizController"/> class.
        /// </summary>
        /// <param name="quizService"> DI</param>
        public OuizController(IQuizService quizService)
        {
            this.quizService = quizService;
        }

        /// <summary>
        /// Получить рандомные номера вопросов
        /// </summary>
        /// <returns>ArrayRandomQuIds</returns>
        /// <response code="200">Возвращаем ответ</response>
        /// <response code="400">Если 0</response>
        [HttpGet("/api/quiz/QuestionsIds")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> QuestionsIds()
        {
            return await Task.Run(() => new JsonResult(this.quizService.RandomQuestionIds()));
        }

        /// <summary>
        /// Следующий вопрос
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// /Ouiz/next?questionId=1
        /// </remarks>
        /// <param name="questionId">id вопроса</param>
        /// <returns>Возвращает вопрос</returns>
        /// <response code="200">Возвращает Json</response>
        /// <response code="400">Если 0</response>
        [HttpGet("/api/quiz/next")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> NextQuestion(int questionId)
        {
            if (questionId == 0)
            {
                return this.BadRequest(new { message = "Не правильный запрос" });
            }

            return await Task.Run(() => new JsonResult(this.quizService.GetNextQuestion(questionId)));
        }

        /// <summary>
        /// Принять ответ
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// {'id':'1','Answer':"4"}
        /// </remarks>
        /// <param name="previousQuestionAnswer">{'Question':'2+2?','Answer':"4"}</param>
        /// <returns>Возвращает bool </returns>
        /// <response code="200">Возвращаем ответ</response>
        /// <response code="400">Если 0</response>
        [HttpGet("/api/quiz/Answer")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAnswer(string previousQuestionAnswer)
        {
            if (previousQuestionAnswer == null)
            {
                return this.BadRequest(new { message = "Не правильный запрос" });
            }

            return await Task.Run(() => new JsonResult(this.quizService.AnswerQuestion(previousQuestionAnswer)));
        }

        /// <summary>
        /// Возвращает % результат
        /// </summary>
        /// <param name="answers"> Пример [true, false, ...]</param>
        /// <returns> % правильных ответов</returns>
        /// <response code="200">Процент</response>
        /// <response code="400">Если 0</response>
        [HttpGet("/api/quiz/complete")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> CompleteQuiz(string answers)
        {
            try
            {
                bool[] arr = JsonConvert.DeserializeObject<bool[]>(answers);
                if (answers.Length == 0)
                {
                    return this.BadRequest(new { message = "Не правильный запрос" });
                }

                return await Task.Run(() => new JsonResult(this.quizService.CompleteQuiz(arr)));
            }
            catch (System.Exception ex)
            {
                return new JsonResult(ex.ToString());
            }
        }
    }
}
