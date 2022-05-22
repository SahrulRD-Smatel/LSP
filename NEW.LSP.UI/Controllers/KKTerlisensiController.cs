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

    public class KKTerlisensiController : BaseController
    {
        // GET: KKTerlisensi
        //Hosted web API REST Service base url  

        public string userLogin = string.Empty;
        public string usrTypeLogin = string.Empty;
        [Authorize]
        public ActionResult Index()
        {
            List<Tb_Kompetensi_Keahlian_Terlisensi_cstm> EmpInfo = new List<Tb_Kompetensi_Keahlian_Terlisensi_cstm>();
            try
            {
                if (Session["usrTypeLogin"] != null) { if (Session["usrTypeLogin"].ToString().ToUpper() != "PROP") { Response.Redirect("~/Login"); } }

                EmpInfo = Tb_Kompetensi_Keahlian_Terlisensi_cstmItem.GetAll();

                //returning the employee list to view  
                return View(EmpInfo);
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // GET: KKTerlisensi/Details/5
        [Authorize]
        public ActionResult Details(string id)
        {
            try
            {
                Int32 ID = 0;
                Int32.TryParse(id, out ID);
                //buat coding untuk menarik APISMK/id
                Tb_Kompetensi_Keahlian_Terlisensi_cstm EmpInfo = new Tb_Kompetensi_Keahlian_Terlisensi_cstm();

                EmpInfo = Tb_Kompetensi_Keahlian_Terlisensi_cstmItem.GetByPK(ID);

                return View(new m_Tb_Kompetensi_Keahlian_Terlisensi_cstm(EmpInfo));
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // GET: KKTerlisensi/Create
        [Authorize]
        public ActionResult Create(string id)
        {
            try
            {
                Tb_Kompetensi_Keahlian_Terlisensi_cstm EmpInfo = new Tb_Kompetensi_Keahlian_Terlisensi_cstm();
                List<Tb_Kompetensi_Keahlian> objKK = new List<Tb_Kompetensi_Keahlian>();
                List<Tb_LSP_cstm> objLSP = new List<Tb_LSP_cstm>();
                List<Tb_Skema> objSKM = new List<Tb_Skema>();

                objKK = Tb_Kompetensi_KeahlianItem.GetAll();
                objLSP = Tb_LSP_cstmItem.GetAll();
                objSKM = Tb_SkemaItem.GetAll();

                // kode kk
                Dictionary<string, string> ooList = new Dictionary<string, string>();
                foreach (var xx in objKK)
                {
                    ooList.Add(xx.Kode_KK.ToString(), xx.Kode_KK.ToString() + " - " + xx.Nama_KK);
                }
                ViewBag.Kode_KKList = dropDownGenerate.toSelectCustom(ooList);
                //

                ooList = new Dictionary<string, string>();
                foreach (var xx in objSKM)
                {
                    ooList.Add(xx.Kode_Skema.ToString(), xx.Kode_Skema.ToString() + " - " + xx.Skema);
                }
                ViewBag.SkemaList = dropDownGenerate.toSelectCustom(ooList);
                ///

                ooList = new Dictionary<string, string>();
                foreach (var xx in objLSP)
                {
                    ooList.Add(xx.Nomer_Lisensi, xx.Nomer_Lisensi + " - " + xx.Nama_Sekolah);
                }
                ViewBag.lspList = dropDownGenerate.toSelectCustom(ooList);
                ///
                Dictionary<string, string> stsLSP = new Dictionary<string, string>() { { "Lama", "Lama" }, { "PRL", "PRL" } };
                ViewBag.StatusKKTerlisensi = dropDownGenerate.toSelectCustom(stsLSP);
                ///

                return View(new m_Tb_Kompetensi_Keahlian_Terlisensi_cstm(EmpInfo));

            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // POST: KKTerlisensi/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(string id, FormCollection collection)
        {           
            try
            {
                userLogin = Session["userLogin"].ToString();
                Tb_Kompetensi_Keahlian_Terlisensi obj = new Tb_Kompetensi_Keahlian_Terlisensi();
                obj.Nomer_Lisensi = Request.Form["Nomer_Lisensi"];
                obj.Kode_KK = Convert.ToInt32(Request.Form["Kode_KK"]);
                obj.Status_KK_Terlisensi = Request.Form["Status_KK_Terlisensi"];
                obj.Jumlah_asesor = Convert.ToInt32(Request.Form["Jumlah_asesor"]);
                obj.creator = userLogin;
                obj.created = DateTime.Now;

                Tb_Kompetensi_Keahlian_TerlisensiItem.Insert(obj);

                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                return RedirectToAction("Create");
            }
        }

        // GET: KKTerlisensi/Edit/5
        [Authorize]
        public ActionResult Edit(string id)
        {
            try
            {
                Int32 ID = 0;
                Int32.TryParse(id, out ID);
                Tb_Kompetensi_Keahlian_Terlisensi_cstm EmpInfo = new Tb_Kompetensi_Keahlian_Terlisensi_cstm();
                List<Tb_Kompetensi_Keahlian> objKK = new List<Tb_Kompetensi_Keahlian>();
                List<Tb_LSP_cstm> objLSP = new List<Tb_LSP_cstm>();
                List<Tb_Skema> objSKM = new List<Tb_Skema>();

                objKK = Tb_Kompetensi_KeahlianItem.GetAll();
                objLSP = Tb_LSP_cstmItem.GetAll();
                objSKM = Tb_SkemaItem.GetAll();

                EmpInfo = Tb_Kompetensi_Keahlian_Terlisensi_cstmItem.GetByPK(ID);

                // kode kk
                Dictionary<string, string> ooList = new Dictionary<string, string>();
                foreach (var xx in objKK)
                {
                    ooList.Add(xx.Kode_KK.ToString(), xx.Kode_KK.ToString() + " - " + xx.Nama_KK);
                }
                ViewBag.Kode_KKList = dropDownGenerate.toSelectCustom(ooList);
                //

                ooList = new Dictionary<string, string>();
                foreach (var xx in objSKM)
                {
                    ooList.Add(xx.Kode_Skema.ToString(), xx.Kode_Skema.ToString() + " - " + xx.Skema);
                }
                ViewBag.SkemaList = dropDownGenerate.toSelectCustom(ooList);
                ///

                ooList = new Dictionary<string, string>();
                foreach (var xx in objLSP)
                {
                    ooList.Add(xx.Nomer_Lisensi, xx.Nomer_Lisensi + " - " + xx.Nama_Sekolah);
                }
                ViewBag.lspList = dropDownGenerate.toSelectCustom(ooList);
                ///
                Dictionary<string, string> stsLSP = new Dictionary<string, string>() { { "Lama", "Lama" }, { "PRL", "PRL" } };
                ViewBag.StatusKKTerlisensi = dropDownGenerate.toSelectCustom(stsLSP);
                ///

                return View(new m_Tb_Kompetensi_Keahlian_Terlisensi_cstm(EmpInfo));
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // POST: KKTerlisensi/Edit/5
        [Authorize]
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                userLogin = Session["userLogin"].ToString();
                Tb_Kompetensi_Keahlian_Terlisensi obj = new Tb_Kompetensi_Keahlian_Terlisensi();
                obj.Kode_KK_Terlisensi = Convert.ToInt32(id);
                obj.Nomer_Lisensi = Request.Form["Nomer_Lisensi"];
                obj.Kode_KK = Convert.ToInt32(Request.Form["Kode_KK"]);
                obj.Status_KK_Terlisensi = Request.Form["Status_KK_Terlisensi"];
                obj.Jumlah_asesor = Convert.ToInt32(Request.Form["Jumlah_asesor"]);
                obj.editor = userLogin;
                obj.edited = DateTime.Now;

                Tb_Kompetensi_Keahlian_TerlisensiItem.Update(obj);

                return RedirectToAction("Details/" + id);

            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // GET: KKTerlisensi/Delete/5
        [Authorize]
        public ActionResult Delete(string id)
        {
            try
            {
                Int32 ID = 0;
                Int32.TryParse(id, out ID);

                Tb_Kompetensi_Keahlian_TerlisensiItem.Delete(ID);

                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }


    }
}
