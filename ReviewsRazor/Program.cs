using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReviewsRazor.Models;
using ReviewsRazor.Repository;
using ReviewsRazor.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.Name = "SessionCookie";
});

string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MessageContext>(options => options.UseSqlServer(connection));


builder.Services.AddRazorPages();


builder.Services.AddScoped<IRepositoryUser, UserRepository>();
builder.Services.AddScoped<IRepositoryMessage, MessageRepository>();
builder.Services.AddScoped<PasswordHasher>();

var app = builder.Build();

app.UseStaticFiles();
app.UseSession();

app.MapRazorPages();

app.Run();