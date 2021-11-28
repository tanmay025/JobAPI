using JobAPI.Models;
using JobAPI.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;

namespace JobAPI.Controllers
{
    public class LocationsController : ApiController
    {
        private ILocationRepository locationRepository;
        public LocationsController()
        {
            this.locationRepository = new LocationRepository(new JobsEntities());
        }

        // GET api/<controller>
        public IEnumerable<ResponseLocationViewModel> Get()
        {
            return locationRepository.GetLocations()
                                     .ToList()
                                     .Select(location =>
                                             new ResponseLocationViewModel()
                                             {
                                                 Id = location.LocationKey,
                                                 Title = location.Title,
                                                 City = location.City,
                                                 state = location.state,
                                                 country = location.country,
                                                 zip = location.zip
                                             });
        }

        // POST api/<controller>
        public int Post([FromBody] RequestLocationViewModel value)
        {
            var location = new Location()
            {
                Title = value.Title,
                City = value.City,
                state = value.state,
                country = value.country,
                zip = value.zip
            };

            locationRepository.InsertLocation(location);
            locationRepository.SaveChanges();
            return location.LocationKey;
        }

        // PUT api/<controller>/5
        public StatusCodeResult Put(int id, [FromBody] RequestLocationViewModel value)
        {
            var location = locationRepository.GetLocationById(id);

            location.Title = value.Title;
            location.City = value.City;
            location.state = value.state;
            location.country = value.country;
            location.zip = value.zip;
            locationRepository.UpdateLocation(location);
            locationRepository.SaveChanges();
            return new StatusCodeResult(HttpStatusCode.OK, this);
        }
    }
}