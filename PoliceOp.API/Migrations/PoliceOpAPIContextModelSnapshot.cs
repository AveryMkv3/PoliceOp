﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PoliceOp.API.Data;

namespace PoliceOp.API.Migrations
{
    [DbContext(typeof(PoliceOpAPIContext))]
    partial class PoliceOpAPIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PoliceOp.Models.AvisRecherche", b =>
                {
                    b.Property<Guid>("UID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateEmission")
                        .HasColumnType("datetime2");

                    b.Property<string>("Informations")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonneRechercheePersonneId")
                        .HasColumnType("int");

                    b.Property<string>("StatutRecherche")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UID");

                    b.HasIndex("PersonneRechercheePersonneId");

                    b.ToTable("AvisRecherches");
                });

            modelBuilder.Entity("PoliceOp.Models.Biometrie", b =>
                {
                    b.Property<Guid>("UID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("DonneesDigitales")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("DonneesFaciales")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("UID");

                    b.ToTable("BioData");
                });

            modelBuilder.Entity("PoliceOp.Models.Diffusion", b =>
                {
                    b.Property<int>("DiffusionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Cible")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateDiffusion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sujet")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DiffusionId");

                    b.ToTable("Diffusions");
                });

            modelBuilder.Entity("PoliceOp.Models.Personne", b =>
                {
                    b.Property<int>("PersonneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid?>("BiometrieUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CouleurCheveux")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CouleurYeux")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IFU")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LieuNaissance")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MereId")
                        .HasColumnType("int");

                    b.Property<string>("NPI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationalite")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PereId")
                        .HasColumnType("int");

                    b.Property<string>("PersonnePhoto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Profession")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SignesParticuliers")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SituationMatrimoniale")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Taille")
                        .HasColumnType("float");

                    b.Property<string>("Teint")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonneId");

                    b.HasIndex("BiometrieUID");

                    b.ToTable("Personnes");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Personne");
                });

            modelBuilder.Entity("PoliceOp.Models.PieceJointe", b =>
                {
                    b.Property<Guid>("PieceJointeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("DiffusionId")
                        .HasColumnType("int");

                    b.Property<string>("ExtensionFichier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Fichier")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("NomFichier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PieceJointeId");

                    b.HasIndex("DiffusionId");

                    b.ToTable("PieceJointes");
                });

            modelBuilder.Entity("PoliceOp.Models.Requete", b =>
                {
                    b.Property<Guid>("UID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateRequete")
                        .HasColumnType("datetime2");

                    b.Property<string>("TermeRequete")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UID");

                    b.ToTable("Requetes");
                });

            modelBuilder.Entity("PoliceOp.Models.Residence", b =>
                {
                    b.Property<Guid>("ResidenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CoordonneesGeo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroChambre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroParcelle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonneId")
                        .HasColumnType("int");

                    b.Property<string>("Rue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ResidenceId");

                    b.HasIndex("PersonneId")
                        .IsUnique()
                        .HasFilter("[PersonneId] IS NOT NULL");

                    b.ToTable("Residences");
                });

            modelBuilder.Entity("PoliceOp.Models.Session", b =>
                {
                    b.Property<Guid>("SessionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SessionID");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("PoliceOp.Models.Agent", b =>
                {
                    b.HasBaseType("PoliceOp.Models.Personne");

                    b.Property<string>("Corps")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Grade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Matricule")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Agent");
                });

            modelBuilder.Entity("PoliceOp.Models.Operateur", b =>
                {
                    b.HasBaseType("PoliceOp.Models.Agent");

                    b.Property<string>("Service")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Operateur");
                });

            modelBuilder.Entity("PoliceOp.Models.AvisRecherche", b =>
                {
                    b.HasOne("PoliceOp.Models.Personne", "PersonneRecherchee")
                        .WithMany()
                        .HasForeignKey("PersonneRechercheePersonneId");
                });

            modelBuilder.Entity("PoliceOp.Models.Personne", b =>
                {
                    b.HasOne("PoliceOp.Models.Biometrie", "Biometrie")
                        .WithMany()
                        .HasForeignKey("BiometrieUID");
                });

            modelBuilder.Entity("PoliceOp.Models.PieceJointe", b =>
                {
                    b.HasOne("PoliceOp.Models.Diffusion", null)
                        .WithMany("PiecesJointes")
                        .HasForeignKey("DiffusionId");
                });

            modelBuilder.Entity("PoliceOp.Models.Residence", b =>
                {
                    b.HasOne("PoliceOp.Models.Personne", "Proprietaire")
                        .WithOne("Residence")
                        .HasForeignKey("PoliceOp.Models.Residence", "PersonneId");
                });
#pragma warning restore 612, 618
        }
    }
}
