using Microsoft.EntityFrameworkCore;

namespace Angular_Final_Proj.Models
{
    public class AngluarProjContext:DbContext
    {
        public AngluarProjContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<DepartmentModel> Department { get; set; }
        public DbSet<StudentModel> Student { get; set; }

    }
}
