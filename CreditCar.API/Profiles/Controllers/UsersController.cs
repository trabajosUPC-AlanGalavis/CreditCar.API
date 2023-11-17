using AutoMapper;
using CreditCar.API.Profiles.Domain.Models;
using CreditCar.API.Profiles.Domain.Services;
using CreditCar.API.Profiles.Resources;
using CreditCar.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CreditCar.API.Profiles.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    
    public UsersController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<UserResource>> GetAllAsync()
    {
        var users = await _userService.ListAsync();
        var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);

        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveUserResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var user = _mapper.Map<SaveUserResource, User>(resource);

        var result = await _userService.SaveAsync(user);

        if (!result.Success)
            return BadRequest(result.Message);

        var userResource = _mapper.Map<User, UserResource>(result.Resource);

        return Ok(userResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUserResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var user = _mapper.Map<SaveUserResource, User>(resource);
        var result = await _userService.UpdateAsync(id, user);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var userResource = _mapper.Map<User, UserResource>(result.Resource);
        
        return Ok(userResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _userService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var userResource = _mapper.Map<User, UserResource>(result.Resource);
        
        return Ok(userResource);
    }
}