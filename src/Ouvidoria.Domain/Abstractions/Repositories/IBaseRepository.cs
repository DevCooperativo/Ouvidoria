namespace Ouvidoria.Domain.Abstractions.Repositories;
public interface IBaseRepository<TEntity>
{
    IEnumerable<TEntity> GetAll(params string[] includes);
    IEnumerable<TEntity> GetAllReadOnly(params string[] includes);
    Task<TEntity?> GetByIdAsync(int id, params string[] includes);
    TEntity? Add(TEntity entity);
    TEntity Update(TEntity entity);
    void Delete(TEntity entity);
}