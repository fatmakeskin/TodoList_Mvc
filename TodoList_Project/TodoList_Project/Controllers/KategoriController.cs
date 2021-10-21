using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoList_Project.Models.Entity;

namespace TodoList_Project.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Db_ToDoProjectEntities1 db = new Db_ToDoProjectEntities1();
        public ActionResult Index()
        {
            var ktg = db.Tbl_Kategori.ToList();
            return View(ktg);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Tbl_Kategori p)
        {
            db.Tbl_Kategori.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult KategoriSil(int id)
        {
            var kategori = db.Tbl_Kategori.Find(id);
            db.Tbl_Kategori.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktg = db.Tbl_Kategori.Find(id);
            return View("KategoriGetir", ktg);
        }
        public ActionResult KategoriGüncelle(Tbl_Kategori p1)
        {
            var kategori = db.Tbl_Kategori.Find(p1.ID);
            kategori.AD = p1.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}