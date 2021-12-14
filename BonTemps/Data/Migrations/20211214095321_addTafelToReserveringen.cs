using Microsoft.EntityFrameworkCore.Migrations;

namespace BonTemps.Data.Migrations
{
    public partial class addTafelToReserveringen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Tafel",
                table: "Reserveringen",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tafel",
                table: "Reserveringen");
        }
    }
}
