using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        }
    }
}