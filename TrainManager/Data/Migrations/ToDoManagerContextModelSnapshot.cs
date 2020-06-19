﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(ToDoManagerContext))]
    partial class ToDoManagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Entities.Line", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArrivalTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartureTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("From")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("To")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrainId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TrainId");

                    b.ToTable("Lines");
                });

            modelBuilder.Entity("Data.Entities.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("ArrivalTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Seat")
                        .HasColumnType("int");

                    b.Property<int?>("TrainId")
                        .HasColumnType("int");

                    b.Property<string>("TrainName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TrainId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Data.Entities.Train", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<bool>("Fast")
                        .HasColumnType("bit");

                    b.Property<int>("LineId")
                        .HasColumnType("int");

                    b.Property<int?>("LineId1")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LineId1");

                    b.ToTable("Trains");
                });

            modelBuilder.Entity("Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TrainId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TrainId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Administrator",
                            IsAdmin = true,
                            LastName = "Administrator",
                            Password = "adminpass",
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("Data.Entities.Line", b =>
                {
                    b.HasOne("Data.Entities.Train", "Train")
                        .WithMany("Lines")
                        .HasForeignKey("TrainId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Entities.Ticket", b =>
                {
                    b.HasOne("Data.Entities.User", "User")
                        .WithOne("Ticket")
                        .HasForeignKey("Data.Entities.Ticket", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Train", "Train")
                        .WithMany()
                        .HasForeignKey("TrainId");
                });

            modelBuilder.Entity("Data.Entities.Train", b =>
                {
                    b.HasOne("Data.Entities.Line", "Line")
                        .WithMany()
                        .HasForeignKey("LineId1");
                });

            modelBuilder.Entity("Data.Entities.User", b =>
                {
                    b.HasOne("Data.Entities.Train", null)
                        .WithMany("Passengers")
                        .HasForeignKey("TrainId");
                });
#pragma warning restore 612, 618
        }
    }
}
