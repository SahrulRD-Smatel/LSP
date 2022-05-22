using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ui.LSP.Models;

namespace ui.LSP.Controllers
{

    [Authorize]
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            List<Tb_Menu> mnu = new List<Tb_Menu>();

            return View(mnu);
        }
    }
}