using CodingChallenge.Data.Classes;
using CodingChallenge.Data.DataAccess;
using CodingChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CodingChallenge.Controllers
{
    public class TituloController : ApiController
    {
        private readonly ITituloRepository repository;


        public TituloController(ITituloRepository titulo)
        {
            repository = titulo;
        }

        // GET: api/Titulo
        //[HttpGet]
        //[Route("api/Titulo")]
        public IEnumerable<string> Get()
        {
            var repositorio = new MockRepository().TituloRepository;
            var titulos = repositorio.GetTitulos();

            return new string[] { "value1", "value2" };
        }

        //GET: api/Titulo/5
        public string Get(int id)
        {
            return "valueID";
        }


        //api/Titulo/byName?nombre=a
        [HttpGet]
        [Route("api/Titulo/byName")]
        public IEnumerable<Titulo> Get(string nombre)
        {

            IEnumerable<Titulo> titulos = repository.Find(nombre);
            return titulos;
        }

        // POST: api/Titulo
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Titulo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Titulo/5
        public void Delete(int id)
        {
        }
    }
}
