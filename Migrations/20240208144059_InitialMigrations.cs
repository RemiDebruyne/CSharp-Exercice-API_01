using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exercice_API_01.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_name = table.Column<string>(type: "nvarchar(max)", nullable: false, collation: "Latin1_General_CI_AI"),
                    Last_name = table.Column<string>(type: "nvarchar(max)", nullable: false, collation: "Latin1_General_CI_AI"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "BirthDate", "First_name", "Gender", "Last_name", "Password" },
                values: new object[,]
                {
                    { 1, new DateTime(1999, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rémi", "Homme", "Debruyne", "sqdgge786dFNYUEI" },
                    { 2, new DateTime(1983, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manu", "Homme", "Max", "bhqdpgre2452uigpzesdfe" },
                    { 3, new DateTime(325, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jean", "Robot", "Bon", "fghqriuopfghE452HOFUR5Y8UHGHVV" },
                    { 4, new DateTime(122, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jaina", "Femme", "Portvaillant", "fkggAZEq451g4r1g4sq" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
