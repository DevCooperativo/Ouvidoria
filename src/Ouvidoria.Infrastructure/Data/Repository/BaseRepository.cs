using Ouvidoria.Domain;
using Ouvidoria.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Ouvidoria.Domain.Abstractions;

namespace Ouvidoria.Infrastructure.Data.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : EntidadeBase
{
    private readonly DataContext _context;

    public BaseRepository(DataContext context)
    {
        _context = context;
    }
    public TEntity Add(TEntity entity)
    {
        return _context.Set<TEntity>().Add(entity).Entity;
    }

    public void Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }

    public IEnumerable<TEntity> GetAll(params string[] includes)
    {
        var query = _context.Set<TEntity>().AsQueryable();

        foreach (var include in includes)
            query = query.Include(include);

        return query;
    }

    public IEnumerable<TEntity> GetAllReadOnly(params string[] includes)
    {
        var query = _context.Set<TEntity>().AsNoTracking();

        foreach (var include in includes)
            query = query.Include(include);

        return query;
    }

    public async Task<TEntity?> GetByIdAsync(int id, params string[] includes)
    {
        var query = _context.Set<TEntity>().AsQueryable();
        foreach (var include in includes)
            query = query.Include(include);
        return await query.FirstOrDefaultAsync(x => x.Id == id);
    }

    public TEntity Update(TEntity entity)
    {
        return _context.Set<TEntity>().Update(entity).Entity;
    }
}