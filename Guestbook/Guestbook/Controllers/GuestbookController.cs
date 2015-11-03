using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Guestbook.Models;


namespace Guestbook.Controllers
{
    public class GuestbookController : Controller
    {
        //
        // GET: /Guestbook/
        private GuestbookContext db = new GuestbookContext();


        public ActionResult Index()
        {
            var mostRecentEntries = (from entry in db.Entries orderby entry.DateAdded descending select entry).Take(5);
            ViewBag.Entries = mostRecentEntries.ToList();
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(GuestbookEntry entry)
        {
            entry.DateAdded = DateTime.Now;
            db.Entries.Add(entry);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
