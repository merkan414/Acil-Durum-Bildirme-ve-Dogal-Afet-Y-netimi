using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AGAD.Models;

namespace AGAD.Controllers
{
    public class ADMINController : Controller
    {
        //
        // GET: /ADMIN/
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index(string returnUrl = "")
        {
            // check User Control
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/admin/1");
            }
            // save return url
            if (!String.IsNullOrEmpty(returnUrl))
            {
                if (Url.IsLocalUrl(returnUrl))
                {
                    Session["returnURL"] = returnUrl;
                }

                return Redirect("/admin");
            }
            // show error
            ViewBag.error = false;
            return View("~/Views/ADMIN/_login.cshtml");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(USER model)
        {
            if (ModelState.IsValid)
            {
                // check user is valid
                if (Membership.ValidateUser(model.EMAIL, model.PASS))
                {
                    FormsAuthentication.RedirectFromLoginPage(model.EMAIL, true);
                }
                // save user control error
                ModelState.AddModelError("", "Kullanıcı Adı ve Şifre Yanlış");
                // show error
                ViewBag.error = true;
            }
            return View("~/Views/ADMIN/_login.cshtml", model);
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult logOut()
        {
            if (User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
            }
            return Redirect("/");
        }




        [Authorize]
        public ActionResult getList(int pagination = 0)
        {
            // not show home icon
            ViewBag.homeIcon = false;
            ViewBag.ID = pagination;
            var temp = new List<AGAD.Models.AGAD>();
            var db = new AGAD.Models.agadContext();
            var user = db.USERs.Where(w => w.EMAIL == User.Identity.Name).FirstOrDefault();
            //check user
            if (user != null)
            {
                ViewBag.userName = user.NAME + " " + user.SURNAME;
            }
            // take 5 agads
            var agads = db.AGADs.OrderBy(w => w.STARTDATE).Skip((pagination - 1) * 5).Take(5);
            var countAGAD = db.AGADs.Count();
            //calculate paging parameter
            ViewBag.countAGAD = Math.Ceiling((decimal)countAGAD / 5);
            ViewBag.pagination = pagination;
            return View("~/Views/ADMIN/_getList.cshtml", agads.ToList());



        }

        [Authorize]
        public ActionResult getDetailAGAD(int detailPage)
        {
            ViewBag.homeIcon = true;
            var db = new AGAD.Models.agadContext();
            var user = db.USERs.Where(w => w.EMAIL == User.Identity.Name).FirstOrDefault();
            if (user != null)
            {
                ViewBag.userName = user.NAME + " " + user.SURNAME;
            }
            ViewBag.confirmState = db.CONFIRMSTATEs.ToList();
            ViewBag.ID = detailPage;
            var model = db.AGADs.Where(w => w.Id == detailPage).FirstOrDefault();
            if (model == null)
            {
                throw new HttpException(404, "Hatalı Öge");
            }
            if(model.CONFIRMSTATEID==(int)CONFIRMSTATEENUM.NOTACCEPTED)
            {
                model.CONFIRMSTATEID = (int)CONFIRMSTATEENUM.PROCESSING;
                db.SaveChanges();
            }
            model.USER_TC = user.TC;
            return View("~/Views/ADMIN/_detailAGAD.cshtml", model);
        }


        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult changeState(string confirmComment, int confirmState, int detailID)
        {
            var db = new agadContext();
            var item = db.AGADs.Where(w => w.Id == detailID).FirstOrDefault();
            var confirmSt = db.CONFIRMSTATEs.Where(w => w.Id == confirmState).FirstOrDefault();
            if (item == null || confirmSt == null)
            {
                throw new HttpException(404, "Hatalı Öge");
            }
            item.CONFIRMSTATEID = confirmState;
            item.CONFIRMCOMMENT = confirmComment;
            db.SaveChanges();
            return Redirect("/admin/detay/" + detailID);
        }
    }
}