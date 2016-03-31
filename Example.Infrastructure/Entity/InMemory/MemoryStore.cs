using System;
using System.Collections.Generic;
using System.Linq;

namespace Example.Infrastructure.Entity.InMemory
{
    internal class MemoryStore
    {
        private Dictionary<Type, List<Object>> _items = new Dictionary<Type, List<object>>();

        public IQueryable<T> GetItems<T>()
        {
            return EnsureList<T>().Cast<T>().AsQueryable();
        }

        public int Clear<T>()
        {
            int count = EnsureList<T>().Count;
            EnsureList<T>().Clear();
            return count;
        }

        public void Remove<T>(T element)
        {
            EnsureList<T>().Remove(element);
        }

        public void Insert<T>(params Object[] items)
        {
            EnsureList<T>().AddRange(items.ToArray());
        }

        private List<Object> EnsureList<T>()
        {
            Type type = typeof(T);

            if (!_items.ContainsKey(type))
            {
                _items.Add(type, new List<Object>());
            }

            return _items[type];
        }
    }
}
