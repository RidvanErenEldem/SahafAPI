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

        public async Task<SaveBookSellerResponse> UpdateAsync(int id, BookSeller bookSeller)
        {
            var existingBookSeller = await bookSellerRepository.FindByIdAsync(id);

            if(existingBookSeller == null)
                return new SaveBookSellerResponse("Book Seller Not Found 404");
            
            existingBookSeller.name = bookSeller.name;

            try
            {
                bookSellerRepository.Update(existingBookSeller);
                await unitOfWork.ComplateAsync();

                return new SaveBookSellerResponse(existingBookSeller);
            }
            catch (Exception ex)
            {
                return new SaveBookSellerResponse($"An error occurred when updating the category: {ex.Message}");
            }
        }
    }
}
