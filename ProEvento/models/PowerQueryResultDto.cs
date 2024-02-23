namespace ProEvento.models;

public class PowerQueryResultDto<T>
{
    public int? TotalCount { get; set; }
    public IEnumerable<T> Records { get; set; }
}