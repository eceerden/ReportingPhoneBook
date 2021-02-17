using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneBookSide.API.Migrations
{
    public partial class editDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isdeleted",
                table: "people",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isdeleted",
                table: "connectionInfos",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isdeleted",
                table: "people");

            migrationBuilder.DropColumn(
                name: "isdeleted",
                table: "connectionInfos");
        }
    }
}
