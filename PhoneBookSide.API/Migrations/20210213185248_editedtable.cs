using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneBookSide.API.Migrations
{
    public partial class editedtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isdeleted",
                table: "people",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "isdeleted",
                table: "connectionInfos",
                newName: "IsDeleted");

            migrationBuilder.AddColumn<DateTime>(
                name: "AddDate",
                table: "people",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "AddDate",
                table: "connectionInfos",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddDate",
                table: "people");

            migrationBuilder.DropColumn(
                name: "AddDate",
                table: "connectionInfos");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "people",
                newName: "isdeleted");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "connectionInfos",
                newName: "isdeleted");
        }
    }
}
