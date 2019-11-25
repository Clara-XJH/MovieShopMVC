using System.Web;
using System.Web.Mvc;
using MovieShopMVC.Filters;

namespace MovieShopMVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new MovieShopExceptionFilter());
        }
    }
}
