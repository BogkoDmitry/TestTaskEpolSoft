﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TestTaskApi.Infrastructure.db;

#nullable disable

namespace TestTaskApi.Migrations
{
    [DbContext(typeof(TestTaskContext))]
    partial class TestTaskContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TestTaskApi.Entities.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("TestTaskApi.Entities.Patient", b =>
                {
                    b.OwnsOne("TestTaskApi.Entities.Patient+PatientName", "Name", b1 =>
                        {
                            b1.Property<Guid>("PatientId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Family")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string[]>("Given")
                                .IsRequired()
                                .HasColumnType("text[]");

                            b1.Property<string>("Use")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("PatientId");

                            b1.ToTable("Patients");

                            b1.WithOwner()
                                .HasForeignKey("PatientId");
                        });

                    b.Navigation("Name")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
