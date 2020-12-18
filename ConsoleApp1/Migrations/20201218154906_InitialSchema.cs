using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp1.Migrations
{
    public partial class InitialSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dependents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Primaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DependentFirstId = table.Column<int>(type: "int", nullable: true),
                    DependentSecondId = table.Column<int>(type: "int", nullable: true),
                    TertiaryFirstId = table.Column<int>(type: "int", nullable: true),
                    TertiarySecondId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Primaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Primaries_Dependents_DependentFirstId",
                        column: x => x.DependentFirstId,
                        principalTable: "Dependents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Primaries_Dependents_DependentSecondId",
                        column: x => x.DependentSecondId,
                        principalTable: "Dependents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tertiary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DependentId = table.Column<int>(type: "int", nullable: true),
                    PrimaryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tertiary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tertiary_Dependents_DependentId",
                        column: x => x.DependentId,
                        principalTable: "Dependents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tertiary_Primaries_PrimaryId",
                        column: x => x.PrimaryId,
                        principalTable: "Primaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Primaries_DependentFirstId",
                table: "Primaries",
                column: "DependentFirstId");

            migrationBuilder.CreateIndex(
                name: "IX_Primaries_DependentSecondId",
                table: "Primaries",
                column: "DependentSecondId");

            migrationBuilder.CreateIndex(
                name: "IX_Primaries_TertiaryFirstId",
                table: "Primaries",
                column: "TertiaryFirstId");

            migrationBuilder.CreateIndex(
                name: "IX_Primaries_TertiarySecondId",
                table: "Primaries",
                column: "TertiarySecondId");

            migrationBuilder.CreateIndex(
                name: "IX_Tertiary_DependentId",
                table: "Tertiary",
                column: "DependentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tertiary_PrimaryId",
                table: "Tertiary",
                column: "PrimaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Primaries_Tertiary_TertiaryFirstId",
                table: "Primaries",
                column: "TertiaryFirstId",
                principalTable: "Tertiary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Primaries_Tertiary_TertiarySecondId",
                table: "Primaries",
                column: "TertiarySecondId",
                principalTable: "Tertiary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Primaries_Dependents_DependentFirstId",
                table: "Primaries");

            migrationBuilder.DropForeignKey(
                name: "FK_Primaries_Dependents_DependentSecondId",
                table: "Primaries");

            migrationBuilder.DropForeignKey(
                name: "FK_Tertiary_Dependents_DependentId",
                table: "Tertiary");

            migrationBuilder.DropForeignKey(
                name: "FK_Primaries_Tertiary_TertiaryFirstId",
                table: "Primaries");

            migrationBuilder.DropForeignKey(
                name: "FK_Primaries_Tertiary_TertiarySecondId",
                table: "Primaries");

            migrationBuilder.DropTable(
                name: "Dependents");

            migrationBuilder.DropTable(
                name: "Tertiary");

            migrationBuilder.DropTable(
                name: "Primaries");
        }
    }
}
