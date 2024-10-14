﻿// <auto-generated />
using System;
using IMF.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IMF.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241013231047_HRModuleAddedToDB")]
    partial class HRModuleAddedToDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IMF.DAL.Identity.ApplicationRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSysAdmin")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("RoleDescription")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("IMF.DAL.Identity.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("GroupName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("IMF.DAL.Models.Common.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CompanyId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("CRNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FocalPerson")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ImageURL")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNo")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("LastModifiedBy");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("IMF.DAL.Models.HR.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("DepartmentName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("LastModifiedBy");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("IMF.DAL.Models.HR.Designation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("DesignationName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("LastModifiedBy");

                    b.ToTable("Designation");
                });

            modelBuilder.Entity("IMF.DAL.Models.HR.Documents", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("DisplayFileName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("UniqueFileName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("LastModifiedBy");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("IMF.DAL.Models.HR.Employees", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EmployeeId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<decimal?>("CurrentBasic")
                        .HasPrecision(18, 3)
                        .HasColumnType("decimal(18, 3)");

                    b.Property<DateOnly>("DateOfAppointment")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int?>("DesignationId")
                        .HasColumnType("int");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FullName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Gender")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("IDCardNo")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateOnly>("IDCardNoValidUntil")
                        .HasColumnType("date");

                    b.Property<string>("ImageURL")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("LoginId")
                        .HasColumnType("int");

                    b.Property<int?>("Nationality")
                        .HasColumnType("int");

                    b.Property<string>("PassportNo")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateOnly>("PassportValidUntil")
                        .HasColumnType("date");

                    b.Property<int?>("PayScaleId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("DesignationId");

                    b.HasIndex("LastModifiedBy");

                    b.HasIndex("PayScaleId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("IMF.DAL.Models.HR.JobHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateOnly>("DateFrom")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DateTo")
                        .HasColumnType("date");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("LastModifiedBy");

                    b.ToTable("JobHistory");
                });

            modelBuilder.Entity("IMF.DAL.Models.HR.PayScale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("PayScaleName")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("LastModifiedBy");

                    b.ToTable("PayScale");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("IMF.DAL.Models.Common.Company", b =>
                {
                    b.HasOne("IMF.DAL.Identity.ApplicationUser", "Created")
                        .WithMany("CompanyCreatedby")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("IMF.DAL.Identity.ApplicationUser", "Modified")
                        .WithMany("CompanyModifiedby")
                        .HasForeignKey("LastModifiedBy")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Created");

                    b.Navigation("Modified");
                });

            modelBuilder.Entity("IMF.DAL.Models.HR.Department", b =>
                {
                    b.HasOne("IMF.DAL.Identity.ApplicationUser", "Created")
                        .WithMany("DepartmentCreatedby")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("IMF.DAL.Identity.ApplicationUser", "Modified")
                        .WithMany("DepartmentModifiedby")
                        .HasForeignKey("LastModifiedBy")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Created");

                    b.Navigation("Modified");
                });

            modelBuilder.Entity("IMF.DAL.Models.HR.Designation", b =>
                {
                    b.HasOne("IMF.DAL.Identity.ApplicationUser", "Created")
                        .WithMany("DesignationCreatedby")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("IMF.DAL.Identity.ApplicationUser", "Modified")
                        .WithMany("DesignationModifiedby")
                        .HasForeignKey("LastModifiedBy")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Created");

                    b.Navigation("Modified");
                });

            modelBuilder.Entity("IMF.DAL.Models.HR.Documents", b =>
                {
                    b.HasOne("IMF.DAL.Identity.ApplicationUser", "Created")
                        .WithMany("DocumentCreatedby")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("IMF.DAL.Identity.ApplicationUser", "Modified")
                        .WithMany("DocumentModifiedby")
                        .HasForeignKey("LastModifiedBy")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Created");

                    b.Navigation("Modified");
                });

            modelBuilder.Entity("IMF.DAL.Models.HR.Employees", b =>
                {
                    b.HasOne("IMF.DAL.Identity.ApplicationUser", "Created")
                        .WithMany("EmployeeCreatedby")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("IMF.DAL.Models.HR.Department", "Department")
                        .WithMany("EmployeeId")
                        .HasForeignKey("DepartmentId");

                    b.HasOne("IMF.DAL.Models.HR.Designation", "Designation")
                        .WithMany("EmployeeId")
                        .HasForeignKey("DesignationId");

                    b.HasOne("IMF.DAL.Identity.ApplicationUser", "Modified")
                        .WithMany("EmployeeModifiedby")
                        .HasForeignKey("LastModifiedBy")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("IMF.DAL.Models.HR.PayScale", "PayScale")
                        .WithMany("EmployeeId")
                        .HasForeignKey("PayScaleId");

                    b.Navigation("Created");

                    b.Navigation("Department");

                    b.Navigation("Designation");

                    b.Navigation("Modified");

                    b.Navigation("PayScale");
                });

            modelBuilder.Entity("IMF.DAL.Models.HR.JobHistory", b =>
                {
                    b.HasOne("IMF.DAL.Identity.ApplicationUser", "Created")
                        .WithMany("JobHistoryCreatedby")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("IMF.DAL.Identity.ApplicationUser", "Modified")
                        .WithMany("JobHistoryModifiedby")
                        .HasForeignKey("LastModifiedBy")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Created");

                    b.Navigation("Modified");
                });

            modelBuilder.Entity("IMF.DAL.Models.HR.PayScale", b =>
                {
                    b.HasOne("IMF.DAL.Identity.ApplicationUser", "Created")
                        .WithMany("PayScaleCreatedby")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("IMF.DAL.Identity.ApplicationUser", "Modified")
                        .WithMany("PayScaleModifiedby")
                        .HasForeignKey("LastModifiedBy")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Created");

                    b.Navigation("Modified");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("IMF.DAL.Identity.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("IMF.DAL.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("IMF.DAL.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("IMF.DAL.Identity.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IMF.DAL.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("IMF.DAL.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IMF.DAL.Identity.ApplicationUser", b =>
                {
                    b.Navigation("CompanyCreatedby");

                    b.Navigation("CompanyModifiedby");

                    b.Navigation("DepartmentCreatedby");

                    b.Navigation("DepartmentModifiedby");

                    b.Navigation("DesignationCreatedby");

                    b.Navigation("DesignationModifiedby");

                    b.Navigation("DocumentCreatedby");

                    b.Navigation("DocumentModifiedby");

                    b.Navigation("EmployeeCreatedby");

                    b.Navigation("EmployeeModifiedby");

                    b.Navigation("JobHistoryCreatedby");

                    b.Navigation("JobHistoryModifiedby");

                    b.Navigation("PayScaleCreatedby");

                    b.Navigation("PayScaleModifiedby");
                });

            modelBuilder.Entity("IMF.DAL.Models.HR.Department", b =>
                {
                    b.Navigation("EmployeeId");
                });

            modelBuilder.Entity("IMF.DAL.Models.HR.Designation", b =>
                {
                    b.Navigation("EmployeeId");
                });

            modelBuilder.Entity("IMF.DAL.Models.HR.PayScale", b =>
                {
                    b.Navigation("EmployeeId");
                });
#pragma warning restore 612, 618
        }
    }
}
