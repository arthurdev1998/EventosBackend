using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEvento.models;

public class PowerQueryResultDto<T>
{
    public int? TotalCount { get; set; }
    public IEnumerable<T> Records { get; set; }
}