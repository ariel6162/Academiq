using Academiq.Interfaces;
using Academiq.Models;
using Academiq.Repositories;
using Academiq.Services;
using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Academiq
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();

            // Register MVC controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Register model binders
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            // Register web abstractions
            builder.RegisterModule<AutofacWebTypesModule>();

            // Enable property injection in view pages
            builder.RegisterSource(new ViewRegistrationSource());

            // Enable property injection into action filters
            builder.RegisterFilterProvider();

            // Register services and repositories
            builder.RegisterType<CourseService>().As<ICourseService>();
            builder.RegisterType<AcademiqDBEntities>().AsSelf().InstancePerRequest();
            builder.RegisterType<CourseRepository>().As<ICourseRepository>().InstancePerLifetimeScope();

            // Set Autofac as the dependency resolver
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}