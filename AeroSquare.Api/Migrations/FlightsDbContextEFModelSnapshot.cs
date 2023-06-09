﻿// <auto-generated />
using System;
using AeroSquare.Repository.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AeroSquare.Api.Migrations
{
    [DbContext(typeof(FlightsDbContextEF))]
    partial class FlightsDbContextEFModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AeroSquare.Entities.Airplane", b =>
                {
                    b.Property<int>("AirplaneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AirplaneId"));

                    b.Property<short>("Capacity")
                        .HasMaxLength(32767)
                        .HasColumnType("smallint");

                    b.Property<short>("FlightCrew")
                        .HasMaxLength(32767)
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("AirplaneId");

                    b.ToTable("Airplane", (string)null);

                    b.HasData(
                        new
                        {
                            AirplaneId = 1,
                            Capacity = (short)126,
                            FlightCrew = (short)6,
                            Name = "Embraer 317"
                        },
                        new
                        {
                            AirplaneId = 2,
                            Capacity = (short)180,
                            FlightCrew = (short)8,
                            Name = "Airbus 320"
                        },
                        new
                        {
                            AirplaneId = 3,
                            Capacity = (short)186,
                            FlightCrew = (short)10,
                            Name = "Boeing 767"
                        });
                });

            modelBuilder.Entity("AeroSquare.Entities.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityId"));

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CityId");

                    b.ToTable("City", (string)null);

                    b.HasData(
                        new
                        {
                            CityId = 1,
                            Name = "Portland"
                        },
                        new
                        {
                            CityId = 2,
                            Name = "Las Vegas"
                        },
                        new
                        {
                            CityId = 3,
                            Name = "Chicago"
                        },
                        new
                        {
                            CityId = 4,
                            Name = "Boise"
                        },
                        new
                        {
                            CityId = 5,
                            Name = "Dallas"
                        });
                });

            modelBuilder.Entity("AeroSquare.Entities.Destination", b =>
                {
                    b.Property<int>("DestinationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DestinationId"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.HasKey("DestinationId");

                    b.HasIndex("CityId");

                    b.ToTable("Destination", (string)null);

                    b.HasData(
                        new
                        {
                            DestinationId = 1,
                            CityId = 2
                        },
                        new
                        {
                            DestinationId = 2,
                            CityId = 3
                        },
                        new
                        {
                            DestinationId = 3,
                            CityId = 4
                        },
                        new
                        {
                            DestinationId = 4,
                            CityId = 5
                        });
                });

            modelBuilder.Entity("AeroSquare.Entities.Flight", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlightId"));

                    b.Property<int>("AirplaneId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("DestinationId")
                        .HasColumnType("int");

                    b.Property<string>("FlightNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ListPrice")
                        .HasColumnType("float");

                    b.Property<int>("OriginId")
                        .HasColumnType("int");

                    b.HasKey("FlightId");

                    b.HasIndex("AirplaneId");

                    b.HasIndex("DestinationId");

                    b.HasIndex("OriginId");

                    b.ToTable("Flight", (string)null);

                    b.HasData(
                        new
                        {
                            FlightId = 1,
                            AirplaneId = 1,
                            ArrivalTime = new DateTime(1900, 1, 1, 7, 45, 0, 0, DateTimeKind.Unspecified),
                            DepartureTime = new DateTime(1900, 1, 1, 6, 15, 0, 0, DateTimeKind.Unspecified),
                            DestinationId = 1,
                            FlightNumber = "AES 108",
                            ListPrice = 1037.28,
                            OriginId = 1
                        },
                        new
                        {
                            FlightId = 2,
                            AirplaneId = 2,
                            ArrivalTime = new DateTime(1900, 1, 1, 14, 16, 0, 0, DateTimeKind.Unspecified),
                            DepartureTime = new DateTime(1900, 1, 1, 10, 23, 0, 0, DateTimeKind.Unspecified),
                            DestinationId = 3,
                            FlightNumber = "AES 210",
                            ListPrice = 1500.1700000000001,
                            OriginId = 2
                        },
                        new
                        {
                            FlightId = 3,
                            AirplaneId = 3,
                            ArrivalTime = new DateTime(1900, 1, 1, 21, 25, 0, 0, DateTimeKind.Unspecified),
                            DepartureTime = new DateTime(1900, 1, 1, 20, 16, 0, 0, DateTimeKind.Unspecified),
                            DestinationId = 1,
                            FlightNumber = "AES 325",
                            ListPrice = 927.0,
                            OriginId = 3
                        },
                        new
                        {
                            FlightId = 4,
                            AirplaneId = 2,
                            ArrivalTime = new DateTime(1900, 1, 1, 11, 34, 0, 0, DateTimeKind.Unspecified),
                            DepartureTime = new DateTime(1900, 1, 1, 7, 25, 0, 0, DateTimeKind.Unspecified),
                            DestinationId = 3,
                            FlightNumber = "AES 218",
                            ListPrice = 1215.25,
                            OriginId = 3
                        },
                        new
                        {
                            FlightId = 5,
                            AirplaneId = 3,
                            ArrivalTime = new DateTime(1900, 1, 1, 4, 15, 0, 0, DateTimeKind.Unspecified),
                            DepartureTime = new DateTime(1900, 1, 1, 23, 38, 0, 0, DateTimeKind.Unspecified),
                            DestinationId = 2,
                            FlightNumber = "AES 927",
                            ListPrice = 2100.0,
                            OriginId = 4
                        },
                        new
                        {
                            FlightId = 6,
                            AirplaneId = 1,
                            ArrivalTime = new DateTime(1900, 1, 1, 6, 23, 0, 0, DateTimeKind.Unspecified),
                            DepartureTime = new DateTime(1900, 1, 1, 4, 20, 0, 0, DateTimeKind.Unspecified),
                            DestinationId = 1,
                            FlightNumber = "AES 639",
                            ListPrice = 1450.3599999999999,
                            OriginId = 5
                        },
                        new
                        {
                            FlightId = 7,
                            AirplaneId = 1,
                            ArrivalTime = new DateTime(1900, 1, 1, 12, 38, 0, 0, DateTimeKind.Unspecified),
                            DepartureTime = new DateTime(1900, 1, 1, 9, 23, 0, 0, DateTimeKind.Unspecified),
                            DestinationId = 1,
                            FlightNumber = "AES 709",
                            ListPrice = 897.12,
                            OriginId = 2
                        },
                        new
                        {
                            FlightId = 8,
                            AirplaneId = 3,
                            ArrivalTime = new DateTime(1900, 1, 1, 13, 4, 0, 0, DateTimeKind.Unspecified),
                            DepartureTime = new DateTime(1900, 1, 1, 10, 16, 0, 0, DateTimeKind.Unspecified),
                            DestinationId = 4,
                            FlightNumber = "AES 354",
                            ListPrice = 1654.8699999999999,
                            OriginId = 2
                        },
                        new
                        {
                            FlightId = 9,
                            AirplaneId = 2,
                            ArrivalTime = new DateTime(1900, 1, 1, 11, 25, 0, 0, DateTimeKind.Unspecified),
                            DepartureTime = new DateTime(1900, 1, 1, 6, 59, 0, 0, DateTimeKind.Unspecified),
                            DestinationId = 4,
                            FlightNumber = "AES 500",
                            ListPrice = 1024.3499999999999,
                            OriginId = 1
                        },
                        new
                        {
                            FlightId = 10,
                            AirplaneId = 2,
                            ArrivalTime = new DateTime(1900, 1, 1, 0, 59, 0, 0, DateTimeKind.Unspecified),
                            DepartureTime = new DateTime(1900, 1, 1, 22, 4, 0, 0, DateTimeKind.Unspecified),
                            DestinationId = 2,
                            FlightNumber = "AES 724",
                            ListPrice = 1024.3499999999999,
                            OriginId = 1
                        });
                });

            modelBuilder.Entity("AeroSquare.Entities.FlightDays", b =>
                {
                    b.Property<int>("FlightDayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlightDayId"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FlightDayId");

                    b.ToTable("FlightDays", (string)null);

                    b.HasData(
                        new
                        {
                            FlightDayId = 1,
                            Name = "Monday"
                        },
                        new
                        {
                            FlightDayId = 2,
                            Name = "Tuesday"
                        },
                        new
                        {
                            FlightDayId = 3,
                            Name = "Wednesday"
                        },
                        new
                        {
                            FlightDayId = 4,
                            Name = "Thursday"
                        },
                        new
                        {
                            FlightDayId = 5,
                            Name = "Friday"
                        },
                        new
                        {
                            FlightDayId = 6,
                            Name = "Saturday"
                        },
                        new
                        {
                            FlightDayId = 7,
                            Name = "Sunday"
                        });
                });

            modelBuilder.Entity("AeroSquare.Entities.Origin", b =>
                {
                    b.Property<int>("OriginId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OriginId"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.HasKey("OriginId");

                    b.HasIndex("CityId");

                    b.ToTable("Origin", (string)null);

                    b.HasData(
                        new
                        {
                            OriginId = 1,
                            CityId = 1
                        },
                        new
                        {
                            OriginId = 4,
                            CityId = 2
                        },
                        new
                        {
                            OriginId = 2,
                            CityId = 3
                        },
                        new
                        {
                            OriginId = 5,
                            CityId = 4
                        },
                        new
                        {
                            OriginId = 3,
                            CityId = 5
                        });
                });

            modelBuilder.Entity("FlightFlightDays", b =>
                {
                    b.Property<int>("FlightDaysFlightDayId")
                        .HasColumnType("int");

                    b.Property<int>("FlightsFlightId")
                        .HasColumnType("int");

                    b.HasKey("FlightDaysFlightDayId", "FlightsFlightId");

                    b.HasIndex("FlightsFlightId");

                    b.ToTable("FlightFlightDays");
                });

            modelBuilder.Entity("AeroSquare.Entities.Destination", b =>
                {
                    b.HasOne("AeroSquare.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("AeroSquare.Entities.Flight", b =>
                {
                    b.HasOne("AeroSquare.Entities.Airplane", "Airplane")
                        .WithMany()
                        .HasForeignKey("AirplaneId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AeroSquare.Entities.Destination", "Destination")
                        .WithMany()
                        .HasForeignKey("DestinationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AeroSquare.Entities.Origin", "Origin")
                        .WithMany()
                        .HasForeignKey("OriginId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Airplane");

                    b.Navigation("Destination");

                    b.Navigation("Origin");
                });

            modelBuilder.Entity("AeroSquare.Entities.Origin", b =>
                {
                    b.HasOne("AeroSquare.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("FlightFlightDays", b =>
                {
                    b.HasOne("AeroSquare.Entities.FlightDays", null)
                        .WithMany()
                        .HasForeignKey("FlightDaysFlightDayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AeroSquare.Entities.Flight", null)
                        .WithMany()
                        .HasForeignKey("FlightsFlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
