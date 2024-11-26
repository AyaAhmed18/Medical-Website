using MedicalWebsite.Applicationn.AutoMapper;
using MedicalWebsite.Applicationn.Contract;
using MedicalWebsite.Applicationn.IService;
using MedicalWebsite.Applicationn.Service;
using MedicalWebsite.Context;
using MedicalWebsite.Infrastructure;
using MedicalWebsite.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.Text.Json.Serialization;
using Vezeeta.Application.Iservices;
//using SendGrid.Helpers.Mail;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

        builder.Services.AddControllers();

        //  cors service 
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAngularApp", policy =>
            {
                policy.WithOrigins("http://localhost:4200")  
                      .AllowAnyHeader()  
                      .AllowAnyMethod()  
                      .AllowCredentials(); 
            });
        });


        builder.Services.AddDbContext<MedicalContext>(options =>
                      options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));
        builder.Services.AddIdentity<User, IdentityRole>(options =>
        {
            options.SignIn.RequireConfirmedEmail = true;  
 
        })
            .AddEntityFrameworkStores<MedicalContext>().AddDefaultTokenProviders(); 
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddAutoMapper(typeof(ProfileAutoMapper));
        builder.Services.AddScoped<IDoctorService, DoctorService>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<ISpeciallizationService, SpecializationService>();
        builder.Services.AddScoped<IBookingService, BookingService>();
        builder.Services.AddScoped<IAppointmentService, AppointmentService>();
        builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        builder.Services.AddScoped<IPatientService, PatientService>();
        builder.Services.AddScoped<IpatientRepository, PatientRepository>();
        builder.Services.AddScoped<IReviewService, OffersService>();
        builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
        builder.Services.AddScoped<IOffersService, OfeersService>();
        builder.Services.AddScoped<IOffersRepository, OffersRepository>();
        builder.Services.AddScoped<ITreatmentService, TreatmentService>();
        builder.Services.AddScoped<ITreatmentRepository, TreatmentRepository>();
        builder.Services.AddScoped<ISubSpecializationService, SubSpecializationService>();
        builder.Services.AddScoped<ISubSpecializationRepository, SubSpecializationRepository>();


builder.Services.AddScoped<IEmailSender, EmailService>();
        builder.Services.AddScoped<EmailService>();
        builder.Services.AddControllers().AddJsonOptions(options =>
                {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });


        builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<ISpicallizationRepository, SpecializationRepository>();
        builder.Services.AddScoped<IBookingRepository, BookingRepository>();
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//builder.Services.Configure<MailSettings>
//             (builder.Configuration.GetSection("MailSettings"));

builder.Services.Configure<IdentityOptions>(options =>
        {
            // Password settings
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 8; // Adjust as necessary
        });



builder.Services.AddTransient<IEmailSender, EmailService>();
        builder.Services.AddSwaggerGen();


   


var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "images")),
            RequestPath = "/images"
        });


app.UseCors("AllowAngularApp");

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
