using ClassModels;
using Microsoft.EntityFrameworkCore;
using SlutProjekt_ClassLibrary;

namespace Projekt_Avancerad.NET.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<AppointmentHistory> AppointmentHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //Appointment SEED
            modelBuilder.Entity<Appointment>().HasData(new Appointment
            {
                ApointmentID = 1,
                AppointmentType = AppointmentType.Carservice,
                AppointmentStatus = AppointmentStatus.Pending,
                AppointmentDate = DateTime.Now,
                CustomerID = 1,
                CompanyID = 2,
            });
            modelBuilder.Entity<Appointment>().HasData(new Appointment
            {
                ApointmentID = 2,
                AppointmentType = AppointmentType.example,
                AppointmentStatus = AppointmentStatus.Declined,
                AppointmentDate = DateTime.Now,
                CustomerID = 2,
                CompanyID = 3,

            });
            modelBuilder.Entity<Appointment>().HasData(new Appointment
            {
                ApointmentID = 3,
                AppointmentType = AppointmentType.Carwash,
                AppointmentStatus = AppointmentStatus.Confirmed,
                AppointmentDate = DateTime.Now,
                CustomerID = 3,
                CompanyID = 1,

            });


            //Customer SEED
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerID = 1,
                CustomerName = "Ludwig",
                CustomerEmail = "ludwig@hotmail.com"
            });
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerID = 2,
                CustomerName = "Robin",
                CustomerEmail = "robin@gmail.com"


            });
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerID = 3,
                CustomerName = "Sara",
                CustomerEmail = "sara@yahoo.com"
            });


            //Companyy SEEd
            modelBuilder.Entity<Company>().HasData(new Company
            {
                CompanyID = 1,
                CompanyName = "Dagges tvätt",
            });
            modelBuilder.Entity<Company>().HasData(new Company
            {
                CompanyID = 2,
                CompanyName = "Mulles bilmeck"
            });
            modelBuilder.Entity<Company>().HasData(new Company
            {
                CompanyID = 3,
                CompanyName = "example ex",
            });

        }
    }
}

