using System.Text.Json;

namespace ProEvento.models
{
    public class PowerQueryFilter
    {
        public string Property { get; set; }
        public JsonElement Value { get; set; }
        public string CombineOperator { get; set; } = "AND";
    }
}