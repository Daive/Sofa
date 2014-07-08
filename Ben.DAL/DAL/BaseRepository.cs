using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ben.DAL.IDAL;
using Ben.Entity;


namespace Ben.DAL.DAL
{
    /// <summary>
    /// 仓储基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly SofaContext sContext = ContextFactory.GetCurrentContext();

        //public BaseRepository(SofaContext context)
        //{
        //    sContext = context;
        //}

        public T Add(T entity)
        {
            //sContext.Set<T>().Attach(entity);
            //sContext.Entry(entity).State = EntityState.Added;
            //sContext.SaveChanges();           
            sContext.Set<T>().Add(entity);
            sContext.SaveChanges();
            return entity;
        }

        public int GetCount(Expression<Func<T, bool>> predicate)
        {
            return sContext.Set<T>().Count(predicate);
        }

        public bool Update(T entity)
        {
            sContext.Set<T>().Attach(entity);
            sContext.Entry(entity).State = EntityState.Modified;
            return sContext.SaveChanges() > 0;
        }

        public bool Delete()
        {
            foreach (var entity in sContext.Set<T>())
            {
                sContext.Set<T>().Attach(entity);
                sContext.Entry(entity).State = EntityState.Deleted;
            }
            return sContext.SaveChanges() > 0;
        }

        public bool Delete(T entity)
        {
            sContext.Set<T>().Attach(entity);
            sContext.Entry(entity).State = EntityState.Deleted;
            return sContext.SaveChanges() > 0;
        }

        public bool Delete(IList<T> entities)
        {
            foreach (var entity in entities)
            {
                sContext.Set<T>().Attach(entity);
                sContext.Entry(entity).State = EntityState.Deleted;
            }
            return sContext.SaveChanges() > 0;
        }

        public bool Exist(Expression<Func<T, bool>> anyLambda)
        {
            return sContext.Set<T>().Any(anyLambda);
        }

        public T Find(Expression<Func<T, bool>> lambda)
        {
            T _entity = sContext.Set<T>().FirstOrDefault<T>(lambda);
            return _entity;
            //return sContext.Set<T>().Find(lambda);
        }

        public IQueryable<T> FindList<S>(Expression<Func<T, bool>> lambda, bool isAsc,
            Expression<Func<T, S>> orderLambda)
        {
            var _list = sContext.Set<T>().Where<T>(lambda);
            if (isAsc) _list = _list.OrderBy<T, S>(orderLambda);
            else _list = _list.OrderByDescending<T,S>(orderLambda);
            return _list;
        }

        public IQueryable<T> FindPageList<S>(int pageIndex, int pageSize, out int totalRecord,
            Expression<Func<T, bool>> whereLambda, bool isAsc,
            Expression<Func<T, S>> orderLambda)
        {
            var _list = sContext.Set<T>().Where<T>(whereLambda);
            totalRecord = _list.Count();
            if (isAsc) _list = _list.OrderBy<T,S>(orderLambda).Skip<T>((pageIndex - 1)*pageSize).Take<T>(pageSize);
            else _list = _list.OrderByDescending<T,S>(orderLambda).Skip<T>((pageSize - 1)*pageSize).Take<T>(pageSize);
            return _list;
        }
    }
}