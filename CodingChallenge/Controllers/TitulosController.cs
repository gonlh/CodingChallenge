using CodingChallenge.Data.DataAccess;
using CodingChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Xml.Linq;

namespace CodingChallenge.Controllers
{
    [System.Web.Http.Route("api/[controller]")]
    public class TitulosController : ApiController
    {

        public ITituloRepository TitulosItems { get; set; }

        [System.Web.Http.HttpGet]
        public IEnumerable<TituloItem> GetAll()
        {
            var repositorio = new MockRepository().TituloRepository;
            var titulos = repositorio.GetTitulos();


            return TitulosItems.GetAll();
        }


        //[HttpGet("{id}", XName = "GetTodo")]
        //public ActionResult GetById(string id)
        //{
        //    var item = TitulosItems.Find(id);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }
        //    return new ObjectResult(item);
        //}

    }
}
