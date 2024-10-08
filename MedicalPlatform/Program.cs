using MedicalWebsite.Applicationn.Contract;
using MedicalWebsite.Applicationn.Service;
using MedicalWebsite.Context;
using MedicalWebsite.Infrastructure;
using MedicalWebsite.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MedicalWebsite.Application.Iservices;
using MedicalWebsite.Applicationn.AutoMapper;
using System.Text;
using Vezeeta.Application.Iservices;
using AutoMapper;
using System.Text.Json.Serialization;
//using AutoMapper.Extensions.Microsoft.DependencyInjection;


namespace MedicalPlatform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddDbContext<MedicalContext>(options =>
                          options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));
            builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<MedicalContext>();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddScoped<IAppointmentService, AppointmentService>();
            builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            builder.Services.AddScoped<IPatientService, PatientService>();
            builder.Services.AddScoped<IpatientRepository, PatientRepository>();
            builder.Services.AddScoped<IReviewService, ReviewService>();
            builder.Services.AddScoped<IReviewRepository,ReviewRepository>();

            builder.Services.AddControllers().AddJsonOptions(options =>
     {
         options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
     });


            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(options =>
                options.WithOrigins("http://localhost:4200")
                .AllowAnyMethod().AllowAnyHeader());

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}



//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//builder.Services.AddDbContext<MedicalContext>(options =>
//              options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));
//builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<MedicalContext>();
//builder.Services.AddEndpointsApiExplorer();


//builder.Services.AddScoped<IAppointmentService, AppointmentService>();
//builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
//builder.Services.AddScoped<IAppointmentService, AppointmentService>();
//builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();



//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
