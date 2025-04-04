namespace Ouvidoria.Domain.Models;

public class BaseEntity
{
    public int id { get; set; }
    private DateTime _dataCriacao { get; set; }
    private DateTime _dataAtualizacao { get; set; }
}