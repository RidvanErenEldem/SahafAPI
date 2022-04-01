using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SahafAPI.Domain.Models;
using SahafAPI.Domain.Repositories;
using SahafAPI.Domain.Services.Communication;
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
        private readonly IUnitOfWork unitOfWork;

        public BookSellerService(IBookSellerRepository bookSellerRepository, IUnitOfWork unitOfWork)
        {
            this.bookSellerRepository = bookSellerRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task<List<BookSeller>> ListAsync()
        {
            return await bookSellerRepository.ListAsync();
        }

        public async Task<SaveBookSellerResponse> SaveAsync(BookSeller bookSeller)
        {
            try
            {
                await bookSellerRepository.AddAsync(bookSeller);
                await unitOfWork.ComplateAsync();

                return new SaveBookSellerResponse(bookSeller);
            }
            catch (Exception ex)
            {
                return new SaveBookSellerResponse($"An error occurred when saving the book seller: {ex.Message}");
            }
        }
    }
}
