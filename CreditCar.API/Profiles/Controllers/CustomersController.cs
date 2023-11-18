using AutoMapper;
using CreditCar.API.Profiles.Domain.Models;
using CreditCar.API.Profiles.Domain.Services;
using CreditCar.API.Profiles.Resources;
using CreditCar.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CreditCar.API.Profiles.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _customerService;
    private readonly IMapper _mapper;
    
    public CustomersController(ICustomerService customerService, IMapper mapper)
    {
        _customerService = customerService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<CustomerResource>> GetAllAsync()
    {
        var users = await _customerService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerResource>>(users);

        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveCustomerResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var user = _mapper.Map<SaveCustomerResource, Customer>(resource);

        var result = await _customerService.SaveAsync(user);

        if (!result.Success)
            return BadRequest(result.Message);

        var userResource = _mapper.Map<Customer, CustomerResource>(result.Resource);

        return Ok(userResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCustomerResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var user = _mapper.Map<SaveCustomerResource, Customer>(resource);
        var result = await _customerService.UpdateAsync(id, user);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var userResource = _mapper.Map<Customer, CustomerResource>(result.Resource);
        
        return Ok(userResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _customerService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var userResource = _mapper.Map<Customer, CustomerResource>(result.Resource);
        
        return Ok(userResource);
    }
}