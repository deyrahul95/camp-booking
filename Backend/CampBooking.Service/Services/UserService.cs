using AutoMapper;
using CampBooking.DAL.DbModel;
using CampBooking.DAL.Interfaces;
using CampBooking.Domain.DTOs;
using CampBooking.Service.Interfaces;

namespace CampBooking.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public bool LoginUsingEmailAndPassword(LoginUser _user)
        {
            var mapped = _mapper.Map<User>(_user);
            var result = _uow.UserRepository.UserLogin(mapped);
            return result;
        }

        public LoginUserDetails GetUserDetails(string _email)
        {
            var result = _uow.UserRepository.FindUserByEmail(_email);
            if(result == null)
            {
                return null;
            }
            var mapped = _mapper.Map<LoginUserDetails>(result);
            return mapped;
        }
    }
}
