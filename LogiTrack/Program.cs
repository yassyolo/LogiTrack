using LogiTrack.Core.Contracts;
using LogiTrack.Core.Services;
using LogiTrack.Infrastructure;
using LogiTrack.Infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddScoped<IEmailSenderService, EmailSenderService>();
    builder.Services.AddHttpClient<GeocodingService>();
    builder.Services.AddScoped<IGoogleDriveService, GoogleDriveService>();
    builder.Services.AddScoped<IRepository, Repository>();
    builder.Services.AddScoped<IEventService, EventService>();
    builder.Services.AddScoped<IDashboardService, DashboardService>();
    builder.Services.AddScoped<IStatisticsService, StatisticsService>();
    builder.Services.AddScoped<IDeliveryStatisticsService, DeliveryStatisticsService>();
    builder.Services.AddScoped<IFuelPriceService, FuelPriceService>();
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IHomeService, HomeService>();
    builder.Services.AddScoped<IClientsService, ClientsService>();
    builder.Services.AddScoped<IVehicleService, VehicleService>();
    builder.Services.AddScoped<IDeliveryService, DeliveryService>();
    builder.Services.AddScoped<IDriverService, DriverService>();
    builder.Services.AddScoped<ICashRegisterService, CashRegisterService>();
    builder.Services.AddScoped<IRequestService, RequestService>();
    builder.Services.AddScoped<IOfferService, OfferService>();
    builder.Services.AddScoped<IInvoiceService, InvoiceService>();
    builder.Services.AddHostedService<NotificationsService>();



builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//TODO: Add password constraints
builder.Services.AddIdentity<IdentityUser, IdentityRole>(opt =>
{
    opt.SignIn.RequireConfirmedAccount = false;
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();


builder.Services.AddRazorPages();
builder.Services.AddHttpClient();

builder.Services.AddControllersWithViews();
builder.Logging.AddConsole(options => options.LogToStandardErrorThreshold = LogLevel.Debug);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error/500");
    app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

try
{
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine($"Error during startup: {ex.Message}");
    throw;
}
