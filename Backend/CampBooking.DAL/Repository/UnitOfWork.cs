using CampBooking.DAL.DB;
using CampBooking.DAL.Interfaces;

namespace CampBooking.DAL.Repository;

/// <summary>
/// Unit of Work class for managing multiple repository operations in the CampDB context.
/// Implements the IUnitOfWork interface.
/// </summary>
/// <param name="context">The CampDBContext instance used for database operations.</param>
public class UnitOfWork(CampDBContext context) : IUnitOfWork
{
    /// <summary>
    /// Gets the repository for managing camps.
    /// </summary>
    public ICampRepository CampRepository => new CampRepository(context);

    /// <summary>
    /// Gets the repository for managing users.
    /// </summary>
    public IUserRepository UserRepository => new UserRepository(context);

    /// <summary>
    /// Gets the repository for managing booking details.
    /// </summary>
    public IBookingDetailsRepo BookingDetailsRepository => new BookingDetailsRepo(context);

    /// <summary>
    /// Gets the repository for managing ratings.
    /// </summary>
    public IRatingRepo RatingRepository => new RatingRepo(context);

    /// <summary>
    /// Saves all changes made in the unit of work asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation, containing a boolean indicating success or failure.</returns>
    public async Task<bool> SaveAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }
}