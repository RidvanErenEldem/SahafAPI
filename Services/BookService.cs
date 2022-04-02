using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SahafAPI.Domain.Models;
using SahafAPI.Domain.Repositories;
using SahafAPI.Domain.Services.Communication;
using SahafAPI.Domain.Services.Interfaces;

namespace SahafAPI.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;
        private readonly IUnitOfWork unitOfWork;

        public BookService(IBookRepository bookRepository, IUnitOfWork unitOfWork)
        {
            this.bookRepository = bookRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<BookResponse> DeleteAsync(int id)
        {
            var existingBook = await bookRepository.FindByIdAsync(id);

            if(existingBook == null)
                return new BookResponse("Book Not Found Error Code: 400");
            
            try
            {
                bookRepository.Remove(existingBook);
                await unitOfWork.ComplateAsync();

                return new BookResponse(existingBook);
            }
            catch (Exception ex)
            {
                return new BookResponse($"An error occurred when deleting the book: {ex.Message}");
            }
        }

        public async Task<List<Book>> ListAsync()
        {
            return await bookRepository.ListAsync();
        }

        public async Task<BookResponse> SaveAsync(Book book)
        {
            try
            {
                await bookRepository.AddAsync(book);
                await unitOfWork.ComplateAsync();

                return new BookResponse(book);
            }
            catch (Exception ex)
            {
                return new BookResponse($"An error occurred when saving the book: {ex.Message}");
            }
        }

        public async Task<BookResponse> UpdateAsync(int id, Book book)
        {
            var existingBook = await bookRepository.FindByIdAsync(id);
            
            if(existingBook == null)
                return new BookResponse("Book Not Found 400");

            existingBook.name = book.name;
            existingBook.bookSellerId = book.bookSellerId;
            
            try
            {
                bookRepository.Update(existingBook);
                await unitOfWork.ComplateAsync();

                return new BookResponse(existingBook);
            }
            catch (Exception ex)
            {
                return new BookResponse($"An error occurred when updating the book: {ex.Message}");
            }

        }
    }
}