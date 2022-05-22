using NEW.LSP.Dta;
using NEW.LSP.Dto;
using NEW.LSP.UI.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;

namespace NEW.LSP.UI.Controllers
{
  
    public class KKeahlianController : BaseController
    {
        // GET: KKeahlian  

        public string userLogin = string.Empty;
        public string usrTypeLogin = string.Empty;
        [Authorize]
        public ActionResult Index()
        {
            try
            {
                if (Session["usrTypeLogin"] != null) { if (Session["usrTypeLogin"].ToString().ToUpper() != "PROP") { Response.Redirect("~/Login"); } }

                List<Tb_Kompetensi_Keahlian> obj = new List<Tb_Kompetensi_Keahlian>();
                obj = Tb_Kompetensi_KeahlianItem.GetAll();

                return View(obj);
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // GET: KKeahlian/Details/5
        [Authorize]
        public ActionResult Details(string id)
        {
            try
            {
                Tb_Kompetensi_Keahlian obj = new Tb_Kompetensi_Keahlian();
                Int32 ID = 0;
                Int32.TryParse(id, out ID);

                obj = Tb_Kompetensi_KeahlianItem.GetByPK(ID);

                return View(new m_Tb_Kompetensi_Keahlian(obj));
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }

        }

        // GET: KKeahlian/Create
        [Authorize]
        public ActionResult Create()
        {
            try
            {
                Tb_Kompetensi_Keahlian obj = new Tb_Kompetensi_Keahlian();
                return View(new m_Tb_Kompetensi_Keahlian(obj));
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // POST: KKeahlian/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(string id, FormCollection collection)
        {
            try
            {
                userLogin = Session["userLogin"].ToString();
                Tb_Kompetensi_Keahlian obj = new Tb_Kompetensi_Keahlian();
                obj.Kode_KK = Convert.ToInt32(Request.Form["Kode_KK"]);
                obj.Nama_KK = Request.Form["Nama_KK"];
                obj.creator = userLogin;
                obj.created = DateTime.Now;

                Tb_Kompetensi_KeahlianItem.Insert(obj);

                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // GET: KKeahlian/Edit/5
        [Authorize]
        public ActionResult Edit(string id)
        {
            try
            {
                Tb_Kompetensi_Keahlian obj = new Tb_Kompetensi_Keahlian();
                Int32 ID = 0;
                Int32.TryParse(id, out ID);

                obj = Tb_Kompetensi_KeahlianItem.GetByPK(ID);

                return View(new m_Tb_Kompetensi_Keahlian(obj));
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // POST: KKeahlian/Edit/5
        [Authorize]
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                userLogin = Session["userLogin"].ToString();
                Tb_Kompetensi_Keahlian obj = new Tb_Kompetensi_Keahlian();
                obj.Kode_KK = Convert.ToInt32(id);
                obj.Nama_KK = Request.Form["Nama_KK"];
                obj.editor = userLogin;
                obj.edited = DateTime.Now;

                Tb_Kompetensi_KeahlianItem.Update(obj);

                return RedirectToAction("Details/" + id);
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // GET: KKeahlian/Delete/5
        [Authorize]
        public ActionResult Delete(string id)
        {
            try
            {
                Int32 ID = 0;
                Int32.TryParse(id, out ID);

                Tb_Kompetensi_KeahlianItem.Delete(ID);

                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }
     
    }
}
