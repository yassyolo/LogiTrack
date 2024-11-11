using LogiTrack.Core.ViewModels.Accountant;
using LogiTrack.Core.ViewModels.CashRegister;

namespace LogiTrack.Core.Contracts
{
    public interface ICashRegisterService
    {
        Task AddCashRegisterForDeliveryAsync(int id, AddCashRegisterViewModel model, Microsoft.AspNetCore.Http.IFormFile file);
        Task<List<CashRegisterIndexViewModel>> GetCashRegistersForDeliveryAsync(string? referenceNumber = null, DateTime? startDate = null, DateTime? endDate = null, string? type = null);
    }
}
