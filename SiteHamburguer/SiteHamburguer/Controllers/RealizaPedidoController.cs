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

                //colocar botoes excluir e edit de HAMBURGUER, ao clicar Pedido_Hamburguer.Cod_Hamburguer_FK
            }
        }
        //GET: CriaHamburguer
        //[HttpPost]
        // public ActionResult CreateHamburguer(PEDIDO hamburguer)
        // {
        //     try
        //     {
        //         using (DBModels db = new DBModels())
        //         {
        //             db.HAMBURGUER.Add(hamburguer);
        //             db.SaveChanges();
        //         }
        //         return RedirectToAction("CreateItem");
        //     }
        //     catch
        //     {
        //         return View();
        //     }
        // }

        // GET: Adiciona Ingrediente ao Hamburguer
        //public ActionResult CreateItem()
        //{
        //    return View();
        //}
        // [HttpPost]

        //public ActionResult CreateItem(List<HAMBURGUER_INGREDIENTE> itemHamburguer)
        //{
        //    try
        //    {
        //        using (DBModels db = new DBModels())
        //        {
        //            //fazer com que receba mais de uma fk, criando outro hamburguer ingrediente com o mesmo fk hamburguer
        //            foreach (HAMBURGUER_INGREDIENTE item in itemHamburguer)
        //            {
        //                db.HAMBURGUER_INGREDIENTE.Add(item);
        //                db.SaveChanges();
        //            }
                       
                    
                     

                    
                   
        //        }
        //        return PartialView("CreateItem");
        //       // return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        //public ActionResult CreatePedido()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult CreatePedido(PedidoRadioButton rb)
        //{
        //    try
        //    {
        //        using (DBModels db = new DBModels())
        //        {
        //            db.HAMBURGUER.Add(rb.HAMBURGUER);
        //            db.SaveChanges(); // adicionado para salvar o hamgurguer criado
        //            Int32 ultimoHamburguer = new Int32();
        //            ultimoHamburguer = 0;

        //            foreach (HAMBURGUER ham in db.HAMBURGUER.ToList())
        //            {
        //                if (ultimoHamburguer == 0)
        //                {
        //                    ultimoHamburguer = ham.COD_HAMBURGUER;
        //                }
        //                else
        //                {
        //                    if (ultimoHamburguer < ham.COD_HAMBURGUER)
        //                    {
        //                        ultimoHamburguer = ham.COD_HAMBURGUER;
        //                    }
        //                }
        //            }



        //            rb.HAMBURGUER_INGREDIENTE.COD_HAMBURGUER_FK = ultimoHamburguer;
        //            db.HAMBURGUER_INGREDIENTE.Add(rb.HAMBURGUER_INGREDIENTE);


        //            para cada ingrediente selecionado no radiobutton, sera criado um hamburguer_ingrediente com o cod do ingrediente
        //            que foi selecionado
        //            com a mesma fk do ultimo Hamburguer criado






        //            db.PEDIDO.Add(rb.PEDIDO); // ?
        //            db.SaveChanges();




        //        }

        //        return RedirectToAction("CreateItem", "RealizaPedido", rb.HAMBURGUER_INGREDIENTE);
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
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
                }

                return CreateItemHamburguer(ultimoHamburguer, pedidoRadioButton.HAMBURGUER_INGREDIENTE_LIST);
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
        public ActionResult CreateItemHamburguer(int codHamburguer, List<HAMBURGUER_INGREDIENTE> lista_hamburguer_ingrediente)
        {
            try
            {
                using (DBModels db = new DBModels())
                {
                    foreach (HAMBURGUER_INGREDIENTE itemHamburguer in lista_hamburguer_ingrediente)
                    {
                        itemHamburguer.COD_HAMBURGUER_FK = codHamburguer;

                        //calculo dos precos

                        db.HAMBURGUER_INGREDIENTE.Add(itemHamburguer);
                        db.SaveChanges();
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //// GET: RealizaPedido
        //[HttpGet]
        //public ActionResult Pao(PedidoRadioButton rb)
        //{
        //    // PedidoRadioButton rb = new PedidoRadioButton();
        //    DBModels db = new DBModels();
        //    //string mainconn = ConfigurationManager.ConnectionStrings["DBModels"].ConnectionString;
        //    SqlConnection sqlconn = new SqlConnection();
        //    string sqlquery = "insert into HAMBURGUER (PRECO_HAMBURGUER) values('0');select @@identity;insert HAMBURGUER_INGREDIENTE(COD_HAMBURGUER_FK, COD_INGREDIENTE_FK, QUANTIDADE, PRECO_TOTAL_HAM_ING) values(SCOPE_IDENTITY(), @pao, '1', '0'); ";
        //    SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
        //    sqlcomm.Parameters.AddWithValue("@pao", rb.Pao);
        //    sqlcomm.ExecuteNonQuery();
        //    sqlconn.Close();
        //    return View();
        //}
        //[HttpPost]
        // public ActionResult Queijo()
        //{
        //   PedidoRadioButton rb = new PedidoRadioButton();
        //    return View(rb);
        //}
        //public ActionResult Carne()
        //{
        //    PedidoRadioButton rb = new PedidoRadioButton();
        //    return View(rb);
        //}
        //public ActionResult Molho()
        //{
        //    PedidoRadioButton rb = new PedidoRadioButton();
        //    return View(rb);
        //}
        //public ActionResult Salada()
        //{
        //    PedidoRadioButton rb = new PedidoRadioButton();
        //    return View(rb);
        //}
        //public ActionResult Adicionais()
        //{
        //    PedidoRadioButton rb = new PedidoRadioButton();
        //    return View(rb);
        //}
        //public ActionResult Final()
        //{
        //    PedidoRadioButton rb = new PedidoRadioButton();
        //    return View(rb);
        //}



        // GET: RealizaPedido/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RealizaPedido/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

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
