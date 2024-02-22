using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEvento.models
{
    public class PowerQueryFilterGroup
    {
        public string CombineOperator { get; set; }
        public PowerQueryFilter[] Filters { get; set; }
    }
}