using CreditCar.API.Payments.Domain.Repositories;
using CreditCar.API.Payments.Domain.Services;
using CreditCar.API.Payments.Persistence.Repositories;
using CreditCar.API.Payments.Services;
using CreditCar.API.Profiles.Domain.Repositories;
using CreditCar.API.Profiles.Domain.Services;
using CreditCar.API.Profiles.Mapping;
using CreditCar.API.Profiles.Persistence.Repositories;
using CreditCar.API.Profiles.Services;
using CreditCar.API.Shared.Domain.Repositories;
using CreditCar.API.Shared.Persistence.Contexts;
using CreditCar.API.Shared.Persistence.Repositories;
using CreditCar.API.Vehicles.Domain.Repositories;
using CreditCar.API.Vehicles.Domain.Services;
using CreditCar.API.Vehicles.Persistence.Repositories;
using CreditCar.API.Vehicles.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());

// Add lowercase routes
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Dependency Injection Configuration
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// AutoMapper Configuration
builder.Services.AddAutoMapper(
    typeof(ModelToResourceProfile), 
    typeof(ResourceToModelProfile));

var app = builder.Build();

// Validation for ensuring Database Objects are created
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();