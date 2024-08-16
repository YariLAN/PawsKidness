using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawsKindness.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Refactoring_Volunteer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "number_pers_need_help",
                table: "volunteers");

            migrationBuilder.DropColumn(
                name: "number_pets_found_a_home",
                table: "volunteers");

            migrationBuilder.DropColumn(
                name: "number_pets_looking_for_a_home",
                table: "volunteers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "number_pers_need_help",
                table: "volunteers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "number_pets_found_a_home",
                table: "volunteers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "number_pets_looking_for_a_home",
                table: "volunteers",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
