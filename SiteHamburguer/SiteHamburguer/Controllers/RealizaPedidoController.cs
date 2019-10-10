using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteHamburguer.Models;
using System.Data.Entity;
using System.Data;
using System.Configuration;


namespace SiteHamburguer.Controllers
{
    public class RealizaPedidoController : Controller
    {
        // GET: RealizaPedido
        [HttpGet]
        public ActionResult Pao()
        {
            PedidoRadioButton rb = new PedidoRadioButton();
            return View(rb);
        }
        [HttpPost]
        public ActionResult Redirect(PedidoRadioButton rb)
        {
            return View();
        }



        // GET: RealizaPedido/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RealizaPedido/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RealizaPedido/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RealizaPedido/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RealizaPedido/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RealizaPedido/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RealizaPedido/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
      
    }
}
