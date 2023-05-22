using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mig_add_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_YayinTalepleri_Salonlar_SalonlarSalonId",
                table: "YayinTalepleri");

            migrationBuilder.DropColumn(
                name: "EtkinlikSorumlusuAciklamasi",
                table: "YayinTalepleri");

            migrationBuilder.DropColumn(
                name: "EtkinlikYeriId",
                table: "YayinTalepleri");

            migrationBuilder.RenameColumn(
                name: "SalonlarSalonId",
                table: "YayinTalepleri",
                newName: "SalonId");

            migrationBuilder.RenameIndex(
                name: "IX_YayinTalepleri_SalonlarSalonId",
                table: "YayinTalepleri",
                newName: "IX_YayinTalepleri_SalonId");

            migrationBuilder.AddForeignKey(
                name: "FK_YayinTalepleri_Salonlar_SalonId",
                table: "YayinTalepleri",
                column: "SalonId",
                principalTable: "Salonlar",
                principalColumn: "SalonId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_YayinTalepleri_Salonlar_SalonId",
                table: "YayinTalepleri");

            migrationBuilder.RenameColumn(
                name: "SalonId",
                table: "YayinTalepleri",
                newName: "SalonlarSalonId");

            migrationBuilder.RenameIndex(
                name: "IX_YayinTalepleri_SalonId",
                table: "YayinTalepleri",
                newName: "IX_YayinTalepleri_SalonlarSalonId");

            migrationBuilder.AddColumn<string>(
                name: "EtkinlikSorumlusuAciklamasi",
                table: "YayinTalepleri",
                type: "nvarchar(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EtkinlikYeriId",
                table: "YayinTalepleri",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_YayinTalepleri_Salonlar_SalonlarSalonId",
                table: "YayinTalepleri",
                column: "SalonlarSalonId",
                principalTable: "Salonlar",
                principalColumn: "SalonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
