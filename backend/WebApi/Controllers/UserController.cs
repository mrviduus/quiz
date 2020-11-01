// <copyright file="UserController.cs" company="Nilorn Group">
// Copyright (c) Nilorn Group. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApi.DataAccess;
using WebApi.Expansion;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IConfiguration configuration;

        public UserController(IUserService userService, IConfiguration configuration)
        {
            this.userService = userService;
            this.configuration = configuration;
        }

        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="userParam">Код доступа</param>
        /// <returns>токен</returns>
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User userParam)
        {
            var user = this.userService.Authenticate(Base64.Base64Encode(userParam.Code));

            if (user == null)
            {
                return this.BadRequest(new { message = "Access is denied, invalid code" });
            }

            return this.Ok(user);
        }

        /// <summary>
        /// Запрос пользователя
        /// </summary>
        /// <returns>возвращает имя пользователя</returns>
        [HttpGet("/api/abracadabra/test/start")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAll()
        {
            var users = await Task.Run(() => this.userService.GetUser());

            return this.Ok(users);
        }

        /// <summary>
        /// инициализация Бд
        /// </summary>
        /// <returns>200</returns>
        [AllowAnonymous]
        [HttpGet("/api/abracadabra/service/populatedb")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PopulateDb()
        {
            try
            {
                var populate = new InitializeDB(this.configuration);
                await Task.Run(() => populate.InitializeData());

                return this.Ok(new { message = "База добавлена" });
            }
            catch (System.Exception ex)
            {
                return this.BadRequest(new { message = ex.ToString() });
            }
        }
    }
}
