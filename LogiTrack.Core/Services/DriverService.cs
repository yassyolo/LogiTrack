using LogisticsSystem.Infrastructure.Data.DataModels;
using LogiTrack.Core.Constants;
using LogiTrack.Core.Contracts;
using LogiTrack.Core.ViewModels.Delivery;
using LogiTrack.Core.ViewModels.Driver;
using LogiTrack.Infrastructure.Data.DataModels;
using LogiTrack.Infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using LogiTrack.Core.ViewModels.Invoice;
using iText.Layout.Properties;
using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf.Canvas.Draw;

namespace LogiTrack.Core.Services
{
    public class DriverService : IDriverService
    {
        private readonly IRepository repository;
        private readonly IGoogleDriveService googleDriveService;

        public DriverService(IRepository repository, IGoogleDriveService googleDriveService)
        {
            this.repository = repository;
            this.googleDriveService = googleDriveService;
        }

        public async Task<bool> DriverHasDeliveryAsync(string username, int deliveryId)
        {
            return await repository.AllReadonly<Delivery>().AnyAsync(x => x.Id == deliveryId && x.Driver.User.UserName == username);
        }

        public async Task<bool> DriverWithUsernameExistsAsync(string username)
        {
            return await repository.AllReadonly<Driver>().AnyAsync(x => x.User.UserName == username);
        }

        public async Task<DriverViewModel?> GetDriverDetailsAsync(string username)
        {
            return await repository.AllReadonly<Driver>().Where(x => x.User.UserName == username)
                .Select(x => new DriverViewModel
                {
                    Name = x.Name,                   
                    Username = x.User.UserName,
                    Salary = x.Salary.ToString(),
                    Age = x.Age.ToString(),
                    YearOfExperience = x.YearOfExperience.ToString(),
                    MonthsOfExperience = x.MonthsOfExperience.ToString(),
                    Preferrences = x.Preferrences
                }).SingleOrDefaultAsync();
        }

        public async Task<LicenseViewModel?> GetDriversLicenseAsync(string username)
        {
            return await repository.AllReadonly<Driver>().Where(x => x.User.UserName == username)
                .Select(x => new LicenseViewModel
                {
                    LicenseNumber = x.LicenseNumber,
                    LicenseExpiryDate = x.LicenseExpiryDate,
                }).SingleOrDefaultAsync();
        }

