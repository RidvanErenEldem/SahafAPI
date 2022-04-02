using AutoMapper;
using SahafAPI.Domain.Models;
using SahafAPI.Resources;

namespace SahafAPI.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<BookSeller, BookSellerResource>();

            CreateMap<Book, BookResource>();
        }
    }
}