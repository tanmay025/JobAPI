using System.Collections.Generic;
using System.Linq;

namespace JobAPI.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private JobsEntities _dataContext;
        public DepartmentRepository(JobsEntities dataContext)
        {
            this._dataContext = dataContext;
        }

        public void DeleteDepartment(int DepartmentId)
        {
            Department department= _dataContext.Departments.Find(DepartmentId);
            _dataContext.Departments.Remove(department);
        }

        public Department GetDepartmentById(int DepartmentId)
        {
            return _dataContext.Departments.Find(DepartmentId);
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _dataContext.Departments.ToList();
        }

        public void InsertDepartment(Department Department_)
        {
            _dataContext.Departments.Add(Department_);
        }

        public void SaveChanges()
        {
            _dataContext.SaveChanges();
        }

        public void UpdateDepartment(Department Department_)
        {
            _dataContext.Entry(Department_).State = System.Data.Entity.EntityState.Modified;
        }
    }
}