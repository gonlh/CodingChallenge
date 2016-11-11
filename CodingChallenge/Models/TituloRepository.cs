using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Web;

namespace CodingChallenge.Models
{
    public class TituloRepository: ITituloRepository
    {
        private static ConcurrentDictionary<string, TituloItem> _todos =
             new ConcurrentDictionary<string, TituloItem>();

        public TituloRepository()
        {
            Add(new TituloItem { Name = "Item1" });
        }

        public IEnumerable<TituloItem> GetAll()
        {
            return _todos.Values;
        }

        public void Add(TituloItem item)
        {
            item.Key = Guid.NewGuid().ToString();
            _todos[item.Key] = item;
        }

        public TituloItem Find(string key)
        {
            TituloItem item;
            _todos.TryGetValue(key, out item);
            return item;
        }

        public TituloItem Remove(string key)
        {
            TituloItem item;
            _todos.TryRemove(key, out item);
            return item;
        }

        public void Update(TituloItem item)
        {
            _todos[item.Key] = item;
        }
    }
}