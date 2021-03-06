﻿// <auto-generated />
using Cars1._0.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cars_mn.Migrations
{
    [DbContext(typeof(CarContext))]
    [Migration("20210218082815_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cars_mn.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DealerId")
                        .HasColumnType("int");

                    b.Property<int>("EngineTypeId")
                        .HasColumnType("int");

                    b.Property<int>("ManufacturerId")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DealerId");

                    b.HasIndex("EngineTypeId");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Cars_mn.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Skeppshult"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Lidhem"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Trosa"
                        });
                });

            modelBuilder.Entity("Cars_mn.Models.Dealer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Dealers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            Name = "Skeppshults bilaffär"
                        },
                        new
                        {
                            Id = 2,
                            CityId = 2,
                            Name = "Lidhems bilaffär"
                        },
                        new
                        {
                            Id = 3,
                            CityId = 3,
                            Name = "Trosa bilaffär"
                        });
                });

            modelBuilder.Entity("Cars_mn.Models.EngineType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Fuel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EngineTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Fuel = "Gasoline"
                        },
                        new
                        {
                            Id = 2,
                            Fuel = "Diesel"
                        },
                        new
                        {
                            Id = 3,
                            Fuel = "Electric"
                        });
                });

            modelBuilder.Entity("Cars_mn.Models.Manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ManufacturerName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerName")
                        .IsUnique();

                    b.ToTable("Manufacturers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ManufacturerName = "Bmw"
                        },
                        new
                        {
                            Id = 2,
                            ManufacturerName = "Volvo"
                        },
                        new
                        {
                            Id = 3,
                            ManufacturerName = "Skoda"
                        },
                        new
                        {
                            Id = 4,
                            ManufacturerName = "Mazda"
                        });
                });

            modelBuilder.Entity("Cars_mn.Models.Car", b =>
                {
                    b.HasOne("Cars_mn.Models.Dealer", "Dealer")
                        .WithMany("Cars")
                        .HasForeignKey("DealerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cars_mn.Models.EngineType", "EngineType")
                        .WithMany()
                        .HasForeignKey("EngineTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cars_mn.Models.Manufacturer", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dealer");

                    b.Navigation("EngineType");

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("Cars_mn.Models.Dealer", b =>
                {
                    b.HasOne("Cars_mn.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Cars_mn.Models.Dealer", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
