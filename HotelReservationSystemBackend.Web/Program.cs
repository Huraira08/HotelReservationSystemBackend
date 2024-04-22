using HotelReservationSystemBackend.Business.BookingRequestManager;
using HotelReservationSystemBackend.Business.HotelManager;
using HotelReservationSystemBackend.Business.UserManager;
using HotelReservationSystemBackend.Data.Context;
using HotelReservationSystemBackend.Data.Repositories.AllocationRepository;
using HotelReservationSystemBackend.Data.Repositories.BookingRepository;
using HotelReservationSystemBackend.Data.Repositories.HotelRepository;
using HotelReservationSystemBackend.Data.Repositories.UserRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HotelReservationContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

builder.Services.AddCors();

// repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<IAllocationRepository, AllocationRepository>();
builder.Services.AddScoped<IBookingRequestRepository, BookingRequestRepository>();

// managers
builder.Services.AddScoped<IHotelManager, HotelManager>();
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<IBookingRequestManager, BookingRequestManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(options =>
options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()
    );

app.MapControllers();

app.Run();
