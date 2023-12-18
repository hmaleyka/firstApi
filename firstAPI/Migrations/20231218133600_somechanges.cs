using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace firstAPI.Migrations
{
    public partial class somechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_brands_brands_BrandId",
                table: "brands");

            migrationBuilder.DropForeignKey(
                name: "FK_colors_colors_ColorId",
                table: "colors");

            migrationBuilder.DropIndex(
                name: "IX_colors_ColorId",
                table: "colors");

            migrationBuilder.DropIndex(
                name: "IX_brands_BrandId",
                table: "brands");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "colors");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "brands");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "colors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "brands",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_colors_ColorId",
                table: "colors",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_brands_BrandId",
                table: "brands",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_brands_brands_BrandId",
                table: "brands",
                column: "BrandId",
                principalTable: "brands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_colors_colors_ColorId",
                table: "colors",
                column: "ColorId",
                principalTable: "colors",
                principalColumn: "Id");
        }
    }
}
