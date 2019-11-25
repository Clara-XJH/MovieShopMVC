using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieShopMVC.Filters
{
    /* The HandleError filter handles the exceptions that are raised by the controller actions, filters and views,
        it returns a custom view named Error which is placed in the Shared folder. 
        The HandleError filter works only if the <customErrors> section is turned on in web.config

    
       The HandleError filter not only just returns the Error view but it also creates and passes the HandleErrorInfo model 
       to the view. The HandleErrorInfo model contains the details about the exception and the names of the controller and action
       that caused the exception
       
       The HandleError filter has some limitations by the way.
        
        1. Not support to log the exceptions 
        2. Doesn't catch HTTP exceptions other than 500 
        3. Doesn't catch exceptions that are raised outside controllers 
        4. Returns error view even for exceptions raised in AJAX calls
        
      */

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class MovieShopExceptionFilter: HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            var controllerName = (string)filterContext.RouteData.Values["controller"];
            var actionName = (string)filterContext.RouteData.Values["action"];
            var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);

            filterContext.Result = new ViewResult
                                   {
                                       ViewName = View,
                                       MasterName = Master,
                                       ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                                       TempData = filterContext.Controller.TempData
                                   };

            var dateExceptionHappened = DateTime.Now.TimeOfDay.ToString();
            //set breakpoint on the following line to see what the requested path and query is
            var pathAndQuery = filterContext.HttpContext.Request.Path + filterContext.HttpContext.Request.QueryString;

            // throw new FileNotFoundException();
            // log the error using logging Frameworks such as nLog, SeriLog, log4net etc.


            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 500;

            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
            base.OnException(filterContext);
        }
    }
}