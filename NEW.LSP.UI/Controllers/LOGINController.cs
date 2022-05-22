using NEW.LSP.Dta;
using NEW.LSP.Dto;
using NEW.LSP.Logic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace NEW.LSP.UI.Controllers
{
    public class LOGINController : Controller
    {
        // GET: LOGIN

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception err)
            {
                return View(err.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var userName = Request.Form["username"];
                    var password = Request.Form["password"];
                    Security.MD5Hash(password.Trim());
                    v_Login Item = v_LoginItem.GetByPK(userName);
                    if (Item != null && Item.Password == password)
                    {
                        FormsAuthentication.SetAuthCookie(Item.Username + "|" + Item.typeUser + "|" + Item.Nama, false);

                        string urls = Request.QueryString["ReturnUrl"];
                        if (!string.IsNullOrEmpty(urls))
                        {
                            List<string> stringList = urls.Split('/').ToList();

                            if (stringList.Count == 4)
                            {
                                return RedirectToAction(stringList[2], stringList[1], new { id = stringList[3] });
                            }
                        }
                        if (Item.typeUser == "PROP")
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else if (Item.typeUser == "SKL")
                        {
                            return RedirectToAction("Index", "HomeSKL");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Login");
                        }
                    }
                }

                ModelState.AddModelError("", "invalid Username or Password");
                return View();

            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
                //return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Default");
        }

    }
}
