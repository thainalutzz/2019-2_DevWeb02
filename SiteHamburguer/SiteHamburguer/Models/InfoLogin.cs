using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteHamburguer.Models
{

    public class InfoLogin
    {
        public CLIENTE CLIENTE { get; set; }
        public COMSUMIDOR COMSUMIDOR { get; set; }
        public COZINHEIRO COZINHEIRO { get; set; }

        public string LoginErroMessagem { get; set; }
        public InfoLogin()
        {
            CLIENTE = new CLIENTE();
            COMSUMIDOR = new COMSUMIDOR();
            COZINHEIRO = new COZINHEIRO();
        }
    }
}