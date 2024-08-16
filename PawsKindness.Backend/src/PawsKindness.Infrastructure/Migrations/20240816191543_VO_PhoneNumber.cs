using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawsKindness.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class VO_PhoneNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "volunteers",
                newName: "phone_number_value");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "phone_number_value",
                table: "volunteers",
                newName: "phone_number");
        }
    }
}
