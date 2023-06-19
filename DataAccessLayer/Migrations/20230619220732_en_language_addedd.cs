using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class en_language_addedd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EtkinlikAciklamasiEn",
                table: "YayinTalepleri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EtkinlikAciklamasiKisaEn",
                table: "YayinTalepleri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EtkinlikAdiEn",
                table: "YayinTalepleri",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SalonAdiEn",
                table: "Salonlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KategoriAdiEn",
                table: "Kategoriler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KampusAdiEn",
                table: "Kampusler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EtkinlikAciklamasiEn",
                table: "Etkinlikler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EtkinlikAciklamasiKisaEn",
                table: "Etkinlikler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EtkinlikAdiEn",
                table: "Etkinlikler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EtkinlikAciklamasiEn",
                table: "YayinTalepleri");

            migrationBuilder.DropColumn(
                name: "EtkinlikAciklamasiKisaEn",
                table: "YayinTalepleri");

            migrationBuilder.DropColumn(
                name: "EtkinlikAdiEn",
                table: "YayinTalepleri");

            migrationBuilder.DropColumn(
                name: "SalonAdiEn",
                table: "Salonlar");

            migrationBuilder.DropColumn(
                name: "KategoriAdiEn",
                table: "Kategoriler");

            migrationBuilder.DropColumn(
                name: "KampusAdiEn",
                table: "Kampusler");

            migrationBuilder.DropColumn(
                name: "EtkinlikAciklamasiEn",
                table: "Etkinlikler");

            migrationBuilder.DropColumn(
                name: "EtkinlikAciklamasiKisaEn",
                table: "Etkinlikler");

            migrationBuilder.DropColumn(
                name: "EtkinlikAdiEn",
                table: "Etkinlikler");
        }
    }
}
