using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteHamburguer.Models;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace SiteHamburguer.Controllers
{
    public class RealizaPedidoController : Controller
    {
        public ActionResult Index()
        {
            using (DBModels db = new DBModels())
            {
                int codPedido = (int)Session["pedidoCOD"];
                return View(db.PEDIDO_HAMBURGUER.Where(x => x.COD_PEDIDO_FK == codPedido).ToList());

     
            }
        }

        public ActionResult CreateItemPedido()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateItemPedido(PedidoRadioButton pedidoRadioButton)
        {
            try
            {
                Int32 ultimoHamburguer = new Int32();
                ultimoHamburguer = 0;
                Int32 ultimoPedidoHamburguer = new Int32();
                ultimoPedidoHamburguer = 0;

                using (DBModels db = new DBModels())
                {
                    HAMBURGUER hamburguer = new HAMBURGUER();
                    db.HAMBURGUER.Add(hamburguer);
                    db.SaveChanges();

                    foreach (HAMBURGUER ham in db.HAMBURGUER.ToList())
                    {
                        if (ultimoHamburguer == 0)
                        {
                            ultimoHamburguer = ham.COD_HAMBURGUER;
                        }
                        else
                        {
                            if (ultimoHamburguer < ham.COD_HAMBURGUER)
                            {
                                ultimoHamburguer = ham.COD_HAMBURGUER;
                            }
                        }
                    }

                    PEDIDO_HAMBURGUER pedido_hamburguer = new PEDIDO_HAMBURGUER();
                    pedido_hamburguer.COD_PEDIDO_FK = (int)Session["pedidoCOD"];
                    pedido_hamburguer.COD_HAMBURGUER_FK = ultimoHamburguer;

                    db.PEDIDO_HAMBURGUER.Add(pedido_hamburguer);
                    db.SaveChanges();

                    foreach (PEDIDO_HAMBURGUER itemPedidoHamburguer in db.PEDIDO_HAMBURGUER.ToList())
                    {
                        if (ultimoPedidoHamburguer == 0)
                        {
                            ultimoPedidoHamburguer = itemPedidoHamburguer.COD_PEDIDO_HAMBURGUER;
                        }
                        else
                        {
                            if (ultimoPedidoHamburguer < itemPedidoHamburguer.COD_PEDIDO_HAMBURGUER)
                            {
                                ultimoPedidoHamburguer = itemPedidoHamburguer.COD_PEDIDO_HAMBURGUER;
                            }
                        }
                    }
                }

                return CreateItemHamburguer(ultimoHamburguer, ultimoPedidoHamburguer, pedidoRadioButton.HAMBURGUER_INGREDIENTE_LIST);
            }
            catch
            {
                return View();
            }
        }
        public ActionResult CreateItemHamburguer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateItemHamburguer(int codHamburguer, int codPedidoHamburguer, List<HAMBURGUER_INGREDIENTE> lista_hamburguer_ingrediente)
        {
            try
            {
                using (DBModels db = new DBModels())
                {
                    double precoHamburguer = new double();
                    precoHamburguer = 0;

                    foreach (HAMBURGUER_INGREDIENTE itemHamburguer in lista_hamburguer_ingrediente)
                    {
                        itemHamburguer.COD_HAMBURGUER_FK = codHamburguer;

                        INGREDIENTE ingrediente = new INGREDIENTE();
                        ingrediente = db.INGREDIENTE.Where(x => x.COD_INGREDIENTE == itemHamburguer.COD_INGREDIENTE_FK).FirstOrDefault();

                        itemHamburguer.QUANTIDADE = 1;
                        itemHamburguer.PRECO_TOTAL_HAM_ING = itemHamburguer.QUANTIDADE * ingrediente.PRECO_INGREDIENTE;

                        precoHamburguer += Convert.ToDouble(itemHamburguer.PRECO_TOTAL_HAM_ING);

                        db.HAMBURGUER_INGREDIENTE.Add(itemHamburguer);
                        db.SaveChanges();
                    }
                    HAMBURGUER hamburguer = new HAMBURGUER();
                    hamburguer.COD_HAMBURGUER = codHamburguer;
                    hamburguer.PRECO_HAMBURGUER = precoHamburguer;
                    db.Entry(hamburguer).State = EntityState.Modified;
                    db.SaveChanges();

                    PEDIDO_HAMBURGUER pedido_hamburguer = new PEDIDO_HAMBURGUER();
                    pedido_hamburguer.COD_PEDIDO_HAMBURGUER = codPedidoHamburguer;
                    pedido_hamburguer.COD_PEDIDO_FK = (int)Session["pedidoCOD"];
                    pedido_hamburguer.COD_HAMBURGUER_FK = codHamburguer;
                    pedido_hamburguer.QUANTIDADE_PED_HAM = 1;
                    pedido_hamburguer.PRECO_TOTAL_PED_HAM = pedido_hamburguer.QUANTIDADE_PED_HAM * hamburguer.PRECO_HAMBURGUER;
                    db.Entry(pedido_hamburguer).State = EntityState.Modified;
                    db.SaveChanges();

                    PEDIDO pedido = new PEDIDO();
                    pedido = db.PEDIDO.Where(x => x.COD_PEDIDO == pedido_hamburguer.COD_PEDIDO_FK).FirstOrDefault();
                    //pedido.COD_PEDIDO = (int)Session["pedidoCOD"];
                    //pedido.COD_CONSUMIDOR_FK = (int)Session["clienteCOD"];

                    if (pedido.PRECO_PEDIDO != null)
                    {
                        pedido.PRECO_PEDIDO += pedido_hamburguer.PRECO_TOTAL_PED_HAM;
                    }
                    else
                    {
                        pedido.PRECO_PEDIDO = pedido_hamburguer.PRECO_TOTAL_PED_HAM;
                    }


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

        // GET: RealizaPedido/Details/5
        public ActionResult Details(int id)
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
            using (DBModels db = new DBModels())
            {
                return View(db.HAMBURGUER.Where(x => x.COD_HAMBURGUER == id).FirstOrDefault());


            }
        }

        // POST: RealizaPedido/Edit/5
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

        // GET: RealizaPedido/Delete/5
        public ActionResult Delete(int id)
        {
            using (DBModels db = new DBModels())
            {
                return View(db.HAMBURGUER.Where(x => x.COD_HAMBURGUER == id).FirstOrDefault());
            }
        }

        // POST: RealizaPedido/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, HAMBURGUER hamburguer)
        {
            try
            {
                using (DBModels db = new DBModels())
                {
                    hamburguer = db.HAMBURGUER.Where(x => x.COD_HAMBURGUER == id).FirstOrDefault();
                    PEDIDO_HAMBURGUER pedido_hamburguer = db.PEDIDO_HAMBURGUER.Where(x => x.COD_HAMBURGUER_FK == id).FirstOrDefault();
                    

                    db.PEDIDO_HAMBURGUER.Remove(pedido_hamburguer);
                    db.SaveChanges();
                    for (int i = 0; i <= 5; i++)
                    {
                        HAMBURGUER_INGREDIENTE hamburguer_ingrediente = db.HAMBURGUER_INGREDIENTE.Where(x => x.COD_HAMBURGUER_FK == id).FirstOrDefault();
                        db.HAMBURGUER_INGREDIENTE.Remove(hamburguer_ingrediente);
                        db.SaveChanges();
                    }

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
