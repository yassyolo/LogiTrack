
using LogiTrack.Core.ViewModels.Clients;
using LogiTrack.Core.ViewModels.Request;
using LogiTrack.Core.ViewModels.Vehicle;
using LogiTrack.Infrastructure.Data.DataModels;
using Microsoft.AspNetCore.Identity;

namespace LogiTrack.Core.Contracts
{
    public interface IClientsService
    {
        Task<IdentityUser> ApprovePendingRegistrationForCompanyWithIdAsync(int id);
        Task<bool> CompanyWithIdExistsAsync(int id);
        Task<ClientsDashboardViewModel?> GetClientCompanyDashboardAsync(string username);
        Task<List<CalendarEventViewModel>?> GetClientCompanyEventsAsync(string username);
        Task<ClientDetailsViewModel?> GetClientDetailsAsync(int id);
        Task<List<ClientsForClientregisterViewModel>> GetClientsForClientsRegisterAsync(bool? active, string? name, string? email, string? registrationNumber);
        Task<List<ClientsForClientregisterViewModel>> GetClientsForClientsRegisterBySearchTermAsync(string? searchTerm);
        Task<ContactDetailsViewModel?> GetCompanyContactDetailsAsync(string username);
        Task<CompanyDetailsViewModel?> GetCompanyDetailsAsync(string username);
        Task<(List<string>, List<int>)> GetDeliveryCountsForCompanyAsync(string username);
        Task<(int domesticDeliveries, int internationalDeliveries)> GetDeliveryTypesForCompanyAsync(string username);
        Task<string?> GetLogisticsCompanyDashboardAsync();
        Task<NewCompanyDetailsForLogisticsViewModel?> GetNewCompanyDetailsForLogisticsAsync(int id);
        Task<List<PendingRegistrationsViewModel>?> GetPendingRegistrationsAsync();
        Task<RequestViewModel?> GetRequestDetailsAsync(int id);
        Task<VehicleDetailsViewModel?> GetVehicleDetailsAsync(int id);
        Task<List<VehicleDetailsViewModel>> GetVehiclesAsync(bool refrigerated, string? registrationNumber = null, string? vehicleType = null, double? minWeightCapacity = null, double? maxWeightCapacity = null, double? minVolume = null, double? maxVolume = null);
        Task<List<VehicleDetailsViewModel>> GetVehiclesBySearchTermAsync(string? searchTerm);
        Task<bool> LogisticsUserWithUsernameExistsAsync(string username);
        Task RegisterClientCompanyAsync(RegisterViewModel model, IdentityUser user);
        Task<IdentityUser> RegisterUserAsync(RegisterViewModel model);
        Task RejectPendingRegistrationForCompanyWithIdAsync(int id);
        Task<bool> UserWithEmailExistsAsync(string email);
        Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber);
        Task<bool> VehicleWithIdExistsAsync(int id);
    }
}
