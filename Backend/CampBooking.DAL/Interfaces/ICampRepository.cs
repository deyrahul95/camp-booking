using CampBooking.Domain.Camps.Entity;

namespace CampBooking.DAL.Interfaces;

/// <summary>
/// Repository interface for managing <c>Camp</c> entities.
/// </summary>
public interface ICampRepository
{
    /// <summary>
    /// Retrieves all camps.
    /// </summary>
    /// <returns>A task that resolves to a list of <c>Camp</c> records.</returns>
    Task<IList<Camp>> GetCamps();

    /// <summary>
    /// Retrieves detailed information for a specific camp.
    /// </summary>
    /// <param name="Id">The unique identifier of the camp.</param>
    /// <returns>A task that resolves to the matching <c>Camp</c> instance.</returns>
    Task<Camp?> ViewDetails(Guid Id);

    /// <summary>
    /// Adds a new camp to the data store.
    /// </summary>
    /// <param name="camp">The camp entity to add.</param>
    /// <returns>A task that resolves to the <c>Guid</c> of the newly created camp.</returns>
    Task<Guid> AddCamp(Camp camp);

    /// <summary>
    /// Updates an existing camp.
    /// </summary>
    /// <param name="Id">The identifier of the camp to edit.</param>
    /// <param name="camp">The updated camp data.</param>
    /// <returns>A task that resolves to the updated <c>Camp</c> instance.</returns>
    Task<Camp?> EditCamp(Guid Id, Camp camp);

    /// <summary>
    /// Deletes a camp.
    /// </summary>
    /// <param name="Id">The identifier of the camp to delete.</param>
    /// <returns>A task that resolves to <c>true</c> if deletion succeeded; otherwise <c>false</c>.</returns>
    Task<bool> DeleteCamp(Guid Id);
}