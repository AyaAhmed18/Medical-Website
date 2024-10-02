using MedicalWebsite.Context;
using MedicalWebsite.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<MedicalContext>(options =>
              options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<MedicalContext>();
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
