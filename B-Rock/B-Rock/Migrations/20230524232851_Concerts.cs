using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B_Rock.Migrations
{
    public partial class Concerts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Concerts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PerformedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UniqueURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concerts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Concerts",
                columns: new[] { "Id", "City", "Country", "DateAndTime", "Location", "PerformedBy", "Title", "UniqueURL" },
                values: new object[,]
                {
                    { 1, "Antwerp", "BE", new DateTime(2023, 5, 25, 20, 0, 0, 0, DateTimeKind.Unspecified), "De Singel", "Haydn & Mozart with Vox Luminis XL", "Mozart Mass", "Mozart-Mass.jpg" },
                    { 2, "Rouen", "FR", new DateTime(2023, 6, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), "Chapelle Corneille", "Antoine Tamestit & B'Rock", "Tears Of Melancholy", "Tears-Of-Melancholy.jpg" },
                    { 3, "Stockholm", "SE", new DateTime(2023, 6, 2, 20, 0, 0, 0, DateTimeKind.Unspecified), "The German Church", "B’Rock Orchestra & Vocal Consort", "The Travels Of Monteverdi", "The-Travels-Of-Monteverdi.jpg" },
                    { 4, "Reims", "FR", new DateTime(2023, 6, 24, 20, 0, 0, 0, DateTimeKind.Unspecified), "Opéra de Raims", "Fin de siècle à Paris", "Un Nouveau Vent", "Un-Nouveau-Vent.jpg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Concerts");
        }
    }
}
