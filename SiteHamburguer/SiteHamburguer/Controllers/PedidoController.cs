using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteHamburguer.Models;
using System.Data.Entity;

namespace SiteHamburguer.Controllers
{
    public class PedidoController : Controller
    {
        public ActionResult Index()
        {
            using (DBModels db = new DBModels())
            {
                return View(db.PEDIDO.ToList());
            }
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            using (DBModels db = new DBModels())
            {
                return View(db.PEDIDO.Where(x => x.COD_PEDIDO == id).FirstOrDefault());
            }
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(PEDIDO pedido)
        {
            try
            {
                using (DBModels db = new DBModels())
                {
                    db.PEDIDO.Add(pedido);
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
                return View(db.PEDIDO.Where(x => x.COD_PEDIDO == id).FirstOrDefault());
            }
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PEDIDO pedido)
        {
            try
            {
                using (DBModels db = new DBModels())
                {
                    db.Entry(pedido).State = EntityState.Modified;
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
                return View(db.PEDIDO.Where(x => x.COD_PEDIDO == id).FirstOrDefault());
            }
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, PEDIDO pedido)
        {
            try
            {
                using (DBModels db = new DBModels())
                {
                    pedido = db.PEDIDO.Where(x => x.COD_PEDIDO == id).FirstOrDefault();
                    db.PEDIDO.Remove(pedido);
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

