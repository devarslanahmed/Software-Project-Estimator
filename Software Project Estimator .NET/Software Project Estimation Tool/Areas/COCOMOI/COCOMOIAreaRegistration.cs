using System.Web.Mvc;

namespace Software_Project_Estimation_Tool.Areas.COCOMOI
{
    public class COCOMOIAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "COCOMOI";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "COCOMOI_default",
                "COCOMOI/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}