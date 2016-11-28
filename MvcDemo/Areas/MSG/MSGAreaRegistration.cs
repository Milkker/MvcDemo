using System.Web.Mvc;

namespace MvcDemo.Areas.MSG
{
    public class MSGAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "MSG";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "MSG_default",
                "MSG/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}