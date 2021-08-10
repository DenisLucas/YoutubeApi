using Microsoft.EntityFrameworkCore.Migrations;

namespace Presentation.Migrations
{
    public partial class Userid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Video_User_Userid",
                table: "Video");

            migrationBuilder.AlterColumn<int>(
                name: "Userid",
                table: "Video",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Video_User_Userid",
                table: "Video",
                column: "Userid",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Video_User_Userid",
                table: "Video");

            migrationBuilder.AlterColumn<int>(
                name: "Userid",
                table: "Video",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Video_User_Userid",
                table: "Video",
                column: "Userid",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
