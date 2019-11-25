using System;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MovieShopMVC
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            /* Exception filters are not global error handlers and this is an important reason that forces us to still rely 
                on Application_Error event. Some programmers don't even use the HandleError filter in their application at all
                and use only the Application_Error event for doing all the error handling and logging work

                The important problem we face in the Application_Error event is, once the program execution reaches this point then
                we are out of MVC context and because of that we can miss some context information related to the exception

                When we need a controller or action level exception handling then we can use the HandleError filter along with
                the Application_Error event else we can simply ignore the HandleError filter
              */

            var exception = Server.GetLastError();
            Response.Clear();

            HttpException httpException = exception as HttpException;

            if (httpException != null)
            {
                string action;
                string friendlyMessage;
                switch (httpException.GetHttpCode())
                {
                    case 404:
                        // page not found
                        action = "NotFoundError";
                        friendlyMessage = "Sorry, No Page found for requested URL";
                        break; 
                    case 401:
                        // UnAuthorized
                        action = "AccessDeniedError";
                        friendlyMessage = "Sorry, You are nor Authorized";
                        break;
                    case 500:
                        // server error
                        action = "InternalError";
                        friendlyMessage = "Sorry, Something bad happened, please try again later";
                        break;
                    default:
                        action = "GeneralError";
                        friendlyMessage = "Sorry, Something bad happened, please try again later";
                        break;
                }

                // clear error on server
                Server.ClearError();

                Response.Redirect($"~/Error/{action}/?message={friendlyMessage}");

            }
            else
            {
                Response.Redirect($"~/Error/GeneralError/?message=something bad happened ");
            }
        }
    }
}