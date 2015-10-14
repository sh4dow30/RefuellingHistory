using System.Web;
using System.Web.Mvc;

namespace Sh4dow.RefuellingHistory
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
