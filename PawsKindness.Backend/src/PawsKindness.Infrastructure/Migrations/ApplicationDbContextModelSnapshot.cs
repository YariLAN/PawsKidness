﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PawsKindness.Infrastructure;

#nullable disable

namespace PawsKindness.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PawsKindness.Domain.Models.Species.Breeds.Breed", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<Guid?>("species_id")
                        .HasColumnType("uuid")
                        .HasColumnName("species_id");

                    b.HasKey("Id")
                        .HasName("pk_breeds");

                    b.HasIndex("species_id")
                        .HasDatabaseName("ix_breeds_species_id");

                    b.ToTable("breeds", (string)null);
                });

            modelBuilder.Entity("PawsKindness.Domain.Models.Species.Species", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_species");

                    b.ToTable("species", (string)null);
                });

            modelBuilder.Entity("PawsKindness.Domain.Models.Volunteers.Pets.Pet", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateOnly?>("BirthDay")
                        .HasColumnType("date")
                        .HasColumnName("birth_day");

                    b.Property<string>("Color")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("color");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .HasMaxLength(800)
                        .HasColumnType("character varying(800)")
                        .HasColumnName("description");

                    b.Property<string>("HealthInfo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("health_info");

                    b.Property<double>("Height")
                        .HasColumnType("double precision")
                        .HasColumnName("height");

                    b.Property<int>("HelpStatus")
                        .HasColumnType("integer")
                        .HasColumnName("help_status");

                    b.Property<bool>("IsCastrated")
                        .HasColumnType("boolean")
                        .HasColumnName("is_castrated");

                    b.Property<bool>("IsVaccinated")
                        .HasColumnType("boolean")
                        .HasColumnName("is_vaccinated");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision")
                        .HasColumnName("weight");

                    b.Property<Guid?>("volunteer_id")
                        .HasColumnType("uuid")
                        .HasColumnName("volunteer_id");

                    b.ComplexProperty<Dictionary<string, object>>("Address", "PawsKindness.Domain.Models.Volunteers.Pets.Pet.Address#Address", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Apartment")
                                .HasMaxLength(20)
                                .HasColumnType("character varying(20)")
                                .HasColumnName("address_apartment");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("address_city");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("address_country");

                            b1.Property<string>("HouseNumber")
                                .HasMaxLength(20)
                                .HasColumnType("character varying(20)")
                                .HasColumnName("address_house_number");

                            b1.Property<int>("PostCode")
                                .HasColumnType("integer")
                                .HasColumnName("address_post_code");

                            b1.Property<string>("Street")
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("address_street");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("PhoneNumber", "PawsKindness.Domain.Models.Volunteers.Pets.Pet.PhoneNumber#PhoneNumber", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("phone_number_value");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("Type", "PawsKindness.Domain.Models.Volunteers.Pets.Pet.Type#Type", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<Guid>("BreedId")
                                .HasColumnType("uuid")
                                .HasColumnName("type_breed_id");

                            b1.Property<Guid>("SpeciesId")
                                .HasColumnType("uuid")
                                .HasColumnName("type_species_id");
                        });

                    b.HasKey("Id")
                        .HasName("pk_pets");

                    b.HasIndex("volunteer_id")
                        .HasDatabaseName("ix_pets_volunteer_id");

                    b.ToTable("pets", (string)null);
                });

            modelBuilder.Entity("PawsKindness.Domain.Models.Volunteers.Pets.PetPhoto", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("IsMain")
                        .HasColumnType("boolean")
                        .HasColumnName("is_main");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("path");

                    b.Property<Guid?>("pet_id")
                        .HasColumnType("uuid")
                        .HasColumnName("pet_id");

                    b.HasKey("Id")
                        .HasName("pk_pet_photos");

                    b.HasIndex("pet_id")
                        .HasDatabaseName("ix_pet_photos_pet_id");

                    b.ToTable("pet_photos", (string)null);
                });

            modelBuilder.Entity("PawsKindness.Domain.Models.Volunteers.Volunteer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .HasMaxLength(800)
                        .HasColumnType("character varying(800)")
                        .HasColumnName("description");

                    b.Property<int>("YearsExperience")
                        .HasColumnType("integer")
                        .HasColumnName("years_experience");

                    b.ComplexProperty<Dictionary<string, object>>("Name", "PawsKindness.Domain.Models.Volunteers.Volunteer.Name#FullName", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("MiddleName")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("name_middle_name");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("name_name");

                            b1.Property<string>("Surname")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("name_surname");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("PhoneNumber", "PawsKindness.Domain.Models.Volunteers.Volunteer.PhoneNumber#PhoneNumber", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("phone_number_value");
                        });

                    b.HasKey("Id")
                        .HasName("pk_volunteers");

                    b.ToTable("volunteers", (string)null);
                });

            modelBuilder.Entity("PawsKindness.Domain.Models.Species.Breeds.Breed", b =>
                {
                    b.HasOne("PawsKindness.Domain.Models.Species.Species", null)
                        .WithMany("Breeds")
                        .HasForeignKey("species_id")
                        .HasConstraintName("fk_breeds_species_species_id");
                });

            modelBuilder.Entity("PawsKindness.Domain.Models.Volunteers.Pets.Pet", b =>
                {
                    b.HasOne("PawsKindness.Domain.Models.Volunteers.Volunteer", null)
                        .WithMany("Pets")
                        .HasForeignKey("volunteer_id")
                        .HasConstraintName("fk_pets_volunteers_volunteer_id");

                    b.OwnsOne("PawsKindness.Domain.Models.Volunteers.Pets.PetDetails", "Details", b1 =>
                        {
                            b1.Property<Guid>("PetId")
                                .HasColumnType("uuid");

                            b1.HasKey("PetId");

                            b1.ToTable("pets");

                            b1.ToJson("details");

                            b1.WithOwner()
                                .HasForeignKey("PetId")
                                .HasConstraintName("fk_pets_pets_id");

                            b1.OwnsMany("PawsKindness.Domain.Models.Volunteers.Requisite", "Requisites", b2 =>
                                {
                                    b2.Property<Guid>("PetDetailsPetId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("integer");

                                    b2.Property<string>("Description")
                                        .HasMaxLength(800)
                                        .HasColumnType("character varying(800)");

                                    b2.HasKey("PetDetailsPetId", "Id");

                                    b2.ToTable("pets");

                                    b2.ToJson("details");

                                    b2.WithOwner()
                                        .HasForeignKey("PetDetailsPetId")
                                        .HasConstraintName("fk_pets_pets_pet_details_pet_id");
                                });

                            b1.Navigation("Requisites");
                        });

                    b.Navigation("Details");
                });

            modelBuilder.Entity("PawsKindness.Domain.Models.Volunteers.Pets.PetPhoto", b =>
                {
                    b.HasOne("PawsKindness.Domain.Models.Volunteers.Pets.Pet", null)
                        .WithMany("Photos")
                        .HasForeignKey("pet_id")
                        .HasConstraintName("fk_pet_photos_pets_pet_id");
                });

            modelBuilder.Entity("PawsKindness.Domain.Models.Volunteers.Volunteer", b =>
                {
                    b.OwnsOne("PawsKindness.Domain.Models.Volunteers.VolunteerDetails", "Details", b1 =>
                        {
                            b1.Property<Guid>("VolunteerId")
                                .HasColumnType("uuid");

                            b1.HasKey("VolunteerId");

                            b1.ToTable("volunteers");

                            b1.ToJson("details");

                            b1.WithOwner()
                                .HasForeignKey("VolunteerId")
                                .HasConstraintName("fk_volunteers_volunteers_id");

                            b1.OwnsMany("PawsKindness.Domain.Models.Volunteers.SocialNetwork", "SocialNetworks", b2 =>
                                {
                                    b2.Property<Guid>("VolunteerDetailsVolunteerId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("integer");

                                    b2.Property<string>("Name")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("character varying(100)");

                                    b2.HasKey("VolunteerDetailsVolunteerId", "Id");

                                    b2.ToTable("volunteers");

                                    b2.ToJson("details");

                                    b2.WithOwner()
                                        .HasForeignKey("VolunteerDetailsVolunteerId")
                                        .HasConstraintName("fk_volunteers_volunteers_volunteer_details_volunteer_id");
                                });

                            b1.OwnsMany("PawsKindness.Domain.Models.Volunteers.Requisite", "Requisites", b2 =>
                                {
                                    b2.Property<Guid>("VolunteerDetailsVolunteerId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("integer");

                                    b2.Property<string>("Description")
                                        .HasMaxLength(800)
                                        .HasColumnType("character varying(800)");

                                    b2.Property<string>("Name")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("character varying(100)");

                                    b2.HasKey("VolunteerDetailsVolunteerId", "Id");

                                    b2.ToTable("volunteers");

                                    b2.ToJson("details");

                                    b2.WithOwner()
                                        .HasForeignKey("VolunteerDetailsVolunteerId")
                                        .HasConstraintName("fk_volunteers_volunteers_volunteer_details_volunteer_id");
                                });

                            b1.Navigation("Requisites");

                            b1.Navigation("SocialNetworks");
                        });

                    b.Navigation("Details");
                });

            modelBuilder.Entity("PawsKindness.Domain.Models.Species.Species", b =>
                {
                    b.Navigation("Breeds");
                });

            modelBuilder.Entity("PawsKindness.Domain.Models.Volunteers.Pets.Pet", b =>
                {
                    b.Navigation("Photos");
                });

            modelBuilder.Entity("PawsKindness.Domain.Models.Volunteers.Volunteer", b =>
                {
                    b.Navigation("Pets");
                });
#pragma warning restore 612, 618
        }
    }
}
