﻿// <auto-generated />
using System;
using BonTemps.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BonTemps.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BonTemps.Models.Allergie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Allergeen")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.HasIndex("Allergeen")
                        .IsUnique();

                    b.ToTable("Allergien");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Allergeen = "Ei"
                        },
                        new
                        {
                            Id = 2,
                            Allergeen = "Gluten"
                        },
                        new
                        {
                            Id = 3,
                            Allergeen = "Melk"
                        },
                        new
                        {
                            Id = 4,
                            Allergeen = "Sezamzaad"
                        },
                        new
                        {
                            Id = 5,
                            Allergeen = "Noten"
                        },
                        new
                        {
                            Id = 6,
                            Allergeen = "Pindas"
                        },
                        new
                        {
                            Id = 7,
                            Allergeen = "Mosterd"
                        },
                        new
                        {
                            Id = 8,
                            Allergeen = "Vis"
                        });
                });

            modelBuilder.Entity("BonTemps.Models.BestelRegel", b =>
                {
                    b.Property<int>("DrankId")
                        .HasColumnType("int");

                    b.Property<int>("ReserveringId")
                        .HasColumnType("int");

                    b.Property<int>("Aantal")
                        .HasColumnType("int");

                    b.HasKey("DrankId", "ReserveringId");

                    b.HasIndex("ReserveringId");

                    b.ToTable("BestelRegels");
                });

            modelBuilder.Entity("BonTemps.Models.Drank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DrankSoortId")
                        .HasColumnType("int");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<double>("Prijs")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("DrankSoortId");

                    b.HasIndex("Naam")
                        .IsUnique();

                    b.ToTable("Dranken");
                });

            modelBuilder.Entity("BonTemps.Models.DrankSoort", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Soort")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.HasIndex("Soort")
                        .IsUnique();

                    b.ToTable("DrankSoorten");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Soort = "Alcohol"
                        },
                        new
                        {
                            Id = 2,
                            Soort = "Frisdrank"
                        },
                        new
                        {
                            Id = 3,
                            Soort = "Kinderdranken"
                        },
                        new
                        {
                            Id = 4,
                            Soort = "Overige"
                        });
                });

            modelBuilder.Entity("BonTemps.Models.Gerecht", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GerechtSoortId")
                        .HasColumnType("int");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.HasIndex("GerechtSoortId");

                    b.HasIndex("Naam")
                        .IsUnique();

                    b.ToTable("Gerechten");
                });

            modelBuilder.Entity("BonTemps.Models.GerechtIngredient", b =>
                {
                    b.Property<int>("GerechtId")
                        .HasColumnType("int");

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.Property<int>("Aantal")
                        .HasColumnType("int");

                    b.HasKey("GerechtId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("GerechtIngredienten");
                });

            modelBuilder.Entity("BonTemps.Models.GerechtSoort", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Soort")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.HasIndex("Soort")
                        .IsUnique();

                    b.ToTable("GerechtSoorten");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Soort = "Voorgerecht"
                        },
                        new
                        {
                            Id = 2,
                            Soort = "Hoofdgerecht"
                        },
                        new
                        {
                            Id = 3,
                            Soort = "Nagerecht"
                        },
                        new
                        {
                            Id = 4,
                            Soort = "Bijgerecht"
                        },
                        new
                        {
                            Id = 5,
                            Soort = "Desert"
                        });
                });

            modelBuilder.Entity("BonTemps.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AllergieId")
                        .HasColumnType("int");

                    b.Property<string>("Eenheid")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("VegetarischId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AllergieId");

                    b.HasIndex("Naam")
                        .IsUnique();

                    b.HasIndex("VegetarischId");

                    b.ToTable("Ingredienten");
                });

            modelBuilder.Entity("BonTemps.Models.Klant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adres")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("PostCode")
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("UserId")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Woonplaats")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.HasIndex("Naam");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Klanten");
                });

            modelBuilder.Entity("BonTemps.Models.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MenuSoortId")
                        .HasColumnType("int");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<decimal>("Prijs")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("MenuSoortId");

                    b.HasIndex("Naam")
                        .IsUnique();

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("BonTemps.Models.MenuGerecht", b =>
                {
                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<int>("GerechtId")
                        .HasColumnType("int");

                    b.HasKey("MenuId", "GerechtId");

                    b.HasIndex("GerechtId");

                    b.ToTable("MenuGerechten");
                });

            modelBuilder.Entity("BonTemps.Models.MenuSoort", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Soort")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.HasIndex("Soort")
                        .IsUnique();

                    b.ToTable("MenuSoorten");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Soort = "Lunch"
                        },
                        new
                        {
                            Id = 2,
                            Soort = "Dinner"
                        });
                });

            modelBuilder.Entity("BonTemps.Models.Reservering", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int>("KlantId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Tijd")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("KlantId");

                    b.ToTable("Reserveringen");
                });

            modelBuilder.Entity("BonTemps.Models.ReserveringMenu", b =>
                {
                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<int>("ReserveringId")
                        .HasColumnType("int");

                    b.Property<int>("Aantal")
                        .HasColumnType("int");

                    b.HasKey("MenuId", "ReserveringId");

                    b.HasIndex("ReserveringId");

                    b.ToTable("ReserveringMenus");
                });

            modelBuilder.Entity("BonTemps.Models.Vegetarisch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Soort")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.HasIndex("Soort")
                        .IsUnique();

                    b.ToTable("Vegetarisch");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Soort = "Vegetarier"
                        },
                        new
                        {
                            Id = 2,
                            Soort = "Veganist"
                        },
                        new
                        {
                            Id = 3,
                            Soort = "Flexitarier"
                        },
                        new
                        {
                            Id = 4,
                            Soort = "Pescotarier"
                        },
                        new
                        {
                            Id = 5,
                            Soort = "Pollotarier"
                        });
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

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

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

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
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

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
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

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BonTemps.Models.BestelRegel", b =>
                {
                    b.HasOne("BonTemps.Models.Drank", "Drank")
                        .WithMany("BestelRegels")
                        .HasForeignKey("DrankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BonTemps.Models.Reservering", "Reservering")
                        .WithMany("BestelRegels")
                        .HasForeignKey("ReserveringId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drank");

                    b.Navigation("Reservering");
                });

            modelBuilder.Entity("BonTemps.Models.Drank", b =>
                {
                    b.HasOne("BonTemps.Models.DrankSoort", "DrankSoort")
                        .WithMany()
                        .HasForeignKey("DrankSoortId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DrankSoort");
                });

            modelBuilder.Entity("BonTemps.Models.Gerecht", b =>
                {
                    b.HasOne("BonTemps.Models.GerechtSoort", "GerechtSoort")
                        .WithMany()
                        .HasForeignKey("GerechtSoortId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GerechtSoort");
                });

            modelBuilder.Entity("BonTemps.Models.GerechtIngredient", b =>
                {
                    b.HasOne("BonTemps.Models.Gerecht", "Gerecht")
                        .WithMany("GerechtIngredienten")
                        .HasForeignKey("GerechtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BonTemps.Models.Ingredient", "Ingredient")
                        .WithMany("GerechtIngredienten")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gerecht");

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("BonTemps.Models.Ingredient", b =>
                {
                    b.HasOne("BonTemps.Models.Allergie", "Allergie")
                        .WithMany()
                        .HasForeignKey("AllergieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BonTemps.Models.Vegetarisch", "Vegetarisch")
                        .WithMany()
                        .HasForeignKey("VegetarischId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Allergie");

                    b.Navigation("Vegetarisch");
                });

            modelBuilder.Entity("BonTemps.Models.Klant", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BonTemps.Models.Menu", b =>
                {
                    b.HasOne("BonTemps.Models.MenuSoort", "MenuSoort")
                        .WithMany()
                        .HasForeignKey("MenuSoortId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuSoort");
                });

            modelBuilder.Entity("BonTemps.Models.MenuGerecht", b =>
                {
                    b.HasOne("BonTemps.Models.Gerecht", "Gerecht")
                        .WithMany("MenuGerechten")
                        .HasForeignKey("GerechtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BonTemps.Models.Menu", "Menu")
                        .WithMany("MenuGerechten")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gerecht");

                    b.Navigation("Menu");
                });

            modelBuilder.Entity("BonTemps.Models.Reservering", b =>
                {
                    b.HasOne("BonTemps.Models.Klant", "Klant")
                        .WithMany()
                        .HasForeignKey("KlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Klant");
                });

            modelBuilder.Entity("BonTemps.Models.ReserveringMenu", b =>
                {
                    b.HasOne("BonTemps.Models.Menu", "Menu")
                        .WithMany("ReserveringMenus")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BonTemps.Models.Reservering", "Reservering")
                        .WithMany("ReserveringMenus")
                        .HasForeignKey("ReserveringId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");

                    b.Navigation("Reservering");
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

            modelBuilder.Entity("BonTemps.Models.Drank", b =>
                {
                    b.Navigation("BestelRegels");
                });

            modelBuilder.Entity("BonTemps.Models.Gerecht", b =>
                {
                    b.Navigation("GerechtIngredienten");

                    b.Navigation("MenuGerechten");
                });

            modelBuilder.Entity("BonTemps.Models.Ingredient", b =>
                {
                    b.Navigation("GerechtIngredienten");
                });

            modelBuilder.Entity("BonTemps.Models.Menu", b =>
                {
                    b.Navigation("MenuGerechten");

                    b.Navigation("ReserveringMenus");
                });

            modelBuilder.Entity("BonTemps.Models.Reservering", b =>
                {
                    b.Navigation("BestelRegels");

                    b.Navigation("ReserveringMenus");
                });
#pragma warning restore 612, 618
        }
    }
}
