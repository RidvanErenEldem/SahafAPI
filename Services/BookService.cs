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
    }
}