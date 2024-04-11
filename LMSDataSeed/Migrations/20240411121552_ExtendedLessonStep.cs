using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMSDataSeed.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedLessonStep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK__LessonStep__B084ACB04D4D10C9",
                table: "LessonStep");

            migrationBuilder.AddPrimaryKey(
                name: "PK__LessonStep__B084ACB04D4D10C9",
                table: "LessonStep",
                column: "LessonStepID");

            migrationBuilder.CreateIndex(
                name: "IX_LessonStep_LessonID",
                table: "LessonStep",
                column: "LessonID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK__LessonStep__B084ACB04D4D10C9",
                table: "LessonStep");

            migrationBuilder.DropIndex(
                name: "IX_LessonStep_LessonID",
                table: "LessonStep");

            migrationBuilder.AddPrimaryKey(
                name: "PK__LessonStep__B084ACB04D4D10C9",
                table: "LessonStep",
                column: "LessonID");
        }
    }
}
