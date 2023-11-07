using AutoMapper;
using CampBooking.DAL.DbModel;
using CampBooking.DAL.Interfaces;
using CampBooking.Domain.DTOs;
using CampBooking.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CampBooking.Service.Services
{
    public class CampService : ICampService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CampService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IList<CampDetailsDTO>> GetAllCamps()
        {
            var list = await _uow.CampRepository.GetCamps();
            var mapped = _mapper.Map<IList<CampDetailsDTO>>(list);
            if(mapped == null)
            {
                throw new Exception($"Entity could not be mapped.");
            }
            return mapped;
        }
        public async Task<CampDetailsDTO> ViewCampDetails(Guid Id)
        {
            var result = await _uow.CampRepository.ViewDetails(Id);
            var mapped = _mapper.Map<CampDetailsDTO>(result);
            if (mapped == null)
            {
                throw new Exception($"Entity could not be mapped.");
            }
            return mapped;
        }

        public async Task<AddCampDTO> AddNewCamp(AddCampDTO campDetails)
        {
            var mapped = _mapper.Map<Camp>(campDetails);
            if (mapped == null)
            {
                throw new Exception($"Entity could not be mapped.");
            }
            mapped.Id = Guid.NewGuid();
            try
            {
                Guid id = await _uow.CampRepository.AddCamp(mapped);
                bool res = await _uow.SaveAsync();
                if(id != Guid.Empty && res)
                {
                    return campDetails;
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<CampDetailsDTO> EditCamp(Guid id,CampDetailsDTO _campDetails)
        {
            var mapped = _mapper.Map<Camp>(_campDetails);
            if (mapped == null)
            {
                throw new Exception($"Entity could not be mapped.");
            }
            try
            {
                var camp = await _uow.CampRepository.EditCamp(id,mapped);
                bool res = await _uow.SaveAsync();
                if (res && camp != null)
                {
                    return _mapper.Map<CampDetailsDTO>(camp);
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteCampDetails(Guid Id)
        {
            var result = await _uow.CampRepository.DeleteCamp(Id);
            var res = await _uow.SaveAsync();
            if (result == false && !res)
            {
                return false;
            }
            return result;
        }
    }
}
