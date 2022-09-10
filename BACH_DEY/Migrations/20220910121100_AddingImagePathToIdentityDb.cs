using Microsoft.EntityFrameworkCore.Migrations;

namespace BACH_DEY.Migrations
{
    public partial class AddingImagePathToIdentityDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IamgePath",
                table: "products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IamgePath",
                table: "products");
        }
    }
}
