using Microsoft.EntityFrameworkCore;
using SmartWorkout.Entities;

namespace SmartWorkout.Context
{
    public class SmartWorkoutContext:DbContext
    {
        public SmartWorkoutContext(DbContextOptions options) 
            : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Exercise> Exercises{ get; set; }
        public DbSet<Workout> Workouts{ get; set; }
        public DbSet<ExerciseLog> ExerciseLogs{ get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<User>()
				.HasIndex(u => u.Email)
				.IsUnique();
		}


		//protected override void OnModelCreating(ModelBuilder modelBuilder)
		//{
		//    // Configure Relationshipts and constrains
		//    modelBuilder.Entity<Workout>()
		//        .HasOne(w => w.User)
		//        .WithMany(u => u.Workouts)
		//        .HasForeignKey(w => w.UserId)
		//        .HasConstraintName("FK_Workouts_Users");
		//    base.OnModelCreating(modelBuilder);
		//}
	}
}
