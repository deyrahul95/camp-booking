using CampBooking.Domain.Camps.DTOs;
using CampBooking.Domain.Camps.Entity;

namespace CampBooking.Shared.Mappers;

/// <summary>
/// Represents camp extensions mapper
/// </summary>
public static class CampMapper
{
    /// <summary>
    /// Mapped camp object to camp details dto object
    /// </summary>
    /// <param name="camp">The camp object</param>
    /// <returns>Return camp details dto object</returns>
    public static CampDetailsDTO ToDetailsDTO(this Camp camp) => new(
        Id: camp.Id,
        Name: camp.Name,
        Price: camp.Price,
        Capacity: camp.Capacity,
        Rating: camp.Rating,
        Description: camp.Description,
        ImageUrl: camp.ImageUrl);

    /// <summary>
    /// Mapped camp entity list to camp details dto object list
    /// </summary>
    /// <param name="camps">The camps entity list</param>
    /// <returns>Returns camp details dto list</returns>
    public static IList<CampDetailsDTO> ToDtoList(this IList<Camp> camps)
        => [.. camps.Select(c => c.ToDetailsDTO())];

    /// <summary>
    /// Mapped add camp dto object to camp entity
    /// </summary>
    /// <param name="campDto">The add camp dto object</param>
    /// <returns>Return camp entity</returns>
    public static Camp ToEntity(this AddCampDTO campDto) => new()
    {
        Id = Guid.NewGuid(),
        Name = campDto.Name,
        Description = campDto.Description,
        ImageUrl = campDto.ImageUrl,
        Capacity = campDto.Capacity,
        Rating = 0,
        Price = campDto.Price
    };

    /// <summary>
    /// Mapped camp details dto object to camp entity
    /// </summary>
    /// <param name="campDetails">The camp details dto object</param>
    /// <returns>Return camp entity</returns>
    public static Camp ToEntity(this CampDetailsDTO campDetails) => new()
    {
        Id = campDetails.Id,
        Name = campDetails.Name,
        Description = campDetails.Description,
        ImageUrl = campDetails.ImageUrl,
        Capacity = campDetails.Capacity,
        Rating = campDetails.Rating,
        Price = campDetails.Price,
    };
}
