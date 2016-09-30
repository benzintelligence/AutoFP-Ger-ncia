using System.Web.Mvc;

namespace AutoFP.Gerencia.MVC.UI.Attribute
{
    public class AutorizacaoAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            if (filterContext.Result is HttpUnauthorizedResult)
                filterContext.HttpContext.Response.Redirect("");
        }
    }
}