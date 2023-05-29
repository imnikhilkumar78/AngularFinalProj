using Angular_Final_Proj.Models;
using Microsoft.EntityFrameworkCore;
namespace Angular_Final_Proj.Services
{

    public class StudentService
    {
        private readonly AngluarProjContext context;
        public StudentService(AngluarProjContext _context)
        {
            context = _context;
        }

        public StudentDTO Register(StudentDTO studentDTO)
        {

            try
            {

                var student = new StudentModel()
                {
                    StudentName = studentDTO.StudentName,
                    StudentCourse = studentDTO.StudentCourse,
                    StudentSpecialization = studentDTO.StudentSpecialization,
                    Percentage = studentDTO.Percentage,
                    DepartmentId = studentDTO.DepartmentId,

                };

                context.Student.Add(student);
                context.SaveChanges();
            }
            catch (Exception ex) { }
            return studentDTO;
        }

        public List<StudentModel> GetAll()
        {
            List<StudentModel> students = context.Student.ToList();
            return students;
        }

        public StudentModel GetStudent(int id)
        {
            StudentModel FoundStudent = null;
            foreach (var item in context.Student)
            {
                if (item.StudentId.Equals(id))
                {
                    FoundStudent = item;
                }
            }
            return FoundStudent;
        }

        public StudentDTO Update(StudentDTO student)
        {
            try
            {
               
                foreach (var item in context.Student)
                {
                    if (item.StudentId == student.StudentId)
                    {

                        item.StudentName = student.StudentName;
                        item.StudentCourse = student.StudentCourse;
                        item.StudentSpecialization = student.StudentSpecialization;
                        item.Percentage = student.Percentage;
                        item.DepartmentId = student.DepartmentId;

                    }
                }
                context.SaveChanges();
                return student;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public bool DeleteStudent(int ID)
        {
            bool result = false;
            var student = context.Student.Find(ID);
            if (student != null)
            {
                context.Entry(student).State = EntityState.Deleted;
                context.SaveChanges();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}
