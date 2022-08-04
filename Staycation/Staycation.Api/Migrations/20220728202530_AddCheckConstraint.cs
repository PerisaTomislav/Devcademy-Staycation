using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Staycation.Api.Migrations
{
    public partial class AddCheckConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"
                    ALTER TABLE Accommodations
                    ADD CHECK (Categorization>=1 AND Categorization<=5);
                ");
            migrationBuilder.Sql(
                @"
                    ALTER TABLE Accommodations
                    ADD CHECK (PersonCount>=1);
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
