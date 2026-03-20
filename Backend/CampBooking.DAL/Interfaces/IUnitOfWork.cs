namespace CampBooking.DAL.Interfaces;

/// <summary>
/// Interface for the Unit of Work pattern, managing repositories and saving changes.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Gets the repository for managing camps.
    /// </summary>
    ICampRepository CampRepository { get; }

    /// <summary>
    /// Gets the repository for managing users.
    /// </summary>
    IUserRepository UserRepository { get; }

    /// <summary>
    /// Gets the repository for managing booking details.
    /// </summary>
    IBookingDetailsRepo BookingDetailsRepository { get; }

    /// <summary>
    /// Gets the repository for managing ratings.
    /// </summary>
    IRatingRepo RatingRepository { get; }

    /// <summary>
    /// Saves all changes made in the unit of work asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation, containing a boolean indicating success or failure.</returns>
    Task<bool> SaveAsync();
}
