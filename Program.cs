using HillarysHairCare.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<HillarysHairCareDbContext>(builder.Configuration["HillarysHairCareDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ENDPOINTS

app.MapGet("/api/appointments", (HillarysHairCareDbContext db) =>
{
    return db.Appointments
        .Include(a => a.Customer)
        .Include(a => a.Stylist);
});

app.MapPost("/api/appointments", (HillarysHairCareDbContext db, Appointment appointment) =>
{
    appointment.Customer = db.Customers.SingleOrDefault(c => c.Id == appointment.CustomerId);
    appointment.Stylist = db.Stylists.SingleOrDefault(s => s.Id == appointment.StylistId);
    db.Appointments.Add(appointment);
    db.SaveChanges();
    return Results.Created($"/api/appointments/{appointment.Id}", appointment);
});

app.MapDelete("/api/appointments/{id}", (HillarysHairCareDbContext db, int id) =>
{
    Appointment appointment = db.Appointments.SingleOrDefault(appointment => appointment.Id == id);
    if (appointment == null)
    {
        return Results.NotFound();
    }
    db.Appointments.Remove(appointment);
    db.SaveChanges();
    return Results.NoContent();

});

app.MapPut("/api/appointments/{id}", (HillarysHairCareDbContext db, int id, Appointment appointment) =>
{
    Appointment appointmentToUpdate = db.Appointments.SingleOrDefault(a => a.Id == id);
    if (appointmentToUpdate == null)
    {
        return Results.NotFound();
    }
    appointmentToUpdate.CustomerId = appointment.CustomerId;
    appointmentToUpdate.StylistId = appointment.StylistId;

    db.SaveChanges();
    return Results.NoContent();
});

app.MapGet("/api/customers", (HillarysHairCareDbContext db) =>
{
        
    return db.Customers;
});



app.MapPost("/api/customers", (HillarysHairCareDbContext db, Customer customer) =>
{
    db.Customers.Add(customer);
    db.SaveChanges();
    return Results.Created($"/api/customers/{customer.Id}", customer);
});

app.MapGet("/api/stylists", (HillarysHairCareDbContext db) =>
{
        
    return db.Stylists;
});

app.MapPost("/api/stylists", (HillarysHairCareDbContext db, Stylist stylist) =>
{
    db.Stylists.Add(stylist);
    db.SaveChanges();
    return Results.Created($"/api/stylists/{stylist.Id}", stylist);
});

app.MapPut("/api/stylists/{id}/deactivate", (HillarysHairCareDbContext db, int id) =>
{
    Stylist stylistToDeactivate = db.Stylists.SingleOrDefault(s => s.Id == id);
    if (stylistToDeactivate == null)
    {
        return Results.NotFound();
    }
    stylistToDeactivate.IsActive = false;

    db.SaveChanges();
    return Results.NoContent();
});

app.MapGet("/api/services", (HillarysHairCareDbContext db) =>
{
        
    return db.Services;
});



app.Run();

