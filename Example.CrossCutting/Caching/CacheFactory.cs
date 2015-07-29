using System;

namespace Example.CrossCutting.Caching
{
    public abstract class CacheFactory : IDisposable
    {
        private ICache _default;

        public abstract ICache CreateCache();

        protected virtual ICache CreateDefaultCache()
        {
            return null;
        }

        public ICache Default
        {
            get
            {
                if (_default == null)
                {
                    _default = CreateDefaultCache();
                }

                return _default;
            }
            set
            {
                _default = value;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (_default != null)
                    {
                        _default.Dispose();
                    }
                }


                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion
    }
}
