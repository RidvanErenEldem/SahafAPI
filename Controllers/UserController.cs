using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SahafAPI.Domain.Models;
using SahafAPI.Domain.Services.Interfaces;
using SahafAPI.Extensions;
using SahafAPI.Resources;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SahafAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<List<UserResource>> GetAllAsync()
        {
            var users = await userService.ListAsync();
            var resources = mapper.Map<List<User>, List<UserResource>>(users);

            return resources;
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] SaveUserResource resource)
        {
            if (!ModelState.IsValid)
		        return BadRequest(ModelState.GetErrorMessages());

            var user = new User();
            user.name = resource.name;
            if(resource.bookBorrowDate > resource.bookReturnDate)
            {
                DateTime? temp = resource.bookBorrowDate;
                resource.bookBorrowDate = resource.bookReturnDate;
                resource.bookReturnDate = temp;
            }
            else if(resource.bookBorrowDate == resource.bookReturnDate)
                return BadRequest("Borrow Date and Return Date cant be same");
            user.bookBorrowDate = resource.bookBorrowDate;
            user.bookReturnDate = resource.bookReturnDate;
            user.bookId = resource.bookId;
            var result = await userService.SaveAsync(user);

            if (!result.success)
		        return BadRequest(result.message);
            
            var userResource = mapper.Map<User, UserResource>(result.user);
            return Ok(userResource);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id,[FromBody] SaveUserResource resource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            
            var user = new User();
            user.name = resource.name;
            user.bookId = resource.bookId;
            if(resource.bookBorrowDate > resource.bookReturnDate)
            {
                DateTime? temp = resource.bookBorrowDate;
                resource.bookBorrowDate = resource.bookReturnDate;
                resource.bookReturnDate = temp;
            }
            else if(resource.bookBorrowDate == resource.bookReturnDate)
                return BadRequest("Borrow Date and Return Date cant be same");
            user.bookBorrowDate = resource.bookBorrowDate;
            user.bookReturnDate = resource.bookReturnDate;

            var result = await userService.UpdateAsync(id, user);

            if(!result.success)
                return BadRequest(result.message);
            
            var userResource = mapper.Map<User, UserResource>(result.user);
            return Ok(userResource);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await userService.DeleteAsync(id);

            if(!result.success)
                return BadRequest(result.message);
            
            var userResource = mapper.Map<User, UserResource>(result.user);
            return Ok(userResource);
        }

        [HttpPut("{id}/borrow")]
        public async Task<IActionResult> AddBookToUser(int id,[FromBody] UserAddBookResource resource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var user = new User();
            user.name = await userService.GetNameAsync(id);
            if(resource.bookBorrowDate > resource.bookReturnDate)
            {
                DateTime temp = resource.bookBorrowDate;
                resource.bookBorrowDate = resource.bookReturnDate;
                resource.bookReturnDate = temp;
            }
            else if(resource.bookBorrowDate == resource.bookReturnDate)
                return BadRequest("Borrow Date and Return Date cant be same");
            user.bookBorrowDate = resource.bookBorrowDate;
            user.bookReturnDate = resource.bookReturnDate;
            user.bookId = resource.bookId;

            var result = await userService.UpdateAsync(id,user);

            if(!result.success)
                return BadRequest(result.message);
            
            var userResource = new UserAddBookResource();
            userResource.bookId = resource.bookId;
            userResource.bookReturnDate = resource.bookReturnDate;
            userResource.bookBorrowDate = resource.bookBorrowDate;
            return Ok(userResource);
        }
    }
}