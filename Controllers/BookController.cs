using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SahafAPI.Domain.Models;
using SahafAPI.Domain.Services.Interfaces;
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
    }
}