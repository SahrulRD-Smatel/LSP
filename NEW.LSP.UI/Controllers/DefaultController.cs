using NEW.LSP.Dta;
using NEW.LSP.Dta.Custom;
using NEW.LSP.Dto;
using NEW.LSP.Dto.Custom;
using NEW.LSP.UI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace NEW.LSP.UI.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {

            try
            {
                var tupleModel = new Tuple<m_Tb_Home, List<Tb_Pengumuman>>(new m_Tb_Home(Tb_Home_cstmItem.GetAll().FirstOrDefault()), Tb_Pengumuman_cstmItem.GetByDateAktif());
                return View(tupleModel);
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }
    }
}