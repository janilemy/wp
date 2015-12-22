using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WeeklyPlaner.DAL;
using System.Data.Entity.Infrastructure.Interception;

namespace WeeklyPlaner
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // add for errors and logging
            DbInterception.Add(new WeeklyPlanerInterceptorTransientErrors());
            DbInterception.Add(new WeeklyPlanerInterceptorLogging());
        }
    }
}
