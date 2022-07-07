using System.ComponentModel.DataAnnotations;

namespace CWWithFront.Models
{
  public class Instructor
  {
    public int ID { get; set; }
    [Required]
    public string LastName { get; set; }
    public string FirstMidName { get; set; }
    public DateTime HireDate { get; set; }
    public OfficeAssignment? OfficeAssignment { get; set; }
    public ICollection<CourseAssignment> CourseAssignments { get; set; }

  }
}
