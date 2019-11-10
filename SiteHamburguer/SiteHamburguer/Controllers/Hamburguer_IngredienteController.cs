using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteHamburguer.Models;
using System.Data.Entity;

namespace SiteHamburguer.Controllers
{
    public class Hamburguer_IngredienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            using (DBModels db = new DBModels())
            {
                return View(db.HAMBURGUER_INGREDIENTE.ToList());
            }
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            using (DBModels db = new DBModels())
            {
                return View(db.HAMBURGUER_INGREDIENTE.Where(x => x.COD_HAMBURGUER_INGREDIENTE == id).FirstOrDefault());
            }
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(HAMBURGUER_INGREDIENTE hamburguer_ingrediente)
        {
            try
            {
                using (DBModels db = new DBModels())
                {
                    db.HAMBURGUER_INGREDIENTE.Add(hamburguer_ingrediente);
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
                return View(db.HAMBURGUER_INGREDIENTE.Where(x => x.COD_HAMBURGUER_INGREDIENTE == id).FirstOrDefault());
            }
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, HAMBURGUER_INGREDIENTE hamburguer_ingrediente)
        {
            try
            {
                using (DBModels db = new DBModels())
                {
                    db.Entry(hamburguer_ingrediente).State = EntityState.Modified;
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
                return View(db.HAMBURGUER_INGREDIENTE.Where(x => x.COD_HAMBURGUER_INGREDIENTE == id).FirstOrDefault());
            }
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, HAMBURGUER_INGREDIENTE hamburguer_ingrediente)
        {
            try
            {
                using (DBModels db = new DBModels())
                {
                    hamburguer_ingrediente = db.HAMBURGUER_INGREDIENTE.Where(x => x.COD_HAMBURGUER_INGREDIENTE == id).FirstOrDefault();
                    db.HAMBURGUER_INGREDIENTE.Remove(hamburguer_ingrediente);
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
