using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.UnitOfWork
{
    /// <summary>
    /// Base interface for implement a "Repository Pattern", for
    /// more information about this pattern see http://martinfowler.com/eaaCatalog/repository.html
    /// or http://blogs.msdn.com/adonet/archive/2009/06/16/using-repository-and-unit-of-work-patterns-with-entity-framework-4-0.aspx
    /// </summary>
    /// <remarks>
    /// Indeed, one might think that IDbSet already a generic repository and therefore
    /// would not need this item. Using this interface allows us to ensure PI principle
    /// within our domain model
    /// </remarks>
    /// <typeparam name="TEntity">Type of entity for this repository </typeparam>
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class
    {
        /// <summary>
        /// Get the unit of work in this repository
        /// </summary>
        IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// Add item into repository
        /// </summary>
        /// <param name="item">Item to add to repository</param>
        void Add(TEntity item);

        /// <summary>
        /// Delete item 
        /// </summary>
        /// <param name="item">Item to delete</param>
        void Remove(TEntity item);
        /// <summary>
        /// 更新一个实体的所有值不为null的属性
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        TEntity LazyUpdate(TEntity item);
        /// <summary>
        /// Set item as modified
        /// </summary>
        /// <param name="item">Item to modify</param>
        void Modify(TEntity item);

        /// <summary>
        ///Track entity into this repository, really in UnitOfWork. 
        ///In EF this can be done with Attach and with Update in NH
        /// </summary>
        /// <param name="item">Item to attach</param>
        void TrackItem(TEntity item);

        /// <summary>
        /// Sets modified entity into the repository. 
        /// When calling Commit() method in UnitOfWork 
        /// these changes will be saved into the storage
        /// </summary>
        /// <param name="persisted">The persisted item</param>
        /// <param name="current">The current item</param>
        void Merge(TEntity persisted, TEntity current);

        /// <summary>
        /// Get element by entity key
        /// </summary>
        /// <param name="id">Entity key value</param>
        /// <returns></returns>
        TEntity Get(string id);

        /// <summary>
        /// Get all elements of type TEntity in repository
        /// </summary>
        /// <returns>List of selected elements</returns>
        IEnumerable<TEntity> GetAll();


        IEnumerable<TResult> Select<TResult>(Expression<Func<TEntity, TResult>> selector);
        /// <summary>
        /// Get all elements of type TEntity that matching a
        /// Specification <paramref name="specification"/>
        /// </summary>
        /// <param name="specification">Specification that result meet</param>
        /// <returns></returns>

        IEnumerable<T> GetFiltered<T>(string sql, params object[] parameters);

        decimal? GetSum(Expression<Func<TEntity, bool>> filter,Expression<Func<TEntity, decimal?>> sumFuc);

        int? GetCount(Expression<Func<TEntity, bool>> filter);
        /// <summary>
        /// Get all elements of type TEntity in repository
        /// </summary>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Number of elements in each page</param>
        /// <param name="orderByExpression">Order by expression for this query</param>
        /// <param name="ascending">Specify if order is ascending</param>
        /// <returns>List of selected elements</returns>
        IEnumerable<TEntity> GetPaged<KProperty>(int pageIndex, int pageSize, Expression<Func<TEntity, KProperty>> orderByExpression, bool ascending, Expression<Func<TEntity, bool>> filter, out int dataIndex, out int dataCount);

        /// <summary>
        /// Get all elements of type TEntity in repository，10 of elements in each page
        /// </summary>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Number of elements in each page</param>
        /// <param name="orderByExpression">Order by expression for this query</param>
        /// <param name="ascending">Specify if order is ascending</param>
        /// <returns>List of selected elements</returns>
        IEnumerable<TEntity> GetPaged<KProperty>(int pageIndex, Expression<Func<TEntity, KProperty>> orderByExpression, bool ascending, Expression<Func<TEntity, bool>> filter, out int dataIndex, out int dataCount);

        /// <summary>
        /// Get all elements of type TEntity in repository
        /// </summary>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Number of elements in each page</param>
        /// <param name="orderByExpression">Order by expression for this query</param>
        /// <param name="ascending">Specify if order is ascending</param>
        /// <returns>List of selected elements</returns>
        IEnumerable<TEntity> GetPaged<KProperty>(int pageIndex, int pageSize, Expression<Func<TEntity, KProperty>> orderByExpression, bool ascending, out int dataIndex, out int dataCount);

        /// <summary>
        /// Get all elements of type TEntity in repository，10 of elements in each page
        /// </summary>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Number of elements in each page</param>
        /// <param name="orderByExpression">Order by expression for this query</param>
        /// <param name="ascending">Specify if order is ascending</param>
        /// <returns>List of selected elements</returns>
        IEnumerable<TEntity> GetPaged<KProperty>(int pageIndex, Expression<Func<TEntity, KProperty>> orderByExpression, bool ascending, out int dataIndex, out int dataCount);

        /// <summary>
        /// Get  elements of type TEntity in repository
        /// </summary>
        /// <param name="filter">Filter that each element do match</param>
        /// <returns>List of selected elements</returns>
        IEnumerable<TEntity> GetFiltered(Expression<Func<TEntity, bool>> filter);
    }
}
