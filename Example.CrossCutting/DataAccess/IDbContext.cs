using System.Collections.Generic;
using System.Linq;

namespace Example.CrossCutting.DataAccess
{
    /// <summary>
    /// Kapselt ein DBContext Objekt.
    /// </summary>
    public interface IDbContext
    {
        /// <summary>
        /// Liefert True, falls Änderungen im Context sind.
        /// </summary>
        bool HasChanges { get;  }

        /// <summary>
        /// Liefert eine Query zur Abfrage von Entities
        /// </summary>
        /// <typeparam name="TEntity">Type der Entity</typeparam>
        /// <param name="tracking">Wenn TRUE werden die Entities im Kontext getrackt</param>
        /// <returns>Query</returns>
        IQueryable<TEntity> Query<TEntity>(bool tracking = true) where TEntity : class;

        /// <summary>
        /// Aktualisiert eine Entität
        /// </summary>
        /// <typeparam name="TEntity">Type der Entity</typeparam>
        /// <param name="entity">Entity</param>
        void Update<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// Fügt eine neue Entität hinzu
        /// </summary>
        /// <typeparam name="TEntity">Type der Entity</typeparam>
        /// <param name="entity">Entity</param>
        void Insert<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// Fügt eine Liste von Entities dem Repository hinzu
        /// </summary>
        /// <typeparam name="TEntity">Type der Entity</typeparam>
        /// <param name="entities">Entities</param>
        void InsertRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;

        /// <summary>
        /// Löscht eine Entität
        /// </summary>
        /// <typeparam name="TEntity">Type der Entity</typeparam>
        /// <param name="entity">Entity</param>
        void Delete<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// Liefert eine Entität mit einem bestimmten Primary Key oder NULL falls die Entität nicht gefunden werden wurde.
        /// </summary>
        /// <typeparam name="TEntity">Type der Entity</typeparam>
        /// <param name="keyValues">Primary Keys der Entität</param>
        /// <returns>TEntity oder NULL</returns>
        TEntity Find<TEntity>(params object[] keyValues) where TEntity : class;

        /// <summary>
        /// Löscht alle Entitäten aus der Tabelle mit Hilfe des TRUNCATE Statements
        /// </summary>
        /// <typeparam name="TEntity">Type der Entity</typeparam>
        /// <returns>Rows affected</returns>
        int Truncate<TEntity>() where TEntity : class;

        /// <summary>
        /// Speichert alle Änderungen.
        /// </summary>
        /// <returns>Rows affected</returns>
        int SaveChanges();

        /// <summary>
        ///
        /// </summary>
        void Dispose();
    }
}
