using System.Web.Mvc;

namespace Software_Project_Estimation_Tool.Areas.COCOMOII
{
    public class COCOMOIIAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "COCOMOII";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "COCOMOII_default",
                "COCOMOII/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}