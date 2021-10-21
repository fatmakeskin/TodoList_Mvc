using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TodoList_Project.Models;
using TodoList_Project.Models.Entity;

namespace TodoList_Project.Controllers
{
    public class ToDoController : Controller
    {
        // GET: ToDo
        Db_ToDoProjectEntities1 db = new Db_ToDoProjectEntities1();
        public ActionResult Index()
        {
            var t = db.Tbl_ToDo.ToList();
            return View(t);
        }
        [HttpGet]
        public ActionResult ToDoEkle()
        {
            List<SelectListItem> deger1 = (from i in db.Tbl_Kategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            return View();
           
        }

        [HttpPost]
        public ActionResult ToDoEkle(Tbl_ToDo p)
        {
            var tdo = db.Tbl_Kategori.Where(t => t.ID == p.Tbl_Kategori.ID).FirstOrDefault();
            p.Tbl_Kategori = tdo;
            db.Tbl_ToDo.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult ToDoSil(int id)
        {
            var tdo = db.Tbl_ToDo.Find(id);
            db.Tbl_ToDo.Remove(tdo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ToDoGetir(int id)
        {
            var tdo = db.Tbl_ToDo.Find(id);
            List<SelectListItem> deger1 = (from i in db.Tbl_Kategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View("Index", tdo);

        }
        public ActionResult ToDoGuncelle(Tbl_ToDo p)
        {
            var tdo = db.Tbl_ToDo.Find(p.ID);
            tdo.BASLIK = p.BASLIK;
            tdo.NOTLAR = p.NOTLAR;
            tdo.TARIH = p.TARIH;
            var kategori = db.Tbl_Kategori.Where(t => t.ID == p.Tbl_Kategori.ID).FirstOrDefault();
            tdo.KATEGORI = kategori.ID;            
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult mailgonder()
        {
            return View();
        }
        [HttpPost]
        public ActionResult mailgonder(string receiverEmail, string subject, string message)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("mailadresi@gmail.com", "");
                    var receivereEmail = new MailAddress(receiverEmail, "Receiver");
                    var password = "Şifre";
                    var sub = subject;
                    var body = message;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receivereEmail)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(mess);
                    }
                    return View();

                }
            }
            catch (Exception)
            {

                ViewBag.Error = "Mail Gönderilirken bir problem yaşandı";
            }
            return View();
        }
    }


}

   
