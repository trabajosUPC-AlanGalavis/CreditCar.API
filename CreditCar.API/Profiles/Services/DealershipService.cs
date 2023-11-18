using CreditCar.API.Profiles.Domain.Models;
using CreditCar.API.Profiles.Domain.Repositories;
using CreditCar.API.Profiles.Domain.Services;
using CreditCar.API.Profiles.Domain.Services.Communication;
using CreditCar.API.Shared.Domain.Repositories;

namespace CreditCar.API.Profiles.Services;

public class DealershipService : IDealershipService
{
    private readonly IDealershipRepository _dealershipRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public DealershipService(IDealershipRepository dealershipRepository, IUnitOfWork unitOfWork)
    {
        _dealershipRepository = dealershipRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Dealership>> ListAsync()
    {
        return await _dealershipRepository.ListAsync();
    }

    public async Task<DealershipResponse> SaveAsync(Dealership dealership)
    {
        try
        {
            await _dealershipRepository.AddAsync(dealership);
            await _unitOfWork.CompleteAsync();
            return new DealershipResponse(dealership);
        }
        catch(Exception e)
        {
            return new DealershipResponse($"An error occurred while saving the dealership: {e.Message}");
        }
    }

    public async Task<DealershipResponse> UpdateAsync(int id, Dealership dealership)
    {
        var existingDealership = await _dealershipRepository.FindByIdAsync(id);
        
        if (existingDealership == null)
            return new DealershipResponse("Dealership not found.");
        
        existingDealership.Name = dealership.Name;

        try
        {
            _dealershipRepository.Update(existingDealership);
            await _unitOfWork.CompleteAsync();
            return new DealershipResponse(existingDealership);
        }
        catch (Exception e)
        {
            return new DealershipResponse($"An error occurred while updating the dealership: {e.Message}");
        }
    }

    public async Task<DealershipResponse> DeleteAsync(int id)
    {
        var existingDealership = await _dealershipRepository.FindByIdAsync(id);
        
        if (existingDealership == null)
            return new DealershipResponse("Dealership not found.");
        
        try
        {
            _dealershipRepository.Remove(existingDealership);
            await _unitOfWork.CompleteAsync();
            return new DealershipResponse(existingDealership);
        }
        catch (Exception e)
        {
            return new DealershipResponse($"An error occurred while deleting the dealership: {e.Message}");
        }
    }
}