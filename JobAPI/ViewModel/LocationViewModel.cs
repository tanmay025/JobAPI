using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobAPI.ViewModel
{
    public class LocationViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zip{ get; set; }
    }
}