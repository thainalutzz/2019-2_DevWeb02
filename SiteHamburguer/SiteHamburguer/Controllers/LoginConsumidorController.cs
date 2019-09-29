using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteHamburguer.Models;
using System.Data.Entity;


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
        public ActionResult Autorize(SiteHamburguer.Models.DBModels.InfoLogin info)
        {
            using (DBModels db = new DBModels())
            {
                var loginTelefone = db.CLIENTE.Where(x => x.TELEFONE == info.CLIENTE.TELEFONE).FirstOrDefault();
                // var loginSenha = db.COMSUMIDOR.Where(x => x.SENHA_CON == info.COMSUMIDOR.SENHA_CON).FirstOrDefault();
                if (loginTelefone == null)
                {
                    info.CLIENTE.LoginErroMessagem = "Usuário nao existe";
                    return View("Index", info);
                }
                else
                {
                    try
                    {
                        var loginSenha = db.COMSUMIDOR.Where(x => x.COD_CLIENTE_FK == loginTelefone.COD_CLIENTE).FirstOrDefault();
                        if (loginSenha.SENHA_CON == info.COMSUMIDOR.SENHA_CON)
                        {

                            //senha certa
                            Session["clienteCOD"] = loginTelefone.COD_CLIENTE;
                            Session["clienteTelefone"] = loginTelefone.TELEFONE;
                            return RedirectToAction("Index", "HomeConsumidor");
                        }
                        else
                        {
                            info.CLIENTE.LoginErroMessagem = "Senha incorreta";
                            return View("Index", info);
                        }
                    }
                    catch (NullReferenceException)
                    {
                        info.CLIENTE.LoginErroMessagem = "Senha incorreta";
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


    }
}