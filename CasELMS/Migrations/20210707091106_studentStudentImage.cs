using Microsoft.EntityFrameworkCore.Migrations;

namespace CasELMS.Migrations
{
    public partial class studentStudentImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Class",
                table: "StudentRegistration",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentImage",
                table: "StudentRegistration",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Class",
                table: "StudentRegistration");

            migrationBuilder.DropColumn(
                name: "StudentImage",
                table: "StudentRegistration");
        }
    }
}
