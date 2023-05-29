using System.ComponentModel.DataAnnotations;

namespace Angular_Final_Proj.Models
{
    public class DepartmentModel
    {
        [Key]

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
