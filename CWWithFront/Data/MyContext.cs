using CWWithFront.Models;
using Microsoft.EntityFrameworkCore;

namespace CWWithFront.Data
{
  public class MyContext : DbContext
  {
    public DbSet<Course> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<CourseAssignment> CourseAssignments { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
    public MyContext(DbContextOptions<MyContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Course>().ToTable("Course");
      modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
      modelBuilder.Entity<Student>().ToTable("Student");
      modelBuilder.Entity<Department>().ToTable("Department");
      modelBuilder.Entity<Instructor>().ToTable("Instructor");
      modelBuilder.Entity<CourseAssignment>().ToTable("CourseAssignment");
      modelBuilder.Entity<OfficeAssignment>().ToTable("OfficeAssignment");

      modelBuilder.Entity<CourseAssignment>().HasKey(c => new { c.InstructorID, c.CourseID });
    }
  }
}
