using CampBooking.Domain.Camps.DTOs;

namespace CampBooking.Service.Interfaces;

/// <summary>
/// Interface for managing camp-related services.
/// </summary>
public interface ICampService
{
    /// <summary>
    /// Retrieves all camps.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation, containing a list of camp details DTOs.</returns>
    Task<IList<CampDetailsDTO>> GetAllCamps();

    /// <summary>
    /// Retrieves specific camp details by its unique identifier.
    /// </summary>
    /// <param name="Id">The unique identifier of the camp.</param>
    /// <returns>A task that represents the asynchronous operation, containing the requested camp details DTO.</returns>
    Task<CampDetailsDTO> ViewCampDetails(Guid Id);

    /// <summary>
    /// Adds a new camp with the provided details.
    /// </summary>
    /// <param name="campDetails">The camp details to be added.</param>
    /// <returns>A task that represents the asynchronous operation, containing the added camp details DTO.</returns>
    Task<AddCampDTO> AddNewCamp(AddCampDTO campDetails);

    /// <summary>
    /// Edits an existing camp's details.
    /// </summary>
    /// <param name="id">The unique identifier of the camp to be edited.</param>
    /// <param name="campDetails">The updated camp details.</param>
    /// <returns>A task that represents the asynchronous operation, containing the updated camp details DTO.</returns>
    Task<CampDetailsDTO> EditCamp(Guid id, CampDetailsDTO campDetails);

    /// <summary>
    /// Deletes camp details by its unique identifier.
    /// </summary>
    /// <param name="Id">The unique identifier of the camp to be deleted.</param>
    /// <returns>A task that represents the asynchronous operation, containing a boolean indicating success or failure.</returns>
    Task<bool> DeleteCampDetails(Guid Id);
}