using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SahafAPI.Domain.Models;
using SahafAPI.Domain.Services.Interfaces;
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

        public BookSellerController(IBookSellerService bookSellerService)
        {
            this.bookSellerService = bookSellerService;
        }

        [HttpGet]
        public async Task<List<BookSeller>> GetAllAsync()
        {
            var bookSellers = await bookSellerService.ListAsync();
            return bookSellers;
        }
    }
}
