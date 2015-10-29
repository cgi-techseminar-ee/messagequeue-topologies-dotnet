namespace Web
{
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using Common;

    using MassTransit;

    public class MvcApplication : System.Web.HttpApplication
    {
        private static IBusControl bus;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            bus = BusFactory.Create("ps-web", configurator => { });
        }

        public static Task Publish<T>(T message) where T : class
        {
            return bus.Publish(message);
        }
    }
}