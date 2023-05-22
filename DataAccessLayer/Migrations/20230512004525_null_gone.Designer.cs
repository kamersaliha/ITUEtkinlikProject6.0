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
    [Migration("20230512004525_null_gone")]
    partial class null_gone
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EntityLayer.Concrete.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

            modelBuilder.Entity("EntityLayer.Concrete.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("Soyad")
                        .IsRequired()
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

                    b.Property<int>("Durumu")
                        .HasColumnType("int");

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

                    b.Property<string>("UcretBilgisi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("BaslangicTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("BitisTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Durumu")
                        .HasColumnType("int");

                    b.Property<string>("EtkinlikAciklamasi")
                        .HasColumnType("nvarchar(600)");

                    b.Property<string>("EtkinlikAciklamasiKisa")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("EtkinlikAdi")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("KampusId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("KategoriId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("KatilimciSayisi")
                        .HasColumnType("int");

                    b.Property<string>("Resim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SalonId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("UcretBilgisi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("YayinTalebiId");

                    b.HasIndex("AppUserId");

                    b.HasIndex("KampusId");

                    b.HasIndex("KategoriId");

                    b.HasIndex("SalonId");

                    b.ToTable("YayinTalepleri");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
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
                    b.HasOne("EntityLayer.Concrete.AppUser", "AppUsers")
                        .WithMany("YayinTalepleri")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Kampus", "Kampus")
                        .WithMany("YayinTalepleri")
                        .HasForeignKey("KampusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Kategori", "Kategoriler")
                        .WithMany("YayinTalepleri")
                        .HasForeignKey("KategoriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Salon", "Salonlar")
                        .WithMany("YayinTalepleri")
                        .HasForeignKey("SalonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUsers");

                    b.Navigation("Kampus");

                    b.Navigation("Kategoriler");

                    b.Navigation("Salonlar");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("EntityLayer.Concrete.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("EntityLayer.Concrete.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("EntityLayer.Concrete.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("EntityLayer.Concrete.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("EntityLayer.Concrete.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityLayer.Concrete.AppUser", b =>
                {
                    b.Navigation("YayinTalepleri");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Kampus", b =>
                {
                    b.Navigation("Salonlar");

                    b.Navigation("YayinTalepleri");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Kategori", b =>
                {
                    b.Navigation("Etkinlikler");

                    b.Navigation("YayinTalepleri");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Salon", b =>
                {
                    b.Navigation("Etkinlikler");

                    b.Navigation("YayinTalepleri");
                });
#pragma warning restore 612, 618
        }
    }
}
