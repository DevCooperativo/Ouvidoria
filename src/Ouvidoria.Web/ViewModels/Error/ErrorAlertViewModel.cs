namespace Ouvidoria.Web.ViewModels.Error;
public class ErrorAlertViewModel
{
    public string Nome { get; set; } = string.Empty;
    public List<string> Errors { get; set; } = [];

    public ErrorAlertViewModel() { }

    public ErrorAlertViewModel(string nome, List<string>? errors = null)
    {
        Nome = nome;
        Errors = errors ?? [];
    }
    public void AddError(string error)
    {
        Errors.Add(error);
    }
}