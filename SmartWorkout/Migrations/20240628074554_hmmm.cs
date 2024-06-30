using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartWorkout.Migrations
{
    /// <inheritdoc />
    public partial class hmmm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseExerciseLog");

            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "ExerciseLogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseLogs_ExerciseId",
                table: "ExerciseLogs",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseLogs_Exercises_ExerciseId",
                table: "ExerciseLogs",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseLogs_Exercises_ExerciseId",
                table: "ExerciseLogs");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseLogs_ExerciseId",
                table: "ExerciseLogs");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "ExerciseLogs");

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
    }
}
