using Angular_Final_Proj.Models;
using Microsoft.EntityFrameworkCore;

namespace Angular_Final_Proj.Services
{
    public class DepartmentService
    { 
    private readonly AngluarProjContext context;
    public DepartmentService(AngluarProjContext _context)
    {
        context = _context;
    }

    public DepartmentModel Registerdepartment(DepartmentModel Department)
    {

        try
        {

            var department = new DepartmentModel()
            {
               DepartmentName=Department.DepartmentName

            };

            context.Department.Add(department);
            context.SaveChanges();
        }
        catch (Exception ex) { }
        return Department;
    }

    public List<DepartmentModel> GetAlldepartment()
    {
        List<DepartmentModel> departments = context.Department.ToList();
        return departments;
    }

    public DepartmentModel Getdepartment(int id)
    {
        DepartmentModel FoundDepartment = null;
        foreach (var item in context.Department)
        {
            if (item.DepartmentId.Equals(id))
            {
                FoundDepartment = item;
            }
        }
        return FoundDepartment;
    }

    public DepartmentModel Updatedepartment(DepartmentModel department)
    {
        try
        {

            foreach (var item in context.Department)
            {
                if (item.DepartmentId == department.DepartmentId)
                {

                   item.DepartmentName = department.DepartmentName;

                }
            }
            context.SaveChanges();
            return department;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }

    public bool Deletedepartment(int ID)
    {
        bool result = false;
        var department = context.Department.Find(ID);
        if (department != null)
        {
            context.Entry(department).State = EntityState.Deleted;
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
