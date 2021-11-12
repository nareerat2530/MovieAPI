using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieProject.Migrations
{
    public partial class updatedimageurlpropertytomovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Movies",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Movies",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Movies",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Movies",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
