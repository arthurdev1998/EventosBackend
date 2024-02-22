using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEvento.models
{
    public class PowerQueryExecuteDto
    {
        public int Limit { get; set; }
        public int? Offset { get; set; }
        public PowerQueryFilterGroup[] FilterGroups { get; set; } = [];
        public OrderDefinition[] Orderby { get; set; } = [];
    }
}