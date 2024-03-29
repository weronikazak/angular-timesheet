﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TimeSheet.API.Data;

namespace timesheet.api.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("TimeSheet.API.Data.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompanyId");

                    b.Property<string>("ProjectName");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("TimeSheet.API.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email");

                    b.Property<string>("Gender");

                    b.Property<DateTime>("LastActive");

                    b.Property<string>("Name");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TimeSheet.API.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyName");

                    b.Property<string>("KodPocztowy");

                    b.Property<string>("Miasto");

                    b.Property<int>("PhoneNumber");

                    b.Property<string>("PrzedstawicielImie");

                    b.Property<string>("PrzedstawicielNazwisko");

                    b.Property<string>("Ulica");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("TimeSheet.API.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RoleName");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("TimeSheet.API.Models.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ProjectId");

                    b.Property<int>("RoleId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("TimeSheet.API.Data.Project", b =>
                {
                    b.HasOne("TimeSheet.API.Models.Company", "Company")
                        .WithMany("Projects")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TimeSheet.API.Models.Worker", b =>
                {
                    b.HasOne("TimeSheet.API.Data.Project", "Project")
                        .WithMany("Workers")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TimeSheet.API.Models.Role", "Role")
                        .WithMany("Workers")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TimeSheet.API.Data.User", "User")
                        .WithMany("Workers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
