namespace Ouvidoria.Domain.Models;

public class Arquivo : BaseEntity
{
    private string _nome { get; set; } = string.Empty;
    private float _tamanho { get; set; }
    private string _tipo { get; set; }
    
}