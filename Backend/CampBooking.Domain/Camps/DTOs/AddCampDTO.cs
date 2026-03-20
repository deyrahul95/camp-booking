namespace CampBooking.Domain.Camps.DTOs;

/// <summary>
/// Represents a data transfer object (DTO) for creating a new camping location or site.
/// </summary>
/// <param name="Name">The name of the camping location or site.</param>
/// <param name="Price">The base price for the camping location per night or per stay.</param>
/// <param name="Capacity">The maximum number of persons the camping site can accommodate.</param>
/// <param name="Description">A detailed description of the camping location, including amenities and features.</param>
/// <param name="ImageUrl">The URL or path to the primary image representing the camping site.</param>
public record AddCampDTO(string Name,
    int Price,
    int Capacity,
    string Description,
    string ImageUrl);
