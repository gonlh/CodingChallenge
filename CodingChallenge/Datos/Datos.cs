using CodingChallenge.Data.Classes;
using CodingChallenge.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodingChallenge.Datos
{
    public static class Datos
    {
        public static IEnumerable<Titulo> titulos;

        public static IEnumerable<Titulo> Titulos
        {
            get {
                if (titulos == null)
                {
                    var repositorio = new MockRepository().TituloRepository;
                    titulos = repositorio.GetTitulos();
                }
                return titulos;
            }
        }    


    }
}