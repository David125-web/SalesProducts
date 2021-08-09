using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesProducts.Api.Responses;
using SalesProducts.Core.DTOs;
using SalesProducts.Core.Entities;
using SalesProducts.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SalesProducts.Api.Controllers
{
    //[Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        /// <summary>
        /// Return all post generators
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetUsers))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<UserDTo>>))]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ApiResponse<IEnumerable<PostDTo>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> GetUsers() 
        {
            var users = _userService.GetUsers();
            var usersDtos = _mapper.Map<IEnumerable<UserDTo>>(users);
            var response = new ApiResponse<IEnumerable<UserDTo>>(usersDtos);
            return Ok(response);
        }
       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUser(id);
            var userDto = _mapper.Map<UserDTo>(user);
            var response = new ApiResponse<UserDTo>(userDto);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Post(UserDTo userDTo)
        {
            var user = _mapper.Map<User>(userDTo);
            await _userService.InsertUser(user);
            var userDto = _mapper.Map<UserDTo>(user);

            var response = new ApiResponse<UserDTo>(userDto);

            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Put(int id, UserDTo userDTo)
        {
            var user = _mapper.Map<User>(userDTo);
            user.Id = id;
            var result = await _userService.UpdateUser(user);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.DeleteUser(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}