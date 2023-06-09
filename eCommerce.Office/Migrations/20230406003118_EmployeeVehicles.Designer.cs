﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eCommerce.Office;

#nullable disable

namespace eCommerce.Office.Migrations
{
    [DbContext(typeof(eCommerceOfficeContext))]
    [Migration("20230406003118_EmployeeVehicles")]
    partial class EmployeeVehicles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("eCommerce.Office.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "José"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Mary"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Phillip"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Joe"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Paul"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Zoe"
                        });
                });

            modelBuilder.Entity("eCommerce.Office.EmployeeSection", b =>
                {
                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("SectionId", "EmployeeId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeesSections");

                    b.HasData(
                        new
                        {
                            SectionId = 1,
                            EmployeeId = 1,
                            Created = new DateTimeOffset(new DateTime(2023, 4, 5, 21, 31, 17, 788, DateTimeKind.Unspecified).AddTicks(744), new TimeSpan(0, -3, 0, 0, 0))
                        },
                        new
                        {
                            SectionId = 1,
                            EmployeeId = 6,
                            Created = new DateTimeOffset(new DateTime(2023, 4, 5, 21, 31, 17, 788, DateTimeKind.Unspecified).AddTicks(865), new TimeSpan(0, -3, 0, 0, 0))
                        },
                        new
                        {
                            SectionId = 2,
                            EmployeeId = 5,
                            Created = new DateTimeOffset(new DateTime(2023, 4, 5, 21, 31, 17, 788, DateTimeKind.Unspecified).AddTicks(871), new TimeSpan(0, -3, 0, 0, 0))
                        },
                        new
                        {
                            SectionId = 2,
                            EmployeeId = 4,
                            Created = new DateTimeOffset(new DateTime(2023, 4, 5, 21, 31, 17, 788, DateTimeKind.Unspecified).AddTicks(873), new TimeSpan(0, -3, 0, 0, 0))
                        },
                        new
                        {
                            SectionId = 3,
                            EmployeeId = 2,
                            Created = new DateTimeOffset(new DateTime(2023, 4, 5, 21, 31, 17, 788, DateTimeKind.Unspecified).AddTicks(875), new TimeSpan(0, -3, 0, 0, 0))
                        },
                        new
                        {
                            SectionId = 4,
                            EmployeeId = 3,
                            Created = new DateTimeOffset(new DateTime(2023, 4, 5, 21, 31, 17, 788, DateTimeKind.Unspecified).AddTicks(877), new TimeSpan(0, -3, 0, 0, 0))
                        });
                });

            modelBuilder.Entity("eCommerce.Office.EmployeeVehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("StartDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("VehicleId", "EmployeeId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeVehicle");
                });

            modelBuilder.Entity("eCommerce.Office.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sections");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Delivery"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Transport"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Marketing"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Management"
                        });
                });

            modelBuilder.Entity("eCommerce.Office.TrainingClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TrainingClasses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Class A"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Class B"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Class C"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Class D"
                        });
                });

            modelBuilder.Entity("eCommerce.Office.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("LicensePlate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vehicles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LicensePlate = "ABC-7771",
                            Name = "Alfa Romeo - C43"
                        },
                        new
                        {
                            Id = 2,
                            LicensePlate = "ABC-7772",
                            Name = "AlphaTauri - AT04"
                        },
                        new
                        {
                            Id = 3,
                            LicensePlate = "ABC-7773",
                            Name = "Alpine - A523"
                        },
                        new
                        {
                            Id = 4,
                            LicensePlate = "ABC-7774",
                            Name = "Aston Martin - AMR23"
                        },
                        new
                        {
                            Id = 5,
                            LicensePlate = "ABC-7775",
                            Name = "Ferrari - SF-23"
                        });
                });

            modelBuilder.Entity("EmployeeTrainingClass", b =>
                {
                    b.Property<int>("EmployeesId")
                        .HasColumnType("int");

                    b.Property<int>("TrainingClassesId")
                        .HasColumnType("int");

                    b.HasKey("EmployeesId", "TrainingClassesId");

                    b.HasIndex("TrainingClassesId");

                    b.ToTable("EmployeeTrainingClass");
                });

            modelBuilder.Entity("eCommerce.Office.EmployeeSection", b =>
                {
                    b.HasOne("eCommerce.Office.Employee", "Employee")
                        .WithMany("EmployeeSection")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eCommerce.Office.Section", "Section")
                        .WithMany("EmployeeSection")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("eCommerce.Office.EmployeeVehicle", b =>
                {
                    b.HasOne("eCommerce.Office.Employee", "Employee")
                        .WithMany("EmployeeVehicles")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eCommerce.Office.Vehicle", "Vehicle")
                        .WithMany("EmployeeVehicles")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("EmployeeTrainingClass", b =>
                {
                    b.HasOne("eCommerce.Office.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eCommerce.Office.TrainingClass", null)
                        .WithMany()
                        .HasForeignKey("TrainingClassesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("eCommerce.Office.Employee", b =>
                {
                    b.Navigation("EmployeeSection");

                    b.Navigation("EmployeeVehicles");
                });

            modelBuilder.Entity("eCommerce.Office.Section", b =>
                {
                    b.Navigation("EmployeeSection");
                });

            modelBuilder.Entity("eCommerce.Office.Vehicle", b =>
                {
                    b.Navigation("EmployeeVehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
