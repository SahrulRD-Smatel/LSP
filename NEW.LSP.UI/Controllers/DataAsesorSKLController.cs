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
    public class DataAsesorSKLController : BaseController
    {

        public string userLogin = string.Empty;
        public string NPSN = string.Empty;

        [Authorize]
        public ActionResult Index()
        {
           
            try
            {
                if (Session["usrTypeLogin"] != null) { if (Session["usrTypeLogin"].ToString().ToUpper() != "SKL") { Response.Redirect("~/Login"); } }
                int npsn = 0;
                int.TryParse(Session["NPSN"].ToString(), out npsn);
                
                List<Tb_Data_Asesor_cstm> EmpInfo = new List<Tb_Data_Asesor_cstm>();
                EmpInfo = Tb_Data_Asesor_cstmItem.GetAllByNPSN(npsn);
                return View(EmpInfo);
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }


        [Authorize]
        [HttpGet]
        public ActionResult Details(string id)
        {

            try
            {
                Tb_Data_Asesor_cstm EmpInfo = new Tb_Data_Asesor_cstm();
                Int32 id_asesor = 0;
                Int32.TryParse(id, out id_asesor);

                EmpInfo = Tb_Data_Asesor_cstmItem.GetByPK(id_asesor);
                //check
                if (EmpInfo.NPSN != Convert.ToInt32(Session["NPSN"].ToString())) { return RedirectToAction("Index"); }
                //check
                return View(new m_Tb_Data_Asesor_cstm(EmpInfo));
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }

        }


        // GET: ASESOR/Create
        [Authorize]
        public ActionResult Create(string id)
        {
            try
            {
                Tb_Data_Asesor_cstm EmpInfo = new Tb_Data_Asesor_cstm();
                List<Tb_SMK> objSMK = new List<Tb_SMK>();
                List<Tb_Kabupaten> objKab = new List<Tb_Kabupaten>();
                List<Tb_Kompetensi_Keahlian> objKK = new List<Tb_Kompetensi_Keahlian>();

                objSMK = Tb_SMKItem.GetAll();
                objKab = Tb_KabupatenItem.GetAll();
                objKK = Tb_Kompetensi_KeahlianItem.GetAll();

                int npsn = 0;
                int.TryParse(Session["NPSN"].ToString(), out npsn);
                Tb_LSP_cstm objLSP = new Tb_LSP_cstm();
                objLSP = Tb_LSP_cstmItem.GetByNPSN(npsn);

                //b.[Nomer_Lisensi], b.NPSN, d.Nama_Sekolah ,e.NamaKabupaten
                EmpInfo.NPSN = objLSP.NPSN; EmpInfo.Nama_Sekolah = objLSP.Nama_Sekolah; EmpInfo.NamaKabupaten = objLSP.NamaKabupaten;

                // kode kk
                Dictionary<string, string> ooList = new Dictionary<string, string>();
                foreach (var xx in objSMK)
                {
                    ooList.Add(xx.NPSN.ToString(), xx.NPSN.ToString() + " - " + xx.Nama_Sekolah);
                }
                ViewBag.dataSMK = dropDownGenerate.toSelectCustom(ooList);

                //kabupaten
                ooList = new Dictionary<string, string>();
                foreach (var xx in objKab)
                {
                    ooList.Add(xx.Kode_Kabupaten.ToString(), xx.NamaKabupaten);
                }
                ViewBag.dataKabupaten = dropDownGenerate.toSelectCustom(ooList);
                //

                //begin
                ooList = new Dictionary<string, string>();
                foreach (var xx in objKK)
                {
                    ooList.Add(xx.Kode_KK.ToString(), xx.Kode_KK.ToString() + " - " + xx.Nama_KK);
                }
                ViewBag.Kode_KKList = dropDownGenerate.toSelectCustom(ooList);
                //end


                return View(new m_Tb_Data_Asesor_cstm(EmpInfo));

            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // POST: KKTerlisensi/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                userLogin = Session["userLogin"].ToString();
                Tb_Data_Asesor obj = new Tb_Data_Asesor();
                obj.No_Reg_Met = Request.Form["No_Reg_Met"];
                obj.Kode_KK = Convert.ToInt32(Request.Form["Kode_KK"]);
                obj.Nama_Asesor = Request.Form["Nama_Asesor"];
                obj.NPSN = Convert.ToInt32(Request.Form["NPSN"]);
                obj.Tanggal_Sertifikat_Asesor = Convert.ToDateTime(Request.Form["Tanggal_Sertifikat_Asesor"]);
                obj.creator = userLogin;
                obj.created = DateTime.Now;

                Tb_Data_AsesorItem.Insert(obj);

                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }



        // GET: LSP/Edit/5
        [Authorize]
        public ActionResult Edit(string id)
        {
            try
            {
                //buat coding untuk menarik APILSP/id
                Tb_Data_Asesor_cstm EmpInfo = new Tb_Data_Asesor_cstm();
                List<Tb_SMK> objSMK = new List<Tb_SMK>();
                List<Tb_Kabupaten> objKab = new List<Tb_Kabupaten>();
                List<Tb_Kompetensi_Keahlian> objKK = new List<Tb_Kompetensi_Keahlian>();

                objSMK = Tb_SMKItem.GetAll();
                objKab = Tb_KabupatenItem.GetAll();
                objKK = Tb_Kompetensi_KeahlianItem.GetAll();

                Int32 id_asesor = 0;
                Int32.TryParse(id, out id_asesor);
                EmpInfo = Tb_Data_Asesor_cstmItem.GetByPK(id_asesor);

                //check
                if (EmpInfo.NPSN != Convert.ToInt32(Session["NPSN"].ToString())) { return RedirectToAction("Index"); }
                //chec

                Dictionary<string, string> ooList = new Dictionary<string, string>();
                foreach (var xx in objSMK)
                {
                    ooList.Add(xx.NPSN.ToString(), xx.NPSN.ToString() + " - " + xx.Nama_Sekolah);
                }
                ViewBag.dataSMK = dropDownGenerate.toSelectCustom(ooList);

                //kabupaten
                ooList = new Dictionary<string, string>();
                foreach (var xx in objKab)
                {
                    ooList.Add(xx.Kode_Kabupaten.ToString(), xx.NamaKabupaten);
                }
                ViewBag.dataKabupaten = dropDownGenerate.toSelectCustom(ooList);
                //

                //begin
                ooList = new Dictionary<string, string>();
                foreach (var xx in objKK)
                {
                    ooList.Add(xx.Kode_KK.ToString(), xx.Kode_KK.ToString() + " - " + xx.Nama_KK);
                }
                ViewBag.Kode_KKList = dropDownGenerate.toSelectCustom(ooList);
                //end

                return View(new m_Tb_Data_Asesor_cstm(EmpInfo));

            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // POST: DataAsesor/Edit/5
        [Authorize]
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                Int32 id_asesor = 0;
                Int32.TryParse(id, out id_asesor);

                //check
                Tb_Data_Asesor_cstm EmpInfo = new Tb_Data_Asesor_cstm();
                EmpInfo = Tb_Data_Asesor_cstmItem.GetByPK(id_asesor);
                if (EmpInfo.NPSN != Convert.ToInt32(Session["NPSN"].ToString())) { return RedirectToAction("Index"); }
                //check

                userLogin = Session["userLogin"].ToString();
                Tb_Data_Asesor obj = new Tb_Data_Asesor();
                obj.id_asesor = Convert.ToInt32(id);
                obj.No_Reg_Met = Request.Form["No_Reg_Met"];
                obj.Kode_KK = Convert.ToInt32(Request.Form["Kode_KK"]);
                obj.Nama_Asesor = Request.Form["Nama_Asesor"];
                obj.NPSN = Convert.ToInt32(Request.Form["NPSN"]);
                obj.Tanggal_Sertifikat_Asesor = Convert.ToDateTime(Request.Form["Tanggal_Sertifikat_Asesor"]);
                obj.editor = userLogin;
                obj.edited = DateTime.Now;

                Tb_Data_AsesorItem.Update(obj);

                return RedirectToAction("Details/" + id);
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // GET: DataAsesor/Delete/5
        [Authorize]
        public ActionResult Delete(string id)
        {
            try
            {
                Int32 ID = 0;
                Int32.TryParse(id, out ID);

                Tb_Data_AsesorItem.Delete(ID);

                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

    }
}