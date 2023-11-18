using AutoMapper;
using CreditCar.API.Payments.Domain.Models;
using CreditCar.API.Payments.Domain.Services;
using CreditCar.API.Payments.Resources;
using Microsoft.AspNetCore.Mvc;

namespace CreditCar.API.Profiles.Controllers;

[ApiController]
[Route("/api/v1/users/{userId}/payments")]
public class UserPaymentsController : ControllerBase
{
    private readonly IPaymentService _paymentService;
    private readonly IMapper _mapper;
    
    public UserPaymentsController(IPaymentService paymentService, IMapper mapper)
    {
        _paymentService = paymentService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<PaymentResource>> GetAllByUserIdAsync(int userId)
    {
        var payments = await _paymentService.ListByUserIdAsync(userId);
        var resources = _mapper.Map<IEnumerable<Payment>, IEnumerable<PaymentResource>>(payments);

        return resources;
    }
}