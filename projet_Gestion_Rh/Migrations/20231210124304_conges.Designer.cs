﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using projet_Gestion_Rh.Models;

#nullable disable

namespace projet_Gestion_Rh.Migrations
{
    [DbContext(typeof(RhDBContext))]
    [Migration("20231210124304_conges")]
    partial class conges
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("projet_Gestion_Rh.Models.Departement", b =>
                {
                    b.Property<int>("DepartementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartementId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomResponsable")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartementId");

                    b.ToTable("Departements");
                });

            modelBuilder.Entity("projet_Gestion_Rh.Models.Employe", b =>
                {
                    b.Property<int>("EmployeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeId"));

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateEmbauche")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartementId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomPrenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PosteId")
                        .HasColumnType("int");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeId");

                    b.HasIndex("DepartementId");

                    b.HasIndex("PosteId");

                    b.ToTable("Employes");
                });

            modelBuilder.Entity("projet_Gestion_Rh.Models.Poste", b =>
                {
                    b.Property<int>("PosteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PosteId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("salaire")
                        .HasColumnType("int");

                    b.HasKey("PosteId");

                    b.ToTable("Postes");
                });

            modelBuilder.Entity("projet_Gestion_Rh.Models.Employe", b =>
                {
                    b.HasOne("projet_Gestion_Rh.Models.Departement", "Departement")
                        .WithMany("Employes")
                        .HasForeignKey("DepartementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("projet_Gestion_Rh.Models.Poste", "Poste")
                        .WithMany("Employes")
                        .HasForeignKey("PosteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departement");

                    b.Navigation("Poste");
                });

            modelBuilder.Entity("projet_Gestion_Rh.Models.Departement", b =>
                {
                    b.Navigation("Employes");
                });

            modelBuilder.Entity("projet_Gestion_Rh.Models.Poste", b =>
                {
                    b.Navigation("Employes");
                });
#pragma warning restore 612, 618
        }
    }
}
