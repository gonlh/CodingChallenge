using CodingChallenge.Data.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodingChallenge.Models
{
    public interface ITituloRepository
    {
        void Add(Titulo item);
        IEnumerable<Titulo> GetAll();
        IEnumerable<Titulo> Find(string key);
        Titulo Remove(string key);
        void Update(Titulo item);
    }
}