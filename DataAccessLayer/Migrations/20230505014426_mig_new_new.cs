using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mig_new_new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_YayinTalepleri_Kampusler_KampusId",
                table: "YayinTalepleri");

            migrationBuilder.DropIndex(
                name: "IX_YayinTalepleri_KampusId",
                table: "YayinTalepleri");

            migrationBuilder.DropColumn(
                name: "KampusId",
                table: "YayinTalepleri");

            migrationBuilder.AlterColumn<string>(
                name: "Durumu",
                table: "YayinTalepleri",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Durumu",
                table: "Etkinlikler",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Durumu",
                table: "YayinTalepleri",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "KampusId",
                table: "YayinTalepleri",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "Durumu",
                table: "Etkinlikler",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_YayinTalepleri_KampusId",
                table: "YayinTalepleri",
                column: "KampusId");

            migrationBuilder.AddForeignKey(
                name: "FK_YayinTalepleri_Kampusler_KampusId",
                table: "YayinTalepleri",
                column: "KampusId",
                principalTable: "Kampusler",
                principalColumn: "KampusId",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
