using CodingChallenge.Data.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodingChallenge.Models
{
    public class TituloItem
    {
        public int Id { get; set; }
        public string Detalle { get; set; }
        public string Descripcion { get; set; }
        public string Simbolo { get; set; }

        public Moneda Moneda { get; set; }
        public TipoTitulo Tipo { get; set; }


    }
}