using System.ComponentModel.DataAnnotations;

namespace CWWithFront.Models
{
  public class Enrollment
  { 
    [Key]
    public int EnrollmentId { get; set; }
    public int CourseID { get; set; }
    public int StudentID { get; set; }
    public Course Course { get; set; }
    public Student Student { get; set; }
    public Grade? Grade { get; set; }

  }
}
