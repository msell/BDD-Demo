using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CreditCardServices.Api.Controllers;
using log4net;
using StructureMap;
using WebApiContrib.IoC.StructureMap;

namespace CreditCardServices.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            InitContainer();
        }

        public static IContainer InitContainer()
        {
            ObjectFactory.Initialize(init =>
            {
                init.Scan((scanner) =>
                {
                    scanner.TheCallingAssembly();
                    scanner.AssemblyContainingType<CreditApplicationController>();
                    scanner.RegisterConcreteTypesAgainstTheFirstInterface();
                });
                init.For<ILog>().Use(x => LogManager.GetLogger(x.Root.ConcreteType));
            });

            GlobalConfiguration.Configuration.DependencyResolver =
                new StructureMapResolver(ObjectFactory.Container);

            return ObjectFactory.Container;
        }
    }
}
