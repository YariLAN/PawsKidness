using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawsKindness.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FullName_Address : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "address",
                table: "pets");

            migrationBuilder.RenameColumn(
                name: "surname",
                table: "volunteers",
                newName: "name_surname");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "volunteers",
                newName: "name_name");

            migrationBuilder.RenameColumn(
                name: "middle_name",
                table: "volunteers",
                newName: "name_middle_name");

            migrationBuilder.AddColumn<string>(
                name: "address_apartment",
                table: "pets",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "address_city",
                table: "pets",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "address_country",
                table: "pets",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "address_house_number",
                table: "pets",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "address_street",
                table: "pets",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "address_apartment",
                table: "pets");

            migrationBuilder.DropColumn(
                name: "address_city",
                table: "pets");

            migrationBuilder.DropColumn(
                name: "address_country",
                table: "pets");

            migrationBuilder.DropColumn(
                name: "address_house_number",
                table: "pets");

            migrationBuilder.DropColumn(
                name: "address_street",
                table: "pets");

            migrationBuilder.RenameColumn(
                name: "name_surname",
                table: "volunteers",
                newName: "surname");

            migrationBuilder.RenameColumn(
                name: "name_name",
                table: "volunteers",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "name_middle_name",
                table: "volunteers",
                newName: "middle_name");

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "pets",
                type: "character varying(800)",
                maxLength: 800,
                nullable: false,
                defaultValue: "");
        }
    }
}
