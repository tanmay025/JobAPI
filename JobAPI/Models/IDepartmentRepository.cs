using System.Collections.Generic;

namespace JobAPI.Models
{
    interface IDepartmentRepository
    {
        IEnumerable<Department> GetDepartments();
        Department GetDepartmentById(int DepartmentId);
        void InsertDepartment(Department Department_);
        void UpdateDepartment(Department Department_);
        void DeleteDepartment(int DepartmentId);
        void SaveChanges();
    }
}
