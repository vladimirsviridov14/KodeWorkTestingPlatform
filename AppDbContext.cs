using System;
using Microsoft.EntityFrameworkCore;
using TestingPlatform.Models;


namespace TestingPlatform


{
    public class AppDbContext: DbContext
    {
        public DbSet<Student> Students => Set<Student>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Group> Groups => Set<Group>();
        public DbSet<Direction> Directions => Set<Direction>();
        public DbSet<Course> Courses => Set<Course>();
        
        public DbSet<Class> Classes => Set<Class>();

        public DbSet<Answer> Answers => Set<Answer>();
        public DbSet<UserTextAnswer> UserTextAnswers => Set<UserTextAnswer>();
        public DbSet<UserSelectedOption> UserSelectedOptions => Set<UserSelectedOption>();
        public DbSet<UserAttemptAnswer> UserAttemptAnswers => Set<UserAttemptAnswer>();
        public DbSet<TestResult> TestResults => Set<TestResult>();

        public DbSet<Test> Tests => Set<Test>();

        public DbSet<Question> Questions => Set<Question>();
        public DbSet<Project> Projects => Set<Project>();

        public DbSet<Attempt> Attempts => Set<Attempt>();









        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Test ↔ Group
            modelBuilder.Entity<Test>()
                .HasMany(t => t.Groups)
                .WithMany(g => g.Tests) // добавь в Group: public List<Test> Tests { get; set; }
                .UsingEntity<Dictionary<string, object>>(
                    "TestGroup",
                    tg => tg.HasOne<Group>().WithMany().HasForeignKey("GroupId"),
                    tg => tg.HasOne<Test>().WithMany().HasForeignKey("TestId"),
                    tg => tg.HasKey("TestId", "GroupId")
                );

            // Test ↔ Course
            modelBuilder.Entity<Test>()
                .HasMany(t => t.Courses)
                .WithMany(c => c.Tests)
                .UsingEntity<Dictionary<string, object>>(
                    "TestCourse",
                    tc => tc.HasOne<Course>().WithMany().HasForeignKey("CourseId"),
                    tc => tc.HasOne<Test>().WithMany().HasForeignKey("TestId"),
                    tc => tc.HasKey("TestId", "CourseId")
                );

            // Test ↔ Project
            modelBuilder.Entity<Test>()
                .HasMany(t => t.Projects)
                .WithMany(p => p.Tests)
                .UsingEntity<Dictionary<string, object>>(
                    "TestProject",
                    tp => tp.HasOne<Project>().WithMany().HasForeignKey("ProjectId"),
                    tp => tp.HasOne<Test>().WithMany().HasForeignKey("TestId"),
                    tp => tp.HasKey("TestId", "ProjectId")
                );

            // Test ↔ Direction
            modelBuilder.Entity<Test>()
                .HasMany(t => t.Directions)
                .WithMany(d => d.Tests)
                .UsingEntity<Dictionary<string, object>>(
                    "TestDirection",
                    td => td.HasOne<Direction>().WithMany().HasForeignKey("DirectionId"),
                    td => td.HasOne<Test>().WithMany().HasForeignKey("TestId"),
                    td => td.HasKey("TestId", "DirectionId")
                );

            // Test ↔ Student
            modelBuilder.Entity<Test>()
                .HasMany(t => t.Students)
                .WithMany(s => s.Tests)
                .UsingEntity<Dictionary<string, object>>(
                    "TestStudent",
                    ts => ts.HasOne<Student>().WithMany().HasForeignKey("StudentId"),
                    ts => ts.HasOne<Test>().WithMany().HasForeignKey("TestId"),
                    ts => ts.HasKey("TestId", "StudentId")
                );

            modelBuilder.Entity<Test>()
    .HasMany(t => t.Students)
    .WithMany(s => s.Tests)
    .UsingEntity<Dictionary<string, object>>(
        "TestStudent",
        ts => ts.HasOne<Student>().WithMany().HasForeignKey("StudentId"),
        ts => ts.HasOne<Test>().WithMany().HasForeignKey("TestId"),
        ts =>
        {
            ts.HasKey("TestId", "StudentId", "AttemptId"); // составной ключ
            ts.HasIndex(new[] { "TestId", "StudentId", "AttemptId" }).IsUnique();
        }
    );
        }
    }
}
