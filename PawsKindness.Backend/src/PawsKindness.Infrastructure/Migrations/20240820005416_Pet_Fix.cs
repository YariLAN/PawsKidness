using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawsKindness.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Pet_Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "phone_number",
                table: "pets");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "birth_day",
                table: "pets",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<string>(
                name: "phone_number_value",
                table: "pets",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "phone_number_value",
                table: "pets");

            migrationBuilder.AlterColumn<DateTime>(
                name: "birth_day",
                table: "pets",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "phone_number",
                table: "pets",
                type: "text",
                nullable: true);
        }
    }
}
