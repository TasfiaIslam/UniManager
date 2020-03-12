using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityManagementSystem.Migrations
{
    public partial class Migration12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeptId",
                table: "Courses",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeptId",
                table: "Courses");
        }
    }
}
