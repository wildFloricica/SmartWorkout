using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartWorkout.Migrations
{
    /// <inheritdoc />
    public partial class WorkoutExerciseLogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkoutId",
                table: "ExerciseLogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseLogs_WorkoutId",
                table: "ExerciseLogs",
                column: "WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseLogs_Workouts_WorkoutId",
                table: "ExerciseLogs",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseLogs_Workouts_WorkoutId",
                table: "ExerciseLogs");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseLogs_WorkoutId",
                table: "ExerciseLogs");

            migrationBuilder.DropColumn(
                name: "WorkoutId",
                table: "ExerciseLogs");
        }
    }
}
