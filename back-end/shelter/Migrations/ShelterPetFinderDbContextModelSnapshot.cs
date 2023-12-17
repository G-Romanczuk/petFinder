﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using shelter.DataBaseContext.ShelterPetFinderDbContext;

#nullable disable

namespace shelter.Migrations
{
    [DbContext(typeof(ShelterPetFinderDbContext))]
    partial class ShelterPetFinderDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("shelter.Models.PetModels.PetImg", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("Images")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("PetModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PetModelId");

                    b.ToTable("PetImgs");
                });

            modelBuilder.Entity("shelter.Models.PetModels.PetModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Activity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Age")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BasicTraining")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Breed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Castration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChildFriendly")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cuddly")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtherCats")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtherDogs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShelterModelId")
                        .HasColumnType("int");

                    b.Property<string>("Size")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Temper")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vaccination")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ShelterModelId");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("shelter.Models.ShelterModels.ShelterHabbitsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("HoursAlone")
                        .HasColumnType("bit");

                    b.Property<bool>("Lifestyle")
                        .HasColumnType("bit");

                    b.Property<int>("ShelterModelId")
                        .HasColumnType("int");

                    b.Property<bool>("Text")
                        .HasColumnType("bit");

                    b.Property<bool>("WalksNumber")
                        .HasColumnType("bit");

                    b.Property<bool>("WalksTime")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ShelterModelId");

                    b.ToTable("ShelterQuestionsHabbits");
                });

            modelBuilder.Entity("shelter.Models.ShelterModels.ShelterModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Town")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Shelters");
                });

            modelBuilder.Entity("shelter.Models.ShelterModels.ShelterPetDetailsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("AnimalsBefore")
                        .HasColumnType("bit");

                    b.Property<bool>("AnimalsBeforeText")
                        .HasColumnType("bit");

                    b.Property<bool>("CareAlone")
                        .HasColumnType("bit");

                    b.Property<bool>("PetPlace")
                        .HasColumnType("bit");

                    b.Property<bool>("PetPlaceAlone")
                        .HasColumnType("bit");

                    b.Property<int>("ShelterModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShelterModelId");

                    b.ToTable("ShelterQuestionsPetDetails");
                });

            modelBuilder.Entity("shelter.Models.ShelterModels.ShelterResidenceModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Animals")
                        .HasColumnType("bit");

                    b.Property<bool>("Elevator")
                        .HasColumnType("bit");

                    b.Property<bool>("Fence")
                        .HasColumnType("bit");

                    b.Property<bool>("FenceHeight")
                        .HasColumnType("bit");

                    b.Property<bool>("Floor")
                        .HasColumnType("bit");

                    b.Property<bool>("HouseMates")
                        .HasColumnType("bit");

                    b.Property<bool>("HouseOwner")
                        .HasColumnType("bit");

                    b.Property<bool>("HousingType")
                        .HasColumnType("bit");

                    b.Property<bool>("IncomeSource")
                        .HasColumnType("bit");

                    b.Property<bool>("PropertySize")
                        .HasColumnType("bit");

                    b.Property<int>("ShelterModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShelterModelId");

                    b.ToTable("ShelterQuestionsResidence");
                });

            modelBuilder.Entity("shelter.Models.UserModels.UserHabbitsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HoursAlone")
                        .HasColumnType("int");

                    b.Property<string>("Lifestyle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserModelId")
                        .HasColumnType("int");

                    b.Property<int>("WalksNumber")
                        .HasColumnType("int");

                    b.Property<int>("WalksTime")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserModelId");

                    b.ToTable("UserQuestionsHabbits");
                });

            modelBuilder.Entity("shelter.Models.UserModels.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IncomeSource")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Terms")
                        .HasColumnType("bit");

                    b.Property<string>("Town")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UsersRegistered");
                });

            modelBuilder.Entity("shelter.Models.UserModels.UserResidenceModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Animals")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Elevator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fence")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FenceHeight")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Floor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouseMates")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouseOwner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HousingType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertySize")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserModelId");

                    b.ToTable("UserQuestionsResidence");
                });

            modelBuilder.Entity("shelter.Models.UserModels.UsersDogDetailsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AnimalsBefore")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnimalsBeforeText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CareAlone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PetPlace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PetPlaceAlone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserModelId");

                    b.ToTable("UserQuestionsPetDetails");
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

            modelBuilder.Entity("shelter.Models.PetModels.PetImg", b =>
                {
                    b.HasOne("shelter.Models.PetModels.PetModel", "PetModel")
                        .WithMany("PetImg")
                        .HasForeignKey("PetModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PetModel");
                });

            modelBuilder.Entity("shelter.Models.PetModels.PetModel", b =>
                {
                    b.HasOne("shelter.Models.ShelterModels.ShelterModel", "ShelterModel")
                        .WithMany("Pets")
                        .HasForeignKey("ShelterModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShelterModel");
                });

            modelBuilder.Entity("shelter.Models.ShelterModels.ShelterHabbitsModel", b =>
                {
                    b.HasOne("shelter.Models.ShelterModels.ShelterModel", "ShelterModel")
                        .WithMany("ShelterHabbits")
                        .HasForeignKey("ShelterModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShelterModel");
                });

            modelBuilder.Entity("shelter.Models.ShelterModels.ShelterPetDetailsModel", b =>
                {
                    b.HasOne("shelter.Models.ShelterModels.ShelterModel", "ShelterModel")
                        .WithMany("ShelterPetDetails")
                        .HasForeignKey("ShelterModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShelterModel");
                });

            modelBuilder.Entity("shelter.Models.ShelterModels.ShelterResidenceModel", b =>
                {
                    b.HasOne("shelter.Models.ShelterModels.ShelterModel", "ShelterModel")
                        .WithMany("ShelterResidence")
                        .HasForeignKey("ShelterModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShelterModel");
                });

            modelBuilder.Entity("shelter.Models.UserModels.UserHabbitsModel", b =>
                {
                    b.HasOne("shelter.Models.UserModels.UserModel", "UserModel")
                        .WithMany("UserHabbits")
                        .HasForeignKey("UserModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserModel");
                });

            modelBuilder.Entity("shelter.Models.UserModels.UserResidenceModel", b =>
                {
                    b.HasOne("shelter.Models.UserModels.UserModel", "UserModel")
                        .WithMany("UserResidence")
                        .HasForeignKey("UserModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserModel");
                });

            modelBuilder.Entity("shelter.Models.UserModels.UsersDogDetailsModel", b =>
                {
                    b.HasOne("shelter.Models.UserModels.UserModel", "UserModel")
                        .WithMany("usersDogDetails")
                        .HasForeignKey("UserModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserModel");
                });

            modelBuilder.Entity("shelter.Models.PetModels.PetModel", b =>
                {
                    b.Navigation("PetImg");
                });

            modelBuilder.Entity("shelter.Models.ShelterModels.ShelterModel", b =>
                {
                    b.Navigation("Pets");

                    b.Navigation("ShelterHabbits");

                    b.Navigation("ShelterPetDetails");

                    b.Navigation("ShelterResidence");
                });

            modelBuilder.Entity("shelter.Models.UserModels.UserModel", b =>
                {
                    b.Navigation("UserHabbits");

                    b.Navigation("UserResidence");

                    b.Navigation("usersDogDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
