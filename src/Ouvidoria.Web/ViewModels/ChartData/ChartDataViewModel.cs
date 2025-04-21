using Ouvidoria.DTO;

namespace Ouvidoria.Web.ViewModels.ChartData;

public class ChartDataViewModel{
    public List<string> Labels { get; set; }
    public List<int> Data { get; set; }

    public ChartDataViewModel(ChartDataDTO chartDataDTO){
        Labels=chartDataDTO.Labels;
        Data=chartDataDTO.Data;
    }
}