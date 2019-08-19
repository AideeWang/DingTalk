
using Domain.DingTalkSync.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.UnitOfWork
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private const int DEFAULT_PAGE_SIZE = 10;
        #region Members

        IQueryableUnitOfWork _UnitOfWork;
        protected IQueryableUnitOfWork UnitOfWorkContext { get { return this._UnitOfWork; } }

        #endregion

        #region Constructor

        public Repository(IQueryableUnitOfWork unitOfWork)
        {
            if (unitOfWork == (IUnitOfWork)null)
                throw new ArgumentNullException("unitOfWork");

            _UnitOfWork = unitOfWork;
        }

        #endregion

        #region IRepository Members

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _UnitOfWork;
            }
        }

        public virtual void Add(TEntity item)
        {

            if (item != (TEntity)null)
            {
                GetSet().Add(item); // add new item in this set

            }
        }

        public virtual void Remove(TEntity item)
        {
            if (item != (TEntity)null)
            {
                _UnitOfWork.Attach(item);

                //set as "removed"
                GetSet().Remove(item);
            }
        }

        public virtual void TrackItem(TEntity item)
        {
            if (item != (TEntity)null)
                _UnitOfWork.Attach<TEntity>(item);
        }

        public virtual void Modify(TEntity item)
        {
            if (item != (TEntity)null)
                _UnitOfWork.SetModified(item);
        }

        public virtual TEntity LazyUpdate(TEntity item)
        {
            if (item != (TEntity)null)
                _UnitOfWork.Update(item);
            return item;
        }

        public virtual TEntity Get(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
                return GetSet().Find(id.ToString());
            else
                return null;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return GetSet();
        }

        public virtual IEnumerable<TResult> Select<TResult>(Expression<Func<TEntity, TResult>> selector)
        {
            return GetSet().Select(selector);
        }

        //public virtual IEnumerable<TEntity> AllMatching(ISpecification<TEntity> specification)
        //{
        //    return GetSet().Where(specification.SatisfiedBy());
        //}

        public virtual IEnumerable<TEntity> GetPaged<KProperty>(int pageIndex, int pageSize, Expression<Func<TEntity, KProperty>> orderByExpression, bool ascending, Expression<Func<TEntity, bool>> filter, out int dataIndex, out int dataCount)
        {
            var set = filter != null ? GetSet().Where(filter) : GetSet();
            dataCount = set.Count();
            dataIndex = dataCount < (pageSize * (pageIndex + 1)) ? (dataCount) : ((pageSize * (pageIndex + 1)));
            if (ascending)
            {
                return set.OrderBy(orderByExpression)
                          .Skip(pageSize * pageIndex)
                          .Take(pageSize);
            }
            else
            {
                return set.OrderByDescending(orderByExpression)
                          .Skip(pageSize * pageIndex)
                          .Take(pageSize);
            }
        }

        public IEnumerable<TEntity> GetPaged<KProperty>(int pageIndex, Expression<Func<TEntity, KProperty>> orderByExpression, bool ascending, Expression<Func<TEntity, bool>> filter, out int dataIndex, out int dataCount)
        {
            return this.GetPaged<KProperty>(pageIndex, DEFAULT_PAGE_SIZE, orderByExpression, ascending, filter, out dataIndex, out dataCount);
        }

        public IEnumerable<TEntity> GetPaged<KProperty>(int pageIndex, int pageSize, Expression<Func<TEntity, KProperty>> orderByExpression, bool ascending, out int dataIndex, out int dataCount)
        {
            return this.GetPaged<KProperty>(pageIndex, pageSize, orderByExpression, ascending, null, out dataIndex, out dataCount);
        }

        public IEnumerable<TEntity> GetPaged<KProperty>(int pageIndex, Expression<Func<TEntity, KProperty>> orderByExpression, bool ascending, out int dataIndex, out int dataCount)
        {
            return this.GetPaged<KProperty>(pageIndex, orderByExpression, ascending, null, out dataIndex, out dataCount);
        }

        public virtual IEnumerable<TEntity> GetFiltered(Expression<Func<TEntity, bool>> filter)
        {
            return GetSet().Where(filter);
        }


        public virtual decimal? GetSum(Expression<Func<TEntity, bool>> filter,Expression<Func<TEntity, decimal?>> sumFuc)
        {
            return GetSet().Where(filter).Sum(sumFuc);
        }

        public virtual int? GetCount(Expression<Func<TEntity, bool>> filter)
        {
            return GetSet().Where(filter).Count();
        }


        public IEnumerable<T> GetFiltered<T>(string sql, params object[] parameters)
        {
            return this.UnitOfWorkContext.ExecuteQuery<T>(sql, parameters);
        }

        public virtual void Merge(TEntity persisted, TEntity current)
        {
            _UnitOfWork.ApplyCurrentValues(persisted, current);
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            if (_UnitOfWork != null)
                _UnitOfWork.Dispose();
        }

        #endregion

        #region Private Methods

        IDbSet<TEntity> GetSet()
        {
            return _UnitOfWork.CreateSet<TEntity>();
        }
        #endregion       
    }
}
