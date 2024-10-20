﻿
using LogiTrack.Core.ViewModels.Accountant;

namespace LogiTrack.Core.Contracts
{
    public interface IDeliveryService
    {
        Task AddCashRegisterForDeliveryAsync(int id, AddCashRegisterViewModel model);
        Task<bool> DeliveryWithIdExistsAsync(int deliveryId);
        Task<DeliveryIndexViewModel> GetDeliveryByReferenceNumberAsync(string searchTerm);
    }
}
