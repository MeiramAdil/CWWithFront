using System.ComponentModel.DataAnnotations;

namespace CWWithFront.Models
{
  public class OfficeAssignment
  {
    [Key]
    public int InstructorID { get; set; }
    public string Location { get; set; }
    public Instructor Instructor { get; set; }
  }
}
