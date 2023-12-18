using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace firstAPI.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cars_brands_BrandId",
                table: "cars");

            migrationBuilder.DropForeignKey(
                name: "FK_cars_colors_ColorID",
                table: "cars");

            migrationBuilder.AlterColumn<int>(
                name: "ColorID",
                table: "cars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "cars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_cars_brands_BrandId",
                table: "cars",
                column: "BrandId",
                principalTable: "brands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_cars_colors_ColorID",
                table: "cars",
                column: "ColorID",
                principalTable: "colors",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cars_brands_BrandId",
                table: "cars");

            migrationBuilder.DropForeignKey(
                name: "FK_cars_colors_ColorID",
                table: "cars");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "cars");

            migrationBuilder.AlterColumn<int>(
                name: "ColorID",
                table: "cars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "cars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_cars_brands_BrandId",
                table: "cars",
                column: "BrandId",
                principalTable: "brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cars_colors_ColorID",
                table: "cars",
                column: "ColorID",
                principalTable: "colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
