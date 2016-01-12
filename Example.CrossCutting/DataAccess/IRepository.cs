using System;
using System.Collections.Generic;
using System.Linq;

namespace Example.CrossCutting.DataAccess
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        /// <summary>
        /// Liefert true wenn eine Entität sich geändert hat
        /// </summary>
        bool HasChanges { get; }

        /// <summary>
        /// Liefert alle Entitäten des Typs TEntity
        /// </summary>
        /// <param name="tracking"></param>
        /// <returns>IQueryable</returns>
        IQueryable<TEntity> Query(bool tracking = false);

        /// <summary>
        /// Liefert eine Entität mit bestimmten Primary Keys oder NULL falls die Entität nicht gefunden werden konnte.
        /// </summary>
        /// <param name="keyValues">Primary Keys der Entität</param>
        /// <returns>TEntity oder NULL</returns>
        TEntity Find(params object[] keyValues);

        /// <summary>
        /// Fügt eine neue Entität hinzu
        /// </summary>
        /// <param name="entity">Entität die hinzugefügt werden soll</param>
        void Insert(TEntity entity);

        /// <summary>
        /// Fügt eine Liste von Entities dem Repository hinzu
        /// </summary>
        /// <param name="entities">Liste von Entities</param>
        void InsertRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Aktualisiert eine Entität
        /// </summary>
        /// <param name="entity">Entität die aktualisiert werden soll</param>
        void Update(TEntity entity);

        /// <summary>
        /// Löscht eine Entität
        /// </summary>
        /// <param name="entity">Entität die gelöscht werden soll</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Löscht alle Entitäten aus der Tabelle mit Hilfe des TRUNCATE Statements
        /// </summary>
        int Truncate();
    }
}
