using LogisticsSystem.Infrastructure.Data.DataModels;
using LogiTrack.Core.Constants;
using LogiTrack.Core.Contracts;
using LogiTrack.Core.ViewModels.CashRegister;
using LogiTrack.Core.ViewModels.Invoice;
using LogiTrack.Infrastructure.Data.DataModels;
using LogiTrack.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace LogiTrack.Core.Services
{
    public class DeliveryStatisticsService : IDeliveryStatisticsService
    {
        private readonly IRepository repository;

        public DeliveryStatisticsService(IRepository repository)
        {
            this.repository = repository;
        }
        public async Task<(int domesticDeliveries, int internationalDeliveries)> GetDestinationTypesForDriverAsync(string username)
        {
            var domesticDeliveries = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>().Where(x => x.Driver.User.UserName == username && x.Offer.Request.Type == RequestTypeConstants.Domestic).CountAsync();
            var internationalDeliveries = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>().Where(x => x.Driver.User.UserName == username && x.Offer.Request.Type == RequestTypeConstants.International).CountAsync();
            return (domesticDeliveries, internationalDeliveries);
        }

        public async Task<(string[], List<int>)> GetDeliveriesCountForDriverAsync(string username)
        {
            var driver = await repository.AllReadonly<Driver>().FirstOrDefaultAsync(x => x.User.UserName == username);
            var deliveries = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>().Where(x => x.DriverId == driver.Id)
                .GroupBy(x => new { x.Offer.Request.CreatedAt.Month, x.Offer.Request.CreatedAt.Year })
                .Select(x => new
                {
                    Month = x.Key.Month,
                    Year = x.Key.Year,
                    Count = x.Count()
                }).OrderBy(x => x.Year).ThenBy(x => x.Month).ToListAsync();

            var data = Enumerable.Range(1, 12)
                   .Select(month => deliveries.FirstOrDefault(x => x.Month == month)?.Count ?? 0)
                   .ToList();
            var list = new[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            return (list, data);

        }

        public async Task<(double successRate, double averageDelay)> GetDeliveryTimesForDriverAsync(string username)
        {
            var deliveries = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>()
                .Include(x => x.Driver).ThenInclude(x => x.User).Include(x => x.Offer).ThenInclude(x => x.Request).ThenInclude(x => x.ClientCompany).ThenInclude(x => x.User).Where(x => x.Driver.User.UserName == username).ToListAsync();

            var totalDeliveries = deliveries.Count;
            if (totalDeliveries == 0)
            {
                return (0, 0);
            }

            var successfulDeliveries = deliveries.Count(x => x.DeliveryStep == 4 && (x.Offer.Request.ExpectedDeliveryDate >= x.ActualDeliveryDate));

            var successRate = (successfulDeliveries / (double)totalDeliveries) * 100;

            var delays = deliveries.Where(x => x.DeliveryStep == 4 && x.Offer.Request.ExpectedDeliveryDate < x.ActualDeliveryDate)
                .Select(x => (x.ActualDeliveryDate - x.Offer.Request.ExpectedDeliveryDate)?.TotalHours ?? 0)
                .ToList();

            var averageDelay = delays.Any() ? delays.Average() : 0;

            return (successRate, averageDelay);
        }
        public async Task<CashRegisterStatisticsViewModel?> GetCashRegisterStatisticsAsync()
        {
            var cashRegisters = await repository.AllReadonly<Infrastructure.Data.DataModels.CashRegister>().ToListAsync();
            var deliveriesWithAdditionalCosts = cashRegisters.GroupBy(x => x.DeliveryId).Count();
            var model = new CashRegisterStatisticsViewModel
            {
                TotalCashRegisters = cashRegisters.Count,
                TotalAdditionalCosts = cashRegisters.Sum(x => x.Amount),
                DeliveriesWithAdditionalCosts = deliveriesWithAdditionalCosts,
                DeliveriesWithAdditionalCostsRatio = (int)(await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().CountAsync() / deliveriesWithAdditionalCosts)
            };
            return model;
        }

        public async Task<Dictionary<string, int>> GetCashRegisterTypesDistributionAsync()
        {
            var model = await repository.AllReadonly<Infrastructure.Data.DataModels.CashRegister>().ToListAsync();
            var cashregisters = model.GroupBy(x => x.Type);

            var dictionary = cashregisters.ToDictionary(x => x.Key, x => x.Count());
            return dictionary;
        }

        public async Task<Dictionary<string, decimal>> GetGetTotalAdditionalCostsByDeliveryTypeAsync()
        {
            var deliveries = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Include(x => x.Offer).ThenInclude(x => x.Request).ToListAsync();
            var deliveriesByType = deliveries.GroupBy(x => x.Offer.Request.Type).ToList();
            var dictionary = deliveriesByType.ToDictionary(x => x.Key, x => x.Sum(x => x.TotalExpenses));
            return dictionary;
        }

        public async Task<(decimal, decimal)> GetCashRegistersAmountAsync()
        {
            var cashRegisters = await repository.AllReadonly<Infrastructure.Data.DataModels.CashRegister>().ToListAsync();

            var totalAmount = cashRegisters.OrderByDescending(x => x.Amount).Select(x => x.Amount).FirstOrDefault();
            var averageAmount = cashRegisters.Average(x => x.Amount);

            return (totalAmount, averageAmount);
        }

        public async Task<Dictionary<string, decimal>> GetTop10ClientsByOverdueAmountAsync()
        {
            var invoices = await repository.AllReadonly<Invoice>().Include(x => x.Delivery).ThenInclude(x => x.Offer)
                .ThenInclude(x => x.Request).ThenInclude(x => x.ClientCompany).Where(x => x.IsPaid == false).ToListAsync();
            var overdueInvoices = invoices.GroupBy(x => x.Delivery.Offer.Request.ClientCompany.Name);
            var dictionary = overdueInvoices.ToDictionary(x => x.Key, x => x.Sum(x => x.Delivery.Offer.FinalPrice));

            return dictionary;
        }
        public async Task<Dictionary<string, decimal>> GetLatePaymentsByClientAsync()
        {
            var invoices = await repository.AllReadonly<Invoice>().Include(x => x.Delivery).ThenInclude(x => x.Offer).ThenInclude(x => x.Request).ThenInclude(x => x.ClientCompany).ToListAsync();

            var overduePaymentsByClient = invoices.GroupBy(x => x.Delivery.Offer.Request.ClientCompany.Name)
                .ToDictionary(group => group.Key,
                               group => group.Sum(invoice => invoice.Delivery.Offer.FinalPrice));

            var top10LatePayments = overduePaymentsByClient.OrderByDescending(kvp => kvp.Value).Take(10).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            return top10LatePayments;
        }

        public async Task<InvoiceStatisticsViewModel?> GetInvoicesStatisticsAsync()
        {
            var averagePaymentTime = await repository.AllReadonly<Invoice>().Where(x => x.IsPaid == true && x.PaidDate.HasValue).ToListAsync();
            var avgTime = averagePaymentTime.Average(x => (x.PaidDate.Value - x.InvoiceDate).TotalDays);
            return new InvoiceStatisticsViewModel
            {
                AveragePaymentTime = averagePaymentTime.Average(x => (x.PaidDate.Value - x.InvoiceDate).TotalDays),
                OverdueAmount = await repository.AllReadonly<Invoice>().Where(x => x.IsPaid == false && x.InvoiceDate.AddDays(30) > DateTime.Now).SumAsync(x => x.Delivery.Offer.FinalPrice),
                PaidAmount = await repository.AllReadonly<Invoice>().Where(x => x.IsPaid == true).SumAsync(x => x.Delivery.Offer.FinalPrice),
                ClientsWithOverdueInvoices = await repository.AllReadonly<Invoice>().Where(x => !x.IsPaid && x.InvoiceDate.AddDays(30) > DateTime.Now).GroupBy(x => x.Delivery.Offer.Request.ClientCompanyId).CountAsync()
            };
        }


        public async Task<Dictionary<string, int>> GetInvoicesByStatusAsync()
        {
            var invoices = await repository.AllReadonly<Invoice>().ToListAsync();
            var invoicesByStatus = invoices.GroupBy(x => x.Status).ToDictionary(x => x.Key, x => x.Count());
            return invoicesByStatus;
        }

        public async Task<(int domesticDeliveries, int internationalDeliveries)> GetDestinationTypesForCompanyAsync(string username)
        {
            var domesticDeliveries = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>().Where(x => x.Offer.Request.ClientCompany.User.UserName == username && x.Offer.Request.Type == RequestTypeConstants.Domestic).CountAsync();
            var internationalDeliveries = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>().Where(x => x.Offer.Request.ClientCompany.User.UserName == username && x.Offer.Request.Type == RequestTypeConstants.International).CountAsync();
            return (domesticDeliveries, internationalDeliveries);
        }

        public async Task<(string[], List<int>)> GetDeliveriesCountForCompanyAsync(string username)
        {
            var company = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>().FirstOrDefaultAsync(x => x.User.UserName == username);
            var deliveries = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>().Where(x => x.Offer.Request.ClientCompanyId == company.Id)
                .GroupBy(x => new { x.Offer.Request.CreatedAt.Month, x.Offer.Request.CreatedAt.Year })
                .Select(x => new
                {
                    Month = x.Key.Month,
                    Year = x.Key.Year,
                    Count = x.Count()
                }).OrderBy(x => x.Year).ThenBy(x => x.Month).ToListAsync();

            var data = Enumerable.Range(1, 12)
                   .Select(month => deliveries.FirstOrDefault(x => x.Month == month)?.Count ?? 0)
                   .ToList();
            var list = new[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            return (list, data);
        }

        public async Task<(double successRate, double averageDelay)> GetDeliveryTimesForCompanyAsync(string username)
        {
            var deliveries = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>()
                .Include(x => x.Offer).ThenInclude(x => x.Request).ThenInclude(x => x.ClientCompany).ThenInclude(x => x.User).Where(x => x.Offer.Request.ClientCompany.User.UserName == username).ToListAsync();

            var totalDeliveries = deliveries.Count;
            if (totalDeliveries == 0)
            {
                return (0, 0);
            }

            var successfulDeliveries = deliveries.Count(x => x.DeliveryStep == 4 && (x.Offer.Request.ExpectedDeliveryDate >= x.ActualDeliveryDate));

            var successRate = (successfulDeliveries / (double)totalDeliveries) * 100;

            var delays = deliveries.Where(x => x.DeliveryStep == 4 && x.Offer.Request.ExpectedDeliveryDate < x.ActualDeliveryDate)
                .Select(x => (x.ActualDeliveryDate - x.Offer.Request.ExpectedDeliveryDate)?.TotalHours ?? 0)
                .ToList();

            var averageDelay = delays.Any() ? delays.Average() : 0;

            return (successRate, averageDelay);
        }

        public async Task<InvoiceStatisticsForClientViewModel?> GetInvoicesStatisticsForClientAsync(string username)
        {
            var invoices = await repository.AllReadonly<Invoice>().Include(x => x.Delivery).ThenInclude(x => x.Offer).ThenInclude(x => x.Request).ThenInclude(x => x.ClientCompany).Where(x => x.Delivery.Offer.Request.ClientCompany.User.UserName == username).ToListAsync();
            return new InvoiceStatisticsForClientViewModel()
            {
                PendingInvoices = invoices.Count(x => !x.IsPaid && x.InvoiceDate.AddDays(30) < DateTime.Now),
                PaidInvoices = invoices.Count(x => x.IsPaid),
                OverdueInvoices = invoices.Count(x => !x.IsPaid && x.InvoiceDate.AddDays(30) < DateTime.Now),
                OverdueAmount = invoices.Where(x => !x.IsPaid && x.InvoiceDate.AddDays(30) < DateTime.Now).Sum(x => x.Delivery.Offer.FinalPrice),
                PaidAmount = invoices.Where(x => x.IsPaid).Sum(x => x.Delivery.Offer.FinalPrice),
                PendingAmount = invoices.Where(x => !x.IsPaid && x.InvoiceDate.AddDays(30) < DateTime.Now).Sum(x => x.Delivery.Offer.FinalPrice),
                AveragePaymentTime = invoices.Where(x => x.IsPaid && x.PaidDate.HasValue).Average(x => (x.PaidDate.Value - x.InvoiceDate).TotalDays)
            };
        }

        public async Task<Dictionary<string, int>> GetInvoicesStatusDistributionAsync(string username)
        {
            return await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Invoice>().Where(x => x.Delivery.Offer.Request.ClientCompany.User.UserName == username)
                .GroupBy(x => x.Status)
                .Select(x => new
                {
                    Status = x.Key,
                    Count = x.Count()
                }).ToDictionaryAsync(x => x.Status, x => x.Count);
        }


        public async Task<decimal> GetTotalSpendingForCompanyAsync(string username)
        {
            return await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Invoice>().Where(x => x.Delivery.Offer.Request.ClientCompany.User.UserName == username).SumAsync(x => x.Delivery.Offer.FinalPrice);
        }
        public async Task<(int domesticDeliveries, int internationalDeliveries)> GetDestinationTypesAsync()
        {
            var domesticDeliveries = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>().Where(x => x.Offer.Request.Type == RequestTypeConstants.Domestic).CountAsync();
            var internationalDeliveries = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>().Where(x => x.Offer.Request.Type == RequestTypeConstants.International).CountAsync();
            return (domesticDeliveries, internationalDeliveries);
        }

        public async Task<(double successRate, double averageDelay)> GetDeliveryTimesAsync()
        {
            var deliveries = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>()
               .Include(x => x.Offer).ThenInclude(x => x.Request).ThenInclude(x => x.ClientCompany).ThenInclude(x => x.User).ToListAsync();

            var totalDeliveries = deliveries.Count;
            if (totalDeliveries == 0)
            {
                return (0, 0);
            }

            var successfulDeliveries = deliveries.Count(x => x.DeliveryStep == 4 && (x.Offer.Request.ExpectedDeliveryDate >= x.ActualDeliveryDate));

            var successRate = (successfulDeliveries / (double)totalDeliveries) * 100;

            var delays = deliveries.Where(x => x.DeliveryStep == 4 && x.Offer.Request.ExpectedDeliveryDate < x.ActualDeliveryDate)
                .Select(x => (x.ActualDeliveryDate - x.Offer.Request.ExpectedDeliveryDate)?.TotalHours ?? 0)
                .ToList();

            var averageDelay = delays.Any() ? delays.Average() : 0;

            return (successRate, averageDelay);
        }
        public async Task<(string[], List<int>)> GetDeliveryCountsForDriverAsync(int id)
        {
            var driver = await repository.AllReadonly<Driver>().FirstOrDefaultAsync(x => x.Id == id);
            var deliveries = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>().Where(x => x.DriverId == driver.Id)
                .GroupBy(x => new { x.Offer.Request.CreatedAt.Month, x.Offer.Request.CreatedAt.Year })
                .Select(x => new
                {
                    Month = x.Key.Month,
                    Year = x.Key.Year,
                    Count = x.Count()
                }).OrderBy(x => x.Year).ThenBy(x => x.Month).ToListAsync();

            var data = Enumerable.Range(1, 12)
                   .Select(month => deliveries.FirstOrDefault(x => x.Month == month)?.Count ?? 0)
                   .ToList();
            var list = new[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            return (list, data);
        }

        public async Task<(string[], List<int>)> GetDeliveryCountsAsync()
        {
            var deliveries = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>()
                .GroupBy(x => new { x.Offer.Request.CreatedAt.Month, x.Offer.Request.CreatedAt.Year })
                .Select(x => new
                {
                    Month = x.Key.Month,
                    Year = x.Key.Year,
                    Count = x.Count()
                }).OrderBy(x => x.Year).ThenBy(x => x.Month).ToListAsync();

            var data = Enumerable.Range(1, 12)
                   .Select(month => deliveries.FirstOrDefault(x => x.Month == month)?.Count ?? 0)
                   .ToList();
            var list = new[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            return (list, data);
        }
        public async Task<Dictionary<string, int>> GetPopularDeliveryCitiesAsync()
        {
            var deliveries = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>().Include(x => x.Offer).ThenInclude(x => x.Request).ThenInclude(x => x.DeliveryAddress).Include(x => x.Offer).ThenInclude(x => x.Request).ThenInclude(x => x.PickupAddress).ToListAsync();
            var dictionary = deliveries.GroupBy(x => x.Offer.Request.DeliveryAddress.City)
                .OrderByDescending(x => x.Count())
                .Take(5)
                .ToDictionary(x => x.Key, x => x.Count());
            return dictionary;
        }
        public async Task<(double, double)> GetCarbonEmissionsForCompanyAsync(string username, int id)
        {
            var specificDeliveryEmission = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>().Include(x => x.Offer).ThenInclude(x => x.Request).ThenInclude(x => x.ClientCompany).ThenInclude(x => x.User).Where(x => x.Offer.Request.ClientCompany.User.UserName == username && x.Id == id).Select(x => x.CarbonEmission).FirstOrDefaultAsync();
            var totalEmissions = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>().Include(x => x.Offer).ThenInclude(x => x.Request).ThenInclude(x => x.ClientCompany).ThenInclude(x => x.User).Where(x => x.Offer.Request.ClientCompany.User.UserName == username).SumAsync(x => x.CarbonEmission);
            return (specificDeliveryEmission, totalEmissions);
        }
        public async Task<Dictionary<int, int>> GetDeliveryRatingsDistributionAsync()
        {
            var ratings = await repository.AllReadonly<Rating>()
        .Select(x => x.RatingStars)
        .ToListAsync();

            var ratingDistribution = ratings
                .GroupBy(x => x)
                .ToDictionary(g => g.Key, g => g.Count());

            return ratingDistribution;
        }
    }
}
