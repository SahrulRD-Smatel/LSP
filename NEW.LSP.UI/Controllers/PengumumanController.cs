using NEW.LSP.Dta;
using NEW.LSP.Dta.Custom;
using NEW.LSP.Dto;
using NEW.LSP.Dto.Custom;
using NEW.LSP.UI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace NEW.LSP.UI.Controllers
{
    public class PengumumanController : BaseController
    {
        // GET: Pengumuman
        //Hosted web API REST Service base url  
        public string userLogin = string.Empty;
        public string usrTypeLogin = string.Empty;

        [Authorize]
        public ActionResult Index()
        {
            List<Tb_Pengumuman> obj = new List<Tb_Pengumuman>();

            try
            {
                if (Session["usrTypeLogin"] != null) { if (Session["usrTypeLogin"].ToString().ToUpper() != "PROP") { Response.Redirect("~/Login"); } }

                obj = Tb_PengumumanItem.GetAll();

                return View(obj);
            }
            catch
            {
                return View(obj);
            }
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            Tb_Pengumuman objAll = new Tb_Pengumuman();
            try
            {
                objAll = Tb_PengumumanItem.GetByPK(id);
                return View(new m_Tb_Pengumuman(objAll));
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
            Tb_Pengumuman objAll = new Tb_Pengumuman();
            try
            {
                return View(new m_Tb_Pengumuman(objAll));
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // POST: Jejaring/Create
        [Authorize]
        [HttpPost]

        public ActionResult Create(FormCollection collection, HttpPostedFileBase picture)
        {
            try
            {
                byte[] imgData = new byte[0];
                if (picture != null)
                {
                    using (BinaryReader br = new BinaryReader(picture.InputStream))
                    {
                        imgData = br.ReadBytes(picture.ContentLength);
                    }
                }

                // TODO: Add insert logic here
                userLogin = Session["userLogin"].ToString();
                Tb_Pengumuman obj = new Tb_Pengumuman();
                obj.no = Request.Form["no"];
                obj.tanggal = Convert.ToDateTime(Request.Form["tanggal"]);
                obj.tanggal_hingga = Convert.ToDateTime(Request.Form["tanggal_hingga"]);
                obj.judul = Request.Form["judul"];
                obj.picture = picture == null ? "" : picture.FileName;
                obj.pictureData = imgData;
                obj.isi = Request.Form["isi"];
                obj.creator = userLogin;
                obj.created = DateTime.Now;

                Tb_PengumumanItem.Insert(obj);

                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj);
                return RedirectToAction("Create");
            }
        }

        // GET: Jejaring/Edit/5
        [Authorize]

        public ActionResult Edit(int id)
        {

            try
            {
                Tb_Pengumuman objAll = new Tb_Pengumuman();
                objAll = Tb_PengumumanItem.GetByPK(id);
                return View(new m_Tb_Pengumuman(objAll));
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // POST: Jejaring/Edit/5
        [Authorize]
        [HttpPost]

        public ActionResult Edit(int id, FormCollection collection, HttpPostedFileBase picture)
        {
            try
            {

                byte[] imgData = new byte[0];
                if (picture != null)
                {
                    using (BinaryReader br = new BinaryReader(picture.InputStream))
                    {
                        imgData = br.ReadBytes(picture.ContentLength);
                    }
                }

                // TODO: Add update logic here
                userLogin = Session["userLogin"].ToString();
                Tb_Pengumuman obj = new Tb_Pengumuman();
                obj.id_pengumuman = id;
                obj.no = Request.Form["no"];
                obj.tanggal = Convert.ToDateTime(Request.Form["tanggal"]);
                obj.tanggal_hingga = Convert.ToDateTime(Request.Form["tanggal_hingga"]);
                obj.judul = Request.Form["judul"];
                obj.picture = picture == null ? "" : picture.FileName;
                obj.pictureData = imgData;
                obj.isi = Request.Form["isi"];
                obj.editor = userLogin;
                obj.edited = DateTime.Now;

                Tb_PengumumanItem.Update(obj);

                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        // GET: Jejaring/Delete/5
        [Authorize]

        public ActionResult Delete(int id)
        {
            try
            {
                Tb_PengumumanItem.Delete(id);

                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj); return View(err.Message);
            }
        }

        //Custom
        [Authorize]
        public JsonResult IsAlreadyNo(string no)
        {
            try
            {
                bool status;

                Tb_Pengumuman obj = new Tb_Pengumuman();
                obj = Tb_Pengumuman_cstmItem.GetByNo(no);
                if (obj != null)
                {
                    //Already registered  
                    status = false;
                }
                else
                {
                    //Available to use  
                    status = true;
                }

                return Json(status, JsonRequestBehavior.AllowGet);
            }
            catch (Exception err)
            {
                Tb_Log_Error obj = new Tb_Log_Error(); obj.FunctionName = MethodBase.GetCurrentMethod().Name; obj.Menu = this.GetType().Name; obj.ErrorLog = err.ToString(); obj.creator = "System"; obj.created = DateTime.Now; Tb_Log_ErrorItem.Insert(obj);
                return Json(false, err.Message);
            }
        }
    }
}