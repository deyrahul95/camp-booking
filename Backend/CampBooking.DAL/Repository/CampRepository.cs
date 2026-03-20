using CampBooking.DAL.DB;
using CampBooking.DAL.Interfaces;
using CampBooking.Domain.Camps.Entity;
using Microsoft.EntityFrameworkCore;

namespace CampBooking.DAL.Repository;

/// <summary>
/// Repository class for managing camp-related operations in the CampDB context.
/// Implements the ICampRepository interface.
/// </summary>
/// <param name="context">The CampDBContext instance used for database operations.</param>
public class CampRepository(CampDBContext context) : ICampRepository
{
    /// <summary>
    /// Retrieves all camps.
    /// </summary>
    /// <returns>A task that resolves to a list of <c>Camp</c> records.</returns>
    public async Task<IList<Camp>> GetCamps()
    {
        return await context.Camps.ToListAsync();
    }

    /// <summary>
    /// Retrieves detailed information for a specific camp.
    /// </summary>
    /// <param name="Id">The unique identifier of the camp.</param>
    /// <returns>A task that resolves to the matching <c>Camp</c> instance.</returns>
    public async Task<Camp?> ViewDetails(Guid Id)
    {
        return await context.Camps.FindAsync(Id);
    }

    /// <summary>
    /// Adds a new camp to the data store.
    /// </summary>
    /// <param name="camp">The camp entity to add.</param>
    /// <returns>A task that resolves to the <c>Guid</c> of the newly created camp.</returns>
    public async Task<Guid> AddCamp(Camp camp)
    {
        var newCamp = new Camp()
        {
            Id = camp.Id,
            Name = camp.Name,
            Price = camp.Price,
            Capacity = camp.Capacity,
            Description = camp.Description,
            ImageUrl = camp.ImageUrl,
        };

        await context.Camps.AddAsync(newCamp);
        return newCamp.Id;
    }

    /// <summary>
    /// Updates an existing camp.
    /// </summary>
    /// <param name="Id">The identifier of the camp to edit.</param>
    /// <param name="camp">The updated camp data.</param>
    /// <returns>A task that resolves to the updated <c>Camp</c> instance.</returns>
    public async Task<Camp?> EditCamp(Guid Id, Camp camp)
    {
        var existingCamp = await ViewDetails(Id);

        if (existingCamp == null)
        {
            return null;
        }

        existingCamp.Name = camp.Name;
        existingCamp.Price = camp.Price;
        existingCamp.Capacity = camp.Capacity;
        existingCamp.Description = camp.Description;
        existingCamp.ImageUrl = camp.ImageUrl;

        return existingCamp;
    }

    /// <summary>
    /// Deletes a camp.
    /// </summary>
    /// <param name="Id">The identifier of the camp to delete.</param>
    /// <returns>A task that resolves to <c>true</c> if deletion succeeded; otherwise <c>false</c>.</returns>
    public async Task<bool> DeleteCamp(Guid Id)
    {
        var camp = await ViewDetails(Id);

        if (camp == null)
        {
            return false;
        }

        context.Camps.Remove(camp);
        return true;
    }
}
