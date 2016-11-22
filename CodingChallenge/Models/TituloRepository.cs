using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Web;
using CodingChallenge.Data.Classes;

namespace CodingChallenge.Models
{
    public class TituloRepository: ITituloRepository
    {
 

        public TituloRepository()
        {
            
        }

        public IEnumerable<Titulo> GetAll()
        {
            return Datos.Datos.Titulos;
        }

        public void Add(Titulo item)
        {           
           
        }

        public IEnumerable<Titulo> Find(string key)
        {

            var titulosFiltrados = from titulo in Datos.Datos.Titulos
                                   where titulo.Descripcion.ToLower().Contains(key.ToLower())
                                   select titulo;
            
            return (IEnumerable < Titulo >) titulosFiltrados;
        }

        public Titulo Remove(string key)
        {
            Titulo item = null;
            
            return item;
        }

        public void Update(Titulo item)
        {            
        }
       
    }
}