using MedicalWebsite.Applicationn.Contract;
using MedicalWebsite.Applicationn.IService;
using MedicalWebsite.Applicationn.Service;
using MedicalWebsite.Context;
using MedicalWebsite.Infrastructure;
using MedicalWebsite.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Vezeeta.Application.Iservices;
//using SendGrid.Helpers.Mail;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<MedicalContext>(options =>
              options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedEmail = true;  
 
})
    .AddEntityFrameworkStores<MedicalContext>().AddDefaultTokenProviders(); 
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISpeciallizationService, SpecializationService>();
builder.Services.AddScoped<IBookingService, BookingService>();

builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISpicallizationRepository, SpecializationRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//builder.Services.Configure<MailSettings>
  //             (builder.Configuration.GetSection("MailSettings"));

builder.Services.AddTransient<IEmailSender, EmailService>();
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
