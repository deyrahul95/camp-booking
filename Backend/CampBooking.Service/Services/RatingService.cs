using AutoMapper;
using CampBooking.DAL.Interfaces;
using CampBooking.Domain.DTOs;
using CampBooking.Domain.Entities;
using CampBooking.Service.Interfaces;

namespace CampBooking.Service.Services
{
    public class RatingService : IRatingService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public RatingService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<int> GetRating(Guid _campId)
        {
            var list = await _uow.RatingRepository.GetAllRatings();
            int count = 0;
            double rating = 0;

            foreach (var item in list)
            {
                if(item.CampId == _campId)
                {
                    if(item.Star > 0)
                    {
                        rating += item.Star;
                        count++;
                    }
                }
            }

            if(count == 0 )
            {
                return 0;
            }
            
            return (int)Math.Round(rating/count);
        }

        public async Task<RatingDTO> SearchRating(SearchRatingDTO _data)
        {
            var list = await _uow.RatingRepository.GetAllRatings();

            foreach (var item in list)
            {
                if(item.CampId == _data.CampId && item.CellPhone == _data.CellPhone && item.ReferenceNumber == _data.ReferenceNumber)
                {
                    return _mapper.Map<RatingDTO>(item);
                }
            }

            return null;
        }

        public async Task<AddRatingDTO> AddNewRating(AddRatingDTO _rating)
        {
            var mapped = _mapper.Map<Rating>(_rating);
            if (mapped == null)
            {
                throw new Exception($"Entity could not be mapped.");
            }
            mapped.Id = Guid.NewGuid();
            try
            {
                Guid id = await _uow.RatingRepository.AddRating(mapped);
                var camp = await _uow.CampRepository.ViewDetails(_rating.CampId);
                camp.Rating = await GetRating(camp.Id); 
                bool res = await _uow.SaveAsync();
                if (id != Guid.Empty && res)
                {
                    return _rating;
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<RatingDTO> UpdateRating(Guid id, RatingDTO _rating)
        {
            var mapped = _mapper.Map<Rating>(_rating);
            if (mapped == null)
            {
                throw new Exception($"Entity could not be mapped.");
            }
            try
            {
                var rating = await _uow.RatingRepository.UpdateRating(id, mapped);
                var camp = await _uow.CampRepository.ViewDetails(_rating.CampId);
                camp.Rating = await GetRating(camp.Id);
                bool res = await _uow.SaveAsync();

                if (res && rating != null)
                {
                    return _mapper.Map<RatingDTO>(rating);
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IList<string>> GetComments(Guid _campId)
        {
            var list = await _uow.RatingRepository.GetAllRatings();
            var comments = new List<string>();
            foreach (var item in list)
            {   
                if(item.CampId == _campId)
                {
                    comments.Add(item.Comment);
                }
            }
            return comments;
        }
    }
}
