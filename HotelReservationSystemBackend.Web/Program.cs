using HotelReservationSystemBackend.Business.BookingRequestManager;
using HotelReservationSystemBackend.Business.HotelManager;
using HotelReservationSystemBackend.Business.UserManager;
using HotelReservationSystemBackend.Data.Context;
using HotelReservationSystemBackend.Data.Repositories.AllocationRepository;
using HotelReservationSystemBackend.Data.Repositories.BookingRepository;
using HotelReservationSystemBackend.Data.Repositories.HotelRepository;
using HotelReservationSystemBackend.Data.Repositories.UserRepository;
using HotelReservationSystemBackend.Web.Utility;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HotelReservationContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    // Add JWT Bearer
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = builder.Configuration["JWT:ValidAudience"],
            ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecretKey"]!))
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole(Role.Admin.ToString()));
    options.AddPolicy("CustomerOnly", policy => policy.RequireRole(Role.Customer.ToString()));
    options.AddPolicy("AdminOrCustomer", policy => policy.RequireRole(Role.Admin.ToString(), Role.Customer.ToString()));
});

builder.Services.AddCors();
builder.Services.AddSignalR().AddJsonProtocol(options => {
    options.PayloadSerializerOptions.PropertyNamingPolicy = null;
});

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
//options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()
//    );

 app.UseCors(x => x
           .AllowAnyMethod()
           .AllowAnyHeader()
           .SetIsOriginAllowed(origin => true)
           .AllowCredentials()));
app.MapHub<Notifier>("/notifier");
app.MapControllers();


app.Run();
