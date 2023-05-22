using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class kampus_id_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KampusId",
                table: "YayinTalepleri",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
