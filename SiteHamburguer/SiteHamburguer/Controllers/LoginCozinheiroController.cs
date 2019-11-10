using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteHamburguer.Models;
using System.Data.Entity;

namespace SiteHamburguer.Controllers
{
    public class LoginCozinheiroController : Controller
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
                        var loginSenha = db.COZINHEIRO.Where(x => x.COD_CLIENTE_FK == loginUsuario.COD_CLIENTE).FirstOrDefault();



                        if (loginSenha.SENHA_COZ == info.COZINHEIRO.SENHA_COZ)
                        {

                            //senha certa
                            Session["clienteCOD"] = loginUsuario.COD_CLIENTE;
                            Session["clienteUsuario"] = loginUsuario.NOME;
                            return RedirectToAction("Index", "HomeCozinheiro");
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
            return RedirectToAction("Index", "LoginCozinheiro");
        }

    }
}