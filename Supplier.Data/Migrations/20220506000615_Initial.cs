using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Supplier.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanySize",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanySize", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JuridicalPerson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CompanyTypeId = table.Column<int>(type: "int", nullable: false),
                    TradeName = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    DateOfIncorporation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false),
                    CompanySizeId = table.Column<int>(type: "int", nullable: false),
                    WebSite = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    ShareQuantity = table.Column<int>(type: "int", nullable: false),
                    ValueShare = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SocialCapital = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JuridicalPerson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JuridicalPerson_CompanySize_SizeId",
                        column: x => x.SizeId,
                        principalTable: "CompanySize",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JuridicalPerson_CompanyType_CompanySizeId",
                        column: x => x.CompanySizeId,
                        principalTable: "CompanyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JuridicalPerson_Person_Id",
                        column: x => x.Id,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NaturalPerson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    MaritalStatus = table.Column<int>(type: "int", nullable: false),
                    Profession = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    CompanyTypeId = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaturalPerson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NaturalPerson_CompanyType_CompanyTypeId",
                        column: x => x.CompanyTypeId,
                        principalTable: "CompanyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NaturalPerson_Person_Id",
                        column: x => x.Id,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonContact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contact = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonContact_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JuridicalPerson_CompanySizeId",
                table: "JuridicalPerson",
                column: "CompanySizeId");

            migrationBuilder.CreateIndex(
                name: "IX_JuridicalPerson_SizeId",
                table: "JuridicalPerson",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_NaturalPerson_CompanyTypeId",
                table: "NaturalPerson",
                column: "CompanyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonContact_PersonId",
                table: "PersonContact",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JuridicalPerson");

            migrationBuilder.DropTable(
                name: "NaturalPerson");

            migrationBuilder.DropTable(
                name: "PersonContact");

            migrationBuilder.DropTable(
                name: "CompanySize");

            migrationBuilder.DropTable(
                name: "CompanyType");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
