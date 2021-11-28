using System.Collections.Generic;
using System.Linq;

namespace JobAPI.Models
{
    public class LocationRepository : ILocationRepository
    {
        private JobsEntities _dataContext;
        public LocationRepository(JobsEntities dataContext)
        {
            this._dataContext = dataContext;
        }
        public void DeleteLocation(int LocationId)
        {
            Location location = _dataContext.Locations.Find(LocationId);
            _dataContext.Locations.Remove(location);
        }

        public Location GetLocationById(int LocationId)
        {
            return _dataContext.Locations.Find(LocationId);
        }

        public IEnumerable<Location> GetLocations()
        {
            return _dataContext.Locations.ToList();
        }

        public void InsertLocation(Location Location_)
        {
            _dataContext.Locations.Add(Location_);
        }

        public void SaveChanges()
        {
            _dataContext.SaveChanges();
        }

        public void UpdateLocation(Location Location_)
        {
            _dataContext.Entry(Location_).State = System.Data.Entity.EntityState.Modified;
        }
    }
}