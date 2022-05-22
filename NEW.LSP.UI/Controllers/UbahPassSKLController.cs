using NEW.LSP.Dta;
using NEW.LSP.Dta.Custom;
using NEW.LSP.Dto;
using NEW.LSP.Dto.Custom;
using NEW.LSP.UI.Models;
using System;
using System.Web.Mvc;


namespace NEW.LSP.UI.Controllers
{

    public class UbahPassSKLController : BaseController
    {
        // GET: UbahPassSKL
        public string userLogin = string.Empty;
        public string NPSN = string.Empty;

        [Authorize]
        public ActionResult Index()
        {
            try
            {
                if (Session["usrTypeLogin"] != null) { if (Session["usrTypeLogin"].ToString().ToUpper() != "SKL") { Response.Redirect("~/Login"); } }
                userLogin = Session["userLogin"].ToString();
                int npsn = 0;
                int.TryParse(Session["NPSN"].ToString(), out npsn);
                Tb_Admin_Sekolah_cstm obj = new Tb_Admin_Sekolah_cstm();

                obj = Tb_Admin_Sekolah_cstmItem.GetByPKNPSN(npsn, userLogin);

                return View(new m_Tb_Admin_Sekolah_cstm(obj));
            }
            catch (Exception err)
            {
                return View(err.Message);
            }
        }

        // POST: ADSekolah/Create
        [Authorize]
        [HttpPost]
        public ActionResult Index(string id, FormCollection collection)
        {
            try
            {
                Int32 ID = 0;
                Int32.TryParse(id, out ID);

                //check
                Tb_Admin_Sekolah_cstm EmpInfo = new Tb_Admin_Sekolah_cstm();
                EmpInfo = Tb_Admin_Sekolah_cstmItem.GetByPK(ID);
                if (EmpInfo.NPSN != Convert.ToInt32(Session["NPSN"].ToString())) { return RedirectToAction("Index"); }
                //check

                userLogin = Session["userLogin"].ToString();
                Tb_Admin_Sekolah obj = new Tb_Admin_Sekolah();
                obj.ID = Convert.ToInt32(id);
                obj.Username = Request.Form["Username"];
                obj.Password = Request.Form["Password"];
                obj.NPSN = Convert.ToInt32(Request.Form["NPSN"]);
                obj.editor = userLogin;
                obj.edited = DateTime.Now;

                Tb_Admin_SekolahItem.Update(obj);
                  
                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                return View(err.Message);
            }
        }
       
    }
}