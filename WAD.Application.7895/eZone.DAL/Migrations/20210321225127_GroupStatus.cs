using Microsoft.EntityFrameworkCore.Migrations;

namespace eZone.DAL.Migrations
{
    public partial class GroupStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupStatus",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupStatus",
                table: "Groups");
        }
    }
}
