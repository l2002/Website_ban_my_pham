using System.Web;
using System.Web.Mvc;

namespace Bán_Mỹ_Phẩm
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}