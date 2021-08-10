using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication3.Migrations
{
    public partial class thirdmigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoursesProfessors_Courses_Coursesid",
                table: "CoursesProfessors");

            migrationBuilder.DropForeignKey(
                name: "FK_CoursesProfessors_Professors_Professorsid",
                table: "CoursesProfessors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoursesProfessors",
                table: "CoursesProfessors");

            migrationBuilder.RenameColumn(
                name: "Professorsid",
                table: "CoursesProfessors",
                newName: "Professor");

            migrationBuilder.RenameColumn(
                name: "Coursesid",
                table: "CoursesProfessors",
                newName: "Course");

            migrationBuilder.RenameIndex(
                name: "IX_CoursesProfessors_Professorsid",
                table: "CoursesProfessors",
                newName: "IX_CoursesProfessors_Professor");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "CoursesProfessors",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoursesProfessors",
                table: "CoursesProfessors",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesProfessors_Course",
                table: "CoursesProfessors",
                column: "Course");

            migrationBuilder.AddForeignKey(
                name: "FK_CoursesProfessors_Courses_Course",
                table: "CoursesProfessors",
                column: "Course",
                principalTable: "Courses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoursesProfessors_Professors_Professor",
                table: "CoursesProfessors",
                column: "Professor",
                principalTable: "Professors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoursesProfessors_Courses_Course",
                table: "CoursesProfessors");

            migrationBuilder.DropForeignKey(
                name: "FK_CoursesProfessors_Professors_Professor",
                table: "CoursesProfessors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoursesProfessors",
                table: "CoursesProfessors");

            migrationBuilder.DropIndex(
                name: "IX_CoursesProfessors_Course",
                table: "CoursesProfessors");

            migrationBuilder.DropColumn(
                name: "id",
                table: "CoursesProfessors");

            migrationBuilder.RenameColumn(
                name: "Professor",
                table: "CoursesProfessors",
                newName: "Professorsid");

            migrationBuilder.RenameColumn(
                name: "Course",
                table: "CoursesProfessors",
                newName: "Coursesid");

            migrationBuilder.RenameIndex(
                name: "IX_CoursesProfessors_Professor",
                table: "CoursesProfessors",
                newName: "IX_CoursesProfessors_Professorsid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoursesProfessors",
                table: "CoursesProfessors",
                columns: new[] { "Coursesid", "Professorsid" });

            migrationBuilder.AddForeignKey(
                name: "FK_CoursesProfessors_Courses_Coursesid",
                table: "CoursesProfessors",
                column: "Coursesid",
                principalTable: "Courses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoursesProfessors_Professors_Professorsid",
                table: "CoursesProfessors",
                column: "Professorsid",
                principalTable: "Professors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
