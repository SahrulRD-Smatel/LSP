using NEW.LSP.Dta;
using NEW.LSP.Dto;
using NEW.LSP.UI.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;

namespace NEW.LSP.UI.Controllers
{
    public class TahunPelajaranController : BaseController
    {
        // GET: TahunPelajaran
        //Hosted web API REST Service base url  

        public string userLogin = string.Empty;
        public string usrTypeLogin = string.Empty;
        [Authorize]
        public ActionResult Index()
        {
            try
            {
                if (Session["usrTypeLogin"] != null) { if (Session["usrTypeLogin"].ToString().ToUpper() != "PROP") { Response.Redirect("~/Login"); } }

                List<Tb_Tahun_Pelajaran> obj = new List<Tb_Tahun_Pelajaran>();
                obj = Tb_Tahun_PelajaranItem.GetAll();

                return View(obj);
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // GET: TahunPelajaran/Details/5
        [Authorize]
        public ActionResult Details(string id)
        {
            try
            {
                Tb_Tahun_Pelajaran obj = new Tb_Tahun_Pelajaran();

                Int32 ID = 0;
                Int32.TryParse(id, out ID);

                obj = Tb_Tahun_PelajaranItem.GetByPK(ID);

                return View(new m_Tb_Tahun_Pelajaran(obj));
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // GET: TahunPelajaran/Create
        [Authorize]
        public ActionResult Create()
        {
            try
            {
                Tb_Tahun_Pelajaran obj = new Tb_Tahun_Pelajaran();

                return View(new m_Tb_Tahun_Pelajaran(obj));
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }

        }

        // POST: TahunPelajaran/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(string id, FormCollection collection)
        {
            try
            {
                userLogin = Session["userLogin"].ToString();
                Tb_Tahun_Pelajaran obj = new Tb_Tahun_Pelajaran();
                obj.Tahun_pelajaran = Request.Form["Tahun_pelajaran"];
                obj.creator = userLogin;
                obj.created = DateTime.Now;

                Tb_Tahun_PelajaranItem.Insert(obj);
                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                return RedirectToAction("Create");
            }
        }

        // GET: TahunPelajaran/Edit/5
        [Authorize]
        public ActionResult Edit(string id)
        {
            try
            {
                Tb_Tahun_Pelajaran obj = new Tb_Tahun_Pelajaran();
                Int32 ID = 0;
                Int32.TryParse(id, out ID);

                obj = Tb_Tahun_PelajaranItem.GetByPK(ID);
                return View(new m_Tb_Tahun_Pelajaran(obj));
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // POST: TahunPelajaran/Edit/5
        [Authorize]
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                userLogin = Session["userLogin"].ToString();
                Tb_Tahun_Pelajaran obj = new Tb_Tahun_Pelajaran();
                obj.ID = Convert.ToInt32(id);
                obj.Tahun_pelajaran = Request.Form["Tahun_pelajaran"];
                obj.editor = userLogin;
                obj.edited = DateTime.Now;

                Tb_Tahun_PelajaranItem.Update(obj);
                return RedirectToAction("Details/" + id);
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // GET: TahunPelajaran/Delete/5
        [Authorize]
        public ActionResult Delete(string id)
        {
            try
            {
                Int32 ID = 0;
                Int32.TryParse(id, out ID);

                Tb_Tahun_PelajaranItem.Delete(ID);
                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }


    }
}
