using JobAPI.Models;
using JobAPI.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;

namespace JobAPI.Controllers
{
    public class DepartmentsController : ApiController
    {
        private IDepartmentRepository departmentRepository;
        public DepartmentsController()
        {
            this.departmentRepository = new DepartmentRepository(new JobsEntities());
        }

        // GET api/<controller>
        public IEnumerable<ResponseDepartmentViewModel> Get()
        {
            return departmentRepository.GetDepartments()
                                     .ToList()
                                     .Select(department =>
                                             new ResponseDepartmentViewModel()
                                             {
                                                 Id = department.DepartmentKey,
                                                 Title = department.Title,
                                             });
        }

        // POST api/<controller>
        public int Post([FromBody] RequestDepartmentViewModel value)
        {

            var department = new Department()
            {
                Title = value.Title,
            };

            departmentRepository.InsertDepartment(department);
            departmentRepository.SaveChanges();
            return department.DepartmentKey;
        }

        // PUT api/<controller>/5
        public StatusCodeResult Put(int id, [FromBody] RequestDepartmentViewModel value)
        {
            var department=departmentRepository.GetDepartmentById(id);
            department.Title = value.Title;
            departmentRepository.UpdateDepartment(department);
            departmentRepository.SaveChanges();
            return new StatusCodeResult(HttpStatusCode.OK, this);
        }
    }
}