using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartWorkout.Migrations
{
    /// <inheritdoc />
    public partial class manytomany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExerciseExerciseLog",
                columns: table => new
                {
                    ExerciseLogsId = table.Column<int>(type: "int", nullable: false),
                    ExercisesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseExerciseLog", x => new { x.ExerciseLogsId, x.ExercisesId });
                    table.ForeignKey(
                        name: "FK_ExerciseExerciseLog_ExerciseLogs_ExerciseLogsId",
                        column: x => x.ExerciseLogsId,
                        principalTable: "ExerciseLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseExerciseLog_Exercises_ExercisesId",
                        column: x => x.ExercisesId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseExerciseLog_ExercisesId",
                table: "ExerciseExerciseLog",
                column: "ExercisesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseExerciseLog");
        }
    }
}
