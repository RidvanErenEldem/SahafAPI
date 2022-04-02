using SahafAPI.Domain.Models;
using SahafAPI.Domain.Repositories;
using SahafAPI.Domain.Services.Communication;
using SahafAPI.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
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

        public async Task<BookSellerResponse> DeleteAsync(int id)
        {
            var existingBookSeller = await bookSellerRepository.FindByIdAsync(id);

            if(existingBookSeller == null)
                return new BookSellerResponse("Book Seller Not Found 400");
            
            try
            {
                bookSellerRepository.Remove(existingBookSeller);
                await unitOfWork.ComplateAsync();

                return new BookSellerResponse(existingBookSeller);
            }
            catch (Exception ex)
            {
                return new BookSellerResponse($"An error occurred when deleting the book seller: {ex.Message}");
            }
        }

        public async Task<List<BookSeller>> ListAsync()
        {
            return await bookSellerRepository.ListAsync();
        }

        public async Task<BookSellerResponse> SaveAsync(BookSeller bookSeller)
        {
            try
            {
                await bookSellerRepository.AddAsync(bookSeller);
                await unitOfWork.ComplateAsync();

                return new BookSellerResponse(bookSeller);
            }
            catch (Exception ex)
            {
                return new BookSellerResponse($"An error occurred when saving the book seller: {ex.Message}");
            }
        }

        public async Task<BookSellerResponse> UpdateAsync(int id, BookSeller bookSeller)
        {
            var existingBookSeller = await bookSellerRepository.FindByIdAsync(id);

            if(existingBookSeller == null)
                return new BookSellerResponse("Book Seller Not Found 400");
            
            existingBookSeller.name = bookSeller.name;

            try
            {
                bookSellerRepository.Update(existingBookSeller);
                await unitOfWork.ComplateAsync();

                return new BookSellerResponse(existingBookSeller);
            }
            catch (Exception ex)
            {
                return new BookSellerResponse($"An error occurred when updating the book seller: {ex.Message}");
            }
        }
    }
}
