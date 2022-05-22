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
    
    public class LSPController : BaseController
    {
        // GET: LSP 
        public string userLogin = string.Empty;
        public string usrTypeLogin = string.Empty;
        [Authorize]
        public ActionResult Index()
        {
            List<Tb_LSP_cstm> EmpInfo = new List<Tb_LSP_cstm>();
            try
            {
                if (Session["usrTypeLogin"] != null) { if (Session["usrTypeLogin"].ToString().ToUpper() != "PROP") { Response.Redirect("~/Login"); } }

                EmpInfo = Tb_LSP_cstmItem.GetAll();
                return View(EmpInfo);
            }
            catch
            {
                return View(EmpInfo);
            }
        }


        // GET: LSP/Details/5
        [Authorize]
        public ActionResult Details(string id)
        {
            Tb_LSP_cstm EmpInfo = new Tb_LSP_cstm();
            try
            {

                EmpInfo = Tb_LSP_cstmItem.GetByPK(id);

                return View(new m_Tb_LSP_cstm(EmpInfo));
            }

            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: LSP/Create
        [Authorize]
        public ActionResult Create()
        {
            try
            {
                Tb_LSP_cstm EmpInfo = new Tb_LSP_cstm();
                List<Tb_SMK> objSMK = new List<Tb_SMK>();
                objSMK = Tb_SMKItem.GetAll();
                Dictionary<string, string> ooList = new Dictionary<string, string>();
                foreach (var xx in objSMK)
                {
                    ooList.Add(xx.NPSN.ToString(), xx.NPSN.ToString() + " - " + xx.Nama_Sekolah);
                }
                ViewBag.dataSMK = dropDownGenerate.toSelectCustom(ooList);

                Dictionary<string, string> sts = new Dictionary<string, string>() { { "Lama", "Lama" }, { "Baru", "Baru" } };
                ViewBag.StsLisensiLSP = dropDownGenerate.toSelectCustom(sts);

                return View(new m_Tb_LSP_cstm(EmpInfo));
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // POST: LSP/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(string id, FormCollection collection)
        {
            m_Tb_LSP_cstm ooo = new m_Tb_LSP_cstm();
            try
            {
                userLogin = Session["userLogin"].ToString();
                Tb_LSP obj = new Tb_LSP();
                obj.Nomer_Lisensi = Request.Form["Nomer_Lisensi"];
                obj.NPSN = Convert.ToInt32(Request.Form["NPSN"]);
                obj.Status_LSP = Request.Form["Status_LSP"];
                obj.Berlaku_Sampai = Convert.ToDateTime(Request.Form["Berlaku_Sampai"]);
                obj.creator = userLogin;
                obj.created = DateTime.Now;

                Tb_LSPItem.Insert(obj);

                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                return RedirectToAction("Create");
            }
        }

        // GET: LSP/Edit/5
        [Authorize]
        public ActionResult Edit(string id)
        {
            try
            {
                //buat coding untuk menarik APILSP/id
                Tb_LSP_cstm EmpInfo = new Tb_LSP_cstm();
                List<Tb_SMK> objSMK = new List<Tb_SMK>();
                objSMK = Tb_SMKItem.GetAll();

                EmpInfo = Tb_LSP_cstmItem.GetByPK(id);

                Dictionary<string, string> ooList = new Dictionary<string, string>();
                foreach (var xx in objSMK)
                {
                    ooList.Add(xx.NPSN.ToString(), xx.NPSN.ToString() + " - " + xx.Nama_Sekolah);
                }
                ViewBag.dataSMK = dropDownGenerate.toSelectCustom(ooList);

                Dictionary<string, string> sts = new Dictionary<string, string>() { { "Lama", "Lama" }, { "Baru", "Baru" } };
                ViewBag.StsLisensiLSP = dropDownGenerate.toSelectCustom(sts);

                return View(new m_Tb_LSP_cstm(EmpInfo));

            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // POST: LSP/Edit/5
        [Authorize]
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                userLogin = Session["userLogin"].ToString();
                Tb_LSP obj = new Tb_LSP();
                obj.Nomer_Lisensi = id;
                obj.NPSN = Convert.ToInt32(Request.Form["NPSN"]);
                obj.Status_LSP = Request.Form["Status_LSP"];
                obj.Berlaku_Sampai = Convert.ToDateTime(Request.Form["Berlaku_Sampai"]);
                obj.editor = userLogin;
                obj.edited = DateTime.Now;

                Tb_LSPItem.Update(obj);

                return RedirectToAction("Details/" + id);
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // GET: LSP/Delete/5
        [Authorize]
        public ActionResult Delete(string id)
        {
            try
            {
                Tb_LSPItem.Delete(id);

                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        [Authorize]
        [HttpPost]
        public string GetLSP(string NomerLisensi)
        {
            Tb_LSP_cstm table = new Tb_LSP_cstm();
            try
            {
                table = Tb_LSP_cstmItem.GetByPK(NomerLisensi);

                return JsonConvert.SerializeObject(table);
            }
            catch (Exception err)
            {
                return err.Message;
            }


        }



    }
}
