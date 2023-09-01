using D_KSRTC.Data;
using D_KSRTC.Repositories.Bookings;
using D_KSRTC.Repositories.BusCategories;
using D_KSRTC.Repositories.Buses;
using D_KSRTC.Repositories.BusRoutes;
using D_KSRTC.Repositories.BusTypeCategories;
using D_KSRTC.Repositories.BusTypes;
using D_KSRTC.Repositories.Location;
using D_KSRTC.Repositories.Passengers;
using D_KSRTC.Repositories.Routes;
using D_KSRTC.Repositories.Users;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//Setting up the connections.
builder.Services.AddDbContext<DKSRTCContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection")));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
//Injecting the repository.
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<IBusTypeRepository, BusTypeRepository>();
builder.Services.AddScoped<IBusCategoryRepository, BusCategoryRepository>();
builder.Services.AddScoped<IBusTypeCategoryRepository, BusTypeCategoryRepository>();
builder.Services.AddScoped<IBusRepository, BusRepository>();
builder.Services.AddScoped<IBusRoutesRepository, BusRoutesRepository>();
builder.Services.AddScoped<IRouteRepository, RouteRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IPassengerRepository, PassengerRepository>();
//Configuring for CORS.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});
builder.Services.AddSwaggerGen();
var app = builder.Build();

//Using Swagger.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//Using the custom CORS Configuration that we made above.
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
