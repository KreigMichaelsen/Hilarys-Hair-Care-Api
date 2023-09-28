using Microsoft.EntityFrameworkCore;
using HillarysHairCare.Models;

public class HillarysHairCareDbContext : DbContext
{

    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Stylist> Stylists { get; set; }
    public DbSet<Service> Services { get; set; }

    public DbSet<AppointmentService> AppointmentServices { get; set; }

    public HillarysHairCareDbContext(DbContextOptions<HillarysHairCareDbContext> context) : base(context)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    // seed data with campsite types
        modelBuilder.Entity<Customer>().HasData(new Customer[]
        {
            new Customer {Id = 1, FirstName = "Jennifer",  LastName = "Lee", IsActive = true},
            new Customer {Id = 2, FirstName = "Kevin",  LastName = "Brown", IsActive = true},
            new Customer {Id = 3, FirstName = "Jessica",  LastName = "Taylor", IsActive = true},
            new Customer {Id = 4, FirstName = "Christopher",  LastName = "Martinez", IsActive = true},
            new Customer {Id = 5, FirstName = "Brian",  LastName = "Wilson", IsActive = true},
            
        });

        modelBuilder.Entity<Stylist>().HasData(new Stylist[]
        {
            new Stylist {Id = 1,  FirstName = "Emily", LastName = "Davis", IsActive =  true},
            new Stylist {Id = 2,  FirstName = "Michael", LastName = "Johnson", IsActive =  true},
            new Stylist {Id = 3,  FirstName = "Sarah", LastName = "Rodriguez", IsActive =  true},
            new Stylist {Id = 4,  FirstName = "David", LastName = "Smith", IsActive =  true},
        });

        modelBuilder.Entity<Service>().HasData(new Service[]
        {
            new Service {Id = 1, Type = "Short Cut"},
            new Service {Id = 2, Type = "Long Cut"},
            new Service {Id = 3, Type = "Beard Trim"},
            new Service {Id = 4, Type = "Hair Dye"},
            new Service {Id = 5, Type = "Blowout"},
        });

        modelBuilder.Entity<AppointmentService>().HasData(new AppointmentService[]
        {
            new AppointmentService {Id = 1, AppointmentId = 1, ServiceId = 4 },
            new AppointmentService {Id = 2, AppointmentId = 1, ServiceId = 5 },
            new AppointmentService {Id = 3, AppointmentId = 2, ServiceId = 1 },
            new AppointmentService {Id = 4, AppointmentId = 2, ServiceId = 3 },
            new AppointmentService {Id = 5, AppointmentId = 3, ServiceId = 2 },
            new AppointmentService {Id = 6, AppointmentId = 3, ServiceId = 5 },
        });

        modelBuilder.Entity<Appointment>().HasData(new Appointment[]
        {
            new Appointment {Id = 1, CustomerId = 1, StylistId = 1},
            new Appointment {Id = 2, CustomerId = 2, StylistId = 2},
            new Appointment {Id = 3, CustomerId = 3, StylistId = 3},
        });
    }
}