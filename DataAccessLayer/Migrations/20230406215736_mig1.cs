using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Iletisimler",
                columns: table => new
                {
                    IletisimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Harita = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirimAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama2 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iletisimler", x => x.IletisimId);
                });

            migrationBuilder.CreateTable(
                name: "Kampusler",
                columns: table => new
                {
                    KampusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KampusAdi = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kampusler", x => x.KampusId);
                });

            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    KategoriId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdi = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.KategoriId);
                });

            migrationBuilder.CreateTable(
                name: "Salonlar",
                columns: table => new
                {
                    SalonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KampusId = table.Column<int>(type: "int", nullable: false),
                    SalonAdi = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    SalonKapasitesi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salonlar", x => x.SalonId);
                    table.ForeignKey(
                        name: "FK_Salonlar_Kampusler_KampusId",
                        column: x => x.KampusId,
                        principalTable: "Kampusler",
                        principalColumn: "KampusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Etkinlikler",
                columns: table => new
                {
                    EtkinlikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EtkinlikAdi = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    EtkinlikYeriId = table.Column<int>(type: "int", nullable: false),
                    SalonlarSalonId = table.Column<int>(type: "int", nullable: false),
                    KatilimciSayisi = table.Column<int>(type: "int", nullable: false),
                    KategoriId = table.Column<int>(type: "int", nullable: false),
                    Durumu = table.Column<bool>(type: "bit", nullable: false),
                    EtkinlikAciklamasiKisa = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    UcretBilgisi = table.Column<bool>(type: "bit", nullable: false),
                    BaslangicTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BitisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Resim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EtkinlikSorumlusu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etkinlikler", x => x.EtkinlikId);
                    table.ForeignKey(
                        name: "FK_Etkinlikler_Kategoriler_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategoriler",
                        principalColumn: "KategoriId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Etkinlikler_Salonlar_SalonlarSalonId",
                        column: x => x.SalonlarSalonId,
                        principalTable: "Salonlar",
                        principalColumn: "SalonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "YayinTalepleri",
                columns: table => new
                {
                    YayinTalebiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EtkinlikAdi = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    EtkinlikYeriId = table.Column<int>(type: "int", nullable: false),
                    SalonlarSalonId = table.Column<int>(type: "int", nullable: false),
                    KatilimciSayisi = table.Column<int>(type: "int", nullable: false),
                    KategoriId = table.Column<int>(type: "int", nullable: false),
                    Durumu = table.Column<bool>(type: "bit", nullable: false),
                    EtkinlikAciklamasi = table.Column<string>(type: "nvarchar(600)", nullable: false),
                    EtkinlikAciklamasiKisa = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    UcretBilgisi = table.Column<bool>(type: "bit", nullable: false),
                    BaslangicTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BitisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Resim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EtkinlikSorumlusu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EtkinlikSorumlusuAciklamasi = table.Column<string>(type: "nvarchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YayinTalepleri", x => x.YayinTalebiId);
                    table.ForeignKey(
                        name: "FK_YayinTalepleri_Kategoriler_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategoriler",
                        principalColumn: "KategoriId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_YayinTalepleri_Salonlar_SalonlarSalonId",
                        column: x => x.SalonlarSalonId,
                        principalTable: "Salonlar",
                        principalColumn: "SalonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Etkinlikler_KategoriId",
                table: "Etkinlikler",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Etkinlikler_SalonlarSalonId",
                table: "Etkinlikler",
                column: "SalonlarSalonId");

            migrationBuilder.CreateIndex(
                name: "IX_Salonlar_KampusId",
                table: "Salonlar",
                column: "KampusId");

            migrationBuilder.CreateIndex(
                name: "IX_YayinTalepleri_KategoriId",
                table: "YayinTalepleri",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_YayinTalepleri_SalonlarSalonId",
                table: "YayinTalepleri",
                column: "SalonlarSalonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Etkinlikler");

            migrationBuilder.DropTable(
                name: "Iletisimler");

            migrationBuilder.DropTable(
                name: "YayinTalepleri");

            migrationBuilder.DropTable(
                name: "Kategoriler");

            migrationBuilder.DropTable(
                name: "Salonlar");

            migrationBuilder.DropTable(
                name: "Kampusler");
        }
    }
}
