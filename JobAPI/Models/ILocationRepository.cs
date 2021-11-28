using System.Collections.Generic;

namespace JobAPI.Models
{
    public interface ILocationRepository
    {
        IEnumerable<Location> GetLocations();
        Location GetLocationById(int LocationId);
        void InsertLocation(Location Location_);
        void UpdateLocation(Location Location_);
        void DeleteLocation(int LocationId);
        void SaveChanges();
    }
}