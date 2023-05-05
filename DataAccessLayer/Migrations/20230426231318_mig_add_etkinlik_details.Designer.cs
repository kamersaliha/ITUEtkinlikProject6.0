﻿// <auto-generated />
using System;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230426231318_mig_add_etkinlik_details")]
    partial class mig_add_etkinlik_details
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EntityLayer.Concrete.Etkinlik", b =>
                {
                    b.Property<int>("EtkinlikId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EtkinlikId"), 1L, 1);

                    b.Property<DateTime>("BaslangicTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BitisTarihi")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Durumu")
                        .HasColumnType("bit");

                    b.Property<string>("EtkinlikAciklamasi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EtkinlikAciklamasiKisa")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("EtkinlikAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("EtkinlikSorumlusu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KategoriId")
                        .HasColumnType("int");

                    b.Property<int>("KatilimciSayisi")
                        .HasColumnType("int");

                    b.Property<string>("Resim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SalonId")
                        .HasColumnType("int");

                    b.Property<bool>("UcretBilgisi")
                        .HasColumnType("bit");

                    b.HasKey("EtkinlikId");

                    b.HasIndex("KategoriId");

                    b.HasIndex("SalonId");

                    b.ToTable("Etkinlikler");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Iletisim", b =>
                {
                    b.Property<int>("IletisimId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IletisimId"), 1L, 1);

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Aciklama2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BirimAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Harita")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IletisimId");

                    b.ToTable("Iletisimler");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Kampus", b =>
                {
                    b.Property<int>("KampusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KampusId"), 1L, 1);

                    b.Property<string>("KampusAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("KampusId");

                    b.ToTable("Kampusler");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Kategori", b =>
                {
                    b.Property<int>("KategoriId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KategoriId"), 1L, 1);

                    b.Property<string>("KategoriAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("KategoriId");

                    b.ToTable("Kategoriler");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Salon", b =>
                {
                    b.Property<int>("SalonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SalonId"), 1L, 1);

                    b.Property<int>("KampusId")
                        .HasColumnType("int");

                    b.Property<string>("SalonAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SalonKapasitesi")
                        .HasColumnType("int");

                    b.HasKey("SalonId");

                    b.HasIndex("KampusId");

                    b.ToTable("Salonlar");
                });

            modelBuilder.Entity("EntityLayer.Concrete.YayinTalebi", b =>
                {
                    b.Property<int>("YayinTalebiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("YayinTalebiId"), 1L, 1);

                    b.Property<DateTime>("BaslangicTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BitisTarihi")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Durumu")
                        .HasColumnType("bit");

                    b.Property<string>("EtkinlikAciklamasi")
                        .IsRequired()
                        .HasColumnType("nvarchar(600)");

                    b.Property<string>("EtkinlikAciklamasiKisa")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("EtkinlikAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("EtkinlikSorumlusu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EtkinlikSorumlusuAciklamasi")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("EtkinlikYeriId")
                        .HasColumnType("int");

                    b.Property<int>("KategoriId")
                        .HasColumnType("int");

                    b.Property<int>("KatilimciSayisi")
                        .HasColumnType("int");

                    b.Property<string>("Resim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SalonlarSalonId")
                        .HasColumnType("int");

                    b.Property<bool>("UcretBilgisi")
                        .HasColumnType("bit");

                    b.HasKey("YayinTalebiId");

                    b.HasIndex("KategoriId");

                    b.HasIndex("SalonlarSalonId");

                    b.ToTable("YayinTalepleri");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Etkinlik", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Kategori", "Kategoriler")
                        .WithMany("Etkinlikler")
                        .HasForeignKey("KategoriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Salon", "Salonlar")
                        .WithMany("Etkinlikler")
                        .HasForeignKey("SalonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategoriler");

                    b.Navigation("Salonlar");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Salon", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Kampus", "Kampusler")
                        .WithMany("Salonlar")
                        .HasForeignKey("KampusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kampusler");
                });

            modelBuilder.Entity("EntityLayer.Concrete.YayinTalebi", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Kategori", "Kategoriler")
                        .WithMany()
                        .HasForeignKey("KategoriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Salon", "Salonlar")
                        .WithMany()
                        .HasForeignKey("SalonlarSalonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategoriler");

                    b.Navigation("Salonlar");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Kampus", b =>
                {
                    b.Navigation("Salonlar");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Kategori", b =>
                {
                    b.Navigation("Etkinlikler");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Salon", b =>
                {
                    b.Navigation("Etkinlikler");
                });
#pragma warning restore 612, 618
        }
    }
}
