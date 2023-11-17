using CreditCar.API.Profiles.Domain.Models;
using CreditCar.API.Profiles.Domain.Repositories;
using CreditCar.API.Profiles.Domain.Services;
using CreditCar.API.Profiles.Domain.Services.Communication;
using CreditCar.API.Shared.Domain.Repositories;

namespace CreditCar.API.Profiles.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }


    public async Task<IEnumerable<User>> ListAsync()
    {
        return await _userRepository.ListAsync();
    }

    public async Task<UserResponse> SaveAsync(User user)
    {
        // Validate if email is already in use
        var existingEmail = await _userRepository.FindByEmailAsync(user.Email);
        if (existingEmail != null)
            return new UserResponse("Email already in use.");
        
        // Validate if dni is already in use
        var existingDni = await _userRepository.FindByDniAsync(user.Dni);
        if (existingDni != null)
            return new UserResponse("Dni already in use.");
        
        // Validate dni length
        if (user.Dni.ToString().Length != 8)
            return new UserResponse("Dni must be 8 digits.");
        
        // Validate zipCode length
        if (user.ZipCode.ToString().Length != 5)
            return new UserResponse("ZipCode must be 5 digits.");
        
        try
        {
            await _userRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();
            return new UserResponse(user);
        }
        catch(Exception e)
        {
            return new UserResponse($"An error occurred while saving the user: {e.Message}");
        }
    }

    public async Task<UserResponse> UpdateAsync(int id, User user)
    {
        var existingUser = await _userRepository.FindByIdAsync(id);
        
        if (existingUser == null)
            return new UserResponse("User not found.");
        
        existingUser.FirstName = user.FirstName;
        existingUser.LastName = user.LastName;
        existingUser.Email = user.Email;
        existingUser.Password = user.Password;
        existingUser.Dni = user.Dni;
        existingUser.ZipCode = user.ZipCode;

        try
        {
            _userRepository.Update(existingUser);
            await _unitOfWork.CompleteAsync();
            return new UserResponse(existingUser);
        }
        catch (Exception e)
        {
            return new UserResponse($"An error occurred while updating the user: {e.Message}");
        }
    }

    public async Task<UserResponse> DeleteAsync(int id)
    {
        var existingUser = await _userRepository.FindByIdAsync(id);
        
        if (existingUser == null)
            return new UserResponse("User not found.");
        
        try
        {
            _userRepository.Remove(existingUser);
            await _unitOfWork.CompleteAsync();
            return new UserResponse(existingUser);
        }
        catch (Exception e)
        {
            return new UserResponse($"An error occurred while deleting the user: {e.Message}");
        }
    }
}