﻿// <auto-generated />
using System;
using EventScreen.Db.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EventScreen.WebUi.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("EventScreen.Db.Models.Settings.ActiveSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ActiveConfigId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ActiveConfigId");

                    b.ToTable("ActiveSettings");
                });

            modelBuilder.Entity("EventScreen.Db.Models.Settings.AlertSettings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("AlertSettings");
                });

            modelBuilder.Entity("EventScreen.Db.Models.Settings.ApiSettings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("GamesEndpoint")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ProgramEndpoint")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ApiSettings");
                });

            modelBuilder.Entity("EventScreen.Db.Models.Settings.EventConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EventAlertSettingsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EventApiSettingsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EventMarqueeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("EventScreensId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EventThemeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EventAlertSettingsId");

                    b.HasIndex("EventApiSettingsId");

                    b.HasIndex("EventMarqueeId");

                    b.HasIndex("EventScreensId");

                    b.HasIndex("EventThemeId");

                    b.ToTable("EventConfigs");
                });

            modelBuilder.Entity("EventScreen.Db.Models.Settings.Marquee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MarqueeSettingsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MarqueeSettingsId");

                    b.ToTable("Marquee");
                });

            modelBuilder.Entity("EventScreen.Db.Models.Settings.MarqueeSettings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Scroll")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("MarqueeSettings");
                });

            modelBuilder.Entity("EventScreen.Db.Models.Settings.ScheduledAlert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AlertMessage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("AlertSettingsId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AlertTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("AlertTitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AlertSettingsId");

                    b.ToTable("ScheduledAlert");
                });

            modelBuilder.Entity("EventScreen.Db.Models.Settings.Screen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DisplayTimeSeconds")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ScreenSettingsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ScreenSettingsId");

                    b.ToTable("Screens");
                });

            modelBuilder.Entity("EventScreen.Db.Models.Settings.ScreenSettings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("ScreenSettings");
                });

            modelBuilder.Entity("EventScreen.Db.Models.Settings.Theme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Background")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Primary")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Secondary")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ThemeName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Themes");
                });

            modelBuilder.Entity("EventScreen.Db.Models.Settings.ThemeSettings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurrentThemeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CurrentThemeId");

                    b.ToTable("ThemeSettings");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("EventScreen.Db.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("EventScreen.Db.Models.Settings.ActiveSetting", b =>
                {
                    b.HasOne("EventScreen.Db.Models.Settings.EventConfig", "ActiveConfig")
                        .WithMany()
                        .HasForeignKey("ActiveConfigId");

                    b.Navigation("ActiveConfig");
                });

            modelBuilder.Entity("EventScreen.Db.Models.Settings.EventConfig", b =>
                {
                    b.HasOne("EventScreen.Db.Models.Settings.AlertSettings", "EventAlertSettings")
                        .WithMany()
                        .HasForeignKey("EventAlertSettingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventScreen.Db.Models.Settings.ApiSettings", "EventApiSettings")
                        .WithMany()
                        .HasForeignKey("EventApiSettingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventScreen.Db.Models.Settings.MarqueeSettings", "EventMarquee")
                        .WithMany()
                        .HasForeignKey("EventMarqueeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventScreen.Db.Models.Settings.ScreenSettings", "EventScreens")
                        .WithMany()
                        .HasForeignKey("EventScreensId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventScreen.Db.Models.Settings.ThemeSettings", "EventTheme")
                        .WithMany()
                        .HasForeignKey("EventThemeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EventAlertSettings");

                    b.Navigation("EventApiSettings");

                    b.Navigation("EventMarquee");

                    b.Navigation("EventScreens");

                    b.Navigation("EventTheme");
                });

            modelBuilder.Entity("EventScreen.Db.Models.Settings.Marquee", b =>
                {
                    b.HasOne("EventScreen.Db.Models.Settings.MarqueeSettings", null)
                        .WithMany("Marquees")
                        .HasForeignKey("MarqueeSettingsId");
                });

            modelBuilder.Entity("EventScreen.Db.Models.Settings.ScheduledAlert", b =>
                {
                    b.HasOne("EventScreen.Db.Models.Settings.AlertSettings", null)
                        .WithMany("ScheduledAlerts")
                        .HasForeignKey("AlertSettingsId");
                });

            modelBuilder.Entity("EventScreen.Db.Models.Settings.Screen", b =>
                {
                    b.HasOne("EventScreen.Db.Models.Settings.ScreenSettings", null)
                        .WithMany("Screens")
                        .HasForeignKey("ScreenSettingsId");
                });

            modelBuilder.Entity("EventScreen.Db.Models.Settings.ThemeSettings", b =>
                {
                    b.HasOne("EventScreen.Db.Models.Settings.Theme", "CurrentTheme")
                        .WithMany()
                        .HasForeignKey("CurrentThemeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrentTheme");
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EventScreen.Db.Models.Settings.AlertSettings", b =>
                {
                    b.Navigation("ScheduledAlerts");
                });

            modelBuilder.Entity("EventScreen.Db.Models.Settings.MarqueeSettings", b =>
                {
                    b.Navigation("Marquees");
                });

            modelBuilder.Entity("EventScreen.Db.Models.Settings.ScreenSettings", b =>
                {
                    b.Navigation("Screens");
                });
#pragma warning restore 612, 618
        }
    }
}
