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
 
    public class JejaringController : BaseController
    {
        // GET: Jejaring
        //Hosted web API REST Service base url  
        public string userLogin = string.Empty;
        public string usrTypeLogin = string.Empty;
        [Authorize]
        public ActionResult Index()
        {
            try
            {
                if (Session["usrTypeLogin"] != null) { if (Session["usrTypeLogin"].ToString().ToUpper() != "PROP") { Response.Redirect("~/Login"); } }

                List<Tb_Jejaring_cstm> objList = new List<Tb_Jejaring_cstm>();

                objList = Tb_Jejaring_cstmItem.GetAll();

                return View(objList);
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // GET: Jejaring/Details/5
        [Authorize]
        [HttpGet]
        public ActionResult Details(string id)
        {
            try
            {
                Tb_Jejaring_cstm obj = new Tb_Jejaring_cstm();
                Int32 ID = 0;
                Int32.TryParse(id, out ID);

                obj = Tb_Jejaring_cstmItem.GetByPK(ID);

                return View(new m_Tb_Jejaring_cstm(obj));
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }


        // GET: Jejaring/Create
        [Authorize]
        public ActionResult Create()
        {
            try
            {          
                Tb_Jejaring_cstm obj = new Tb_Jejaring_cstm();
                List<Tb_Kompetensi_Keahlian> objKK = new List<Tb_Kompetensi_Keahlian>();
                List<Tb_SMK> objSMK = new List<Tb_SMK>();
                List<Tb_LSP_cstm> objLSP = new List<Tb_LSP_cstm>();

                objLSP = Tb_LSP_cstmItem.GetAll();
                objKK = Tb_Kompetensi_KeahlianItem.GetAll();
                objSMK = Tb_SMKItem.GetAll();

                //begin
                Dictionary<string, string> ooList = new Dictionary<string, string>();
                foreach (var xx in objLSP)
                {
                    ooList.Add(xx.Nomer_Lisensi, xx.Nomer_Lisensi + " - " + xx.Nama_Sekolah);
                }
                ViewBag.lspList = dropDownGenerate.toSelectCustom(ooList);
                //end

                //begin
                ooList = new Dictionary<string, string>();
                foreach (var xx in objKK)
                {
                    ooList.Add(xx.Kode_KK.ToString(), xx.Kode_KK.ToString() + " - " + xx.Nama_KK);
                }
                ViewBag.Kode_KKList = dropDownGenerate.toSelectCustom(ooList);
                //end

                //begin
                ooList = new Dictionary<string, string>();
                foreach (var xx in objSMK)
                {
                    ooList.Add(xx.NPSN.ToString(), xx.NPSN.ToString() + " - " + xx.Nama_Sekolah);
                }
                ViewBag.dataSMK = dropDownGenerate.toSelectCustom(ooList);
                //end

                return View(new m_Tb_Jejaring_cstm(obj));
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // POST: Jejaring/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(string id, FormCollection collection)
        {
            try
            {
                userLogin = Session["userLogin"].ToString();
                Tb_Jejaring obj = new Tb_Jejaring();
                obj.Nomer_Lisensi = Request.Form["Nomer_Lisensi"];
                obj.Kode_KK_Terlisensi = Convert.ToInt32(Request.Form["Kode_KK_Terlisensi"]);
                obj.NPSN = Convert.ToInt32(Request.Form["NPSNJ"]);
                obj.creator = userLogin;
                obj.created = DateTime.Now;

                Tb_JejaringItem.Insert(obj);            

                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                return RedirectToAction("Create");
            }
        }

        // GET: Jejaring/Edit/5
        [Authorize]
        public ActionResult Edit(string id)
        {
            try
            {
                Tb_Jejaring_cstm obj = new Tb_Jejaring_cstm();
                List<Tb_Kompetensi_Keahlian> objKK = new List<Tb_Kompetensi_Keahlian>();
                List<Tb_SMK> objSMK = new List<Tb_SMK>();
                List<Tb_LSP_cstm> objLSP = new List<Tb_LSP_cstm>();

                objLSP = Tb_LSP_cstmItem.GetAll();
                objKK = Tb_Kompetensi_KeahlianItem.GetAll();
                objSMK = Tb_SMKItem.GetAll();

                //begin
                Dictionary<string, string> ooList = new Dictionary<string, string>();
                foreach (var xx in objLSP)
                {
                    ooList.Add(xx.Nomer_Lisensi, xx.Nomer_Lisensi + " - " + xx.Nama_Sekolah);
                }
                ViewBag.lspList = dropDownGenerate.toSelectCustom(ooList);
                //end

                //begin
                ooList = new Dictionary<string, string>();
                foreach (var xx in objKK)
                {
                    ooList.Add(xx.Kode_KK.ToString(), xx.Kode_KK.ToString() + " - " + xx.Nama_KK);
                }
                ViewBag.Kode_KKList = dropDownGenerate.toSelectCustom(ooList);
                //end

                //begin
                ooList = new Dictionary<string, string>();
                foreach (var xx in objSMK)
                {
                    ooList.Add(xx.NPSN.ToString(), xx.NPSN.ToString() + " - " + xx.Nama_Sekolah);
                }
                ViewBag.dataSMK = dropDownGenerate.toSelectCustom(ooList);
                //end

                Int32 ID = 0;
                Int32.TryParse(id, out ID);

                obj = Tb_Jejaring_cstmItem.GetByPK(ID);

                return View(new m_Tb_Jejaring_cstm(obj));

            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // POST: Jejaring/Edit/5
        [Authorize]
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                userLogin = Session["userLogin"].ToString();
                Tb_Jejaring obj = new Tb_Jejaring();
                obj.Kode_Jejaring = Convert.ToInt32(id);
                obj.Nomer_Lisensi = Request.Form["Nomer_Lisensi"];
                obj.Kode_KK_Terlisensi = Convert.ToInt32(Request.Form["Kode_KK_Terlisensi"]);
                obj.NPSN = Convert.ToInt32(Request.Form["NPSNJ"]);
                obj.editor = userLogin;
                obj.edited = DateTime.Now;

                Tb_JejaringItem.Update(obj);

                return RedirectToAction("Details/" + id);
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // GET: Jejaring/Delete/5
        [Authorize]
        public ActionResult Delete(string id)
        {
            try
            {
                Int32 ID = 0;
                Int32.TryParse(id, out ID);

                Tb_JejaringItem.Delete(ID);

                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }       

    }
}
