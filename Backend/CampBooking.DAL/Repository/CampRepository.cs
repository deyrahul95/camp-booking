using CampBooking.DAL.DB;
using CampBooking.DAL.Interfaces;
using CampBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CampBooking.DAL.Repository
{
    public class CampRepository : ICampRepository
    {
        private readonly CampDBContext _context;

        public CampRepository(CampDBContext context)
        {
            _context = context;
        }
        public async Task<IList<Camp>> GetCamps()
        {
            return await _context.Camps.ToListAsync();
        }
        public async Task<Camp> ViewDetails(Guid Id)
        {
            return await _context.Camps.FindAsync(Id);
        }
        public async Task<Guid> AddCamp(Camp _camp)
        {
            var newCamp = new Camp()
            {
                Id = _camp.Id,
                Name = _camp.Name,
                Price = _camp.Price,
                Capacity = _camp.Capacity,
                Description = _camp.Description,
                ImageUrl = _camp.ImageUrl,
            };
            await _context.Camps.AddAsync(newCamp);
            return newCamp.Id;
        }

        public async Task<Camp> EditCamp(Guid Id, Camp _camp)
        {
            var camp = await ViewDetails(Id);
            if (camp == null) return null;
            camp.Name = _camp.Name;
            camp.Price = _camp.Price;
            camp.Capacity = _camp.Capacity;
            camp.Description = _camp.Description;
            camp.ImageUrl = _camp.ImageUrl;
            return camp;
        }

        public async Task<bool> DeleteCamp(Guid Id)
        {
            var camp = await ViewDetails(Id);
            if (camp == null) return false;
            _context.Camps.Remove(camp);
            return true;
        }
    }
}
