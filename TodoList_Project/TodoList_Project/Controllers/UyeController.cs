using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoList_Project.Models.Entity;

namespace TodoList_Project.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye
        Db_ToDoProjectEntities1 db = new Db_ToDoProjectEntities1();
        public ActionResult UyeBilgi()
        {
            return View();
        }
    }
}