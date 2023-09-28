﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HillarysHairCare.Migrations
{
    [DbContext(typeof(HillarysHairCareDbContext))]
    [Migration("20230928162039_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HillarysHairCare.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<int>("StylistId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StylistId");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            StylistId = 1
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 2,
                            StylistId = 2
                        },
                        new
                        {
                            Id = 3,
                            CustomerId = 3,
                            StylistId = 3
                        });
                });

            modelBuilder.Entity("HillarysHairCare.Models.AppointmentService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AppointmentId")
                        .HasColumnType("integer");

                    b.Property<int>("ServiceId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("ServiceId");

                    b.ToTable("AppointmentServices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AppointmentId = 1,
                            ServiceId = 4
                        },
                        new
                        {
                            Id = 2,
                            AppointmentId = 1,
                            ServiceId = 5
                        },
                        new
                        {
                            Id = 3,
                            AppointmentId = 2,
                            ServiceId = 1
                        },
                        new
                        {
                            Id = 4,
                            AppointmentId = 2,
                            ServiceId = 3
                        },
                        new
                        {
                            Id = 5,
                            AppointmentId = 3,
                            ServiceId = 2
                        },
                        new
                        {
                            Id = 6,
                            AppointmentId = 3,
                            ServiceId = 5
                        });
                });

            modelBuilder.Entity("HillarysHairCare.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Jennifer",
                            IsActive = true,
                            LastName = "Lee"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Kevin",
                            IsActive = true,
                            LastName = "Brown"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Jessica",
                            IsActive = true,
                            LastName = "Taylor"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Christopher",
                            IsActive = true,
                            LastName = "Martinez"
                        },
                        new
                        {
                            Id = 5,
                            FirstName = "Brian",
                            IsActive = true,
                            LastName = "Wilson"
                        });
                });

            modelBuilder.Entity("HillarysHairCare.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Short Cut"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Long Cut"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Beard Trim"
                        },
                        new
                        {
                            Id = 4,
                            Type = "Hair Dye"
                        },
                        new
                        {
                            Id = 5,
                            Type = "Blowout"
                        });
                });

            modelBuilder.Entity("HillarysHairCare.Models.Stylist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Stylists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Emily",
                            IsActive = true,
                            LastName = "Davis"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Michael",
                            IsActive = true,
                            LastName = "Johnson"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Sarah",
                            IsActive = true,
                            LastName = "Rodriguez"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "David",
                            IsActive = true,
                            LastName = "Smith"
                        });
                });

            modelBuilder.Entity("HillarysHairCare.Models.Appointment", b =>
                {
                    b.HasOne("HillarysHairCare.Models.Customer", "Customer")
                        .WithMany("Appointments")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HillarysHairCare.Models.Stylist", "Stylist")
                        .WithMany("Appointments")
                        .HasForeignKey("StylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Stylist");
                });

            modelBuilder.Entity("HillarysHairCare.Models.AppointmentService", b =>
                {
                    b.HasOne("HillarysHairCare.Models.Appointment", "Appointment")
                        .WithMany("AppointmentServices")
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HillarysHairCare.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("HillarysHairCare.Models.Appointment", b =>
                {
                    b.Navigation("AppointmentServices");
                });

            modelBuilder.Entity("HillarysHairCare.Models.Customer", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("HillarysHairCare.Models.Stylist", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
