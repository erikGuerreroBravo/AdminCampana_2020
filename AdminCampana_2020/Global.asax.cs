using System;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AdminCampana_2020.App_Start;
using AdminCampana_2020.Controllers;
using AdminCampana_2020.Infraestructure;
using NLog;

namespace AdminCampana_2020
{
    public class MvcApplication : HttpApplication
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        protected void Application_Start()
        {
            Log.Info("Starting up...");
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutomaperWebProfile.Run();
            System.Web.Optimization.BundleTable.EnableOptimizations = true;
            System.Web.Helpers.AntiForgeryConfig.UniqueClaimTypeIdentifier =
               System.Security.Claims.ClaimTypes.NameIdentifier;
            Log.Info("Routes and bundles registered");
            Log.Info("Started");
            
        }

        protected void Application_End()
        {
            Log.Info("Stopped");
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            Log.Error(exception, "Unhandled application exception");

            var httpContext = ((HttpApplication)sender).Context;
            httpContext.Response.Clear();
            httpContext.ClearError();

            if (new HttpRequestWrapper(httpContext.Request).IsAjaxRequest())
            {
                return;
            }

            ExecuteErrorController(httpContext, exception as HttpException);
        }

        private void ExecuteErrorController(HttpContext httpContext, HttpException exception)
        {
            var routeData = new RouteData();
            routeData.Values["controller"] = "Error";

            if (exception != null && exception.GetHttpCode() == (int)HttpStatusCode.NotFound)
            {
                routeData.Values["action"] = "NotFound";
            }
            else
            {
                routeData.Values["action"] = "InternalServerError";
            }

            using (Controller controller = new ErrorController())
            {
                ((IController)controller).Execute(new RequestContext(new HttpContextWrapper(httpContext), routeData));
                
            }
        }
    }
}
