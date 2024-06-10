﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyProject.DataAccess.Context;

#nullable disable

namespace MyProject.DataAccess.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20240609125916_AddUserRoleStaticClassForHasData")]
    partial class AddUserRoleStaticClassForHasData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyProject.DataAccess.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            InsertDate = new DateTime(2024, 6, 9, 16, 29, 15, 109, DateTimeKind.Local).AddTicks(8131),
                            IsDeleted = false,
                            Title = "Admin",
                            UpdateTime = new DateTime(2024, 6, 9, 16, 29, 15, 109, DateTimeKind.Local).AddTicks(8141)
                        },
                        new
                        {
                            Id = 2,
                            InsertDate = new DateTime(2024, 6, 9, 16, 29, 15, 109, DateTimeKind.Local).AddTicks(8214),
                            IsDeleted = false,
                            Title = "Operator",
                            UpdateTime = new DateTime(2024, 6, 9, 16, 29, 15, 109, DateTimeKind.Local).AddTicks(8215)
                        });
                });

            modelBuilder.Entity("MyProject.DataAccess.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MyProject.DataAccess.Entities.Users_Roles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("Users_Roles");
                });

            modelBuilder.Entity("MyProject.DataAccess.Entities.Users_Roles", b =>
                {
                    b.HasOne("MyProject.DataAccess.Entities.Role", "Role")
                        .WithMany("Users_Roles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MyProject.DataAccess.Entities.User", "User")
                        .WithMany("Users_Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyProject.DataAccess.Entities.Role", b =>
                {
                    b.Navigation("Users_Roles");
                });

            modelBuilder.Entity("MyProject.DataAccess.Entities.User", b =>
                {
                    b.Navigation("Users_Roles");
                });
#pragma warning restore 612, 618
        }
    }
}