        public async Task AddStatusForDeliveryAsync(int deliveryId, AddStatusViewModel model, string username, string address)
        {
            var driver = await repository.All<Infrastructure.Data.DataModels.Driver>().FirstOrDefaultAsync(x => x.User.UserName == username);
            var delivery = await repository.All<Infrastructure.Data.DataModels.Delivery>().Include(x => x.Offer).ThenInclude(x => x.Request).ThenInclude(x => x.ClientCompany).ThenInclude(x => x.User).FirstOrDefaultAsync(x => x.Id == deliveryId && x.DriverId == driver.Id);
            var deliveryTracking = new Infrastructure.Data.DataModels.DeliveryTracking
            {
                DeliveryId = deliveryId,
                DriverId = driver.Id,
                Notes = model.Notes,
                Timestamp = DateTime.Now,
                StatusUpdate = model.StatusUpdate,
                Latitude = model.Latitude.Value,
                Longitude = model.Longitude.Value,
                Address = address
            };

            var calendarEvent = new Infrastructure.Data.DataModels.CalendarEvent
            {
                EventType = model.StatusUpdate,
                Date = DateTime.Now,
                UserId = delivery.Offer.Request.ClientCompany.User.Id,
                Title = $"Status for {delivery.ReferenceNumber}: {model.StatusUpdate}"
            };
            switch (model.StatusUpdate)
            {
                case DeliveryTrackingStatusConstants.Collected:
                    delivery.DeliveryStep = 2;
                    break;
                case DeliveryTrackingStatusConstants.InTransit:
                    delivery.DeliveryStep = 3;
                    break;
                case DeliveryTrackingStatusConstants.Delivered:
                    delivery.DeliveryStep = 4;
                    await GenerateInvoiceAsync(delivery);
                   
                    var notification = new Notification
                    {
                        Message = $"Delivery {delivery.ReferenceNumber} has been delivered. Check it out now!",
                        Title = "Delivery Delivered",
                        UserId = delivery.Offer.Request.ClientCompany.User.Id,
                        Date = DateTime.Now
                    };
                    await repository.AddAsync(notification);
                    var logisticsUser = await repository.AllReadonly<IdentityUser>().FirstOrDefaultAsync(x => x.UserName == "logistics");
                    var notificationForLogisticsUser = new Notification
                    {
                        Title = "Rating",
                        Message = $"Delivery {delivery.ReferenceNumber} has been delivered. Check it out now!",
                        UserId = logisticsUser.Id,
                        IsRead = false
                    };
                    var calendarEventForLogistics = new Infrastructure.Data.DataModels.CalendarEvent
                    {
                        EventType = model.StatusUpdate,
                        Date = DateTime.Now,
                        UserId = logisticsUser.Id,
                        Title = $"Status for {delivery.ReferenceNumber}: {model.StatusUpdate}"
                    };
                    await repository.AddAsync(notificationForLogisticsUser);
                    var speditorUser = await repository.AllReadonly<IdentityUser>().FirstOrDefaultAsync(x => x.UserName == "speditor");
                    var notificationForSpeditorUser = new Notification
                    {
                        Title = "Rating",
                        Message = $"Delivery {delivery.ReferenceNumber} has been delivered. Check it out now!",
                        UserId = logisticsUser.Id,
                        IsRead = false
                    };
                    await repository.AddAsync(notificationForSpeditorUser);
                    break;
            }
            await repository.AddAsync(calendarEvent);
            await repository.AddAsync(deliveryTracking);
            await repository.SaveChangesAsync();
        }

        public async Task GenerateInvoiceAsync(Delivery delivery)
        {
            var offer = await repository.AllReadonly<Offer>()
                .Include(o => o.Request)
                .FirstOrDefaultAsync(o => o.Id == delivery.OfferId);
            var invoice = new Invoice()
            {
                Status = StatusConstants.Pending,
                DeliveryId = delivery.Id,
                Description = "Invoice for delivery " + delivery.ReferenceNumber,
                InvoiceDate = DateTime.Now,
                InvoiceNumber = $"INV{Guid.NewGuid().ToString()}",
            };

            var invoiceToFile = new InvoiceCreationViewModel
            {
                InvoiceNumber = invoice.InvoiceNumber,
                ClientCompanyName = offer.Request.ClientCompany.Name,
                DeliveryReferenceNumber = delivery.ReferenceNumber,
                DeliveryDate = delivery.ActualDeliveryDate ?? DateTime.Now,
                DueDate = delivery.ActualDeliveryDate ?? DateTime.Now.AddDays(30),
                Price = offer.FinalPrice,
                PickupAddress = $"{offer.Request.PickupAddress.Street}, {offer.Request.PickupAddress.City}, {offer.Request.PickupAddress.County}",
                DeliveryAddress = $"{offer.Request.DeliveryAddress.Street}, {offer.Request.DeliveryAddress.City}, {offer.Request.DeliveryAddress.County}"
            };

            var fileName = $"{invoice.InvoiceNumber}.pdf";
            var filePath = Path.Combine("Invoices", fileName);

            using (var stream = new MemoryStream())
            {
                var writer = new PdfWriter(filePath);
                var pdf = new PdfDocument(writer);
                iText.Layout.Document document = new iText.Layout.Document(pdf);

                PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                document.Add(new Paragraph("Invoice")
                    .SetFont(boldFont)
                    .SetFontSize(24)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetMarginBottom(20)); 

                document.Add(new Paragraph($"Invoice Number: {invoiceToFile.InvoiceNumber}")
                    .SetFontSize(12)
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetMarginBottom(5)); 

                document.Add(new Paragraph($"Client: {invoiceToFile.ClientCompanyName}")
                    .SetFontSize(12)
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetMarginBottom(5));

                document.Add(new Paragraph($"Delivery Reference: {invoiceToFile.DeliveryReferenceNumber}")
                    .SetFontSize(12)
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetMarginBottom(5));

                document.Add(new Paragraph($"Delivery Date: {invoiceToFile.DeliveryDate:yyyy-MM-dd}")
                    .SetFontSize(12)
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetMarginBottom(5));

                document.Add(new Paragraph($"Due Date: {invoiceToFile.DueDate:yyyy-MM-dd}")
                    .SetFontSize(12)
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetMarginBottom(5));

                document.Add(new Paragraph($"Price: {invoiceToFile.Price:C}")
                    .SetFontSize(12)
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetMarginBottom(5)
                    .SetFontColor(ColorConstants.RED)); 

                document.Add(new Paragraph($"Pickup Address: {invoiceToFile.PickupAddress}")
                    .SetFontSize(12)
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetMarginBottom(5));

                document.Add(new Paragraph($"Delivery Address: {invoiceToFile.DeliveryAddress}")
                    .SetFontSize(12)
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetMarginBottom(20)); 

                document.Add(new Paragraph("Thank you for your business!")
                    .SetFontSize(14)
                    .SetFont(boldFont)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontColor(ColorConstants.BLUE)
                    .SetMarginTop(30));

                document.Add(new LineSeparator(new SolidLine()).SetMarginTop(20));

                document.Close();
            }

            var googleDriveFileId = await googleDriveService.UploadFileAsync(filePath, "application/pdf");

            //var fileId = 
        }

