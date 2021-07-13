using Microsoft.EntityFrameworkCore.Migrations;

namespace CasELMS.Migrations
{
    public partial class changeTeacherName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Course",
                newName: "TeacherName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TeacherName",
                table: "Course",
                newName: "TeacherId");
        }
    }
}
