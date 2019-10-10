using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteHamburguer.Models
{
    public class PedidoRadioButton
    {
        public string Pao { get; set; }
        public List<INGREDIENTE> INGREDIENTEs
        {
            get
            {
                DBModels db = new DBModels();
                return db.INGREDIENTE.ToList();
            }
        }
    }
    
}