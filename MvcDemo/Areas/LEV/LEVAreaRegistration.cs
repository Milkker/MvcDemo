using System.Web.Mvc;

namespace MvcDemo.Areas.LEV
{
    public class LEVAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "LEV";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "LEV_default",
                "LEV/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}