        public async Task<List<DriverForLogisticsViewModel>> GetDriversAsync(string? name = null, string? licenseNumber = null, bool? isAvailable = null, decimal? minSalary = null, decimal? maxSalary = null)
        {
            var query = repository.AllReadonly<Infrastructure.Data.DataModels.Driver>().Include(x => x.User).AsQueryable();
            if(minSalary != null)
            {
                query = query.Where(x => x.Salary >= minSalary);
            }
            if (maxSalary != null)
            {
                query = query.Where(x => x.Salary <= maxSalary);
            }
            if (name != null)
            {
                query = query.Where(x => x.Name.Contains(name));
            }
            if (licenseNumber != null)
            {
                query = query.Where(x => x.LicenseNumber.Contains(licenseNumber));
            }
            if (isAvailable != null)
            {
                query = query.Where(x => x.IsAvailable == isAvailable);
            }

            var drivers = await query.ToListAsync();
            return drivers.Select(x => new DriverForLogisticsViewModel
            {
                Id = x.Id,
                Name = x.Name,
                LicenseNumber = x.LicenseNumber,
                Phone = x.User.PhoneNumber,
                LicenseExpiryDate = x.LicenseExpiryDate.ToString(),               
                Username = x.User.UserName,
                Salary = x.Salary.ToString(),
                Age = x.Age.ToString(),
                YearOfExperience = x.YearOfExperience.ToString(),
                MonthsOfExperience = x.MonthsOfExperience.ToString(),
                IsAvailable = x.IsAvailable,
            }).ToList();   
        }

