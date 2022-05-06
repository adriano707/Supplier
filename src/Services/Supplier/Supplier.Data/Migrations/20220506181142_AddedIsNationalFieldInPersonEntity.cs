using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Supplier.Data.Migrations
{
    public partial class AddedIsNationalFieldInPersonEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsNational",
                table: "Person",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                table: "Person",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FantasyName",
                table: "JuridicalPerson",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsNational",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "FantasyName",
                table: "JuridicalPerson");
        }
    }
}
