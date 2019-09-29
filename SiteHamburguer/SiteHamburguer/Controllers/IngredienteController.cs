using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteHamburguer.Models;
using System.Data.Entity;

namespace SiteHamburguer.Controllers
{
    public class IngredienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            using (DBModels db = new DBModels())
            {
                return View(db.INGREDIENTE.ToList());
            }
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            using (DBModels db = new DBModels())
            {
                return View(db.INGREDIENTE.Where(x => x.COD_INGREDIENTE == id).FirstOrDefault());
            }
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(INGREDIENTE ingrediente)
        {
            try
            {
                using (DBModels db = new DBModels())
                {
                    db.INGREDIENTE.Add(ingrediente);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            using (DBModels db = new DBModels())
            {
                return View(db.INGREDIENTE.Where(x => x.COD_INGREDIENTE == id).FirstOrDefault());
            }
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, INGREDIENTE ingrediente)
        {
            try
            {
                using (DBModels db = new DBModels())
                {
                    db.Entry(ingrediente).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            using (DBModels db = new DBModels())
            {
                return View(db.INGREDIENTE.Where(x => x.COD_INGREDIENTE == id).FirstOrDefault());
            }
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, INGREDIENTE ingrediente)
        {
            try
            {
                using (DBModels db = new DBModels())
                {
                    ingrediente = db.INGREDIENTE.Where(x => x.COD_INGREDIENTE == id).FirstOrDefault();
                    db.INGREDIENTE.Remove(ingrediente);
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
