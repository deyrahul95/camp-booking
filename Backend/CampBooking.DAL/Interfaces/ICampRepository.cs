using CampBooking.DAL.DbModel;

namespace CampBooking.DAL.Interfaces
{
    public interface ICampRepository
    {
        Task<IList<Camp>> GetCamps();
        Task<Camp> ViewDetails(Guid Id);
        Task<Guid> AddCamp(Camp _camp);
        Task<Camp> EditCamp(Guid Id, Camp _camp);
        Task<bool> DeleteCamp(Guid Id);
        
    }
}
