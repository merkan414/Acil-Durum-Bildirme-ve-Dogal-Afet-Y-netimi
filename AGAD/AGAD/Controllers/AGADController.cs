using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AGAD.App_Start;
using AGAD.Models;
using Newtonsoft.Json.Linq;

namespace AGAD.Controllers
{
    public class AGADController : Controller
    {
        //
        // GET: /AGAD/
        public ActionResult Index()
        {
            using(var db=new agadContext())
            {

                ViewBag.lastAgadList = (from item in db.AGADs

                                        where (item.CONFIRMSTATE_Item.Id != (int)CONFIRMSTATEENUM.NOTACCEPTED)
                                        select item).ToList<Models.AGAD>();
                ViewBag.agadType = (from type in db.AGADTYPEs select type).ToList();
                ViewBag.agadCityList = (from city in db.CITies select city).ToList();
                ViewBag.agadTownList = (from town in db.TOWNs where (town.CITY_ID == 1) select town).ToList();

                Session["imagePaths"] = null;
                return View(ViewBag);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult saveImage(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                // extract only the fielname
                var fileName = Path.GetFileName(file.FileName);
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath("~/Content/uploads"), fileName);
                file.SaveAs(path);
                List<string> paths;
                if(Session["imagePaths"]!=null)
                {
                    paths = Session["imagePaths"] as List<string>;
                    
                }
                else
                {
                    paths=new List<string>();
                }
                paths.Add("~/Content/uploads/" + fileName);
                Session["imagePaths"] = paths;
            }
            return Json(new { success = true });
        }



       

        [HttpPost]
        [AjaxOnly]
        [ValidateAntiForgeryToken]
        public JsonResult getList()
        {
           
            var db=new agadContext();
            var id=Convert.ToInt32(Request["cityID"]);
            var list = db.TOWNs.Where(w => w.CITY_ID == id).ToList();
            return Json(list, JsonRequestBehavior.DenyGet);  
        }

        [HttpPost]
        [AjaxOnly]
        public JsonResult saveAgad(AGAD.Models.AGAD model)
        {
            if (ModelState.IsValid)
            {
                using(var db=new AGAD.Models.agadContext())
                {
                    using (var trans = db.Database.BeginTransaction())
                    {
                        try
                        {
                            if (Session["imagePaths"] != null)
                            {
                                
                                db.AGADs.Add(model);
                             
                               var liste=Session["imagePaths"] as List<string>;
                                foreach(var item in liste)
                                {
                                    db.IMAGEPATHs.Add(new IMAGEPATH
                                    {
                                        AGAD_ID=model.Id,
                                        PATH=item
                                    });
                                    
                                }
                                
                                
                            }
                            db.SaveChanges();
                            trans.Commit();
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            return Json(new { success = false });
                        }
                    }
                }
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            } 
        }
	}
}