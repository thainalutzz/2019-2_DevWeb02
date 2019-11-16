using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteHamburguer.Models;
using System.Data.Entity;
using System.Web.Routing;

namespace SiteHamburguer.Controllers
{
    public class LoginConsumidorController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Autorize(SiteHamburguer.Models.InfoLogin info)
        {
            
            using (DBModels db = new DBModels())
            {
                var loginUsuario = db.CLIENTE.Where(x => x.NOME == info.CLIENTE.NOME).FirstOrDefault();
                ModelState.Clear();
                // var loginSenha = db.COMSUMIDOR.Where(x => x.SENHA_CON == info.COMSUMIDOR.SENHA_CON).FirstOrDefault();
                if (loginUsuario == null)
                {
                    
                    info.LoginErroMessagem = "Usuário nao existe";
                    return View("Index", info);
                }

                else
                {
                    try
                    {
                        var loginSenha = db.COMSUMIDOR.Where(x => x.COD_CLIENTE_FK == loginUsuario.COD_CLIENTE).FirstOrDefault();
                        if (loginSenha.SENHA_CON == info.COMSUMIDOR.SENHA_CON)
                        {

                            //senha certa
                            Session["clienteCOD"] = loginSenha.COD_CONSUMIDOR;
                            Session["clienteUsuario"] = loginUsuario.NOME;
                            return RedirectToAction("Index", "HomeConsumidor");
                        }
                        else
                        {
                            info.LoginErroMessagem = "Senha incorreta";
                            return View("Index", info);
                        }
                    }
                    catch (NullReferenceException)
                    {
                        info.LoginErroMessagem = "Senha incorreta";
                        return View("Index", info);
                    }
                }
            }

        }

        public ActionResult LogOut()
        {
            int clienteCOD = (int)Session["clienteCOD"];
            Session.Abandon();
            return RedirectToAction("Index", "LoginConsumidor");
        }
        public ActionResult RealizarPedido()
        {
           
            DBModels db = new DBModels();
            PedidoRadioButton rb = new PedidoRadioButton();
            
            int clienteCOD = (int)Session["clienteCOD"];
            PEDIDO pedido = new PEDIDO();
            {
                pedido.COD_CONSUMIDOR_FK = clienteCOD;
                pedido.STATUS = "Pendente";
            }
            db.PEDIDO.Add(pedido);
            db.SaveChanges();
            Session["pedidoCOD"] = pedido.COD_PEDIDO;
            return RedirectToAction("CreateItemPedido", "RealizaPedido");
            //PedidoController pedidoControler = new PedidoController();
            // return RedirectToAction("Create", "Pedido" );//nao esta passando o valor do pedido

            //return RedirectToAction("Create","Pedido", new {
            //    pedido = pedidoR
            //});
            // return   pedidoControler.Create(pedidoR);
            //return RedirectToAction("Create", new RouteValueDictionary(new
            //{
            //    Controller = "Pedido",
            //    ActionResult = "Create",
            //    pedido = pedidoR
            //}));

            //Int32 ultimoPedido = new Int32();
            //ultimoPedido = 0;

            //foreach (PEDIDO itemPedido in db.PEDIDO.ToList())
            //{
            //    if (ultimoPedido == 0)
            //    {
            //        ultimoPedido = itemPedido.COD_PEDIDO;
            //    }
            //    else
            //    {
            //        if (ultimoPedido < itemPedido.COD_PEDIDO)
            //        {
            //            ultimoPedido = itemPedido.COD_PEDIDO;
            //        }
            //    }
            //}

            //Session["pedidoCOD"] = ultimoPedido;
            //return RedirectToAction("Index", "RealizaPedido");




            //int pedidoCOD = (int)Session["pedidoCOD"];


            //return RedirectToAction("Pao", "RealizaPedido");
        }




    }
}