using CreditCar.API.Payments.Domain.Models;
using CreditCar.API.Payments.Domain.Repositories;
using CreditCar.API.Payments.Domain.Services;
using CreditCar.API.Payments.Domain.Services.Communication;
using CreditCar.API.Shared.Domain.Repositories;

namespace CreditCar.API.Payments.Services;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public PaymentService(IPaymentRepository paymentRepository, IUnitOfWork unitOfWork)
    {
        _paymentRepository = paymentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Payment>> ListAsync()
    {
        return await _paymentRepository.ListAsync();
    }

    public async Task<PaymentResponse> SaveAsync(Payment payment)
    {
        try
        {
            await _paymentRepository.AddAsync(payment);
            await _unitOfWork.CompleteAsync();
            return new PaymentResponse(payment);
        }
        catch(Exception e)
        {
            return new PaymentResponse($"An error occurred while saving the payment: {e.Message}");
        }
    }

    public async Task<PaymentResponse> UpdateAsync(int id, Payment payment)
    {
        var existingPayment = await _paymentRepository.FindByIdAsync(id);
        
        if (existingPayment == null)
            return new PaymentResponse("Payment not found.");
        
        existingPayment.Currency = payment.Currency;
        existingPayment.RateType = payment.RateType;
        existingPayment.SelectedRate = payment.SelectedRate;
        existingPayment.SelectedPeriod = payment.SelectedPeriod;
        existingPayment.RateValue = payment.RateValue;
        existingPayment.ClosingDate = payment.ClosingDate;
        existingPayment.TotalGracePeriod = payment.TotalGracePeriod;
        existingPayment.PartialGracePeriod = payment.PartialGracePeriod;
        existingPayment.InitialFee = payment.InitialFee;
        existingPayment.FinalFee = payment.FinalFee;
        existingPayment.CreditLifeInsurance = payment.CreditLifeInsurance;
        existingPayment.VehicleInsurance = payment.VehicleInsurance;
        existingPayment.CreateDate = payment.CreateDate;
        existingPayment.FormattedRateValue = payment.FormattedRateValue;
        existingPayment.Cok = payment.Cok;
        existingPayment.Van = payment.Van;
        existingPayment.Tea = payment.Tcea;
        existingPayment.Tcea = payment.Tcea;
        existingPayment.Tir = payment.Tir;
        
        try
        {
            _paymentRepository.Update(existingPayment);
            await _unitOfWork.CompleteAsync();
            return new PaymentResponse(existingPayment);
        }
        catch (Exception e)
        {
            return new PaymentResponse($"An error occurred while updating the payment: {e.Message}");
        }
    }

    public async Task<PaymentResponse> DeleteAsync(int id)
    {
        var existingPayment = await _paymentRepository.FindByIdAsync(id);
        
        if (existingPayment == null)
            return new PaymentResponse("Payment not found.");
        
        try
        {
            _paymentRepository.Remove(existingPayment);
            await _unitOfWork.CompleteAsync();
            return new PaymentResponse(existingPayment);
        }
        catch (Exception e)
        {
            return new PaymentResponse($"An error occurred while deleting the payment: {e.Message}");
        }
    }
    
    public async Task<IEnumerable<Payment>> ListByUserIdAsync(int userId)
    {
        return await _paymentRepository.FindByCustomerIdAsync(userId);
    }
    
    public async Task<IEnumerable<Payment>> ListByVehicleIdAsync(int vehicleId)
    {
        return await _paymentRepository.FindByVehicleIdAsync(vehicleId);
    }
    
    public async Task<IEnumerable<Payment>> ListByDealershipIdAsync(int dealershipId)
    {
        return await _paymentRepository.FindByDealershipIdAsync(dealershipId);
    }
}