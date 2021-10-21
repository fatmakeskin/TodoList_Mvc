using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoList_Project.Models.Entity;
using System.Web.Security;
using TodoList_Project.Models;

namespace TodoList_Project.Controllers
{
    [AllowAnonymous]
    public class GuvenlikController : Controller
    {
        // GET: Security
        Db_ToDoProjectEntities1 db = new Db_ToDoProjectEntities1();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Tbl_Uye user)
        {
            var UyeGiris = db.Tbl_Uye.FirstOrDefault(u => u.MAIL == user.MAIL && user.SIFRE == user.SIFRE);
            if (UyeGiris!=null)
            {
                FormsAuthentication.SetAuthCookie(user.MAIL, false);
                Session["AD"] = UyeGiris.AD.ToString();
                Session["SOYAD"] = UyeGiris.SOYAD.ToString();
                Session["KULLANICIADI"] = UyeGiris.KULLANICIADI.ToString();
                Session["SIFRE"] = UyeGiris.SIFRE.ToString();
                return RedirectToAction("Index", "ToDo");
            }
            else
            {
                ViewBag.Mesaj = "Geçersiz kullanıcı girişi yaptınız..";
                return View();
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(Tbl_Uye p)
        {
            db.Tbl_Uye.Add(p);            
            db.SaveChanges();
            return RedirectToAction("Login", "Guvenlik");
        }


    }
}