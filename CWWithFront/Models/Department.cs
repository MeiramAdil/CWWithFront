using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CWWithFront.Models
{
  public class Department
  {
    [Key]
    public int DepartmentID { get; set; }
    [StringLength(50, MinimumLength =3)]
    public string Name { get; set; }
    [DataType(DataType.Currency)]
    [Column(TypeName ="money")]
    public decimal Budget { get; set; }
    public DateTime StartDate { get; set; }
    public int InstructorID { get; set; }
    public Instructor Administrator { get; set; }
    public List<Course> Courses { get; set; }
  }
}
