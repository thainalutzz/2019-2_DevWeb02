using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteHamburguer.Models;
using System.Data.Entity;
 

namespace SiteHamburguer.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            using (DBModels db = new DBModels())
            {
                return View(db.CLIENTE.ToList());
            }
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            using (DBModels db = new DBModels())
            {
                return View(db.CLIENTE.Where(x => x.COD_CLIENTE == id).FirstOrDefault());
            }
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(CLIENTE cliente)
        {
            try
            {
                using (DBModels db = new DBModels())
                {
                    db.CLIENTE.Add(cliente);
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
                return View(db.CLIENTE.Where(x => x.COD_CLIENTE == id).FirstOrDefault());
            }
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CLIENTE cliente)
        {
            try
            {
                using (DBModels db = new DBModels())
                {
                    db.Entry(cliente).State = EntityState.Modified;
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
                return View(db.CLIENTE.Where(x => x.COD_CLIENTE == id).FirstOrDefault());
            }
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CLIENTE cliente)
        {
            try
            {
                using (DBModels db = new DBModels())
                {
                    cliente = db.CLIENTE.Where(x => x.COD_CLIENTE == id).FirstOrDefault();
                    db.CLIENTE.Remove(cliente);
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
