using System.Web.Mvc;

namespace Software_Project_Estimation_Tool.Areas.SLIM
{
    public class SLIMAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SLIM";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "SLIM_default",
                "SLIM/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}