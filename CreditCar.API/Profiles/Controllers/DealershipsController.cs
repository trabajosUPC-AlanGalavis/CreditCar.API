using AutoMapper;
using CreditCar.API.Profiles.Domain.Models;
using CreditCar.API.Profiles.Domain.Services;
using CreditCar.API.Profiles.Resources;
using CreditCar.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CreditCar.API.Profiles.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class DealershipsController : ControllerBase
{
    private readonly IDealershipService _dealershipService;
    private readonly IMapper _mapper;
    
    public DealershipsController(IDealershipService dealershipService, IMapper mapper)
    {
        _dealershipService = dealershipService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<DealershipResource>> GetAllAsync()
    {
        var dealerships = await _dealershipService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Dealership>, IEnumerable<DealershipResource>>(dealerships);

        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveDealershipResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var dealership = _mapper.Map<SaveDealershipResource, Dealership>(resource);

        var result = await _dealershipService.SaveAsync(dealership);

        if (!result.Success)
            return BadRequest(result.Message);

        var userResource = _mapper.Map<Dealership, DealershipResource>(result.Resource);

        return Ok(userResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveDealershipResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var dealership = _mapper.Map<SaveDealershipResource, Dealership>(resource);
        var result = await _dealershipService.UpdateAsync(id, dealership);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var userResource = _mapper.Map<Dealership, DealershipResource>(result.Resource);
        
        return Ok(userResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _dealershipService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var dealershipResource = _mapper.Map<Dealership, DealershipResource>(result.Resource);
        
        return Ok(dealershipResource);
    }
}