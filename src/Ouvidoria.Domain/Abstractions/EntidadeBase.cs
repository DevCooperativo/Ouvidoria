namespace Ouvidoria.Domain.Abstractions;

public abstract class EntidadeBase
{
    public int Id { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public DateTime DataAtualizacao { get; private set; }

    protected EntidadeBase()
    {
        DataCriacao = DateTime.Now;
        DataAtualizacao = DateTime.Now;
    }
}