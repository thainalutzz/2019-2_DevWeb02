using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteHamburguer.Models;
using System.Data.Entity;

namespace SiteHamburguer.Controllers
{
    public class HomeCozinheiroController : Controller
    {
        // GET: HomeCozinheiro
        public ActionResult Index()
        {

            using (DBModels db = new DBModels())
            {

                return View(db.PEDIDO.ToList().Where(x => x.STATUS == "Pendente"));
            }
        }


        public ActionResult Final(int id)
        {
            return View();
        }


        public ActionResult Cancelar(int id, PEDIDO pedido)
        {
            try

            {
                using (DBModels db = new DBModels())
                {
                    pedido = db.PEDIDO.Where(x => x.COD_PEDIDO == id).FirstOrDefault();
                    pedido.STATUS = "Pendente";
                    pedido.COD_COZINHEIRO_FK = null;
                    db.Entry(pedido).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index", "HomeCozinheiro");
                }

            }
            catch
            {

                return View();
            }
        }

        public ActionResult PedidoAceito(int id)
        {
            return PedidoAceito(id, new PEDIDO());
        }


        [HttpPost]
        public ActionResult PedidoAceito(int id, PEDIDO pedido)
        {
            try
            {
                using (DBModels db = new DBModels())
                {
                    pedido = db.PEDIDO.Where(x => x.COD_PEDIDO == id).FirstOrDefault();
                    pedido.STATUS = "Concluido";
                    db.Entry(pedido).State = EntityState.Modified;
                    db.SaveChanges();

                    return View("Final", pedido);
                }

            }
            catch
            {

                return View();
            }
        }

        public ActionResult Aceitar(int id, PEDIDO pedido)
        {
            try
            {
                using (DBModels db = new DBModels())
                {

                    pedido = db.PEDIDO.Where(x => x.COD_PEDIDO == id).FirstOrDefault();
                    pedido.STATUS = "Em Atendimento";
                    pedido.COD_COZINHEIRO_FK = (int)Session["clienteCOD"];

                    db.Entry(pedido).State = EntityState.Modified;
                    db.SaveChanges();


                }

                return View("Details", pedido);
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Details(int id)
        {
            using (DBModels db = new DBModels())
            {
                PEDIDO pedido = new PEDIDO();
                pedido = db.PEDIDO.Where(x => x.COD_PEDIDO == id).FirstOrDefault();
                pedido.STATUS = "Em Atendimento";
                pedido.COD_COZINHEIRO_FK = (int)Session["clienteCOD"];

                db.Entry(pedido).State = EntityState.Modified;
                db.SaveChanges();

                Session["pedidoCOD"] = id;
                return View(db.PEDIDO_HAMBURGUER.ToList().Where(x => x.COD_PEDIDO_FK == id));
            }
        }

        public ActionResult DetalheHamburguer(int id)
        {
            List<INGREDIENTE> listaIngredientes = new List<INGREDIENTE>();

            using (DBModels db = new DBModels())
            {
                foreach (HAMBURGUER_INGREDIENTE item in db.HAMBURGUER_INGREDIENTE.ToList().Where(x => x.COD_HAMBURGUER_FK == id))
                {
                    INGREDIENTE ingrediente = new INGREDIENTE();
                    ingrediente = db.INGREDIENTE.Where(x => x.COD_INGREDIENTE == item.COD_INGREDIENTE_FK).FirstOrDefault();
                    // ingrediente.COD_INGREDIENTE = item.COD_INGREDIENTE_FK;
                    //ingrediente.DESCR_INGREDIENTE = db.INGREDIENTE.Where(x => x.COD_INGREDIENTE == item.COD_INGREDIENTE_FK).FirstOrDefault().DESCR_INGREDIENTE;
                    listaIngredientes.Add(ingrediente);
                }
            }
            
            return View(listaIngredientes);


        }
    }
}