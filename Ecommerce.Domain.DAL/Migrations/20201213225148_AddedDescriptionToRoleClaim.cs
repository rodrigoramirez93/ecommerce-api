using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Domain.DAL.Migrations
{
    public partial class AddedDescriptionToRoleClaim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AspNetRoleClaims",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "AspNetRoleClaims");
        }
    }
}
