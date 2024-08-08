using System.Linq.Expressions;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Dedsi.Ddd.Domain.Repositories;

public interface IDedsiRepository<TEntity,TKey> : IRepository<TEntity,TKey> where TEntity : class, IEntity<TKey>
{
    /// <summary>
    /// 启用：IsChangeTrackingEnabled
    /// </summary>
    void EnableChangeTracking();
    
    /// <summary>
    /// 关闭：IsChangeTrackingEnabled
    /// </summary>
    void CloseChangeTracking();

    /// <summary>
    /// 分页查询
    /// </summary>
    /// <param name="wherePredicate"></param>
    /// <param name="orderPredicate"></param>
    /// <param name="isReverse"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <typeparam name="TOrderKey"></typeparam>
    /// <returns></returns>
    Task<(int, List<TEntity>)> GetPagedListAsync<TOrderKey>(
        Expression<Func<TEntity, bool>> wherePredicate,
        Expression<Func<TEntity, TOrderKey>> orderPredicate,
        bool isReverse = true,
        int pageIndex = 1,
        int pageSize = 10);

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="wherePredicate"></param>
    /// <returns></returns>
    Task<int> DeleteAsync(Expression<Func<TEntity, bool>> wherePredicate);

    /// <summary>
    /// 执行sql，返回受影响行数
    /// </summary>
    /// <param name="sql"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<int> ExecuteSqlAsync(FormattableString sql, CancellationToken cancellationToken = default);
}