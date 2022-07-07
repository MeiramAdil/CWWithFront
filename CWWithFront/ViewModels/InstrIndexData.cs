using CWWithFront.Models;

namespace CWWithFront.ViewModels
{
  public class InstrIndexData
  {
    public IEnumerable<Instructor> Instructors { get; set; }
    public IEnumerable<Course> Courses { get; set; }
    public IEnumerable<Enrollment> Enrollments { get; set; }
  }
}
