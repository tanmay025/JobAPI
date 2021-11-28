using JobAPI.ViewModel;
using System.Collections.Generic;

namespace JobAPI.Models
{
    public interface IJobRepository
    {
        IEnumerable<Job> GetJobs();
        IEnumerable<Job> FilterJobs(SearchJobsViewModel request);
        Job GetJobById(int JobId);
        void InsertJob(Job Job_);
        void UpdateJob(Job Job_);
        void DeleteJob(int JobId);
        void SaveChanges();
    }
}