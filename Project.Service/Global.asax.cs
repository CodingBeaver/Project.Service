using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using Project.Service.AutoMapper;
using Project.Service.Entity;
using Project.Service.Repository;
using Project.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Project.Service
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            var builder = new ContainerBuilder();
            var config = new HttpConfiguration();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<VehicleService>().As<IVehicleService>();
            builder.RegisterType<MakeRepository>().As<IMakeRepository>();
            builder.RegisterType<ModelRepository>().As<IModelRepository>();
            builder.RegisterType<VehicleMake>().As<IVehicleMake>();
            builder.RegisterType<VehicleModel>().As<IVehicleModel>();
            builder.RegisterType<VehicleContext>().AsSelf().InstancePerLifetimeScope();


            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<OrganizationProfile>();
            })).AsSelf().InstancePerRequest();

            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var configuration = context.Resolve<MapperConfiguration>();
                return configuration.CreateMapper(context.Resolve);
            }).As<IMapper>().InstancePerLifetimeScope();

            var container = builder.Build();

            GlobalConfiguration.Configuration.DependencyResolver =
                 new AutofacWebApiDependencyResolver(container);



            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
