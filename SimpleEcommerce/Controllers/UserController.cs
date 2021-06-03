using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleEcommerce.Dtos;
using SimpleEcommerce.Entities;
using SimpleEcommerce.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;

        public UserController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }




        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()

        {
            return _userService.Getusers();

            //  return new List<User> { };


        }


        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {


            using var hmac = new HMACSHA512();

            var user = new User
            {
                UserName = registerDto.UserName,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            UserDto userDto = new UserDto
            {
                UserName = user.UserName,
                Token = _tokenService.createToken(user)
            };
            return await Task.FromResult(userDto);



        }

        [HttpPost("login")]
        public async Task< ActionResult<UserDto>> Login (LoginDto loginDto)
        {
            User user = _userService.Login(loginDto.UserName);
            if (user == null)
            {
                return await Task.FromResult(Unauthorized("invalid username "));
            }else
            {

                using var hmac = new HMACSHA512(user.PasswordSalt);
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

                for(var i = 0; i < computeHash.Length; i++)
                {
                    if(computeHash[i] != user.PasswordHash[i])
                    {
                        return await Task.FromResult(Unauthorized("Invalid Password "));
                    }
                }

                UserDto userDto = new UserDto
                {
                    UserName = user.UserName,
                    Token = _tokenService.createToken(user)
                };
                return await Task.FromResult(userDto);


          

            }

        }
       
    }
}
