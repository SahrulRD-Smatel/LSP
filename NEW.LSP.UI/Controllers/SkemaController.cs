using NEW.LSP.Dta;
using NEW.LSP.Dta.Custom;
using NEW.LSP.Dto;
using NEW.LSP.Dto.Custom;
using NEW.LSP.Logic;
using NEW.LSP.UI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;

namespace NEW.LSP.UI.Controllers
{
    public class SkemaController : BaseController
    {
        public string userLogin = string.Empty;
        public string usrTypeLogin = string.Empty;
        [Authorize]

        public ActionResult Index()
        {
            List<Tb_Skema> EmpInfo = new List<Tb_Skema>();
            try
            {
                if (Session["usrTypeLogin"] != null) { if (Session["usrTypeLogin"].ToString().ToUpper() != "PROP") { Response.Redirect("~/Login"); } }

                EmpInfo = Tb_SkemaItem.GetAll();
                return View(EmpInfo);
            }
            catch
            {
                return View(EmpInfo);
            }
        }


        // GET: Skema/Details/5
        [Authorize]
        public ActionResult Details(string id)
        {
            try
            {
                Tb_Skema obj = new Tb_Skema();
                Int32 ID = 0;
                Int32.TryParse(id, out ID);

                obj = Tb_SkemaItem.GetByPK(ID);

                return View(new m_Tb_Skema(obj));
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }

        }

        [Authorize]
        public ActionResult Create()
        {
            try
            {
                Tb_Skema obj = new Tb_Skema();
                return View(new m_Tb_Skema(obj));
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // POST: Skema/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(string id, FormCollection collection)
        {
            try
            {
                userLogin = Session["userLogin"].ToString();
                Tb_Skema obj = new Tb_Skema();
                obj.Kode_KK = Convert.ToInt32(Request.Form["Kode_KK"]);
                obj.Kode_Skema = Convert.ToInt32(Request.Form["Kode_Skema"]);
                obj.Skema = Request.Form["Skema"];
                obj.creator = userLogin;
                obj.created = DateTime.Now;

                Tb_SkemaItem.Insert(obj);

                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        [Authorize]
        public ActionResult Edit(string id)
        {
            try
            {
                Tb_Skema obj = new Tb_Skema();
                Int32 ID = 0;
                Int32.TryParse(id, out ID);

                obj = Tb_SkemaItem.GetByPK(ID);

                return View(new m_Tb_Skema(obj));
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // POST: Skema/Edit/5
        [Authorize]
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                userLogin = Session["userLogin"].ToString();
                Tb_Skema obj = new Tb_Skema();
                obj.Kode_Skema = Convert.ToInt32(id);
                obj.Kode_KK = Convert.ToInt32(Request.Form["Kode_KK"]);
                obj.Skema = Request.Form["Skema"];
                obj.editor = userLogin;
                obj.edited = DateTime.Now;

                Tb_SkemaItem.Update(obj);

                return RedirectToAction("Details/" + id);
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // GET: Skema/Delete/5
        [Authorize]
        public ActionResult Delete(string id)
        {
            try
            {
                Int32 ID = 0;
                Int32.TryParse(id, out ID);

                Tb_SkemaItem.Delete(ID);

                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }
    }
}
