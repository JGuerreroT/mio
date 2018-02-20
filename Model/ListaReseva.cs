using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ListaReseva
    {

        public string Periodo { get; set; }

        public string Moneda { get; set; }

        public DateTime Fecha { get; set; }

        public decimal Sepelio { get; set; }

        public decimal Garantizado { get; set; }

        public decimal Matematica { get; set; }

        public decimal total { get; set; }

        public string Estado { get; set; }


    }
}
