using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace ProEvento.models
{
    public class PowerQueryFilter
    {
        public string Property { get; set; }
        public JsonElement Value { get; set; }
        public string CombineOperator { get; set; } = "AND";
    }
}