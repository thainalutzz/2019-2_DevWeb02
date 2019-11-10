using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteHamburguer.Models;
using System.Data.Entity;

namespace SiteHamburguer.Controllers
{
    public class Pedido_HamburguerController : Controller
    {
        public ActionResult Index()
        {
            using (DBModels db = new DBModels())
            {
                return View(db.PEDIDO_HAMBURGUER.ToList());
            }
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            using (DBModels db = new DBModels())
            {
                return View(db.PEDIDO_HAMBURGUER.Where(x => x.COD_PEDIDO_HAMBURGUER == id).FirstOrDefault());
            }
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(PEDIDO_HAMBURGUER pedido_hamburguer)
        {
            try
            {
                using (DBModels db = new DBModels())
                {
                    db.PEDIDO_HAMBURGUER.Add(pedido_hamburguer);
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
                return View(db.PEDIDO_HAMBURGUER.Where(x => x.COD_PEDIDO_HAMBURGUER == id).FirstOrDefault());
            }
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PEDIDO_HAMBURGUER pedido_hamburguer)
        {
            try
            {
                using (DBModels db = new DBModels())
                {
                    db.Entry(pedido_hamburguer).State = EntityState.Modified;
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
                return View(db.PEDIDO_HAMBURGUER.Where(x => x.COD_PEDIDO_HAMBURGUER == id).FirstOrDefault());
            }
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, PEDIDO_HAMBURGUER pedido_hamburguer)
        {
            try
            {
                using (DBModels db = new DBModels())
                {
                    pedido_hamburguer = db.PEDIDO_HAMBURGUER.Where(x => x.COD_PEDIDO_HAMBURGUER == id).FirstOrDefault();
                    db.PEDIDO_HAMBURGUER.Remove(pedido_hamburguer);
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

