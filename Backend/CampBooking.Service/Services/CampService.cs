using AutoMapper;
using CampBooking.DAL.Interfaces;
using CampBooking.Domain.DTOs;
using CampBooking.Domain.Entities;
using CampBooking.Service.Interfaces;

namespace CampBooking.Service.Services;

/// <summary>
/// Service class for managing camp operations.
/// Implements the ICampService interface.
/// </summary>
/// <param name="uow">The unit of work instance used for database operations.</param>
/// <param name="mapper">The mapper instance used for mapping between entities and DTOs.</param>
public class CampService(IUnitOfWork uow, IMapper mapper) : ICampService
{
    /// <summary>
    /// Retrieves all camps.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation, containing a list of camp details DTOs.</returns>
    public async Task<IList<CampDetailsDTO>> GetAllCamps()
    {
        var list = await uow.CampRepository.GetCamps();
        var mapped = mapper.Map<IList<CampDetailsDTO>>(list) ?? throw new Exception($"Entity could not be mapped.");
        return mapped;
    }

    /// <summary>
    /// Retrieves specific camp details by its unique identifier.
    /// </summary>
    /// <param name="Id">The unique identifier of the camp.</param>
    /// <returns>A task that represents the asynchronous operation, containing the requested camp details DTO.</returns>
    public async Task<CampDetailsDTO> ViewCampDetails(Guid Id)
    {
        var result = await uow.CampRepository.ViewDetails(Id);
        var mapped = mapper.Map<CampDetailsDTO>(result) ?? throw new Exception($"Entity could not be mapped.");
        return mapped;
    }

    /// <summary>
    /// Adds a new camp with the provided details.
    /// </summary>
    /// <param name="campDetails">The camp details to be added.</param>
    /// <returns>A task that represents the asynchronous operation, containing the added camp details DTO.</returns>
    public async Task<AddCampDTO> AddNewCamp(AddCampDTO campDetails)
    {
        var mapped = mapper.Map<Camp>(campDetails) ?? throw new Exception($"Entity could not be mapped.");
        mapped.Id = Guid.NewGuid();

        try
        {
            Guid id = await uow.CampRepository.AddCamp(mapped);
            bool res = await uow.SaveAsync();

            if (id != Guid.Empty && res)
            {
                return campDetails;
            }

            return null;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    /// <summary>
    /// Edits an existing camp's details.
    /// </summary>
    /// <param name="id">The unique identifier of the camp to be edited.</param>
    /// <param name="campDetails">The updated camp details.</param>
    /// <returns>A task that represents the asynchronous operation, containing the updated camp details DTO.</returns>
    public async Task<CampDetailsDTO> EditCamp(Guid id, CampDetailsDTO campDetails)
    {
        var mapped = mapper.Map<Camp>(campDetails) ?? throw new Exception($"Entity could not be mapped.");

        try
        {
            var camp = await uow.CampRepository.EditCamp(id, mapped);
            bool res = await uow.SaveAsync();

            if (res && camp != null)
            {
                return mapper.Map<CampDetailsDTO>(camp);
            }

            return null;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    /// <summary>
    /// Deletes camp details by its unique identifier.
    /// </summary>
    /// <param name="Id">The unique identifier of the camp to be deleted.</param>
    /// <returns>A task that represents the asynchronous operation, containing a boolean indicating success or failure.</returns>
    public async Task<bool> DeleteCampDetails(Guid Id)
    {
        var result = await uow.CampRepository.DeleteCamp(Id);
        var res = await uow.SaveAsync();

        if (result == false && !res)
        {
            return false;
        }

        return result;
    }
}