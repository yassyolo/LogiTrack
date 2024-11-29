using LogiTrack.Core.ViewModels.Clients;
using Microsoft.AspNetCore.Identity;

namespace LogiTrack.Core.Contracts
{
    public interface IClientsService
    {        
        Task<bool> CompanyWithIdExistsAsync(int id);
        Task<ClientDetailsViewModel?> GetClientDetailsAsync(int id);
        Task<List<ClientsForClientregisterViewModel>> GetClientsForClientsRegisterAsync(bool? active = null, string? name = null, string? email = null, string? registrationNumber = null, string? phoneNumber = null);
        Task<List<ClientsForClientregisterViewModel>> GetClientsForClientsRegisterBySearchTermAsync(string? searchTerm = null);
        Task<ContactDetailsViewModel?> GetCompanyContactDetailsAsync(string username);
        Task<CompanyDetailsViewModel?> GetCompanyDetailsAsync(string username);
        Task<int> GetCompanyIdByRegistrationNumberAsync(string registrationNumber);         
        Task<NewCompanyDetailsForLogisticsViewModel?> GetNewCompanyDetailsForLogisticsAsync(int id);
        Task<List<PendingRegistrationsViewModel>?> GetPendingRegistrationsAsync();              
        Task RejectPendingRegistrationForCompanyWithIdAsync(int id);       
    }
}
