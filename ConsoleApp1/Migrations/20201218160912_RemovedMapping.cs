using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp1.Migrations
{
    public partial class RemovedMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tertiary_Primaries_PrimaryId",
                table: "Tertiary");

            migrationBuilder.DropIndex(
                name: "IX_Tertiary_PrimaryId",
                table: "Tertiary");

            migrationBuilder.DropColumn(
                name: "PrimaryId",
                table: "Tertiary");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrimaryId",
                table: "Tertiary",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tertiary_PrimaryId",
                table: "Tertiary",
                column: "PrimaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tertiary_Primaries_PrimaryId",
                table: "Tertiary",
                column: "PrimaryId",
                principalTable: "Primaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
