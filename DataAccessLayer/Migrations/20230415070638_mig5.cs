using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Etkinlikler_Salonlar_SalonlarSalonId",
                table: "Etkinlikler");

            migrationBuilder.DropColumn(
                name: "EtkinlikYeriId",
                table: "Etkinlikler");

            migrationBuilder.RenameColumn(
                name: "SalonlarSalonId",
                table: "Etkinlikler",
                newName: "SalonId");

            migrationBuilder.RenameIndex(
                name: "IX_Etkinlikler_SalonlarSalonId",
                table: "Etkinlikler",
                newName: "IX_Etkinlikler_SalonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Etkinlikler_Salonlar_SalonId",
                table: "Etkinlikler",
                column: "SalonId",
                principalTable: "Salonlar",
                principalColumn: "SalonId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Etkinlikler_Salonlar_SalonId",
                table: "Etkinlikler");

            migrationBuilder.RenameColumn(
                name: "SalonId",
                table: "Etkinlikler",
                newName: "SalonlarSalonId");

            migrationBuilder.RenameIndex(
                name: "IX_Etkinlikler_SalonId",
                table: "Etkinlikler",
                newName: "IX_Etkinlikler_SalonlarSalonId");

            migrationBuilder.AddColumn<int>(
                name: "EtkinlikYeriId",
                table: "Etkinlikler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Etkinlikler_Salonlar_SalonlarSalonId",
                table: "Etkinlikler",
                column: "SalonlarSalonId",
                principalTable: "Salonlar",
                principalColumn: "SalonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
