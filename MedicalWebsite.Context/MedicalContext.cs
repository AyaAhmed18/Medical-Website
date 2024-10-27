using MedicalWebsite.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace MedicalWebsite.Context
{
    public class MedicalContext : IdentityDbContext<User>
    {
        public MedicalContext(DbContextOptions<MedicalContext> options) : base(options)
        { }

        public DbSet<Doctor>Doctors {  get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Specialization> Specializations { get; set; }

       
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            var entities = ChangeTracker.Entries<BaseEntity>();

            foreach (var entity in entities)
            {
                if
                (entity.State == EntityState.Added)
                {
                    entity.Entity.CreatedAt = DateTime.UtcNow;
                    entity.Entity.CreatedBy = 1;
                }
                if
                (entity.State == EntityState.Modified)
                {
                    entity.Entity.UpdatedAt = DateTime.UtcNow;
                    entity.Entity.UpdatedBy = 1;
                }
            }
            // set value for base entity data 
            //ChangeTracker.Entries
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            // set value for base entity data 
            var entities = ChangeTracker.Entries<BaseEntity>();

            foreach (var entity in entities)
            {
                if
                (entity.State == EntityState.Added)
                {
                    entity.Entity.CreatedAt = DateTime.UtcNow;
                    entity.Entity.CreatedBy = 1;
                }
                if (entity.State == EntityState.Modified)
                {
                    entity.Entity.UpdatedAt = DateTime.UtcNow;
                    entity.Entity.UpdatedBy = 1;
                }
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
                builder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

                 builder.Entity<Review>()
                .HasOne(r => r.Patient)
                .WithMany(p => p.Reviews)
                .HasForeignKey(r => r.PatientId)
                .OnDelete(DeleteBehavior.Restrict); 

            var adminRole = new IdentityRole
            {
                Id = "1",
                Name = "Admin",
                NormalizedName = "ADMIN"
            };
            
            var hasher = new PasswordHasher<User>();

            // Seeding the admin user
            var ayaUser = new User
            {
               Id="1",
               UserName="AyaAhmedAdmin",
               Email = "AyaAhmed18@gmail.com",
               EmailConfirmed = true,
               IsDeleted = false,
               
            };
            ayaUser.PasswordHash = hasher.HashPassword(ayaUser, "AdminPassword123!");

            var AsmaaUser = new User
            {
                Id = "2",
                UserName = "AsmaaGaberAdmin",
                Email = "AsmaaGaber18@gmail.com",
                EmailConfirmed = true,
                IsDeleted = false,

            };
            AsmaaUser.PasswordHash = hasher.HashPassword(AsmaaUser, "AdminPassword123@#");

            var HebaUser = new User
            {
                Id = "3",
                UserName = "HebaAdmin",
                Email = "\"Heba18@gmail.com",
                EmailConfirmed = true,
                IsDeleted = false,

            };
            HebaUser.PasswordHash = hasher.HashPassword(HebaUser, "AdminPassword123!");




            builder.Entity<IdentityRole>().HasData(adminRole);


            // Seeding the users into the database
            builder.Entity<User>().HasData(ayaUser, AsmaaUser, HebaUser);

            builder.Entity<IdentityUserRole<string>>().HasData(
                    new IdentityUserRole<string>
                    {
                        UserId = ayaUser.Id,
                        RoleId = adminRole.Id
                    },
                    new IdentityUserRole<string>
                    {
                        UserId = AsmaaUser.Id,
                        RoleId = adminRole.Id
                    },
                    new IdentityUserRole<string>
                    {
                        UserId = HebaUser.Id,
                        RoleId = adminRole.Id
                    }
                    
                );

            base.OnModelCreating(builder);
        }
    }
}
