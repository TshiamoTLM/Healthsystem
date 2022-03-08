using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using healthsystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace healthsystem.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientType> PatientsType { get; set; }
        public DbSet<HealthWorker> HealthWorkers { get; set; }
        public DbSet<WorkerType> WorkerTypes { get; set; }
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<History> History { get; set; }

        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<NewsFeed> Newsfeeds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().ToTable("Patients");
            modelBuilder.Entity<PatientType>().ToTable("PatientsType");
            modelBuilder.Entity<HealthWorker>().ToTable("HealthWorkers");
            modelBuilder.Entity<WorkerType>().ToTable("WorkersType");
            modelBuilder.Entity<Consultation>().ToTable("Consultations");
            modelBuilder.Entity<History>().ToTable("History");
            modelBuilder.Entity<Reminder>().ToTable("Reminders");

            modelBuilder.Entity<PatientType>().HasData(
                new PatientType { PatientTypeId = 1, TypeName = "Visitor" },
                new PatientType { PatientTypeId = 2, TypeName = "Student" },
                new PatientType { PatientTypeId = 3, TypeName = "Staff" }
                );
            modelBuilder.Entity<WorkerType>().HasData(
                new WorkerType { WorkerTypeId = 1, TypeName = "Doctor" },
                new WorkerType { WorkerTypeId = 2, TypeName = "Nurse" }
                );



            modelBuilder.Entity<Consultation>().HasData(
                new Consultation { ConsultationId = 1, Date = DateTime.Now },
                new Consultation { ConsultationId = 2, Date = DateTime.Now });


            base.OnModelCreating(modelBuilder);
        }

         public static async Task CreateAdminAccount(IServiceProvider serviceProvider,
           IConfiguration configuration)
            {
                UserManager<AppUser> userManager =
                    serviceProvider.GetRequiredService<UserManager<AppUser>>();
                RoleManager<IdentityRole> roleManager =
                    serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                string username = configuration["Data:AdminUser:Name"];
                string email = configuration["Data:AdminUser:Email"];
                string password = configuration["Data:AdminUser:Password"];
                string role = configuration["Data:AdminUser:Role"];

                if (await roleManager.FindByNameAsync("Admin") == null)
                {
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                }
                if (await roleManager.FindByNameAsync("HealthWorker") == null)
                {
                    await roleManager.CreateAsync(new IdentityRole("HealthWorker"));
                }
                if (await roleManager.FindByNameAsync("Patient") == null)
                {
                    await roleManager.CreateAsync(new IdentityRole("Patient"));
                }


                if (await userManager.FindByNameAsync(username) == null)
                {
                    if (await roleManager.FindByNameAsync(role) == null)
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                    AppUser user = new AppUser
                    {
                        UserName = username,
                        Email = email
                    };
                    IdentityResult result = await userManager.CreateAsync(user, password);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, role);
                    }
                }
            }
    }
}    
