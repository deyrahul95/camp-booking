namespace CampBooking.Domain.Camps.DTOs;

/// <summary>
/// Represents a data transfer object (DTO) for retrieving detailed information about a camping location.
/// </summary>
/// <param name="Id">The unique identifier of the camping location.</param>
/// <param name="Name">The name of the camping site or location.</param>
/// <param name="Price">The base price for the camping location per night or per stay.</param>
/// <param name="Capacity">The maximum number of persons the camping site can accommodate.</param>
/// <param name="Rating">The average rating of the camping location, typically on a scale of 1-5.</param>
/// <param name="Description">A detailed description of the camping location, including amenities and features.</param>
/// <param name="ImageUrl">The URL or path to the primary image representing the camping site.</param>
public record CampDetailsDTO(
    Guid Id,
    string Name,
    int Price,
    int Capacity,
    double Rating,
    string Description,
    string ImageUrl);
