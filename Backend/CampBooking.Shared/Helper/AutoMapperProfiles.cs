using AutoMapper;
using CampBooking.Domain.Auth.DTOs;
using CampBooking.Domain.Bookings.DTOs;
using CampBooking.Domain.Bookings.Entity;
using CampBooking.Domain.Camps.DTOs;
using CampBooking.Domain.Camps.Entity;
using CampBooking.Domain.Ratings.DTOs;
using CampBooking.Domain.Ratings.Entity;
using CampBooking.Domain.Users.DTOs;
using CampBooking.Domain.Users.Entity;

namespace CampBooking.Shared.Helper;

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
