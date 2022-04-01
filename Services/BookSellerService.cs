using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SahafAPI.Domain.Models;
using SahafAPI.Domain.Repositories;
using SahafAPI.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahafAPI.Services
{
    public class BookSellerService : IBookSellerService
    {
        private readonly IBookSellerRepository bookSellerRepository;

        public BookSellerService(IBookSellerRepository bookSellerRepository)
        {
            this.bookSellerRepository = bookSellerRepository;
        }
        public async Task<List<BookSeller>> ListAsync()
        {
            return await bookSellerRepository.ListAsync();
        }
    }
}
