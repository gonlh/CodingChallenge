using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodingChallenge.Models
{
    public interface ITituloRepository
    {
        void Add(TituloItem item);
        IEnumerable<TituloItem> GetAll();
        TituloItem Find(string key);
        TituloItem Remove(string key);
        void Update(TituloItem item);
    }
}