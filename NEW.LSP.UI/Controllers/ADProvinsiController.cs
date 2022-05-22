
using NEW.LSP.Dta;
using NEW.LSP.Dto;
using NEW.LSP.UI.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;

namespace NEW.LSP.UI.Controllers
{

    public class ADProvinsiController : BaseController
    {
        // GET: ADProvinsi
        //Hosted web API REST Service base url  

        public string userLogin = string.Empty;
        public string usrTypeLogin = string.Empty;
        [Authorize]
        public ActionResult Index()
        {
            try
            {
                if (Session["usrTypeLogin"] != null) { if (Session["usrTypeLogin"].ToString().ToUpper() != "PROP") { Response.Redirect("~/Login"); } }

                List<Tb_Admin_Provinsi> obj = new List<Tb_Admin_Provinsi>();
                obj = Tb_Admin_ProvinsiItem.GetAll();

                return View(obj);
            }
            catch (Exception err)
            {                
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // GET: ADProvinsi/Details/5
        [Authorize]
        public ActionResult Details(string id)
        {
            try
            {
                Tb_Admin_Provinsi obj = new Tb_Admin_Provinsi();

                Int32 ID = 0;
                Int32.TryParse(id, out ID);

                obj = Tb_Admin_ProvinsiItem.GetByPK(ID);

                return View(new m_Tb_Admin_Provinsi(obj));
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // GET: ADProvinsi/Create
        [Authorize]
        public ActionResult Create()
        {
            try
            {
                Tb_Admin_Provinsi obj = new Tb_Admin_Provinsi();

                return View(new m_Tb_Admin_Provinsi(obj));
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // POST: ADProvinsi/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(string id, FormCollection collection)
        {
            try
            {
                userLogin = Session["userLogin"].ToString();

                Tb_Admin_Provinsi obj = new Tb_Admin_Provinsi();
                obj.Username = Request.Form["Username"];
                obj.Password = Request.Form["Password"];
                obj.NamaLengkap = Request.Form["NamaLengkap"];
                obj.creator = userLogin;
                obj.created = DateTime.Now;

                Tb_Admin_ProvinsiItem.Insert(obj);
                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                return RedirectToAction("Create");
            }
        }

        // GET: ADProvinsi/Edit/5
        [Authorize]
        public ActionResult Edit(string id)
        {
            try
            {
                Tb_Admin_Provinsi obj = new Tb_Admin_Provinsi();
                Int32 ID = 0;
                Int32.TryParse(id, out ID);

                obj = Tb_Admin_ProvinsiItem.GetByPK(ID);
                return View(new m_Tb_Admin_Provinsi(obj));
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // POST: ADProvinsi/Edit/5
        [Authorize]
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                userLogin = Session["userLogin"].ToString();

                Tb_Admin_Provinsi obj = new Tb_Admin_Provinsi();
                obj.ID = Convert.ToInt32(id);
                obj.Username = Request.Form["Username"];
                obj.Password = Request.Form["Password"];
                obj.NamaLengkap = Request.Form["NamaLengkap"];
                obj.editor = userLogin;
                obj.edited = DateTime.Now;

                Tb_Admin_ProvinsiItem.Update(obj);

                return RedirectToAction("Details/" + id);
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // GET: ADProvinsi/Delete/5
        [Authorize]
        public ActionResult Delete(string id)
        {
            try
            {
                Int32 ID = 0;
                Int32.TryParse(id, out ID);

                Tb_Admin_ProvinsiItem.Delete(ID);
                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

    }
}
