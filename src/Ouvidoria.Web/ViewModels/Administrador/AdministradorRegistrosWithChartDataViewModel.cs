using Ouvidoria.Web.ViewModels.ChartData;
using Ouvidoria.Web.ViewModels.Registro;

namespace Ouvidoria.Web.ViewModels.Administrador;

public class AdministradorRegistrosWithChartDataViewModel{

    public IEnumerable<RegistroViewModel> Registros { get; set; }
    public ChartDataViewModel ChartData { get; set; }

    
    public AdministradorRegistrosWithChartDataViewModel(IEnumerable<RegistroViewModel> registros, ChartDataViewModel chartData)
    {
        Registros=registros;
        ChartData=chartData;
    }
}