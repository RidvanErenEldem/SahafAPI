using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SahafAPI.Domain.Models;

namespace SahafAPI.Domain.Services.Communication
{
    public class SaveBookSellerResponse : BaseResponse
    {
        public BookSeller bookSeller { get; set; }
        
        private SaveBookSellerResponse(bool success, string message, BookSeller bookSeller) :base(success, message)
        {
            this.bookSeller = bookSeller;
        }

        public SaveBookSellerResponse(BookSeller bookSeller) : this(true, string.Empty, bookSeller)
        {}

        public SaveBookSellerResponse(string message) : this(false, message, null)
        {}
        
    }
}