        public async Task<List<DriverForLogisticsViewModel>> GetDriversBySearchtermAsync(string? searchTerm)
        {
            var query = repository.AllReadonly<Infrastructure.Data.DataModels.Driver>().Include(x => x.User).AsQueryable();
            if (searchTerm != null)
            {
                var searchTermToLower = searchTerm.ToLower();
                query = query.Where(x => x.Name.ToLower().Contains(searchTermToLower) ||
                    x.LicenseNumber.ToLower().Contains(searchTermToLower) ||
                    x.Salary.ToString().Contains(searchTermToLower) ||
                    x.User.UserName.ToLower().Contains(searchTermToLower) ||
                    x.User.PhoneNumber.Contains(searchTermToLower) ||
                    x.Preferrences.ToLower().Contains(searchTermToLower) ||
                    x.Age.ToString().Contains(searchTerm) ||
                    x.YearOfExperience.ToString().Contains(searchTerm) ||
                    x.MonthsOfExperience.ToString().Contains(searchTerm) ||
                    x.IsAvailable.ToString().Contains(searchTerm));

                var drivers = await query.ToListAsync();

                return drivers.Select(x => new DriverForLogisticsViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    LicenseNumber = x.LicenseNumber,
                    LicenseExpiryDate = x.LicenseExpiryDate.ToString(),
                    Phone = x.User.PhoneNumber,
                    Username = x.User.UserName,
                    Salary = x.Salary.ToString(),
                    Age = x.Age.ToString(),
                    YearOfExperience = x.YearOfExperience.ToString(),
                    MonthsOfExperience = x.MonthsOfExperience.ToString(),
                    IsAvailable = x.IsAvailable,
                }).ToList();
            }
            return new List<DriverForLogisticsViewModel>();
        }

        public async Task<bool> DriverWithIdExistsAsync(int id)
        {
            return await repository.AllReadonly<Infrastructure.Data.DataModels.Driver>().AnyAsync(x => x.Id == id);
        }

        public async Task<DriverForLogisticsViewModel?> GetDriverDetailsForLogisticsAsync(int id)
        {
            var deliveriesForDriver = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Include(x => x.Offer).ThenInclude(x => x.Request).Where(x => x.DriverId == id).ToListAsync();
            var model = await repository.AllReadonly<Infrastructure.Data.DataModels.Driver>().Include(x => x.User).Where(x => x.Id == id)
                .Select(x => new DriverForLogisticsViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    DaysTillExpiry = (x.LicenseExpiryDate - DateTime.Now).Days.ToString(),
                    Phone = x.User.PhoneNumber,
                    LicenseNumber = x.LicenseNumber,
                    LicenseExpiryDate = x.LicenseExpiryDate.ToString(),                 
                    Username = x.User.UserName,
                    Salary = x.Salary.ToString(),
                    Age = x.Age.ToString(),
                    YearOfExperience = x.YearOfExperience.ToString(),
                    MonthsOfExperience = x.MonthsOfExperience.ToString(),
                    IsAvailable = x.IsAvailable,
                    Preferrences = x.Preferrences,
                    DeliveriesCount = deliveriesForDriver.Count,                 
                    PhoneNumber = x.User.PhoneNumber,                     
                }).FirstOrDefaultAsync();

            var cashRegisters = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.CashRegister>().Where(x => x.Delivery.DriverId == id).ToListAsync();
            model.AdditionalCost = cashRegisters.Sum(x => x.Amount);
            model.AverageAdditionalCost = cashRegisters.Any() ? cashRegisters.Average(x => x.Amount): 0; 
            model.AverageDeliveryTime = deliveriesForDriver.Any(x => x.ActualDeliveryDate.HasValue) ? deliveriesForDriver.Average(x => (x.ActualDeliveryDate - x.Offer.Request.ExpectedDeliveryDate).Value.TotalHours).ToString("F2"): "0"; 
            model.SuccessfulDeliveriesCount = deliveriesForDriver.Count(x => x.DeliveryStep == 4 && x.Offer.Request.ExpectedDeliveryDate >= x.ActualDeliveryDate);
            model.UndeliveryDeliveriesCount = deliveriesForDriver.Count(x => x.DeliveryStep < 4);
            model.AverageDeliveryDistance = deliveriesForDriver.Any() ? deliveriesForDriver.Average(x => x.Offer.Request.Kilometers).ToString() : "0";
            model.KiloMetersDriven = deliveriesForDriver.Sum(x => x.Offer.Request.Kilometers);

