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
  
    public class PenerimaSertifikatController : BaseController
    {
        // GET: PenerimaSertifikat
        //Hosted web API REST Service base url  

        public string userLogin = string.Empty;
        public string usrTypeLogin = string.Empty;
        [Authorize]
        public ActionResult Index()
        {
            try
            {
                if (Session["usrTypeLogin"] != null) { if (Session["usrTypeLogin"].ToString().ToUpper() != "PROP") { Response.Redirect("~/Login"); } }

                List<Tb_Penerima_Sertifikat_cstm> obj = new List<Tb_Penerima_Sertifikat_cstm>();

                obj = Tb_Penerima_Sertifikat_cstmItem.GetAll();

                return View(obj);
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // GET: PenerimaSertifikat/Details/5
        [Authorize]
        public ActionResult Details(string id)
        {
            try
            {
                Int32 ID = 0;
                Int32.TryParse(id, out ID);
                Tb_Penerima_Sertifikat_cstm obj = new Tb_Penerima_Sertifikat_cstm();
                obj = Tb_Penerima_Sertifikat_cstmItem.GetByPK(ID);

                return View(new m_Tb_Penerima_Sertifikat_cstm(obj));
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // GET: PenerimaSertifikat/Create
        [Authorize]
        public ActionResult Create()
        {
            try
            {
                Tb_Penerima_Sertifikat_cstm empInfo = new Tb_Penerima_Sertifikat_cstm();
                List<Tb_LSP_cstm> objLSP = new List<Tb_LSP_cstm>();
                List<Tb_Kompetensi_Keahlian> objKK = new List<Tb_Kompetensi_Keahlian>();
                List<Tb_Tahun_Pelajaran> objTP = new List<Tb_Tahun_Pelajaran>();
                List<Tb_Skema> objSKM = new List<Tb_Skema>();
                objLSP = Tb_LSP_cstmItem.GetAll();
                objKK = Tb_Kompetensi_KeahlianItem.GetAll();
                objTP = Tb_Tahun_PelajaranItem.GetAll();
                objSKM = Tb_SkemaItem.GetAll();

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
                ViewBag.Kode_kkList = dropDownGenerate.toSelectCustom(ooList);
                ///

                //begin
                ooList = new Dictionary<string, string>();
                foreach (var xx in objSKM)
                {
                    ooList.Add(xx.Kode_Skema.ToString(), xx.Kode_Skema.ToString() + " - " + xx.Skema);
                }
                ViewBag.SkemaList = dropDownGenerate.toSelectCustom(ooList);
                ///

                //begin
                ooList = new Dictionary<string, string>();
                foreach (var xx in objTP)
                {
                    ooList.Add(xx.ID.ToString(), xx.Tahun_pelajaran);
                }
                ViewBag.thnPelajaranList = dropDownGenerate.toSelectCustom(ooList);
                //end

                return View(new m_Tb_Penerima_Sertifikat_cstm(empInfo));

            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // POST: PenerimaSertifikat/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(string id, FormCollection collection)
        {
            try
            {
                userLogin = Session["userLogin"].ToString();
                Tb_Penerima_Sertifikat obj = new Tb_Penerima_Sertifikat();
                obj.Nomer_Lisensi = Request.Form["Nomer_Lisensi"];
                obj.Kode_KK = Convert.ToInt32(Request.Form["Kode_KK"]);
                obj.IDTahun_pelajaran = Convert.ToInt32(Request.Form["IDTahun_pelajaran"]);
                obj.Jumlah_penerima_sertifikat = Convert.ToInt32(Request.Form["Jumlah_penerima_sertifikat"]);
                obj.creator = userLogin;
                obj.created = DateTime.Now;

                Tb_Penerima_SertifikatItem.Insert(obj);

                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                return RedirectToAction("Create");
            }
        }

        // GET: PenerimaSertifikat/Edit/5
        [Authorize]
        public ActionResult Edit(string id)
        {
            try
            {
                Tb_Penerima_Sertifikat_cstm empInfo = new Tb_Penerima_Sertifikat_cstm();
                List<Tb_LSP_cstm> objLSP = new List<Tb_LSP_cstm>();
                List<Tb_Kompetensi_Keahlian> objKK = new List<Tb_Kompetensi_Keahlian>();
                List<Tb_Tahun_Pelajaran> objTP = new List<Tb_Tahun_Pelajaran>();
                List<Tb_Skema> objSKM = new List<Tb_Skema>();
                objLSP = Tb_LSP_cstmItem.GetAll();
                objKK = Tb_Kompetensi_KeahlianItem.GetAll();
                objTP = Tb_Tahun_PelajaranItem.GetAll();
                objSKM = Tb_SkemaItem.GetAll();

                Int32 ID = 0;
                Int32.TryParse(id, out ID);
                empInfo = Tb_Penerima_Sertifikat_cstmItem.GetByPK(ID);

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
                ViewBag.Kode_kkList = dropDownGenerate.toSelectCustom(ooList);
                ///

                //begin
                ooList = new Dictionary<string, string>();
                foreach (var xx in objSKM)
                {
                    ooList.Add(xx.Kode_Skema.ToString(), xx.Kode_Skema.ToString() + " - " + xx.Skema);
                }
                ViewBag.SkemaList = dropDownGenerate.toSelectCustom(ooList);
                ///

                //begin
                ooList = new Dictionary<string, string>();
                foreach (var xx in objTP)
                {
                    ooList.Add(xx.ID.ToString(), xx.Tahun_pelajaran);
                }
                ViewBag.thnPelajaranList = dropDownGenerate.toSelectCustom(ooList);
                //end

                return View(new m_Tb_Penerima_Sertifikat_cstm(empInfo));
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // POST: PenerimaSertifikat/Edit/5
        [Authorize]
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                userLogin = Session["userLogin"].ToString();
                Tb_Penerima_Sertifikat obj = new Tb_Penerima_Sertifikat();
                obj.Kode_Penerima_Sertifikat = Convert.ToInt32(id);
                obj.Nomer_Lisensi = Request.Form["Nomer_Lisensi"];
                obj.Kode_KK = Convert.ToInt32(Request.Form["Kode_KK"]);
                obj.IDTahun_pelajaran = Convert.ToInt32(Request.Form["IDTahun_pelajaran"]);
                obj.Jumlah_penerima_sertifikat = Convert.ToInt32(Request.Form["Jumlah_penerima_sertifikat"]);
                obj.editor = userLogin;
                obj.edited = DateTime.Now;

                Tb_Penerima_SertifikatItem.Update(obj);

                return RedirectToAction("Details/" + id);
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // GET: PenerimaSertifikat/Delete/5
        [Authorize]
        public ActionResult Delete(string id)
        {
            try
            {
                Int32 ID = 0;
                Int32.TryParse(id, out ID);

                Tb_Penerima_SertifikatItem.Delete(ID);

                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }


    }
}
