﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using shelter.DataBaseContext.ShelterDbContext;

#nullable disable

namespace shelter.Migrations.ShelterDb
{
    [DbContext(typeof(ShelterDbContext))]
    [Migration("20231018215134_NullableAccept")]
    partial class NullableAccept
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

                    b.Property<bool>("PropertySize")
                        .HasColumnType("bit");

                    b.Property<int>("ShelterModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShelterModelId");

                    b.ToTable("ShelterQuestionsResidence");
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

            modelBuilder.Entity("shelter.Models.ShelterModels.ShelterModel", b =>
                {
                    b.Navigation("ShelterHabbits");

                    b.Navigation("ShelterPetDetails");

                    b.Navigation("ShelterResidence");
                });
#pragma warning restore 612, 618
        }
    }
}
