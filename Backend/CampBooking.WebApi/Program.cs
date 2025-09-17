using CampBooking.DAL.DB;
using CampBooking.DAL.Interfaces;
using CampBooking.DAL.Repository;
using CampBooking.Service.Interfaces;
using CampBooking.Service.Services;
using CampBooking.Shared.Helper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add Auto Mapper Profile
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICampService, CampService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IRatingService, RatingService>();

// Database Connection and Migration 
builder.Services.AddDbContext<CampDBContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 2, 0)
    ),
    b => b.MigrationsAssembly("CampBooking.WebApi"))
);

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
