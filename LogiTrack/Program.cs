using LogiTrack.Core.Contracts;
using LogiTrack.Core.Services;
using LogiTrack.Infrastructure;
using LogiTrack.Infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedAccount = true;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Home/Login"; 
    options.AccessDeniedPath = "/Home/AccessDenied"; 
    options.ExpireTimeSpan = TimeSpan.FromHours(3); 
    options.SlidingExpiration = true; 
    options.Cookie.HttpOnly = true; 
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always; 
});

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

app.UseHttpsRedirection();

app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers["Cache-Control"] = "no-store";
        ctx.Context.Response.Headers["Pragma"] = "no-cache";
    }
});

app.Use(async (context, next) =>
{
    context.Response.Headers["X-Content-Type-Options"] = "nosniff";
    context.Response.Headers["X-Frame-Options"] = "DENY";
    context.Response.Headers["X-XSS-Protection"] = "1; mode=block";
    context.Response.Headers["Strict-Transport-Security"] = "max-age=31536000; includeSubDomains";
    await next();
});

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();
