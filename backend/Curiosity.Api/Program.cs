using Curiosity.Api.Data;
using Curiosity.Api.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Curiosity.Api.Repositories;
using Curiosity.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Preluăm connection string-ul din appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. Înregistrăm AppDbContext (Dependency Injection)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// --- ADĂUGARE NOUĂ: Dependency Injection pentru Repository și Service ---
builder.Services.AddScoped<IMissionRepository, MissionRepository>();
builder.Services.AddScoped<IMissionService, MissionService>();
// -----------------------------------------------------------------------

// 3. Înregistrăm ASP.NET Core Identity pentru autentificare
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Adăugăm middleware-urile pentru securitate
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();