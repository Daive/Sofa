using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Ben.DAL.IDAL
{
    public interface IBaseRepository<T>
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>数据实体</returns>
        T Add(T entity);

        /// <summary>
        /// 获取记录数量
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns>记录数</returns>
        int GetCount(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>bool</returns>
        bool Update(T entity);

        /// <summary>
        /// 删除所有/删除单个/删除部分
        /// </summary>
        /// <param name="entity">无/数据实体/数据列表</param>
        /// <returns>bool</returns>
        bool Delete();
        bool Delete(T entity);
        bool Delete(IList<T> entities);

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="anyLambda">条件表达式</param>
        /// <returns>bool</returns>
        bool Exist(Expression<Func<T, bool>> anyLambda);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="lambda"></param>
        /// <returns></returns>
        T Find(Expression<Func<T, bool>> lambda);

        /// <summary>
        /// 查找数据列表
        /// </summary>
        /// <typeparam name="S">排序</typeparam>
        /// <param name="lambda">查询表达式</param>
        /// <param name="isAsc">是否升序</param>
        /// <param name="orderLambda">排序表达式</param>
        /// <returns>数据列表</returns>
        IQueryable<T> FindList<S>(Expression<Func<T, bool>> lambda, bool isAsc, Expression<Func<T, S>> orderLambda);

        /// <summary>
        /// 查找分页数据列表
        /// </summary>
        /// <typeparam name="S">排序</typeparam>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页记录数量</param>
        /// <param name="totalRecord">总记录数</param>
        /// <param name="whereLambda">查询表达式</param>
        /// <param name="isAsc">是否升序</param>
        /// <param name="orderLambda">排序表达式</param>
        /// <returns>数据列表</returns>
        IQueryable<T> FindPageList<S>(int pageIndex, int pageSize, out int totalRecord,
            Expression<Func<T, bool>> whereLambda, bool isAsc, Expression<Func<T, S>> orderLambda);
    }
}