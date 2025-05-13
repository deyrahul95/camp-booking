using AutoMapper;
using CampBooking.DAL.Interfaces;
using CampBooking.Domain.DTOs;
using CampBooking.Domain.Entities;
using CampBooking.Service.Interfaces;
using CampBooking.Shared.HelperFunctions;

namespace CampBooking.Service.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public BookService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IList<BookDetailsDTO>> GetAllBookingDetails()
        {
            var list = await _uow.BookingDetailsRepository.GetAllBookingDetails();
            var mapped = _mapper.Map<IList<BookDetailsDTO>>(list);
            if (mapped == null)
            {
                throw new Exception($"Entity could not be mapped.");
            }
            return mapped;
        }

        public async Task<BookDetailsDTO> ViewBookingDetails(Guid Id)
        {
            var result = await _uow.BookingDetailsRepository.GetBookingDetails(Id);
            var mapped = _mapper.Map<BookDetailsDTO>(result);
            if (mapped == null)
            {
                throw new Exception($"Entity could not be mapped.");
            }
            return mapped;
        }

        public async Task<string> AddNewBooking(AddBookDTO _booking)
        {
            var isFreeForBook = await FreeForBook(_mapper.Map<CheckForFreeDTO>(_booking));
            if(isFreeForBook == false)
            {
                return "Camp is Not Free For Book";
            }
            var mapped = _mapper.Map<BookingDetails>(_booking);
            if (mapped == null)
            {
                throw new Exception($"Entity could not be mapped.");
            }
            mapped.Id = Guid.NewGuid();
            mapped.ReferenceNumber = GetReferenceNumber.RandomNumber(mapped.Id,mapped.CellPhone,mapped.ZipCode);
            try
            {
                string refNum = await _uow.BookingDetailsRepository.AddBookingDetails(mapped);
                bool res = await _uow.SaveAsync();
                if (refNum != null && res)
                {
                    return refNum;
                }
                return "null";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteBooking(Guid _id)
        {
            var result = await _uow.BookingDetailsRepository.DeleteBookingDetails(_id);
            if(result == false)
            {
                return false;
            }
            return await _uow.SaveAsync();
        }

        public async Task<BookDetailsDTO> SearchBooking(string _refNum,string _phone,string _zipcode)
        {
            var results = await _uow.BookingDetailsRepository.GetAllBookingDetails();
            foreach (var item in results)
            {
                if(item.ReferenceNumber == _refNum && item.CellPhone == _phone && item.ZipCode == _zipcode)
                {
                    return _mapper.Map<BookDetailsDTO>(item);
                }
            }

            return null;
        }

        public async Task<bool> FreeForBook(CheckForFreeDTO _data)
        {
            if (DateTime.Parse(_data.CheckIn) > DateTime.Parse(_data.CheckOut))
            {
                return false;
            }
            var allDetails = await _uow.BookingDetailsRepository.GetAllBookingDetails();
            var result = true;
            foreach (var item in allDetails)
            {
                if(item.CampId == _data.CampId)
                {
                    if((DateTime.Parse(_data.CheckIn) >= DateTime.Parse(item.CheckIn)) && 
                        (DateTime.Parse(_data.CheckIn) < DateTime.Parse(item.CheckOut)))
                    {
                        result = false; break;
                    }

                    if ((DateTime.Parse(_data.CheckOut) > DateTime.Parse(item.CheckIn)) &&
                        (DateTime.Parse(_data.CheckOut) <= DateTime.Parse(item.CheckOut)))
                    {
                        result = false; break;
                    }

                    if ((DateTime.Parse(item.CheckOut) > DateTime.Parse(_data.CheckIn)) &&
                        (DateTime.Parse(item.CheckOut) < DateTime.Parse(_data.CheckOut)))
                    {
                        result = false; break;
                    }

                    if ((DateTime.Parse(item.CheckIn) > DateTime.Parse(_data.CheckIn)) &&
                        (DateTime.Parse(item.CheckIn) < DateTime.Parse(_data.CheckOut)))
                    {
                        result = false; break;
                    }
                }
            }
           
            return result;
        }

        public async Task<IList<CampDetailsDTO>> GetAllFreeCampsForBooking(SearchFreeCampsDTO _data)
        {
            var campList = await _uow.CampRepository.GetCamps();
            var result = new List<CampDetailsDTO>();

            foreach (var item in campList)
            {
                var data = new CheckForFreeDTO
                {
                    CampId = item.Id,
                    CheckOut = _data.CheckOut,
                    CheckIn = _data.CheckIn
                };
                var res = await FreeForBook(data);
                if (res == true)
                {
                    var mapped = _mapper.Map<CampDetailsDTO>(item);
                    if (mapped == null)
                    {
                        throw new Exception($"Entity could not be mapped.");
                    }
                    result.Add(mapped);
                }
            }

            return result;
        }
    }
}
