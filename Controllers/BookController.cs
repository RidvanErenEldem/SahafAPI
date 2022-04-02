using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SahafAPI.Domain.Models;
using SahafAPI.Domain.Services.Interfaces;
using SahafAPI.Extensions;
using SahafAPI.Resources;

namespace SahafAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly IBookService bookService;
        private readonly IMapper mapper;

        public BookController(IBookService bookService, IMapper mapper)
        {
            this.bookService = bookService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<List<BookResource>> GetAllAsync()
        {
            var books = await bookService.ListAsync();
            var resources = mapper.Map<List<Book>, List<BookResource>>(books);
            return  resources;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] SaveBookResource resource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var book = new Book();
            book.name = resource.name;
            book.bookSellerId = resource.bookSellerId;
            var result = await bookService.SaveAsync(book);

             if(!result.success)
                return BadRequest(result.message);

            var bookResource = mapper.Map<Book, BookResource>(result.book);
            return Ok(bookResource);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, SaveBookResource resource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var book = new Book();
            book.name = resource.name;
            book.bookSellerId = resource.bookSellerId;
            var result = await bookService.UpdateAsync(id, book);

            if(!result.success)
                return BadRequest(result.message);
            
            var bookResource = mapper.Map<Book, BookResource>(result.book);
            return Ok(bookResource);
        }
    }
}