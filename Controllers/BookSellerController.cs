using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SahafAPI.Domain.Models;
using SahafAPI.Domain.Services.Interfaces;
using SahafAPI.Extensions;
using SahafAPI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahafAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookSellerController : Controller
    {
        private readonly IBookSellerService bookSellerService;
        private readonly IMapper mapper;

        public BookSellerController(IBookSellerService bookSellerService, IMapper mapper)
        {
            this.bookSellerService = bookSellerService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<List<BookSellerResource>> GetAllAsync()
        {
            var bookSellers = await bookSellerService.ListAsync();
            var resources = mapper.Map<List<BookSeller>, List<BookSellerResource>>(bookSellers);
            return  resources;
        }

        /*[HttpPost]
        public async Task<IActionResult> SaveAsync([FromBody] SaveBookSeller save)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
        }*/
    }
}
