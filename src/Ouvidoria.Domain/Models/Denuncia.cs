
namespace Ouvidoria.Domain.Models;
public class Denuncia : BaseEntity
{
    private string _tipo { get; set; } = string.Empty;
    private string _descricao { get; set; } = string.Empty;
    private string _status { get; set; } = string.Empty;
    private string _alvo { get; set; } = string.Empty;
    private DateTime _dataCriacao { get; set; } = DateTime.Now;
    private DateTime _dataAtualizacao { get; set; } = DateTime.Now;
    private Usuario? _autor { get; set; }

    public Denuncia(string empty, string descricao, string status, string alvo, DateTime dataAtualizacao, Usuario? autor)
    {

    }
}