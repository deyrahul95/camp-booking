using CampBooking.Domain.DTOs;

namespace CampBooking.Service.Interfaces
{
    public interface ICampService
    {
        Task<IList<CampDetailsDTO>> GetAllCamps();
        Task<CampDetailsDTO> ViewCampDetails(Guid Id);
        Task<AddCampDTO> AddNewCamp(AddCampDTO campDetails);
        Task<CampDetailsDTO> EditCamp(Guid id, CampDetailsDTO _campDetails);
        Task<bool> DeleteCampDetails(Guid Id);
    }
}
