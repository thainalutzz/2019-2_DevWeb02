using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteHamburguer.Models
{
    public class PedidoRadioButton
    {

        public INGREDIENTE INGREDIENTE { get; set; }
        public PEDIDO PEDIDO { get; set; }
        public HAMBURGUER HAMBURGUER { get; set; }
        public HAMBURGUER_INGREDIENTE HAMBURGUER_INGREDIENTE { get; set; }
        public PEDIDO_HAMBURGUER PEDIDO_HAMBURGUER { get; set; }
        public List<HAMBURGUER_INGREDIENTE> HAMBURGUER_INGREDIENTE_LIST { get; set; }


        public COMSUMIDOR COMSUMIDOR { get; set; }
        public COZINHEIRO COZINHEIRO { get; set; }
        public PedidoRadioButton()
        {

            INGREDIENTE = new INGREDIENTE();
            PEDIDO = new PEDIDO();
            HAMBURGUER = new HAMBURGUER();
            HAMBURGUER_INGREDIENTE = new HAMBURGUER_INGREDIENTE();
            PEDIDO_HAMBURGUER = new PEDIDO_HAMBURGUER();
            COMSUMIDOR = new COMSUMIDOR();
            COZINHEIRO = new COZINHEIRO();



        }

    }

}