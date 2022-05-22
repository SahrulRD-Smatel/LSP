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
    public class DataAsesorController : BaseController
    {
        public string userLogin = string.Empty;
        public string usrTypeLogin = string.Empty;
        [Authorize]
        public ActionResult Index()
        {
            List<Tb_Data_Asesor_cstm> EmpInfo = new List<Tb_Data_Asesor_cstm>();
            try
            {
                if (Session["usrTypeLogin"] != null) { if (Session["usrTypeLogin"].ToString().ToUpper() != "PROP") { Response.Redirect("~/Login"); } }

                EmpInfo = Tb_Data_Asesor_cstmItem.GetAll();
                return View(EmpInfo);
            }
            catch
            {
                return View(EmpInfo);
            }
        }


        // GET: DataAsesor/Details/5
        [Authorize]
        public ActionResult Details(string id)
        {
            try
            {
                Tb_Data_Asesor_cstm objAll = new Tb_Data_Asesor_cstm();
                Int32 ID = 0;
                Int32.TryParse(id, out ID);

                objAll = Tb_Data_Asesor_cstmItem.GetByPK(ID);
                return View(new m_Tb_Data_Asesor_cstm(objAll));
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


                Int32 ID = 0;
                Int32.TryParse(id, out ID);
                EmpInfo = Tb_Data_Asesor_cstmItem.GetByPK(ID);

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