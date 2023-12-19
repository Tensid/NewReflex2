﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reflex.Data;

#nullable disable

namespace Reflex.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231219170357_iipax")]
    partial class iipax
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AgsConfigConfig", b =>
                {
                    b.Property<Guid>("AgsConfigsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ConfigsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AgsConfigsId", "ConfigsId");

                    b.HasIndex("ConfigsId");

                    b.ToTable("AgsConfigConfig");
                });

            modelBuilder.Entity("ByggrConfigConfig", b =>
                {
                    b.Property<Guid>("ByggrConfigsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ConfigsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ByggrConfigsId", "ConfigsId");

                    b.HasIndex("ConfigsId");

                    b.ToTable("ByggrConfigConfig");
                });

            modelBuilder.Entity("ConfigEcosConfig", b =>
                {
                    b.Property<Guid>("ConfigsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EcosConfigsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ConfigsId", "EcosConfigsId");

                    b.HasIndex("EcosConfigsId");

                    b.ToTable("ConfigEcosConfig");
                });

            modelBuilder.Entity("ConfigIipaxConfig", b =>
                {
                    b.Property<Guid>("ConfigsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IipaxConfigsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ConfigsId", "IipaxConfigsId");

                    b.HasIndex("IipaxConfigsId");

                    b.ToTable("ConfigIipaxConfig");
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.DeviceFlowCodes", b =>
                {
                    b.Property<string>("UserCode")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasMaxLength(50000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("DeviceCode")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("Expiration")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("SessionId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SubjectId")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("UserCode");

                    b.HasIndex("DeviceCode")
                        .IsUnique();

                    b.HasIndex("Expiration");

                    b.ToTable("DeviceCodes", (string)null);
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.Key", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Algorithm")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("DataProtected")
                        .HasColumnType("bit");

                    b.Property<bool>("IsX509Certificate")
                        .HasColumnType("bit");

                    b.Property<string>("Use")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Use");

                    b.ToTable("Keys");
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.PersistedGrant", b =>
                {
                    b.Property<string>("Key")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("ConsumedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasMaxLength(50000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("Expiration")
                        .HasColumnType("datetime2");

                    b.Property<string>("SessionId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SubjectId")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Key");

                    b.HasIndex("ConsumedTime");

                    b.HasIndex("Expiration");

                    b.HasIndex("SubjectId", "ClientId", "Type");

                    b.HasIndex("SubjectId", "SessionId", "Type");

                    b.ToTable("PersistedGrants", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Reflex.Data.Models.AgsConfig", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CasePattern")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateField")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentPattern")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EstateNameSearch")
                        .HasColumnType("bit");

                    b.Property<string>("Instance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SearchWay")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AgsConfigs");
                });

            modelBuilder.Entity("Reflex.Data.Models.AgsSettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ServiceUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AgsSettings");
                });

            modelBuilder.Entity("Reflex.Data.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("DefaultConfigId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DefaultTab")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("\"Cases\"");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

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

                    b.HasIndex("DefaultConfigId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Reflex.Data.Models.ByggrConfig", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Diarieprefixes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentTypes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HideCasesWithTextMatching")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HideConfidentialOccurences")
                        .HasColumnType("int");

                    b.Property<string>("HideDocumentsWithNoteTextMatching")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HideNotesInPreview")
                        .HasColumnType("bit");

                    b.Property<string>("HideOccurencesWithTextMatching")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("MinCaseStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OccurenceTypes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("OnlyActiveCases")
                        .HasColumnType("bit");

                    b.Property<bool>("OnlyCasesWithoutMainDecision")
                        .HasColumnType("bit");

                    b.Property<string>("PersonRoles")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Statuses")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tabs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("WorkingMaterial")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("ByggrConfigs");
                });

            modelBuilder.Entity("Reflex.Data.Models.ByggrSettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ByggrSettings");
                });

            modelBuilder.Entity("Reflex.Data.Models.Config", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(0);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Map")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tabs")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Configs");
                });

            modelBuilder.Entity("Reflex.Data.Models.EcosConfig", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DocumentTypes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HideConfidentialCases")
                        .HasColumnType("int");

                    b.Property<int>("HideConfidentialDocuments")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OccurrenceTypes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProcessTypes")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EcosConfigs");
                });

            modelBuilder.Entity("Reflex.Data.Models.EcosSettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EcosSettings");
                });

            modelBuilder.Entity("Reflex.Data.Models.FbSettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FbServiceDatabase")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FbServicePassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FbServiceUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FbServiceUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FbWebbBoendeUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FbWebbByggnadUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FbWebbByggnadUsrUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FbWebbFastighetUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FbWebbFastighetUsrUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FbWebbLagenhetUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FbSettings");
                });

            modelBuilder.Entity("Reflex.Data.Models.IipaxConfig", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CaseOtherSecrecyVisibility")
                        .HasColumnType("int");

                    b.Property<int>("CasePulPersonalSecrecyVisibility")
                        .HasColumnType("int");

                    b.Property<int>("CaseSecrecyVisibility")
                        .HasColumnType("int");

                    b.Property<int>("DocOtherSecrecyVisibility")
                        .HasColumnType("int");

                    b.Property<int>("DocPulPersonalSecrecyVisibility")
                        .HasColumnType("int");

                    b.Property<int>("DocSecrecyVisibility")
                        .HasColumnType("int");

                    b.Property<int>("FileOtherSecrecyVisibility")
                        .HasColumnType("int");

                    b.Property<int>("FilePulPersonalSecrecyVisibility")
                        .HasColumnType("int");

                    b.Property<int>("FileSecrecyVisibility")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ObjectTypes")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IipaxConfigs");
                });

            modelBuilder.Entity("Reflex.Data.Models.IipaxSettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ServiceUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IipaxSettings");
                });

            modelBuilder.Entity("AgsConfigConfig", b =>
                {
                    b.HasOne("Reflex.Data.Models.AgsConfig", null)
                        .WithMany()
                        .HasForeignKey("AgsConfigsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Reflex.Data.Models.Config", null)
                        .WithMany()
                        .HasForeignKey("ConfigsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ByggrConfigConfig", b =>
                {
                    b.HasOne("Reflex.Data.Models.ByggrConfig", null)
                        .WithMany()
                        .HasForeignKey("ByggrConfigsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Reflex.Data.Models.Config", null)
                        .WithMany()
                        .HasForeignKey("ConfigsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ConfigEcosConfig", b =>
                {
                    b.HasOne("Reflex.Data.Models.Config", null)
                        .WithMany()
                        .HasForeignKey("ConfigsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Reflex.Data.Models.EcosConfig", null)
                        .WithMany()
                        .HasForeignKey("EcosConfigsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ConfigIipaxConfig", b =>
                {
                    b.HasOne("Reflex.Data.Models.Config", null)
                        .WithMany()
                        .HasForeignKey("ConfigsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Reflex.Data.Models.IipaxConfig", null)
                        .WithMany()
                        .HasForeignKey("IipaxConfigsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Reflex.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Reflex.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Reflex.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Reflex.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Reflex.Data.Models.ApplicationUser", b =>
                {
                    b.HasOne("Reflex.Data.Models.Config", "DefaultConfig")
                        .WithMany("ApplicationUserDefaultConfig")
                        .HasForeignKey("DefaultConfigId");

                    b.Navigation("DefaultConfig");
                });

            modelBuilder.Entity("Reflex.Data.Models.Config", b =>
                {
                    b.Navigation("ApplicationUserDefaultConfig");
                });
#pragma warning restore 612, 618
        }
    }
}