            model.Deliveries = deliveriesForDriver.Select(x => new DeliveryForClientsDeliveriesViewModel
            {
                Id = x.Id,
                ReferenceNumber = x.ReferenceNumber,
                DeliveryAddress = $"{x.Offer.Request.DeliveryAddress.Street}, {x.Offer.Request.DeliveryAddress.City}, {x.Offer.Request.DeliveryAddress.County}",
                PickupAddress = $"{x.Offer.Request.PickupAddress.Street}, {x.Offer.Request.PickupAddress.City}, {x.Offer.Request.PickupAddress.County}",
                ExpectedDeliveryDate = x.Offer.Request.ExpectedDeliveryDate.ToString("dd-MM-yyyy"),
                FinalPrice = x.Offer.FinalPrice.ToString(),
                IsPaid = x.Invoice.IsPaid,
                IsDelivered = x.DeliveryStep == 4 ? true : false,
                TotalWeight = x.Offer.Request.TotalWeight.ToString(),
                TotalVolume = x.Offer.Request.TotalVolume.ToString(),
                TotalItems = x.Offer.Request.StandartCargo == null ? x.Offer.Request.NumberOfNonStandartGoods.ToString() : x.Offer.Request.StandartCargo.NumberOfPallets.ToString(),
                ActualDeliveryDate = x.ActualDeliveryDate.GetValueOrDefault().ToString("dd-MM-yyyy")
            }).ToList();
            return model;
        }

        public async Task<int> GetDriverByLicenseNumberAsync(string licenseNumber)
        {
            return await repository.AllReadonly<Infrastructure.Data.DataModels.Driver>().Where(x => x.LicenseNumber == licenseNumber).Select(x => x.Id).FirstOrDefaultAsync();
        }

        public async Task<IdentityUser> AddDriverUserAsync(AddDriverViewModel model)
        {
            var user = new IdentityUser
            {
                UserName = $"{model.Name.ToLower()}_{model.Age}",
                PhoneNumber = model.PhoneNumber
            };
            await repository.AddAsync(user);
            await repository.SaveChangesAsync();
            return user;
        }

        public async Task AddDriverAsync(AddDriverViewModel model, string id)
        {
            var driver = new Infrastructure.Data.DataModels.Driver
            {
                Name = model.Name,
                Age = model.Age,
                LicenseNumber = model.LicenseNumber,
                LicenseExpiryDate = model.LicenseExpiryDate,
                Salary = model.Salary,
                YearOfExperience = model.YearOfExperience,
                MonthsOfExperience = model.MonthsOfExperience,
                UserId = id,
                IsAvailable = true,
                Preferrences = model.Preferrences
            };
            await repository.AddAsync(driver);
            await repository.SaveChangesAsync();
        }

        public async Task<AddDriverViewModel?> GetDriverForEditAsync(int id)
        {
            return await repository.AllReadonly<Infrastructure.Data.DataModels.Driver>().Where(x => x.Id == id)
                .Select(x => new AddDriverViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Age = x.Age,
                    LicenseNumber = x.LicenseNumber,
                    LicenseExpiryDate = x.LicenseExpiryDate,
                    Salary = x.Salary,
                    YearOfExperience = x.YearOfExperience,
                    MonthsOfExperience = x.MonthsOfExperience,
                    Preferrences = x.Preferrences
                }).FirstOrDefaultAsync();
        }

        public async Task EditDriverAsync(int id, AddDriverViewModel model)
        {
            var driver = await repository.All<Infrastructure.Data.DataModels.Driver>().FirstOrDefaultAsync(x => x.Id == id);
            driver.Name = model.Name;
            driver.Age = model.Age;
            driver.LicenseNumber = model.LicenseNumber;
            driver.LicenseExpiryDate = model.LicenseExpiryDate;
            driver.Salary = model.Salary;
            driver.YearOfExperience = model.YearOfExperience;
            driver.MonthsOfExperience = model.MonthsOfExperience;
            driver.Preferrences = model.Preferrences;
            await repository.SaveChangesAsync();
        }
    }
}
