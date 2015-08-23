using System;
using System.Collections.Generic;
using System.Linq;

namespace Example.CrossCutting.Container
{
    public abstract class ContainerFactory : IDisposable
    {
        private const String DefaultContainerName = "_DEFAULTCONTAINER_";
        private readonly IDictionary<String, IContainer> _containers = new Dictionary<String, IContainer>();

        public ContainerFactory()
        {
            RegisterContainer(DefaultContainerName, CreateContainer());
        }

        public IContainer Default
        {
            get { return GetContainer(DefaultContainerName); }
        }

        public virtual void RegisterContainer(IContainer container)
        {
            if (container == null)
                throw new ArgumentNullException("container");

            String key = container.GetType().FullName;
            RegisterContainer(key, container);
        }

        public virtual void RegisterContainer(String name, IContainer container)
        {
            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("name");

            if (container == null)
                throw new ArgumentNullException("container");

            if (GetContainer(name) != null)
                throw new ArgumentException(String.Format("Container with name '{0}' already registered!", name));

            _containers.Add(name, container);
        }

        public virtual void UnRegisterContainer(IContainer container)
        {
            if (container == null)
                throw new ArgumentNullException("container");

            String key = container.GetType().FullName;
            UnRegisterContainer(key, container);
        }

        public virtual void UnRegisterContainer(String name, IContainer container)
        {
            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("name");

            if (container == null)
                throw new ArgumentNullException("container");

            if (_containers.ContainsKey(name))
            {
                _containers[name].Dispose();
                _containers.Remove(name);
            }
        }

        public virtual IContainer GetContainer(String name)
        {
            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("name");

            if (_containers.ContainsKey(name))
                return _containers[name];

            return null;
        }

        protected abstract IContainer CreateContainer();

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    var containers = _containers.ToList();
                    foreach (var containerItem in containers)
                    {
                        UnRegisterContainer(containerItem.Key, containerItem.Value);
                    }

                    _containers.Clear();

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
