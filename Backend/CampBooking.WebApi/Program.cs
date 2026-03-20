using CampBooking.DAL.DB;
using CampBooking.DAL.Interfaces;
using CampBooking.DAL.Repository;
using CampBooking.Service.Interfaces;
using CampBooking.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

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
