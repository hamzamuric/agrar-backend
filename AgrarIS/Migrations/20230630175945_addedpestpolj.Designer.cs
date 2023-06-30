﻿// <auto-generated />
using System;
using AgrarIS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AgrarIS.Migrations
{
    [DbContext(typeof(AgrarISContext))]
    [Migration("20230630175945_addedpestpolj")]
    partial class addedpestpolj
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AgrarIS.Models.Korisnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("BrojTelefona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KorisnickoIme")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Lozinka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("OdobrenaRegistracija")
                        .HasColumnType("bit");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Pol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Korisnik");
                });

            modelBuilder.Entity("AgrarIS.Models.Parcela", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BrojParcele")
                        .HasColumnType("int");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<double>("Povrsina")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Parcela");
                });

            modelBuilder.Entity("AgrarIS.Models.Pesticid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pesticid");
                });

            modelBuilder.Entity("AgrarIS.Models.PoljoprivrednoDobro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DatumSadnice")
                        .HasColumnType("datetime2");

                    b.Property<double>("MaksimalniPotencijalDavanja")
                        .HasColumnType("float");

                    b.Property<double>("MinimalniPotencijalDavanja")
                        .HasColumnType("float");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sorta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VocnjakId")
                        .HasColumnType("int");

                    b.Property<int>("VremeSazrevanja")
                        .HasColumnType("int");

                    b.Property<int>("ZivotniVek")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PoljoprivrednoDobro");
                });

            modelBuilder.Entity("AgrarIS.Models.Sluzbenik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("BrojTelefona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KorisnickoIme")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Lozinka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StrucnaSprema")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sluzbenik");
                });

            modelBuilder.Entity("AgrarIS.Models.Subvencija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Odobrena")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Subvencija");
                });

            modelBuilder.Entity("AgrarIS.Models.Vocnjak", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ParcelaId")
                        .HasColumnType("int");

                    b.Property<int>("PoljoprivrednoDobroId")
                        .HasColumnType("int");

                    b.Property<string>("Tip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ParcelaId");

                    b.HasIndex("PoljoprivrednoDobroId")
                        .IsUnique();

                    b.ToTable("Vocnjak");
                });

            modelBuilder.Entity("PesticidPoljoprivrednoDobro", b =>
                {
                    b.Property<int>("PesticidisId")
                        .HasColumnType("int");

                    b.Property<int>("PoljoprivrednoDobrosId")
                        .HasColumnType("int");

                    b.HasKey("PesticidisId", "PoljoprivrednoDobrosId");

                    b.HasIndex("PoljoprivrednoDobrosId");

                    b.ToTable("PesticidPoljoprivrednoDobro");
                });

            modelBuilder.Entity("AgrarIS.Models.Vocnjak", b =>
                {
                    b.HasOne("AgrarIS.Models.Parcela", "Parcela")
                        .WithMany("Vocnjaks")
                        .HasForeignKey("ParcelaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgrarIS.Models.PoljoprivrednoDobro", "PoljoprivrednoDobro")
                        .WithOne("Vocnjak")
                        .HasForeignKey("AgrarIS.Models.Vocnjak", "PoljoprivrednoDobroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parcela");

                    b.Navigation("PoljoprivrednoDobro");
                });

            modelBuilder.Entity("PesticidPoljoprivrednoDobro", b =>
                {
                    b.HasOne("AgrarIS.Models.Pesticid", null)
                        .WithMany()
                        .HasForeignKey("PesticidisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgrarIS.Models.PoljoprivrednoDobro", null)
                        .WithMany()
                        .HasForeignKey("PoljoprivrednoDobrosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AgrarIS.Models.Parcela", b =>
                {
                    b.Navigation("Vocnjaks");
                });

            modelBuilder.Entity("AgrarIS.Models.PoljoprivrednoDobro", b =>
                {
                    b.Navigation("Vocnjak")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
