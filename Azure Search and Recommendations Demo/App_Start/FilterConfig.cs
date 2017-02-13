using System.Web;
using System.Web.Mvc;

namespace Azure_Search_and_Recommendations_Demo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
