using System;

namespace Example.CrossCutting.Caching
{
    public interface ICache : IDisposable
    {
        bool Contains(Object key);
        void Remove(Object key);

        Object Get(Object key);
        void Set(Object key, Object value);
    }
}
