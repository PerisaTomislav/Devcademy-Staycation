using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Staycation.Api.Migrations
{
    public partial class AddImageDataAttribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Accommodations",
                newName: "ImageTitle");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Accommodations",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Accommodations");

            migrationBuilder.RenameColumn(
                name: "ImageTitle",
                table: "Accommodations",
                newName: "ImageUrl");
        }
    }
}
