using Arduino.API.Dto.Request.Auth;
using Arduino.API.Dto.Response.Auth;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;

namespace Arduino.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_uow"></param>
        /// <param name="_mapper"></param>
        /// <param name="_baseLocalizer"></param>
        public AuthController(
            IUnitOfWork _uow,
            IMapper _mapper,
            IStringLocalizer<BaseResource> _baseLocalizer
            )
            : base(_uow, _mapper, _baseLocalizer)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("register")]
        [AllowAnonymous]
        public IActionResult Register([FromBody] RegisterRequestDTO dto)
        {
            RegisterResponse response = new RegisterResponse();

            var userExists = uow.User.FindByEmail(dto.Email);

            if (userExists.Success)
                return NotFound(response, userExists.Message);

            var user = mapper.Map<User>(dto);

            var userCreated = uow.User.Register(user);

            if (!userCreated.Success)
                return NotFound(response, userCreated.Message);

            if (!uow.Commit())
                return NotFound(response);

            response.Id = userCreated.Data;

            return Ok(response);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult LogIn([FromBody]LogInRequestDTO dto)
        {
            LogInResponse response = new LogInResponse();

            var userExists = uow.User.FindByEmail(dto.Email);

            if (!userExists.Success)
                return NotFound(response, userExists.Message);

            User user = userExists.Data;

            var isLogin = uow.User.LogIn(user, dto.Password);

            if (!isLogin.Success)
                return NotFound(response,isLogin.Message);

            response = mapper.Map<LogInResponse>(user);
            response.Token = isLogin.Message;
            response.ExpireDate = DateTime.Now.AddDays(1);

            return Ok(response);
        }
    }
}
