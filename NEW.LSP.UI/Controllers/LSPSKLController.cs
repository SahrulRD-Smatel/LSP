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
 
    public class LSPSKLController : BaseController
    {
        // GET: LSPSKL  

        public string userLogin = string.Empty;
        public string NPSN = string.Empty;
        public string usrTypeLogin = string.Empty;

        [Authorize]
        public ActionResult Index()
        {
            try
            {
                if (Session["usrTypeLogin"] != null) { if (Session["usrTypeLogin"].ToString().ToUpper() != "SKL") { Response.Redirect("~/Login"); } }

                int npsn = 0;
                int.TryParse(Session["NPSN"].ToString(), out npsn);

                Tb_LSP_cstm EmpInfo = new Tb_LSP_cstm();
                EmpInfo = Tb_LSP_cstmItem.GetByNPSN(npsn);

                m_Tb_LSP_cstm obj = new m_Tb_LSP_cstm();

                return View(EmpInfo == null? obj: new m_Tb_LSP_cstm(EmpInfo));
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // GET: SMK/Edit/5
        [Authorize]
        public ActionResult Edit(string id)
        {
            try
            {
                Tb_LSP_cstm EmpInfo = new Tb_LSP_cstm();

                EmpInfo = Tb_LSP_cstmItem.GetByPK(id);
                //check
                if (EmpInfo.NPSN != Convert.ToInt32(Session["NPSN"].ToString())) { return RedirectToAction("Index"); }
                //check

                Dictionary<string, string> sts = new Dictionary<string, string>() { { "Lama", "Lama" }, { "Baru", "Baru" } };
                ViewBag.StsLisensiLSP = dropDownGenerate.toSelectCustom(sts);

                return View(new m_Tb_LSP_cstm(EmpInfo));
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
                Tb_LSP_cstm EmpInfo = new Tb_LSP_cstm();
                EmpInfo = Tb_LSP_cstmItem.GetByPK(id);
                if (EmpInfo.NPSN != Convert.ToInt32(Session["NPSN"].ToString())) { return RedirectToAction("Index"); }
                //chek

                userLogin = Session["userLogin"].ToString();
                Tb_LSP obj = new Tb_LSP();
                obj.Nomer_Lisensi = id;
                obj.NPSN = Convert.ToInt32(Request.Form["NPSN"]);
                obj.Status_LSP = Request.Form["Status_LSP"];
                obj.Berlaku_Sampai = Convert.ToDateTime(Request.Form["Berlaku_Sampai"]);
                obj.editor = userLogin;
                obj.edited = DateTime.Now;

                Tb_LSPItem.Update(obj);

                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }
    }
}
