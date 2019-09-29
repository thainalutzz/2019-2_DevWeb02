using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteHamburguer.Models;
using System.Data.Entity;

namespace SiteHamburguer.Controllers
{
    public class HamburguerController : Controller
    {
        // GET: Hamburguer
        public ActionResult Index()
        {
            using (DBModels db = new DBModels())
            {
                return View(db.HAMBURGUER.ToList());
            }
        }

        // GET: Hamburguer/Details/5
        public ActionResult Details(int id)
        {
            using (DBModels db = new DBModels())
            {
                return View(db.HAMBURGUER.Where(x => x.COD_HAMBURGUER == id).FirstOrDefault());
            }
        }

        // GET: Hamburguer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hamburguer/Create
        [HttpPost]
        public ActionResult Create(HAMBURGUER hamburguer)
        {
            try
            {
                using (DBModels db = new DBModels())
                {
                    db.HAMBURGUER.Add(hamburguer);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Hamburguer/Edit/5
        public ActionResult Edit(int id)
        {
            using (DBModels db = new DBModels())
            {
                return View(db.HAMBURGUER.Where(x => x.COD_HAMBURGUER == id).FirstOrDefault());
            }
        }

        // POST: Hamburguer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, HAMBURGUER hamburguer)
        {
            try
            {
                using (DBModels db = new DBModels())
                {
                    db.Entry(hamburguer).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Hamburguer/Delete/5
        public ActionResult Delete(int id)
        {
            using (DBModels db = new DBModels())
            {
                return View(db.HAMBURGUER.Where(x => x.COD_HAMBURGUER == id).FirstOrDefault());
            }
        }

        // POST: Hamburguer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, HAMBURGUER hamburguer)
        {
            try
            {
                using (DBModels db = new DBModels())
                {
                    hamburguer = db.HAMBURGUER.Where(x => x.COD_HAMBURGUER == id).FirstOrDefault();
                    db.HAMBURGUER.Remove(hamburguer);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
