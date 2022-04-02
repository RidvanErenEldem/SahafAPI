using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SahafAPI.Domain.Models;

namespace SahafAPI.Domain.Services.Communication
{
    
    public class BookResponse : BaseResponse
    {
        public Book book {get; set; }
        private BookResponse(bool success, string message, Book book) :base(success, message)
        {
            this.book = book;
        }

        public BookResponse(Book book) : this(true, string.Empty, book)
        {}

        public BookResponse(string message) : this(false, message, null)
        {}
    }
}