using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace NEW.LSP.UI.Controllers
{
    public class BaseController : Controller
    {

        [AllowAnonymous]
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            //FormsAuthentication.SignOut();
            //string serverName = HttpUtility.UrlEncode(Request.ServerVariables["SERVER_NAME"]);
            //string vdirName = Request.ApplicationPath;
            //Response.Redirect(HttpContext.Current.Request.Url.Authority + redirect);
            //Response.Redirect("~" + redirect);

            if (User.Identity.IsAuthenticated)
            {
                if (Session["userLogin"] == null)
                {
                    HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

                    Session["usrTypeLogin"] = ticket.Name.Split('|')[1];
                    Session["NPSN"] = ticket.Name.Split('|')[2];
                    Session["userLogin"] = ticket.Name.Split('|')[0];
                }
            }
            else
            {
                Response.Redirect("~/Login");
            }



        }

    }
}