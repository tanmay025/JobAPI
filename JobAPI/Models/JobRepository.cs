using JobAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JobAPI.Models
{
    public class JobRepository : IJobRepository
    {
        private JobsEntities _dataContext;
        public JobRepository(JobsEntities dataContext)
        {
            this._dataContext = dataContext;
        }

        public void DeleteJob(int JobId)
        {
            Job job = _dataContext.Jobs.Find(JobId);
            _dataContext.Jobs.Remove(job);
        }

        public Job GetJobById(int JobId)
        {
            return _dataContext.Jobs.Find(JobId);
        }

        public IEnumerable<Job> GetJobs()
        {
            return _dataContext.Jobs.ToList();
        }
        public IEnumerable<Job> FilterJobs(SearchJobsViewModel searchRequest)
        {
            var query = _dataContext.Jobs
                                    .Where(job =>
                                           job.Title
                                            .Contains(searchRequest.SearchValue))
                                    .AsEnumerable();
            if (searchRequest.departmentId.HasValue)
            {
                query = query.Where(job =>
                                    job.DepartmentKey == searchRequest.departmentId);
            }

            if (searchRequest.locationId.HasValue)
            {
                query = query.Where(job =>
                                    job.LocationKey == searchRequest.locationId);
            }

            var pageSize = searchRequest.PageSize;
            var pageNumber = searchRequest.PageNo - 1;
            if (pageSize == 0)
            {
                pageSize = 10;
            }
            if (pageNumber != 0)
            {
                query = query.OrderBy(job =>
                                  job.Title)
                             .Skip(pageNumber * pageSize);
            }

            return query.Take(searchRequest.PageSize);
        }

        public void InsertJob(Job job)
        {
            _dataContext.Jobs.Add(job);
        }

        public void SaveChanges()
        {
            _dataContext.SaveChanges();
        }

        public void UpdateJob(Job job)
        {
            _dataContext.Entry(job).State = System.Data.Entity.EntityState.Modified;
        }
    }
}