using NEW.LSP.Dta;
using NEW.LSP.Dta.Custom;
using NEW.LSP.Dto;
using NEW.LSP.Dto.Custom;
using NEW.LSP.UI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace NEW.LSP.UI.Controllers
{
    public class PengumumanSKLController : BaseController
    {
        // GET: PengumumanSKL
        public string userLogin = string.Empty;
        public string usrTypeLogin = string.Empty;

        [Authorize]
        public ActionResult Index()
        {
            List<Tb_Pengumuman> obj = new List<Tb_Pengumuman>();

            try
            {
                if (Session["usrTypeLogin"] != null) { if (Session["usrTypeLogin"].ToString().ToUpper() != "SKL") { Response.Redirect("~/Login"); } }

                obj = Tb_PengumumanItem.GetAll();

                return View(obj);
            }
            catch
            {
                return View(obj);
            }
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            Tb_Pengumuman objAll = new Tb_Pengumuman();
            try
            {
                objAll = Tb_PengumumanItem.GetByPK(id);
                return View(new m_Tb_Pengumuman(objAll));
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }

        }

        //Custom
        [Authorize]
        public JsonResult IsAlreadyNo(string no)
        {
            try
            {
                bool status;

                Tb_Pengumuman obj = new Tb_Pengumuman();
                obj = Tb_Pengumuman_cstmItem.GetByNo(no);
                if (obj != null)
                {
                    //Already registered  
                    status = false;
                }
                else
                {
                    //Available to use  
                    status = true;
                }

                return Json(status, JsonRequestBehavior.AllowGet);
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj);
                return Json(false, err.Message);
            }
        }

    }
}