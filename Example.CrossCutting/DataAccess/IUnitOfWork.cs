using System;

namespace Example.CrossCutting.DataAccess
{
    /// <summary>
    /// Definiert eine Schnittstelle für Fowlers UnitOfWork - Pattern
    ///
    /// http://martinfowler.com/eaaCatalog/unitOfWork.html
    /// http://msdn.microsoft.com/en-us/magazine/dd882510.aspx
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Liefert ein Repository für eine bestimmte Entity.
        /// </summary>
        /// <typeparam name="TEntity">Entity Type</typeparam>
        /// <returns>IRepository</returns>
        IRepository<TEntity> RepositoryFor<TEntity>() where TEntity : class;

        /// <summary>
        /// Persistiert alle Änderungen.
        /// </summary>
        void Commit();
    }
}
