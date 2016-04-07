using System.Web.Mvc;

namespace SupplyChain.WebUI.Areas.BusinessPartners
{
    public class BusinessPartnersAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "BusinessPartners";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "BusinessPartners_default",
                "BusinessPartners/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}