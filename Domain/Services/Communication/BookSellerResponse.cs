using SahafAPI.Domain.Models;

namespace SahafAPI.Domain.Services.Communication
{
    public class BookSellerResponse : BaseResponse
    {
        public BookSeller bookSeller { get; set; }
        
        private BookSellerResponse(bool success, string message, BookSeller bookSeller) :base(success, message)
        {
            this.bookSeller = bookSeller;
        }

        public BookSellerResponse(BookSeller bookSeller) : this(true, string.Empty, bookSeller)
        {}

        public BookSellerResponse(string message) : this(false, message, null)
        {}
        
    }
}