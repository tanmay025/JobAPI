using JobAPI.Models;
using JobAPI.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;

namespace JobAPI.Controllers
{
    public class JobsController : ApiController
    {
        private IJobRepository jobRepository;
        public JobsController()
        {
            this.jobRepository = new JobRepository(new JobsEntities());
        }

        /// <summary>
        /// API allows to get job details based on the Id
        /// </summary>
        /// <param name="id">Job Id</param>
        /// <returns>ResponseJobViewModel response class to display job details</returns>
        public ResponseJobViewModel Get(int id)
        {
            var job = jobRepository.GetJobById(id);
            return new ResponseJobViewModel()
            {
                Id = job.JobKey,
                Code = job.Code,
                Title = job.Title,
                Description = job.Description,
                Location = new LocationViewModel()
                {
                    Id = job.Location.LocationKey,
                    Title = job.Location.Title,
                    City = job.Location.City,
                    State = job.Location.state,
                    Country = job.Location.country,
                    Zip = job.Location.zip,
                },
                Department = new DepartmentViewModel()
                {
                    Id = job.Department.DepartmentKey,
                    Title = job.Department.Title
                },
                PostedDate = job.PostedDate,
                ClosingDate = job.ClosingDate,
            };
        }

        /// <summary>
        /// API searches the jobs and returns the list of jobs based on the page number and page size
        /// </summary>
        /// <param name="request">
        /// SearchValue : compares with title of the job
        /// pageNo: page number ranges from 1 to max
        /// pageSize: page size ranges from 1 to 100
        /// departmentid: optional parameter to compare against department of the job
        /// locationid: optional parameter to compare against location of the job
        /// </param>
        /// <returns>List of ResponseJobViewModel response class to display job details</returns>
        [Route("api/jobs/list")]
        public List<ResponseJobViewModel> List(SearchJobsViewModel request)
        {
            var output = jobRepository.FilterJobs(request);
            return output.ToList().Select(job =>
            new ResponseJobViewModel()
            {
                Id = job.JobKey,
                Code = job.Code,
                Title = job.Title,
                Description = job.Description,
                Location = new LocationViewModel()
                {
                    Id = job.Location.LocationKey,
                    Title = job.Location.Title,
                    City = job.Location.City,
                    State = job.Location.state,
                    Country = job.Location.country,
                    Zip = job.Location.zip,
                },
                Department = new DepartmentViewModel()
                {
                    Id = job.Department.DepartmentKey,
                    Title = job.Department.Title
                },
                PostedDate = job.PostedDate,
                ClosingDate = job.ClosingDate,
            }).ToList();
        }
        /// <summary>
        /// API to post/create jobs in the system
        /// </summary>
        /// <param name="value">Request object with job details</param>
        /// <returns>Job Id of the created job</returns>
        public int Post([FromBody] RequestJobViewModel value)
        {
            var job = new Job()
            {
                DepartmentKey = value.DepartmentId,
                LocationKey = value.LocationId,
                Title = value.Title,
                Description = value.Description,
                PostedDate = System.DateTime.Now,
                ClosingDate = value.ClosingDate,
                Code = ""
            };

            jobRepository.InsertJob(job);
            jobRepository.SaveChanges();
            return job.JobKey;
        }

        /// <summary>
        /// API to update the job
        /// </summary>
        /// <param name="id">Job ID</param>
        /// <param name="value">Request object to update the job detail</param>
        /// <returns>status code returned on success</returns>
        public StatusCodeResult Put(int id, [FromBody] RequestJobViewModel value)
        {
            var job = jobRepository.GetJobById(id);

            job.DepartmentKey = value.DepartmentId;
            job.LocationKey = value.LocationId;
            job.Title = value.Title;
            job.Description = value.Description;
            job.ClosingDate = value.ClosingDate;
            job.Code = "";

            jobRepository.UpdateJob(job);
            jobRepository.SaveChanges();
            return new StatusCodeResult(HttpStatusCode.OK, this);
        }
    }
}