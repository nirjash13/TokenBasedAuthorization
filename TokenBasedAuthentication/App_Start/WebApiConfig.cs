using System.Reflection;
using System.Web.Http;
using System.Web.Http.Cors;
using Autofac;
using Autofac.Integration.WebApi;
using TokenBasedAuthentication.DataAccess.Interfaces;
using TokenBasedAuthentication.DataAccess.Services;
using AuthorizeAttribute = TokenBasedAuthentication.Infrastructure.AuthorizeAttribute;

namespace TokenBasedAuthentication
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute("*", "*", "*");
            //config.EnableCors(cors);
            // Web API configuration and services
            // Web API routes


            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
            );

            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            RegisterServices(builder);
            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            config.DependencyResolver = resolver;

            config.Filters.Add(new AuthorizeAttribute());
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<SecurityService>()
                .As<ISecurityService>();
        }
    }
}