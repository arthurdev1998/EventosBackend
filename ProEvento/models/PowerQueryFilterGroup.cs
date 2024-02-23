namespace ProEvento.models
{
    public class PowerQueryFilterGroup
    {
        public string CombineOperator { get; set; }
        public PowerQueryFilter[] Filters { get; set; }
    }
}