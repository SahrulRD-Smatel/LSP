using NEW.LSP.Dta;
using NEW.LSP.Dta.Custom;
using NEW.LSP.Dto;
using NEW.LSP.Dto.Custom;
using NEW.LSP.Logic;
using NEW.LSP.UI.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;


namespace NEW.LSP.UI.Controllers
{

    public class ADSekolahController : BaseController
    {
        // GET: ADSekolah
        //Hosted web API REST Service base url  

        public string userLogin = string.Empty;
        public string usrTypeLogin = string.Empty;
        [Authorize]
        public ActionResult Index()
        {
            try
            {
                List<Tb_Admin_Sekolah> obj = new List<Tb_Admin_Sekolah>();
                obj = Tb_Admin_SekolahItem.GetAll();

                return View(obj);
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // GET: ADSekolah/Details/5
        [Authorize]
        public ActionResult Details(string id)
        {
            try
            {
                Tb_Admin_Sekolah_cstm obj = new Tb_Admin_Sekolah_cstm();

                Int32 ID = 0;
                Int32.TryParse(id, out ID);

                obj = Tb_Admin_Sekolah_cstmItem.GetByPK(ID);

                return View(new m_Tb_Admin_Sekolah_cstm(obj));
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // GET: ADSekolah/Create
        [Authorize]
        public ActionResult Create()
        {
            try
            {
                List<Tb_SMK> objSMK = new List<Tb_SMK>();
                Tb_Admin_Sekolah_cstm obj = new Tb_Admin_Sekolah_cstm();

                objSMK = Tb_SMKItem.GetAll();
                Dictionary<string, string> ooList = new Dictionary<string, string>();
                foreach (var xx in objSMK)
                {
                    ooList.Add(xx.NPSN.ToString(), xx.NPSN.ToString() + " - " + xx.Nama_Sekolah);
                }
                ViewBag.dataSMK = dropDownGenerate.toSelectCustom(ooList);

                return View(new m_Tb_Admin_Sekolah_cstm(obj));
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // POST: ADSekolah/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                userLogin = Session["userLogin"].ToString();
                Tb_Admin_Sekolah obj = new Tb_Admin_Sekolah();
                obj.Username = Request.Form["Username"];
                obj.Password = Request.Form["Password"];
                obj.NPSN = Convert.ToInt32(Request.Form["NPSN"]);
                obj.creator = userLogin;
                obj.created = DateTime.Now;

                Tb_Admin_SekolahItem.Insert(obj);
                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                return RedirectToAction("Create");
            }
        }

        // GET: ADSekolah/Edit/5
        [Authorize]
        public ActionResult Edit(string id)
        {
            try
            {
                List<Tb_SMK> objSMK = new List<Tb_SMK>();
                Tb_Admin_Sekolah_cstm obj = new Tb_Admin_Sekolah_cstm();
                objSMK = Tb_SMKItem.GetAll();

                Dictionary<string, string> ooList = new Dictionary<string, string>();
                foreach (var xx in objSMK)
                {
                    ooList.Add(xx.NPSN.ToString(), xx.Nama_Sekolah);
                }
                ViewBag.dataSMK = dropDownGenerate.toSelectCustom(ooList);

                Int32 ID = 0;
                Int32.TryParse(id, out ID);
                obj = Tb_Admin_Sekolah_cstmItem.GetByPK(ID);
                return View(new m_Tb_Admin_Sekolah_cstm(obj));
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // POST: ADSekolah/Edit/5
        [Authorize]
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                userLogin = Session["userLogin"].ToString();
                Tb_Admin_Sekolah obj = new Tb_Admin_Sekolah();
                obj.ID = Convert.ToInt32(id);
                obj.Username = Request.Form["Username"];
                obj.Password = Request.Form["Password"];
                obj.NPSN = Convert.ToInt32(Request.Form["NPSN"]);
                obj.editor = userLogin;
                obj.edited = DateTime.Now;

                Tb_Admin_SekolahItem.Update(obj);
                return RedirectToAction("Details/" + id);
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // GET: ADSekolah/Delete/5
        [Authorize]
        public ActionResult Delete(string id)
        {
            try
            {
                Int32 ID = 0;
                Int32.TryParse(id, out ID);

                Tb_Admin_SekolahItem.Delete(ID);
                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

    }
}
