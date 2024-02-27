using System.Web;
using System.Web.Mvc;

namespace Laboratoire3_Guitare
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
