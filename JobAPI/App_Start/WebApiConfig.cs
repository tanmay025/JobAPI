using System.Web.Http;

namespace JobAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "JobApiv1",
                routeTemplate: "api/v1/jobs/{id}",
                defaults: new { controller = "Jobs", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "Locationv1",
                routeTemplate: "api/v1/locations/{id}",
                defaults: new { controller = "Locations", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "Departmentv1",
                routeTemplate: "api/v1/departments/{id}",
                defaults: new { controller = "Departments", id = RouteParameter.Optional }
            );

            config.Filters.Add(new ValidateModelAttribute());
        }
    }
}
