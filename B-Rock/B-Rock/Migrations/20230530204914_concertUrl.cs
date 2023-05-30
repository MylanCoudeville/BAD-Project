using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B_Rock.Migrations
{
    public partial class concertUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExternLink",
                table: "Concerts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExternLink",
                value: "https://b-rock.org/project/mozart-mass-3/");

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExternLink",
                value: "https://b-rock.org/project/tears-of-melancholy-2/");

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExternLink",
                value: "https://b-rock.org/project/monteverdis-journey/");

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 4,
                column: "ExternLink",
                value: "https://b-rock.org/project/un-nouveau-vent/");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExternLink",
                table: "Concerts");
        }
    }
}
