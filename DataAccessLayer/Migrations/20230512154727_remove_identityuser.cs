using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class remove_identityuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_YayinTalepleri_AspNetUsers_AppUserId",
                table: "YayinTalepleri");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "YayinTalepleri",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_YayinTalepleri_AspNetUsers_AppUserId",
                table: "YayinTalepleri",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_YayinTalepleri_AspNetUsers_AppUserId",
                table: "YayinTalepleri");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "YayinTalepleri",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_YayinTalepleri_AspNetUsers_AppUserId",
                table: "YayinTalepleri",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
