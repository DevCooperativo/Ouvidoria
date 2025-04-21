namespace Ouvidoria.DTO;

public class ChartDataDTO
{
    public List<string> Labels { get; set; } = [];
    public List<int> Data { get; set; } = [];

    public ChartDataDTO() { }

    public ChartDataDTO(List<string> labels, List<int> data)
    {
        Labels = labels;
        Data = data;
    }
}
