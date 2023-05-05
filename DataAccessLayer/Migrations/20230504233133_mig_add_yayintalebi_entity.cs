using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mig_add_yayintalebi_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EtkinlikSorumlusu",
                table: "YayinTalepleri");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "YayinTalepleri",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_YayinTalepleri_AppUserId",
                table: "YayinTalepleri",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_YayinTalepleri_AspNetUsers_AppUserId",
                table: "YayinTalepleri",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_YayinTalepleri_AspNetUsers_AppUserId",
                table: "YayinTalepleri");

            migrationBuilder.DropIndex(
                name: "IX_YayinTalepleri_AppUserId",
                table: "YayinTalepleri");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "YayinTalepleri");

            migrationBuilder.AddColumn<string>(
                name: "EtkinlikSorumlusu",
                table: "YayinTalepleri",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
