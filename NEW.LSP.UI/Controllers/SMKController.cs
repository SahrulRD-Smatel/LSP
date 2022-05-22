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

    public class SMKController : BaseController
    {
        // GET: SMK

        public string userLogin = string.Empty;
        public string usrTypeLogin = string.Empty;
        [Authorize]
        public ActionResult Index()
        {
            List<Tb_SMK_cstm> EmpInfo = new List<Tb_SMK_cstm>();
            try
            {
                if (Session["usrTypeLogin"] != null) { if (Session["usrTypeLogin"].ToString().ToUpper() != "PROP") { Response.Redirect("~/Login"); } }

                EmpInfo = Tb_SMK_cstmItem.getAllCustom();
                return View(EmpInfo);
            }
            catch
            {
                return View(EmpInfo);
            }
        }

        // GET: SMK/Details/5
        [Authorize]
        public ActionResult Details(string id)
        {
            Tb_SMK_cstm EmpInfo = new Tb_SMK_cstm();
            try
            {
                Int32 npsn = 0;
                Int32.TryParse(id, out npsn);

                EmpInfo = Tb_SMK_cstmItem.GetByPKCustom(npsn);

                return View(new m_Tb_SMK_cstm(EmpInfo));
            }

            catch
            {
                return RedirectToAction("Index");
            }

        }

        // GET: SMK/Create
        [Authorize]
        public ActionResult Create()
        {
            Tb_SMK_cstm EmpInfo = new Tb_SMK_cstm();
            try
            {

                List<Tb_Kompetensi_Keahlian> objKK = new List<Tb_Kompetensi_Keahlian>();
                List<Tb_Kabupaten> objKab = new List<Tb_Kabupaten>();
                objKK = Tb_Kompetensi_KeahlianItem.GetAll();
                objKab = Tb_KabupatenItem.GetAll();

                //kabupaten
                Dictionary<string, string> ooList = new Dictionary<string, string>();
                foreach (var xx in objKab)
                {
                    ooList.Add(xx.Kode_Kabupaten.ToString(), xx.NamaKabupaten);
                }
                ViewBag.dataKabupaten = dropDownGenerate.toSelectCustom(ooList);
                //
                //kopetensi keahlian
                ooList = new Dictionary<string, string>();
                foreach (var xx in objKK)
                {
                    ooList.Add(xx.Kode_KK.ToString(), xx.Nama_KK);
                }
                ViewBag.Kode_KKList = dropDownGenerate.toSelectCustom(ooList);
                //

                Dictionary<string, string> stsSekolah = new Dictionary<string, string>() { { "NEGERI", "NEGERI" }, { "SWASTA", "SWASTA" } };
                ViewBag.StatusSekolah = dropDownGenerate.toSelectCustom(stsSekolah);

                Dictionary<string, string> stsLSP = new Dictionary<string, string>() { { "Memiliki LSP", "Memiliki LSP" }, { "Belum Memiliki LSP", "Belum Memiliki LSP" } };
                ViewBag.StatusLSP = dropDownGenerate.toSelectCustom(stsLSP);

                return View(new m_Tb_SMK_cstm(EmpInfo));

            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(string id, FormCollection collection)
        {
            try
            {
                userLogin = Session["userLogin"].ToString();
                Tb_SMK obj = new Tb_SMK();
                obj.NPSN = Convert.ToInt32(Request.Form["NPSN"]);
                obj.Kode_Kabupaten = Convert.ToInt32(Request.Form["Kode_Kabupaten"]);
                obj.Nama_Sekolah = Request.Form["Nama_Sekolah"];
                obj.Status_Sekolah = Request.Form["Status_Sekolah"];
                obj.Status_LSP = Request.Form["Status_LSP"];
                obj.Kode_KK = Convert.ToInt32(Request.Form["Kode_KK"]);
                obj.creator = userLogin;
                obj.created = DateTime.Now;

                Tb_SMKItem.Insert(obj);

                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                return RedirectToAction("Create");
            }
        }

        // GET: SMK/Edit/5
        [Authorize]
        public ActionResult Edit(string id)
        {
            Tb_SMK_cstm EmpInfo = new Tb_SMK_cstm();
            try
            {

                //buat coding untuk menarik APISMK/id               
                List<Tb_Kompetensi_Keahlian> objKK = new List<Tb_Kompetensi_Keahlian>();
                List<Tb_Kabupaten> objKab = new List<Tb_Kabupaten>();
                objKK = Tb_Kompetensi_KeahlianItem.GetAll();
                objKab = Tb_KabupatenItem.GetAll();

                Int32 npsn = 0;
                Int32.TryParse(id, out npsn);
                EmpInfo = Tb_SMK_cstmItem.GetByPKCustom(npsn);

                //kabupaten
                Dictionary<string, string> ooList = new Dictionary<string, string>();
                foreach (var xx in objKab)
                {
                    ooList.Add(xx.Kode_Kabupaten.ToString(), xx.NamaKabupaten);
                }
                ViewBag.dataKabupaten = dropDownGenerate.toSelectCustom(ooList);
                //
                //kopetensi keahlian
                ooList = new Dictionary<string, string>();
                foreach (var xx in objKK)
                {
                    ooList.Add(xx.Kode_KK.ToString(), xx.Nama_KK);
                }
                ViewBag.Kode_KKList = dropDownGenerate.toSelectCustom(ooList);
                //

                Dictionary<string, string> stsSekolah = new Dictionary<string, string>() { { "NEGERI", "NEGERI" }, { "SWASTA", "SWASTA" } };
                ViewBag.StatusSekolah = dropDownGenerate.toSelectCustom(stsSekolah);

                Dictionary<string, string> stsLSP = new Dictionary<string, string>() { { "Memiliki LSP", "Memiliki LSP" }, { "Belum Memiliki LSP", "Belum Memiliki LSP" } };
                ViewBag.StatusLSP = dropDownGenerate.toSelectCustom(stsLSP);


                return View(new m_Tb_SMK_cstm(EmpInfo));
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // POST: SMK/Edit/5
        [Authorize]
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                userLogin = Session["userLogin"].ToString();
                Tb_SMK obj = new Tb_SMK();
                obj.NPSN = Convert.ToInt32(id);
                obj.Kode_Kabupaten = Convert.ToInt32(Request.Form["Kode_Kabupaten"]);
                obj.Nama_Sekolah = Request.Form["Nama_Sekolah"];
                obj.Status_Sekolah = Request.Form["Status_Sekolah"];
                obj.Status_LSP = Request.Form["Status_LSP"];
                obj.Kode_KK = Convert.ToInt32(Request.Form["Kode_KK"]);
                obj.editor = userLogin;
                obj.edited = DateTime.Now;

                Tb_SMKItem.Update(obj);

                return RedirectToAction("Details/" + id);
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // GET: SMK/Delete/5
        [Authorize]
        public ActionResult Delete(string id)
        {
            try
            {
                Int32 npsn = 0;
                Int32.TryParse(id, out npsn);

                Tb_SMKItem.Delete(npsn);

                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        [Authorize]
        [HttpPost]
        public string GetSMK(string NPSN)
        {
            try
            {
                Tb_SMK_cstm table = new Tb_SMK_cstm();
                Int32 npsn = 0;
                Int32.TryParse(NPSN, out npsn);

                table = Tb_SMK_cstmItem.GetByPKCustom(npsn);

                return JsonConvert.SerializeObject(table);
            }
            catch (Exception err)
            {
                return err.Message;
            }


        }

    }
}
