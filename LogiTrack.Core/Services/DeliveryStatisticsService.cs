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
			var deliveryCounts = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>().Where(x => x.Driver.User.UserName == username)
		                         .GroupBy(x => x.Offer.Request.Type)
		                         .Select(g => new
		                         {
		                         	Type = g.Key,
			                        Count = g.Count()
		                         }).ToListAsync();

			int domesticDeliveries = deliveryCounts.FirstOrDefault(x => x.Type == RequestTypeConstants.Domestic)?.Count ?? 0;
			int internationalDeliveries = deliveryCounts.FirstOrDefault(x => x.Type == RequestTypeConstants.International)?.Count ?? 0;

			return (domesticDeliveries, internationalDeliveries);
		}

        public async Task<(string[], List<int>)> GetDeliveriesCountForDriverAsync(string username)
        {
            var deliveries = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>().Where(x => x.Driver.User.UserName == username)
                .GroupBy(x => new { x.Offer.Request.CreatedAt.Month, x.Offer.Request.CreatedAt.Year })
                .Select(x => new
                {
                    Month = x.Key.Month,
                    Year = x.Key.Year,
                    Count = x.Count()
                })
                .OrderBy(x => x.Year)
                .ThenBy(x => x.Month)
                .ToListAsync();

            var data = Enumerable.Range(1, 12).Select(month => deliveries.FirstOrDefault(x => x.Month == month)?.Count ?? 0).ToList();
            var list = new[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            return (list, data);
        }

        public async Task<(double successRate, double averageDelay)> GetDeliveryTimesForDriverAsync(string username)
        {
            var deliveries = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>()
                .Include(x => x.Driver).ThenInclude(x => x.User).Include(x => x.Offer).ThenInclude(x => x.Request).ThenInclude(x => x.ClientCompany).ThenInclude(x => x.User).Where(x => x.Driver.User.UserName == username).ToListAsync();

            if (deliveries.Count == 0)
            {
                return (0, 0);
            }

            var successfulDeliveries = deliveries.Count(x => x.DeliveryStep == 4 && (x.Offer.Request.ExpectedDeliveryDate >= x.ActualDeliveryDate));

            var successRate = (successfulDeliveries / (double)deliveries.Count) * 100;

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
            var query = await repository.AllReadonly<Infrastructure.Data.DataModels.CashRegister>().ToListAsync();
            var cashRegisters = query.GroupBy(x => x.Type);
            return cashRegisters.ToDictionary(x => x.Key, x => x.Count());
        }

        public async Task<Dictionary<string, decimal>> GetGetTotalAdditionalCostsByDeliveryTypeAsync()
        {
            var query = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Include(x => x.Offer).ThenInclude(x => x.Request).ToListAsync();
            var deliveries = query.GroupBy(x => x.Offer.Request.Type);
            return deliveries.ToDictionary(x => x.Key, x => x.Sum(x => x.TotalExpenses));

        }

        public async Task<(decimal, decimal)> GetCashRegistersAmountAsync()
        {
			var cashRegisterData = await repository.AllReadonly<Infrastructure.Data.DataModels.CashRegister>()
		                          .GroupBy(x => 1) 
		                          .Select(g => new
		                          {
		                          	MaxAmount = g.Max(x => x.Amount),
		                         	AverageAmount = g.Average(x => x.Amount)
		                          }).FirstOrDefaultAsync();

			if (cashRegisterData == null)
			{
				return (0, 0);
			}

			return (cashRegisterData.MaxAmount, cashRegisterData.AverageAmount);
		}

        public async Task<Dictionary<string, decimal>> GetTop10ClientsByOverdueAmountAsync()
        {
            var query = await repository.AllReadonly<Invoice>().Include(x => x.Delivery).ThenInclude(x => x.Offer).ThenInclude(x => x.Request).ThenInclude(x => x.ClientCompany).Where(x => x.IsPaid == false).ToListAsync();
            var invoices = query.GroupBy(x => x.Delivery.Offer.Request.ClientCompany.Name);
			return	invoices.ToDictionary(x => x.Key, x => x.Sum(x => x.Delivery.Offer.FinalPrice));
        }

        public async Task<Dictionary<string, decimal>> GetLatePaymentsByClientAsync()
        {
            var query = await repository.AllReadonly<Delivery>().Include(x => x.Invoice).Include(x => x.Offer).ThenInclude(x => x.Request).ThenInclude(x => x.ClientCompany).ToListAsync();
            var queryGrouping = query.GroupBy(x => x.Offer.Request.ClientCompany.Name);
            var invoices = queryGrouping.ToDictionary(x => x.Key, x => x.Sum(invoice => invoice.Offer.FinalPrice));

            var top10LatePayments = invoices.OrderByDescending(x => x.Value).Take(10).ToDictionary(x => x.Key, x => x.Value);

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
            var query = await repository.AllReadonly<Invoice>().ToListAsync();
            var invoices = query.GroupBy(x => x.Status);
             return invoices.ToDictionary(x => x.Key, x => x.Count());   
        }

        public async Task<(int domesticDeliveries, int internationalDeliveries)> GetDestinationTypesForCompanyAsync(string username)
        {
			var deliveryCounts = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>().Where(x => x.Offer.Request.ClientCompany.User.UserName == username)
								  .GroupBy(x => x.Offer.Request.Type)
								  .Select(g => new
								  {
									  Type = g.Key,
									  Count = g.Count()
								  }).ToListAsync();

			int domesticDeliveries = deliveryCounts.FirstOrDefault(x => x.Type == RequestTypeConstants.Domestic)?.Count ?? 0;
			int internationalDeliveries = deliveryCounts.FirstOrDefault(x => x.Type == RequestTypeConstants.International)?.Count ?? 0;

			return (domesticDeliveries, internationalDeliveries);
		}

        public async Task<(string[], List<int>)> GetDeliveriesCountForCompanyAsync(string username)
        {
            var deliveries = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>().Where(x => x.Offer.Request.ClientCompany.User.UserName == username)
                .GroupBy(x => new { x.Offer.Request.CreatedAt.Month, x.Offer.Request.CreatedAt.Year })
                .Select(x => new
                {
                    Month = x.Key.Month,
                    Year = x.Key.Year,
                    Count = x.Count()
                }).OrderBy(x => x.Year).ThenBy(x => x.Month).ToListAsync();

            var data = Enumerable.Range(1, 12).Select(month => deliveries.FirstOrDefault(x => x.Month == month)?.Count ?? 0).ToList();
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
            var invoices = await repository
                .AllReadonly<Invoice>()
                .Include(x => x.Delivery)
                .ThenInclude(x => x.Offer)
                .ThenInclude(x => x.Request)
                .ThenInclude(x => x.ClientCompany)
                .Where(x => x.Delivery.Offer.Request.ClientCompany.User.UserName == username)
                .ToListAsync();

            var paidInvoicesWithDates = invoices
                .Where(x => x.IsPaid && x.PaidDate.HasValue)
                .Select(x => (x.PaidDate.Value - x.InvoiceDate).TotalDays);

            return new InvoiceStatisticsForClientViewModel()
            {
                PendingInvoices = invoices.Count(x => !x.IsPaid && x.InvoiceDate.AddDays(30) >= DateTime.Now),
                PaidInvoices = invoices.Count(x => x.IsPaid),
                OverdueInvoices = invoices.Count(x => !x.IsPaid && x.InvoiceDate.AddDays(30) < DateTime.Now),
                OverdueAmount = invoices
                    .Where(x => !x.IsPaid && x.InvoiceDate.AddDays(30) < DateTime.Now)
                    .Sum(x => x.Delivery.Offer.FinalPrice),
                PaidAmount = invoices
                    .Where(x => x.IsPaid)
                    .Sum(x => x.Delivery.Offer.FinalPrice),
                PendingAmount = invoices
                    .Where(x => !x.IsPaid && x.InvoiceDate.AddDays(30) >= DateTime.Now)
                    .Sum(x => x.Delivery.Offer.FinalPrice),
                AveragePaymentTime = paidInvoicesWithDates.Any()
                    ? paidInvoicesWithDates.Average()
                    : 0
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
			var deliveryCounts = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>()
								 .GroupBy(x => x.Offer.Request.Type)
								 .Select(g => new
								 {
									 Type = g.Key,
									 Count = g.Count()
								 }).ToListAsync();

			int domesticDeliveries = deliveryCounts.FirstOrDefault(x => x.Type == RequestTypeConstants.Domestic)?.Count ?? 0;
			int internationalDeliveries = deliveryCounts.FirstOrDefault(x => x.Type == RequestTypeConstants.International)?.Count ?? 0;

			return (domesticDeliveries, internationalDeliveries);
		}

        public async Task<(double successRate, double averageDelay)> GetDeliveryTimesAsync()
        {
            var deliveries = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>()
               .Include(x => x.Offer).ThenInclude(x => x.Request).ToListAsync();

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
            var deliveries = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>().Where(x => x.DriverId == id)
                .GroupBy(x => new { x.Offer.Request.CreatedAt.Month, x.Offer.Request.CreatedAt.Year })
                .Select(x => new
                {
                    Month = x.Key.Month,
                    Year = x.Key.Year,
                    Count = x.Count()
                }).OrderBy(x => x.Year).ThenBy(x => x.Month).ToListAsync();

            var data = Enumerable.Range(1, 12).Select(month => deliveries.FirstOrDefault(x => x.Month == month)?.Count ?? 0).ToList();
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

            var data = Enumerable.Range(1, 12).Select(month => deliveries.FirstOrDefault(x => x.Month == month)?.Count ?? 0).ToList();
            var list = new[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            return (list, data);
        }

        public async Task<Dictionary<string, int>> GetPopularDeliveryCitiesAsync()
        {
            var query = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>().Include(x => x.Offer).ThenInclude(x => x.Request).ThenInclude(x => x.DeliveryAddress).Include(x => x.Offer).ThenInclude(x => x.Request).ThenInclude(x => x.PickupAddress).ToListAsync();
            var deliveries = query.GroupBy(x => x.Offer.Request.DeliveryAddress.City);
            return deliveries
                .OrderByDescending(x => x.Count())
                .Take(5)
                .ToDictionary(x => x.Key, x => x.Count());
        }

        public async Task<(double, double)> GetCarbonEmissionsForCompanyAsync(string username, int id)
        {
            var specificDeliveryEmission = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>().Include(x => x.Offer).ThenInclude(x => x.Request).ThenInclude(x => x.ClientCompany).ThenInclude(x => x.User).Where(x => x.Offer.Request.ClientCompany.User.UserName == username && x.Id == id).Select(x => x.CarbonEmission).FirstOrDefaultAsync();
            var totalEmissions = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>().Include(x => x.Offer).ThenInclude(x => x.Request).ThenInclude(x => x.ClientCompany).ThenInclude(x => x.User).Where(x => x.Offer.Request.ClientCompany.User.UserName == username).SumAsync(x => x.CarbonEmission);
            return (specificDeliveryEmission, totalEmissions);
        }

        public async Task<Dictionary<int, int>> GetDeliveryRatingsDistributionAsync()
        {
            var query = await repository.AllReadonly<Rating>().ToListAsync();
            return query.GroupBy(x => x.RatingStars).ToDictionary(x => x.Key, x => x.Count());
        }
    }
}
