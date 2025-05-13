using AutoMapper;
using CampBooking.Domain.DTOs;
using CampBooking.Domain.Entities;

namespace CampBooking.Shared.Helper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Camp, CampDetailsDTO>().ReverseMap();
            CreateMap<Camp, AddCampDTO>().ReverseMap();
            CreateMap<User, UserDetails>().ReverseMap();
            CreateMap<User, LoginUser>().ReverseMap();
            CreateMap<User, LoginUserDetails>().ReverseMap();
            CreateMap<BookingDetails, BookDetailsDTO>().ReverseMap();
            CreateMap<BookingDetails, AddBookDTO>().ReverseMap();
            CreateMap<AddBookDTO, CheckForFreeDTO>().ReverseMap();
            CreateMap<Rating, RatingDTO>().ReverseMap();
            CreateMap<Rating, AddRatingDTO>().ReverseMap();
        }
    }
}
