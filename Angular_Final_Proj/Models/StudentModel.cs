using System.ComponentModel.DataAnnotations;

namespace Angular_Final_Proj.Models
{
    public class StudentModel
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentCourse { get; set; }
        public string StudentSpecialization { get; set; }
        public double Percentage { get; set; }

        public int DepartmentId { get; set; }
        public DepartmentModel Department { get; set; }

    }
}
