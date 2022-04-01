using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SahafAPI.Domain.Services.Interfaces;
using SahafAPI.Domain.Models;

namespace SahafAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookSellerController : Controller
    {
        private readonly IBookSellerService _bookSellerService;

        public BookSellerController(IBookSellerService bookSellerService)
        {
            _bookSellerService = bookSellerService;
        }

        [HttpGet]
        public async Task<BookSeller> GetAllAsync()
        {
            var bookSellers = await _bookSellerService.ListAsync();
            return bookSellers;
        }
    }
}