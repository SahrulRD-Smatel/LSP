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
 
    public class ProfileSKLController : BaseController
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

                Tb_SMK_cstm EmpInfo = new Tb_SMK_cstm();
                EmpInfo = Tb_SMK_cstmItem.GetByPKCustom(npsn);

                return View(new m_Tb_SMK_cstm(EmpInfo));
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
                int npsn = 0;
                int.TryParse(Session["NPSN"].ToString(), out npsn);

                List<Tb_Kompetensi_Keahlian> objKK = new List<Tb_Kompetensi_Keahlian>();
                List<Tb_Kabupaten> objKab = new List<Tb_Kabupaten>();
                objKK = Tb_Kompetensi_KeahlianItem.GetAll();
                objKab = Tb_KabupatenItem.GetAll();

                Tb_SMK_cstm EmpInfo = new Tb_SMK_cstm();
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
                //check
                if (Request.Form["NPSN"].ToString() != Session["NPSN"].ToString()) { return RedirectToAction("Index"); }
                //check

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

                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

    }
}