namespace Ouvidoria.Domain;

public interface IUnitOfWork
{
    Task<bool> Commit();
    Task Rollback();
}