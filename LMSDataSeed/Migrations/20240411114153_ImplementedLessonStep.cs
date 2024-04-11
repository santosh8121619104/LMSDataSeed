using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMSDataSeed.Migrations
{
    /// <inheritdoc />
    public partial class ImplementedLessonStep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LessonStep",
                columns: table => new
                {
                    LessonID = table.Column<int>(type: "int", nullable: false),
                    LessonStepID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<int>(type: "int", nullable: true),
                    StepName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true),
                    Runtime = table.Column<TimeOnly>(type: "time", nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    ModifiedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    ContentType = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LessonStep__B084ACB04D4D10C9", x => x.LessonID);
                    table.ForeignKey(
                        name: "FK__LessonStep__CourseID__4D5F7D71",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                    table.ForeignKey(
                        name: "FK__LessonStep__LessonID__4D5F7D71",
                        column: x => x.LessonID,
                        principalTable: "Lesson",
                        principalColumn: "LessonID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LessonStep_CourseID",
                table: "LessonStep",
                column: "CourseID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LessonStep");
        }
    }
}
