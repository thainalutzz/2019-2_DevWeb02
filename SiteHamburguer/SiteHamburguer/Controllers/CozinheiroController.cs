﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteHamburguer.Models;
using System.Data.Entity;

namespace SiteHamburguer.Controllers
{
    public class CozinheiroController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            using (DBModels db = new DBModels())
            {
                return View(db.COZINHEIRO.ToList());
            }
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            using (DBModels db = new DBModels())
            {
                return View(db.COZINHEIRO.Where(x => x.COD_COZINHEIRO == id).FirstOrDefault());
            }
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(InfoLogin info)
        {
            try
            {
                using (DBModels db = new DBModels())
                {
                    db.CLIENTE.Add(info.CLIENTE);
                    db.SaveChanges();

                    Int32 ultimoCliente = new Int32();
                    ultimoCliente = 0;

                    foreach (CLIENTE cli in db.CLIENTE.ToList())
                    {
                        if (ultimoCliente == 0)
                        {
                            ultimoCliente = cli.COD_CLIENTE;
                        }
                        else
                        {
                            if (ultimoCliente < cli.COD_CLIENTE)
                            {
                                ultimoCliente = cli.COD_CLIENTE;
                            }
                        }
                    }
                    info.COZINHEIRO.COD_CLIENTE_FK = ultimoCliente;
                    db.COZINHEIRO.Add(info.COZINHEIRO);
                    db.SaveChanges();
                }

                return RedirectToAction("Index","LoginCozinheiro");
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
                return View(db.COZINHEIRO.Where(x => x.COD_COZINHEIRO == id).FirstOrDefault());
            }
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, COZINHEIRO cozinheiro)
        {
            try
            {
                using (DBModels db = new DBModels())
                {
                    db.Entry(cozinheiro).State = EntityState.Modified;
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
                return View(db.COZINHEIRO.Where(x => x.COD_COZINHEIRO == id).FirstOrDefault());
            }
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, COZINHEIRO cozinheiro)
        {
            try
            {
                using (DBModels db = new DBModels())
                {
                    cozinheiro = db.COZINHEIRO.Where(x => x.COD_COZINHEIRO == id).FirstOrDefault();
                    db.COZINHEIRO.Remove(cozinheiro);
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
