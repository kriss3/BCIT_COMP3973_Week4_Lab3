using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppMvcEFCore.Data.Migrations
{
    public partial class remove_provNameFromCities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProvinceName",
                table: "Cities");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProvinceName",
                table: "Cities",
                nullable: true);
        }
    }
}
